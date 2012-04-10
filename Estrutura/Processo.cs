using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Dados;

namespace Estrutura
{
    public class TipoAcao : Modelo.Acao.ModeloTipoAcao
    {
        public TipoAcao()
            : base()
        {

        }
        public void Remover()
        {            
            this.ConferirOrigemParaManipularDados();
            AcessoTipoAcao.RemoverTipoAcao(this);
        }

        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            AcessoTipoAcao.InserirTipoAcao(this);
        }

        public void Alterar()
        {
            this.ConferirOrigemParaManipularDados();
            AcessoTipoAcao.AlterarTipoAcao(this);
        }

        public void Obter()
        {
            AcessoTipoAcao.ObterTipoAcao(this);
        }

        public int QuantidadeProcessos
        {
            get
            {
                int count = 0;
                foreach (Modelo.Processo.ModeloProcesso p in Processos.Listar())
                {
                    if (p.TipoAcao.Id == this.Id)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }

    public static class TiposAcao
    {
        public static IEnumerable<Modelo.Acao.ModeloTipoAcao> Listar()
        {
            return AcessoTipoAcao.ListarTipoAcao(() => (Modelo.Acao.ModeloTipoAcao)new TipoAcao());
        }

        public static ListaAssociada<TipoAcao> ObterListaAssociada()
        {
            ListaAssociada<TipoAcao> grp
                = new ListaAssociada<TipoAcao>(() => new TipoAcao());

            foreach (Modelo.Acao.ModeloTipoAcao grupo in
                AcessoTipoAcao.ListarTipoAcao(() => (Modelo.Acao.ModeloTipoAcao)new TipoAcao()))
            {
                grp.Add((TipoAcao)grupo);
            }
            return grp;
        }
    }

    public class Recorte : Modelo.Processo.ModeloRecorteProcesso
    {
        public Recorte(Modelo.Processo.ModeloProcesso processo, Modelo.Usuario.ModeloUsuario usuario)
            : base()
        {
            this.UsuarioInclusao = usuario;
            this.Processo = processo;
        }
    }

    public class Processo : Modelo.Processo.ModeloProcesso
    {
        public ObservableCollection<Cliente> Clientes { get; private set; }
        public ObservableCollection<Recorte> Recortes { get; private set; }

        public Processo()
            : base()
        {    
            this.TipoAcao = new TipoAcao();
            this.Clientes = new ObservableCollection<Cliente>();
            this.Clientes.CollectionChanged += (sender, args) => Clientes.ToList().ForEach((cli) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        if (!cli.Processos.Contains(this))
                        {
                            cli.Processos.Add(this);
                        }                
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        if (cli.Processos.Contains(this))
                        {
                            cli.Processos.Remove(this);
                        }                
                        break;
                }
            });
            this.Recortes = new ObservableCollection<Recorte>();
            this.Recortes.CollectionChanged += (sender, args) => Recortes.ToList().ForEach((rec) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        if (rec.Processo != this)
                        {
                            rec.Processo = this;
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        if (rec.Processo == this)
                        {
                            rec.Processo = null;
                        }
                        break;
                }
            });
        }

