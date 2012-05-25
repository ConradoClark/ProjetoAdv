using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Estrutura
{
    public class Endereco : Modelo.Comum.ModeloEndereco
    {
        public override string ToString()
        {
            return String.Format(
                "{2} {3}, {0}/{1} (CEP: {4})", Cidade, Uf, Logradouro, Numero, Cep);
        }
    }

    public class Atendimento : Modelo.Cliente.ModeloAtendimentoCliente
    {
        public Atendimento(Modelo.Cliente.ModeloCliente cliente, Modelo.Usuario.ModeloUsuario usuario) : base()
        {
            this.UsuarioAtendimento = usuario;
            this.Cliente = cliente;
            this.DataHoraAtendimento = DateTime.Now;
        }
    }

    public class Beneficio : Modelo.Cliente.ModeloBeneficioCliente
    {
        public Beneficio(Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.Cliente = cliente;
            this.TipoBeneficio = null;
        }

        public Beneficio(Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio, Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.Cliente = cliente;
            this.TipoBeneficio = tipoBeneficio;
        }

        public bool Obter()
        {
            return Dados.AcessoClienteBeneficio.ObterBeneficioCliente(this);
        }
    }

    public class Contato : Modelo.Cliente.ModeloContatoCliente
    {
        public Contato(Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.Cliente = cliente;
        }
        public bool Obter()
        {
            return Dados.AcessoClienteContato.ObterContatoCliente(this);
        }
    }    

    public class Dependente : Modelo.Cliente.ModeloDependenteCliente
    {
        public Dependente(Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.Cliente = cliente;
        }
        public bool Obter()
        {
            return Dados.AcessoClienteDependente.ObterDependenteCliente(this);
        }
    }

    public class GrupoDiferencial : Modelo.Cliente.ModeloGrupoDiferencialCliente
    {
        public GrupoDiferencial(Modelo.GrupoDiferencial.ModeloGrupoDiferencial tipoGrupoDiferencial, Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.GrupoDiferencial = tipoGrupoDiferencial;
            this.Cliente = cliente;
        }

        public GrupoDiferencial(Modelo.Cliente.ModeloCliente cliente)
            : base()
        {
            this.GrupoDiferencial = null;
            this.Cliente = cliente;
        }

        public string Nome
        {
            get
            {
                return GrupoDiferencial.Nome;
            }
        }

        public Modelo.GrupoDiferencial.ModeloGrupoDiferencial Grupo
        {
            get
            {
                return GrupoDiferencial;
            }
        }
    }

    public class ProcessoCliente : Modelo.Cliente.ModeloProcessoCliente
    {
        public ProcessoCliente(Modelo.Processo.ModeloProcesso processo, Modelo.Cliente.ModeloCliente cliente)
            : base()
        {            
            this.Processo = processo;
            this.Cliente = cliente;
        }

        public bool Obter()
        {
            return Dados.AcessoProcessoCliente.ObterClienteProcesso(this);
        }
    }

    public class Cliente : Modelo.Cliente.ModeloCliente
    {
        public ListaAssociada<Beneficio> Beneficios { get; private set; }
        public ListaAssociada<Contato> Contatos { get; private set; }
        public ListaAssociada<Dependente> Dependentes { get; private set; }
        public ListaAssociada<GrupoDiferencial> GruposDiferenciais { get; private set; }
        public ObservableCollection<Processo> Processos { get; private set; }
        public ListaAssociada<Atendimento> Atendimentos { get; private set; }

        public override string ToString()
        {
            return this.Nome;
        }

        public Cliente()
            : base()
        {
            this.Endereco = new Endereco();
            this.Beneficios = new ListaAssociada<Beneficio>(()=>new Beneficio(this));
            this.Contatos = new ListaAssociada<Contato>(()=>new Contato(this));
            this.Dependentes = new ListaAssociada<Dependente>(()=> new Dependente(this));
            this.GruposDiferenciais = new ListaAssociada<GrupoDiferencial>(() => new GrupoDiferencial(this));
            this.Processos = new ObservableCollection<Processo>();
            this.Atendimentos = new ListaAssociada<Atendimento>(()=>new Atendimento(this,Sessao.UsuarioAtual));

            Processos.CollectionChanged += (sender, args) => Processos.ToList().ForEach((pro) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        if (!pro.Clientes.Contains(this))
                        {
                            pro.Clientes.Add(this);
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        if (pro.Clientes.Contains(this))
                        {
                            pro.Clientes.Remove(this);
                        }
                        break;
                }
            });
            this.Atendimentos.ListChanged += (sender, args) => Atendimentos.ToList().ForEach((att) =>
            {
                switch (args.ListChangedType)
                {
                    case System.ComponentModel.ListChangedType.ItemAdded:
                        if (att.Cliente != this)
                        {
                            att.Cliente = this;
                        }
                        break;
                    case System.ComponentModel.ListChangedType.ItemDeleted:
                        if (att.Cliente == this)
                        {
                            att.Cliente = null;
                        }
                        break;
                }
            });
        }

        #region Metodos Cliente
        public override void Limpar()
        {
            base.Limpar();
            this.LimparColecoes();
        }
        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            Dados.AcessoCliente.InserirCliente(this);
            this.AcertarColecoes();
        }

        public bool Obter()
        {
            this.LimparColecoes();
            bool resultado = Dados.AcessoCliente.ObterCliente(this);
            if (resultado)
            {
                this.ObterColecoes();
            }
            return resultado;
        }

        public void ObterColecoes()
        {
            Dados.AcessoClienteBeneficio.ListarBeneficioCliente(this,
                    () => (Modelo.Cliente.ModeloBeneficioCliente)new Beneficio(new TipoBeneficio(), this))
                    .Cast<Beneficio>().ToList()
                    .ForEach((ben) => this.Beneficios.Add(ben));
            Dados.AcessoClienteContato.ListarContatoCliente(this,
                    () => (Modelo.Cliente.ModeloContatoCliente)new Contato(this))
                    .Cast<Contato>().ToList()
                    .ForEach((con) => this.Contatos.Add(con));
            Dados.AcessoClienteDependente.ListarDependenteCliente(this,
                    () => (Modelo.Cliente.ModeloDependenteCliente)new Dependente(this))
                    .Cast<Dependente>().ToList()
                    .ForEach((dep) => this.Dependentes.Add(dep));
            Dados.AcessoClienteGrupoDiferencial.ListarGrupoDiferencialCliente(this,
                    () => (Modelo.Cliente.ModeloGrupoDiferencialCliente)new GrupoDiferencial(new TipoGrupoDiferencial(), this))
                    .Cast<GrupoDiferencial>().ToList()
                    .ForEach((grp) => this.GruposDiferenciais.Add(grp));
            Dados.AcessoClienteProcesso.ListarProcessoCliente(this,
                    () => (Modelo.Cliente.ModeloProcessoCliente)new ProcessoCliente(new Processo(),this))
                    .Cast<ProcessoCliente>().ToList()
                    .ForEach((pro) => this.Processos.Add((Processo)pro.Processo));
            Dados.AcessoClienteAtendimento.ListarAtendimentoCliente(this,
                    () => (Modelo.Cliente.ModeloAtendimentoCliente)new Atendimento(this, new Usuario()))
                    .Cast<Atendimento>().ToList()
                    .ForEach((att) => this.Atendimentos.Add((Atendimento)att));
        }

        public void Salvar()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoCliente.AlterarCliente(this);
            this.AcertarColecoes();
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            this.LimparColecoes();
            this.AcertarColecoes();
            Dados.AcessoCliente.RemoverCliente(this);
        }

        private void AcertarColecoes()
        {
            this.AcertarBeneficios();
            this.AcertarContatos();
            this.AcertarDependentes();
            this.AcertarGruposDiferenciais();
            this.AcertarProcessos();
            this.AcertarAtendimentos();
        }

        private void LimparColecoes()
        {
            this.Beneficios.Clear();
            this.Contatos.Clear();
            this.Dependentes.Clear();
            this.GruposDiferenciais.Clear();
            this.Processos.Clear();
            this.Atendimentos.Clear();
        }
        #endregion

        #region Metodos Beneficio
        private void InserirBeneficio(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            beneficioCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteBeneficio.InserirBeneficioCliente(beneficioCliente);
        }

        private void AlterarBeneficio(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            beneficioCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteBeneficio.AlterarBeneficioCliente(beneficioCliente);
        }

        private void RemoverBeneficio(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            beneficioCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteBeneficio.RemoverBeneficioCliente(beneficioCliente);
        }

        private void AcertarBeneficios()
        {
            List<Modelo.Cliente.ModeloBeneficioCliente> beneficiosAdicionar = new List<Modelo.Cliente.ModeloBeneficioCliente>();
            List<Modelo.Cliente.ModeloBeneficioCliente> beneficiosAlterar = new List<Modelo.Cliente.ModeloBeneficioCliente>();
            foreach (Beneficio beneficio in this.Beneficios)
            {
                Beneficio tempBeneficio = new Beneficio(beneficio.TipoBeneficio, beneficio.Cliente);
                tempBeneficio.Id = beneficio.Id;
                if (!Dados.AcessoClienteBeneficio.ObterBeneficioCliente(tempBeneficio))
                {
                    beneficiosAdicionar.Add(beneficio);                    
                }
                else
                {
                    beneficiosAlterar.Add(beneficio);
                }
            }

            beneficiosAdicionar.ForEach((ben) => InserirBeneficio(ben));
            beneficiosAlterar.ForEach((ben) => AlterarBeneficio(ben));

            IEnumerable<Beneficio> beneficiosListados = Dados.AcessoClienteBeneficio.ListarBeneficioCliente(this, () => (Modelo.Cliente.ModeloBeneficioCliente)new Beneficio(new TipoBeneficio(), this)).Cast<Beneficio>();
            foreach (Beneficio beneficio in beneficiosListados)
            {
                if (this.Beneficios.All((ben) => ben.Id != beneficio.Id))
                {
                    this.RemoverBeneficio(beneficio);
                }
            }
        }
        #endregion

        #region Metodos Contato
        private void InserirContato(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            contatoCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteContato.InserirContatoCliente(contatoCliente);
        }

        private void AlterarContato(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            contatoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteContato.AlterarContatoCliente(contatoCliente);
        }

        private void RemoverContato(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            contatoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteContato.RemoverContatoCliente(contatoCliente);
        }

        private void AcertarContatos()
        {
            List<Modelo.Cliente.ModeloContatoCliente> contatosAdicionar = new List<Modelo.Cliente.ModeloContatoCliente>();
            List<Modelo.Cliente.ModeloContatoCliente> contatosAlterar = new List<Modelo.Cliente.ModeloContatoCliente>();

            foreach (Contato contato in this.Contatos)
            {
                Contato tempContato = new Contato(contato.Cliente);
                tempContato.Id = contato.Id;
                if (!Dados.AcessoClienteContato.ObterContatoCliente(tempContato) || contato.Id==null)
                {
                    contatosAdicionar.Add(contato);
                }
                else
                {
                    contatosAlterar.Add(contato);
                }
            }
            contatosAdicionar.ForEach((con) => InserirContato(con));
            contatosAlterar.ForEach((con) => AlterarContato(con));

            IEnumerable<Contato> contatosListados = Dados.AcessoClienteContato.ListarContatoCliente(this, () => (Modelo.Cliente.ModeloContatoCliente)new Contato(this)).Cast<Contato>();
            foreach (Contato contato in contatosListados)
            {
                if (this.Contatos.All((con) => con.Id != contato.Id))
                {
                    this.RemoverContato(contato);
                }
            }
        }
        #endregion

        #region Metodos Dependente
        private void InserirDependente(Modelo.Cliente.ModeloDependenteCliente dependenteCliente)
        {
            dependenteCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteDependente.InserirDependenteCliente(dependenteCliente);
        }

        private void AlterarDependente(Modelo.Cliente.ModeloDependenteCliente dependenteCliente)
        {
            dependenteCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteDependente.AlterarDependenteCliente(dependenteCliente);
        }

        private void RemoverDependente(Modelo.Cliente.ModeloDependenteCliente dependenteCliente)
        {
            dependenteCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteDependente.RemoverDependenteCliente(dependenteCliente);
        }

        private void AcertarDependentes()
        {
            List<Modelo.Cliente.ModeloDependenteCliente> dependentesAdicionar = new List<Modelo.Cliente.ModeloDependenteCliente>();
            List<Modelo.Cliente.ModeloDependenteCliente> dependentesAlterar = new List<Modelo.Cliente.ModeloDependenteCliente>();

            foreach (Dependente dependente in this.Dependentes)
            {
                Dependente tempDependente = new Dependente(dependente.Cliente);
                tempDependente.Id = dependente.Id;
                if (dependente.Id == null || !Dados.AcessoClienteDependente.ObterDependenteCliente(tempDependente))
                {
                    dependentesAdicionar.Add(dependente);
                }
                else
                {
                    dependentesAlterar.Add(dependente);
                }
            }
            dependentesAdicionar.ForEach((dep) => InserirDependente(dep));
            dependentesAlterar.ForEach((dep) => AlterarDependente(dep));

            IEnumerable<Dependente> DependentesListados = Dados.AcessoClienteDependente.ListarDependenteCliente(this, () => (Modelo.Cliente.ModeloDependenteCliente)new Dependente(this)).Cast<Dependente>();
            foreach (Dependente dependente in DependentesListados)
            {
                if (this.Dependentes.All((dep) => dep.Id != dependente.Id))
                {
                    this.RemoverDependente(dependente);
                }
            }
        }
        #endregion

        #region Metodos Grupo Diferencial
        private void InserirGrupoDiferencial(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            grupoDiferencialCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteGrupoDiferencial.InserirGrupoDiferencialCliente(grupoDiferencialCliente);
        }

        private void RemoverGrupoDiferencial(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            grupoDiferencialCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteGrupoDiferencial.RemoverGrupoDiferencialCliente(grupoDiferencialCliente);
        }

        private void AcertarGruposDiferenciais()
        {
            IEnumerable<GrupoDiferencial> GruposDiferenciaisListados = Dados.AcessoClienteGrupoDiferencial.ListarGrupoDiferencialCliente(this, () => (Modelo.Cliente.ModeloGrupoDiferencialCliente)new GrupoDiferencial(new TipoGrupoDiferencial(), this)).Cast<GrupoDiferencial>();

            List<Modelo.Cliente.ModeloGrupoDiferencialCliente> gruposAdicionar = new List<Modelo.Cliente.ModeloGrupoDiferencialCliente>();

            foreach (GrupoDiferencial grupoDiferencial in this.GruposDiferenciais)
            {
                GrupoDiferencial tempGrupoDif = GruposDiferenciaisListados.FirstOrDefault((grp) =>
                    grp.Cliente.Id == grupoDiferencial.Cliente.Id &&
                    grp.GrupoDiferencial.Id == grupoDiferencial.GrupoDiferencial.Id);
                if (tempGrupoDif == null)
                {
                    gruposAdicionar.Add(grupoDiferencial); 
                }
            }
            gruposAdicionar.ForEach((grp) => InserirGrupoDiferencial(grp));

            foreach (GrupoDiferencial grupoDiferencial in GruposDiferenciaisListados)
            {
                if (this.GruposDiferenciais.All((con) => con.Cliente.Id != grupoDiferencial.Cliente.Id && con.GrupoDiferencial.Id == grupoDiferencial.GrupoDiferencial.Id))
                {
                    this.RemoverGrupoDiferencial(grupoDiferencial);
                }
            }
        }
        #endregion

        #region Metodos Processo
        private void InserirProcesso(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            processoCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteProcesso.InserirProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void InserirProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            processo.ConferirOrigemParaManipularDados();
            ProcessoCliente processoCliente = new ProcessoCliente(processo,this);
            processoCliente.Obter();
            processoCliente.ConferirOrigemParaInserir();
            Dados.AcessoClienteProcesso.InserirProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void RemoverProcesso(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            processoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteProcesso.RemoverProcessoCliente(processoCliente);
            AcertarColecoes();
        }

        private void RemoverProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            processo.ConferirOrigemParaManipularDados();
            ProcessoCliente processoCliente = new ProcessoCliente(processo,this);
            processoCliente.Obter();
            processoCliente.ConferirOrigemParaInserir();
            processoCliente.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteProcesso.RemoverProcessoCliente(processoCliente);
        }

        private void AcertarProcessos()
        {
            IEnumerable<ProcessoCliente> processosListados = Dados.AcessoClienteProcesso.ListarProcessoCliente(this, () => (Modelo.Cliente.ModeloProcessoCliente)new ProcessoCliente(new Processo(),this)).Cast<ProcessoCliente>();

            List<Modelo.Cliente.ModeloProcessoCliente> processosAdicionar = new List<Modelo.Cliente.ModeloProcessoCliente>();

            foreach (Processo processo in this.Processos)
            {
                Processo tempProcesso = new Processo();
                tempProcesso.Id = processo.Id;

                ProcessoCliente processoCliente = new ProcessoCliente(processo,this);
                if (!Dados.AcessoProcessoCliente.ObterClienteProcesso(processoCliente))
                {
                    processosAdicionar.Add(processoCliente);
                }
            }
            processosAdicionar.ForEach((pro) => this.InserirProcesso(pro));

            foreach (ProcessoCliente processoCliente in processosListados)
            {
                if (this.Processos.All((pro) => pro.Id != processoCliente.Processo.Id))
                {
                    this.RemoverProcesso(processoCliente);
                }
            }
        }
        #endregion

        #region Metodos Atendimento
        private void InserirAtendimento(Modelo.Cliente.ModeloAtendimentoCliente Atendimento)
        {
            Atendimento.ConferirOrigemParaInserir();
            Dados.AcessoClienteAtendimento.InserirAtendimentoCliente(Atendimento);
        }

        private void RemoverAtendimento(Modelo.Cliente.ModeloAtendimentoCliente Atendimento)
        {
            Atendimento.ConferirOrigemParaManipularDados();
            Dados.AcessoClienteAtendimento.RemoverAtendimentoCliente(Atendimento);
        }

        private void AcertarAtendimentos()
        {
            List<Modelo.Cliente.ModeloAtendimentoCliente> atendimentosAdicionar = new List<Modelo.Cliente.ModeloAtendimentoCliente>();

            foreach (Atendimento atendimento in this.Atendimentos)
            {
                if (!Dados.AcessoClienteAtendimento.ObterAtendimentoCliente(atendimento))
                {
                    atendimentosAdicionar.Add(atendimento);
                }
            }
            atendimentosAdicionar.ForEach((att) => InserirAtendimento(att));
            IEnumerable<Atendimento> AtendimentosListados = Dados.AcessoClienteAtendimento.ListarAtendimentoCliente(this, () => (Modelo.Cliente.ModeloAtendimentoCliente)new Atendimento(this, new Usuario())).Cast<Atendimento>();
            foreach (Atendimento atendimento in AtendimentosListados)
            {
                if (this.Atendimentos.All((att) => att.Cliente.Id != atendimento.Cliente.Id && att.DataHoraAtendimento != atendimento.DataHoraAtendimento))
                {
                    this.RemoverAtendimento(atendimento);
                }
            }
        }
        #endregion
    }

    public static class Clientes
    {
        public static IEnumerable<Modelo.Cliente.ModeloCliente> Pesquisar(Modelo.Cliente.ModeloCliente clienteBase)
        {
            return Dados.AcessoCliente.PesquisarCliente(clienteBase, () => (Modelo.Cliente.ModeloCliente)new Cliente());
        }

        public static IEnumerable<Modelo.Cliente.ModeloCliente> PesquisarFullText(string textoBusca)
        {
            return Dados.AcessoCliente.PesquisarClienteFullText(textoBusca, () => (Modelo.Cliente.ModeloCliente)new Cliente());
        }
    }
}
