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

        public override string ToString()
        {
            return this.Descricao;
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
        public ListaAssociada<Cliente> Clientes { get; private set; }
        public ObservableCollection<Recorte> Recortes { get; private set; }
        public ListaAssociada<ProcessoAdvogado> Responsaveis { get; private set; }

        public Processo()
            : base()
        {
            this.TipoAcao = new TipoAcao();
            this.Cabeca = new Cliente();
            this.Clientes = new ListaAssociada<Cliente>(() => new Cliente());
            this.Clientes.ListChanged += (sender, args) => Clientes.ToList().ForEach((cli) =>
            {
                switch (args.ListChangedType)
                {
                    case System.ComponentModel.ListChangedType.ItemAdded:
                        if (!cli.Processos.Contains(this))
                        {
                            cli.Processos.Add(this);
                        }
                        break;
                    case System.ComponentModel.ListChangedType.ItemDeleted:
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

            this.Responsaveis = new ListaAssociada<ProcessoAdvogado>(() => new ProcessoAdvogado(new Advogado(), this));
            this.Responsaveis.ListChanged += (sender, args) => Responsaveis.ToList().ForEach((proadv) =>
            {
                switch (args.ListChangedType)
                {
                    case System.ComponentModel.ListChangedType.ItemAdded:
                        if (proadv.Processo != this)
                        {
                            proadv.Processo = this;
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

        public bool Obter()
        {
            bool result = Dados.AcessoProcesso.ObterProcesso(this);
            if (result)
            {
                this.LimparColecoes();
                this.ObterColecoes();
            }
            return result;
        }

        public void Listar()
        {
            Dados.AcessoProcesso.PesquisarProcesso(this, () => new Processo());
        }

        public void ObterColecoes()
        {
            Dados.AcessoProcessoCliente.ListarClienteProcesso(this,
                    () => (Modelo.Cliente.ModeloProcessoCliente)new ProcessoCliente(this, new Cliente()))
                    .Cast<ProcessoCliente>().ToList()
                    .ForEach((cli) => this.Clientes.Add((Cliente)cli.Cliente));

            Dados.AcessoProcessoAdvogado.ListarProcessoAdvogado(new ProcessoAdvogado(new Advogado(), this),
                () => (Modelo.Advogado.ModeloAdvogadoProcesso)new ProcessoAdvogado(new Advogado(), this))
                .Cast<ProcessoAdvogado>().ToList()
                .ForEach((proadv) => this.Responsaveis.Add(proadv));

            Dados.AcessoProcessoRecorte.ListarRecorteProcesso(this, 
                () => (Modelo.Processo.ModeloRecorteProcesso) new Recorte(this, new Usuario()))
                .Cast<Recorte>().ToList()
                .ForEach((rec) => this.Recortes.Add(rec));

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
            this.AcertarAdvogadosResponsaveis();
        }

        private void LimparColecoes()
        {
            this.Clientes.Clear();
            this.Recortes.Clear();
            this.Responsaveis.Clear();
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
                    acertar += () => this.InserirCliente(processoCliente);
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
            List<Modelo.Processo.ModeloRecorteProcesso> recortesAdicionar = new List<Modelo.Processo.ModeloRecorteProcesso>();
            foreach (Recorte recorte in this.Recortes)
            {
                if (!Dados.AcessoProcessoRecorte.ObterRecorteProcesso(recorte))
                {
                    recortesAdicionar.Add(recorte);
                }
            }
            recortesAdicionar.ForEach((rec) => InserirRecorte(rec));
            IEnumerable<Recorte> recortesListados = Dados.AcessoProcessoRecorte.ListarRecorteProcesso(this, () => (Modelo.Processo.ModeloRecorteProcesso)new Recorte(this, new Usuario())).Cast<Recorte>();
            foreach (Recorte recorte in recortesListados)
            {
                if (this.Recortes.All((rec) => rec.Processo.Id != recorte.Processo.Id && rec.DataInclusao != recorte.DataInclusao))
                {
                    this.RemoverRecorte(recorte);
                }
            }
        }
        #endregion

        #region Metodos Advogados Responsaveis

        private void InserirProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado)
        {
            processoAdvogado.ConferirOrigemParaInserir();
            Dados.AcessoProcessoAdvogado.InserirProcessoAdvogado(processoAdvogado);
        }

        private void RemoverProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado)
        {
            processoAdvogado.ConferirOrigemParaManipularDados();
            Dados.AcessoProcessoAdvogado.RemoverProcessoAdvogado(processoAdvogado);
        }

        private void AcertarAdvogadosResponsaveis()
        {
            List<Modelo.Advogado.ModeloAdvogadoProcesso> responsaveisAdicionar = new List<Modelo.Advogado.ModeloAdvogadoProcesso>();
            foreach (ProcessoAdvogado processoAdvogado in this.Responsaveis)
            {
                if (!Dados.AcessoProcessoAdvogado.ObterProcessoAdvogado(processoAdvogado))
                {
                    responsaveisAdicionar.Add(processoAdvogado);
                }
                responsaveisAdicionar.ForEach((proadv) => InserirProcessoAdvogado(proadv));
            }

            IEnumerable<ProcessoAdvogado> processoAdvogadoListados = Dados.AcessoProcessoAdvogado.ListarProcessoAdvogado(new ProcessoAdvogado(new Advogado(), this), () => (Modelo.Advogado.ModeloAdvogadoProcesso)new ProcessoAdvogado(new Advogado(), this)).Cast<ProcessoAdvogado>();
            foreach (ProcessoAdvogado processoAdvogado in processoAdvogadoListados)
            {
                if (this.Responsaveis.All((adv) => adv.Advogado.Id != processoAdvogado.Advogado.Id))
                {
                    this.RemoverProcessoAdvogado(processoAdvogado);
                }
            }
        }

        #endregion

        #endregion
    }

    public class ProcessoAdvogado : Modelo.Advogado.ModeloAdvogadoProcesso
    {
        public ProcessoAdvogado(Modelo.Advogado.ModeloAdvogado advogado, Modelo.Processo.ModeloProcesso processo)
        {
            this.Processo = processo;
            this.Advogado = advogado;
        }

        public string NomeAdvogado
        {
            get { return Advogado.Nome; }
        }

        public static IEnumerable<ProcessoAdvogado> ListarPorProcesso(Processo processo)
        {
            return AcessoAdvogado.ListarAdvogado(() => new Advogado())
                .Select((obj) => new ProcessoAdvogado(obj, processo));
        }

        public override bool Equals(object obj)
        {
            if (obj is ProcessoAdvogado)
            {
                ProcessoAdvogado comp = (ProcessoAdvogado)obj;
                if (this.Processo == null || comp.Processo == null)
                {
                    return comp.Processo == this.Processo && comp.Advogado.Equals(this.Advogado);
                }
                return comp.Processo.Equals(this.Processo) && comp.Advogado.Equals(this.Advogado);
            }
            return false;
        }
        public override int GetHashCode(){
            if (this.Processo == null)
            {
                return Advogado.GetHashCode();
            }
            else
            {
                return Processo.GetHashCode() & Advogado.GetHashCode();
            }            
        }
    }

    public static class Processos
    {
        public static IEnumerable<Modelo.Processo.ModeloProcesso> Listar()
        {
            return AcessoProcesso.PesquisarProcesso(new Processo(), () => new Processo());
        }

        public static IEnumerable<Modelo.Processo.ModeloProcesso> Pesquisar(Modelo.Processo.ModeloProcesso processoBase)
        {
            return AcessoProcesso.PesquisarProcesso(processoBase, () => new Processo());
        }
    }
}