        #region Metodos Processo
        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            Dados.AcessoProcesso.InserirProcesso(this);
            this.AcertarColecoes();
        }

        public void Obter()
        {
            Dados.AcessoProcesso.ObterProcesso(this);
            this.ObterColecoes();
        }

        public void Listar()
        {
            Dados.AcessoProcesso.PesquisarProcesso(this,()=> new Processo());
        }

        public void ObterColecoes()
        {
            Dados.AcessoProcessoCliente.ListarClienteProcesso(this,
                    () => (Modelo.Cliente.ModeloProcessoCliente)new ProcessoCliente(this,new Cliente()))
                    .Cast<ProcessoCliente>().ToList()
                    .ForEach((cli) => this.Clientes.Add((Cliente)cli.Cliente));

            Dados.AcessoProcessoRecorte.ListarRecorteProcesso(this,
                    () => (Modelo.Processo.ModeloRecorteProcesso)new Recorte(this, new Usuario()))
                    .Cast<Recorte>().ToList()
                    .ForEach((rec) => this.Recortes.Add((Recorte)rec));
        }

        public void Salvar()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoProcesso.AlterarProcesso(this);
            this.AcertarColecoes();
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            this.LimparColecoes();
            this.AcertarColecoes();
            Dados.AcessoProcesso.RemoverProcesso(this);
        }

        private void AcertarColecoes()
        {
            this.AcertarClientes();
            this.AcertarRecortes();
        }

        private void LimparColecoes()
        {
            this.Clientes.Clear();
        }

        #region Metodos Cliente
        private void InserirCliente(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            processoCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteProcesso.InserirProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void InserirCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            cliente.ConferirOrigemParaManipularDados();
            ProcessoCliente processoCliente = new ProcessoCliente(this, cliente);
            processoCliente.Obter();
            processoCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteProcesso.InserirProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void RemoverCliente(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            processoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteProcesso.RemoverProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void RemoverCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            cliente.ConferirOrigemParaManipularDados();
            ProcessoCliente processoCliente = new ProcessoCliente(this, cliente);
            processoCliente.Obter();
            processoCliente.ConferirOrigemParaInserir();
            processoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteProcesso.RemoverProcessoCliente(processoCliente);
        }

        private void AcertarClientes()
        {
            Action acertar = new Action(() => { });
            foreach (Cliente cliente in this.Clientes)
            {
                Cliente tempCliente = new Cliente();
                tempCliente.Id = cliente.Id;
                ProcessoCliente processoCliente = new ProcessoCliente(this, cliente);
                if (!Dados.AcessoProcessoCliente.ObterClienteProcesso(processoCliente))
                {
                    acertar+= ()=> this.InserirCliente(processoCliente);
                }
            }
            acertar();
            IEnumerable<ProcessoCliente> clientesListados = Dados.AcessoProcessoCliente.ListarClienteProcesso(this, () => (Modelo.Cliente.ModeloProcessoCliente)new ProcessoCliente(this, new Cliente())).Cast<ProcessoCliente>();
            foreach (ProcessoCliente processoCliente in clientesListados)
            {
                if (this.Clientes.All((cli) => cli.Id != processoCliente.Cliente.Id))
                {
                    this.RemoverCliente(processoCliente);
                }
            }
        }
        #endregion

        #region Metodos Recorte

        private void InserirRecorte(Modelo.Processo.ModeloRecorteProcesso recorte)
        {
            recorte.ConferirOrigemParaInserir();
            Dados.AcessoProcessoRecorte.InserirRecorteProcesso(recorte);
        }

        private void RemoverRecorte(Modelo.Processo.ModeloRecorteProcesso recorte)
        {
            recorte.ConferirOrigemParaManipularDados();
            Dados.AcessoProcessoRecorte.RemoverRecorteProcesso(recorte);
        }

        private void AcertarRecortes()
        {
            Action acertar = new Action(() => { });
            foreach (Recorte recorte in this.Recortes)
            {
                if (!Dados.AcessoProcessoRecorte.ObterRecorteProcesso(recorte))
                {
                   acertar+= ()=> this.InserirRecorte(recorte);
                }
            }
            acertar();
            IEnumerable<Recorte> recortesListados = Dados.AcessoProcessoRecorte.ListarRecorteProcesso(this, () => (Modelo.Processo.ModeloRecorteProcesso)new Recorte(this,new Usuario())).Cast<Recorte>();
            foreach (Recorte recorte in recortesListados)
            {
                if (this.Recortes.All((rec) => rec.Processo.Id != recorte.Processo.Id && rec.DataInclusao != recorte.DataInclusao))
                {
                    this.RemoverRecorte(recorte);
                }
            }
        }
        #endregion

        #endregion
    }

    public static class Processos
    {
        public static IEnumerable<Modelo.Processo.ModeloProcesso> Listar(){
            return AcessoProcesso.PesquisarProcesso(new Processo(),()=> new Processo());
        }
    }
}
