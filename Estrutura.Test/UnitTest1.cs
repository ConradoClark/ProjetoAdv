using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Modelo.Comum;

namespace Estrutura.Test
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ListarUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "conrado.clarke";
            usuario.Senha = "12345";
            usuario.Nome = "Conrado Adevany Clarke";
            usuario.Inserir();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            var usuarios = Sessao.ListarUsuarios().ToList();
            Assert.IsTrue(usuarios.Any((usr) => usr.Id == usuario.Id));

            usuario.Remover();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void LogarUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "conrado.clarke";
            usuario.Senha = "12345";
            usuario.Nome = "Conrado Adevany Clarke";
            usuario.Inserir();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);
         
            usuario.Logar();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            usuario.Remover();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void InserirUsuario()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "conrado.clarke";
            usuario.Senha = "12345";                 
            usuario.Nome = "Conrado Adevany Clarke";
            usuario.Inserir();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            usuario.Remover();
            Assert.IsNull(usuario.Id);
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void InserirCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Scott Peppers";
            cliente.Endereco.Uf = "SP";
            cliente.EstadoCivil = Modelo.Comum.EstadoCivil.Solteiro;
            cliente.TituloEleitor = "12345678900";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void ObterCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Scott Peppers";
            cliente.Inserir();

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Assert.AreEqual(cliente.Nome, cliente2.Nome);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void PesquisarCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Angelina Jolie";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Cliente clienteBase = new Cliente();
            clienteBase.Nome = "Jolie";
            IEnumerable<Modelo.Cliente.ModeloCliente> resultado = Clientes.Pesquisar(clienteBase);

            Assert.IsTrue(resultado.Any((res) => res.Id == cliente.Id));
            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void InserirTipoBeneficio()
        {
            TipoBeneficio tipoBeneficio = new TipoBeneficio();
            tipoBeneficio.Descricao = "NovoTipo";
            tipoBeneficio.Inserir();
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Banco);

            tipoBeneficio.Remover();
            Assert.IsNull(tipoBeneficio.Id);
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void AlterarTipoBeneficio()
        {
            TipoBeneficio tipoBeneficio = new TipoBeneficio();
            tipoBeneficio.Descricao = "NovoTipo";
            tipoBeneficio.Inserir();
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Banco);

            tipoBeneficio.Descricao = "NovoTipoAlterado";
            tipoBeneficio.Alterar();

            TipoBeneficio tipoBeneficio2 = new TipoBeneficio();
            tipoBeneficio2.Id = tipoBeneficio.Id;
            tipoBeneficio2.Obter();
            Assert.AreEqual(tipoBeneficio2.OrigemDados, OrigemDados.Banco);

            Assert.AreEqual(tipoBeneficio.Descricao, tipoBeneficio.Descricao);

            tipoBeneficio.Remover();
            Assert.IsNull(tipoBeneficio.Id);
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void ListarTipoBeneficio()
        {
            TipoBeneficio tipoBeneficio = new TipoBeneficio();
            tipoBeneficio.Descricao = "NovoTipo";
            tipoBeneficio.Inserir();

            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Banco);
            Assert.IsTrue(TiposBeneficio.Listar().Any((res) => res.Id == tipoBeneficio.Id));

            tipoBeneficio.Remover();
            Assert.IsNull(tipoBeneficio.Id);
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void TesteBeneficioCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Angelina Jolie";
            cliente.Inserir();          
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            TipoBeneficio tipoBeneficio = new TipoBeneficio();
            tipoBeneficio.Descricao = "NovoTipo";
            tipoBeneficio.Inserir();
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Banco);

            Beneficio beneficio = new Beneficio(tipoBeneficio, cliente);
            cliente.Beneficios.Add(beneficio);
            
            cliente.Salvar();
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Banco);

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();

            Beneficio beneficio2 = cliente.Beneficios.FirstOrDefault();
            Assert.IsNotNull(beneficio2);
            Assert.AreEqual(beneficio.Id,beneficio2.Id);

            cliente.Beneficios.Clear();
            cliente.Salvar();

            Cliente cliente3 = new Cliente();
            cliente3.Id = cliente.Id;
            cliente3.Obter();

            Beneficio beneficio3 = cliente.Beneficios.FirstOrDefault();
            Assert.IsNull(beneficio3);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);

            tipoBeneficio.Remover();
            Assert.IsNull(tipoBeneficio.Id);
            Assert.AreEqual(tipoBeneficio.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void TesteContatoCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Angelina Jolie";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Contato contato = new Contato(cliente);
            cliente.Contatos.Add(contato);

            cliente.Salvar();
            Assert.AreEqual(contato.OrigemDados, OrigemDados.Banco);

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();

            Contato contato2 = cliente.Contatos.FirstOrDefault();
            Assert.IsNotNull(contato2);
            Assert.AreEqual(contato.Id, contato2.Id);

            cliente.Contatos.Clear();
            cliente.Salvar();

            Cliente cliente3 = new Cliente();
            cliente3.Id = cliente.Id;
            cliente3.Obter();

            Contato contato3 = cliente.Contatos.FirstOrDefault();
            Assert.IsNull(contato3);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void TesteDependenteCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Angelina Jolie";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Dependente dependente = new Dependente(cliente);
            dependente.GrauParentesco = GrausParentesco.Irmao;
            dependente.Nome = "Joseph Climber";
            cliente.Dependentes.Add(dependente);

            cliente.Salvar();
            Assert.AreEqual(dependente.OrigemDados, OrigemDados.Banco);

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();

            Dependente dependente2 = cliente.Dependentes.FirstOrDefault();
            Assert.IsNotNull(dependente2);
            Assert.AreEqual(dependente.Id, dependente2.Id);

            cliente.Dependentes.Clear();
            cliente.Salvar();

            Cliente cliente3 = new Cliente();
            cliente3.Id = cliente.Id;
            cliente3.Obter();

            Dependente dependente3 = cliente.Dependentes.FirstOrDefault();
            Assert.IsNull(dependente3);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void TesteGrupoDiferencialCliente()
        {
            Cliente cliente = new Cliente();
            cliente.Nome = "Megan Fox";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            TipoGrupoDiferencial tipo = new TipoGrupoDiferencial();
            tipo.Nome = "INSS";

            tipo.Inserir();
            Assert.AreEqual(tipo.OrigemDados, OrigemDados.Banco);

            GrupoDiferencial grupo = new GrupoDiferencial(tipo, cliente);
            cliente.GruposDiferenciais.Add(grupo);
            cliente.Salvar();

            Assert.AreEqual(grupo.OrigemDados, OrigemDados.Banco);

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();

            Assert.IsNotNull(cliente2.GruposDiferenciais.FirstOrDefault((grp)=>grp.Cliente.Id == cliente2.Id && grp.GrupoDiferencial.Id == tipo.Id));

            cliente2.GruposDiferenciais.Clear();
            cliente2.Salvar();

            Cliente cliente3 = new Cliente();
            cliente3.Id = cliente.Id;
            cliente3.Obter();

            Assert.IsNull(cliente2.GruposDiferenciais.FirstOrDefault((grp) => grp.Cliente.Id == cliente2.Id && grp.GrupoDiferencial.Id == tipo.Id));

            tipo.Remover();
            Assert.AreEqual(tipo.OrigemDados, OrigemDados.Local);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);
        }
        
        [TestMethod]
        public void TesteProcessoCliente()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "conrado.clarke";
            usuario.Senha = "12345";
            usuario.Nome = "Conrado Adevany Clarke";
            usuario.Inserir();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);
         
            usuario.Logar();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            Cliente cliente = new Cliente();
            cliente.Nome = "Mila Kunis";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            TipoAcao tipoAcao = new TipoAcao();
            tipoAcao.Descricao = "Danos morais por duelo na lama";
            tipoAcao.Inserir();
            Assert.AreEqual(tipoAcao.OrigemDados, OrigemDados.Banco);
                       
            Processo processo = new Processo();
            processo.Cabeca.Nome = "Cameron Diaz";
            processo.Reu = "Jessica Rabbit";
            processo.TipoAcao = tipoAcao;

            processo.Inserir();

            Processo processo2 = new Processo();
            processo2.Id = processo.Id;
            processo2.Obter();
            Assert.AreEqual(tipoAcao.Id, processo2.TipoAcao.Id);

            processo.Clientes.Add(cliente);
            processo.Salvar();

            //Verifica sincronização entre coleções
            Assert.IsTrue(cliente == processo.Clientes[0]);
            Assert.IsTrue(processo == cliente.Processos[0]);

            ProcessoCliente processoCliente = new ProcessoCliente(processo, cliente);
            Assert.IsTrue(processoCliente.Obter());

            Recorte recorte = new Recorte(processo, Sessao.UsuarioAtual);
            processo.Recortes.Add(recorte);
            Assert.IsTrue(processo.Recortes[0] == recorte);

            processo.Salvar();

            Processo processo3 = new Processo();
            processo3.Id = processo.Id;
            processo3.Obter();

            Assert.IsNotNull(processo3.Recortes.FirstOrDefault((rec) => rec.DataInclusao == recorte.DataInclusao && rec.Processo.Id == recorte.Processo.Id));

            processo.Recortes.Clear();
            processo.Clientes.Clear();
            processo.Salvar();
            Assert.IsFalse(processoCliente.Obter());

            processo.Remover();
            Assert.IsNull(processo.Id);
            Assert.AreEqual(processo.OrigemDados, OrigemDados.Local);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);

            tipoAcao.Remover();
            Assert.IsNull(tipoAcao.Id);
            Assert.AreEqual(tipoAcao.OrigemDados, OrigemDados.Local);

            usuario.Remover();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Local);
        }

        [TestMethod]
        public void TestePendencia()
        {
            Pendencia pendencia = new Pendencia();
            pendencia.Descricao = "O rato roeu a roupa do rei de Roma";
            pendencia.Inserir();

            Assert.AreEqual(OrigemDados.Banco,pendencia.OrigemDados);

            Pendencia pendencia2 = new Pendencia();
            pendencia2.Id = pendencia.Id;
            pendencia2.Obter();

            Assert.AreEqual(pendencia.Descricao, pendencia2.Descricao);

            Pendencia pendencia3 = (Pendencia) Pendencias.Listar(() => new Pendencia()).FirstOrDefault();
            Assert.IsNotNull(pendencia3);
            Assert.AreEqual(pendencia3.Id, pendencia.Id);
            Assert.AreEqual(pendencia3.Descricao, pendencia.Descricao);

            pendencia.Descricao = "Casa de ferreiro, espeto de pau";
            pendencia.Alterar();

            Pendencia pendencia4 = new Pendencia();
            pendencia4.Id = pendencia.Id;
            pendencia4.Obter();

            Assert.AreEqual(pendencia.Descricao, pendencia4.Descricao);
            pendencia.Remover();

            Assert.AreEqual(OrigemDados.Local, pendencia.OrigemDados);
            Assert.IsFalse(pendencia.Obter());
        }

        [TestMethod]
        public void TesteAtendimentoCliente()
        {
            Usuario usuario = new Usuario();
            usuario.Login = "conrado.clarke";
            usuario.Senha = "12345";
            usuario.Nome = "Conrado Adevany Clarke";
            usuario.Inserir();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            usuario.Logar();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Banco);

            Cliente cliente = new Cliente();
            cliente.Nome = "Jennifer Aniston";
            cliente.Inserir();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Atendimento atendimento = new Atendimento(cliente, Sessao.UsuarioAtual);
            atendimento.AtendimentoInterno = "Atendimento visível apenas para os advogados, não aparece na página de clientes";
            atendimento.AtendimentoExterno = "Atendimento visível a todos";

            cliente.Atendimentos.Add(atendimento);
            cliente.Salvar();

            Cliente cliente2 = new Cliente();
            cliente2.Id = cliente.Id;
            cliente2.Obter();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Atendimento atendimento2 = cliente.Atendimentos.FirstOrDefault();
            Assert.IsNotNull(atendimento2);
            Assert.AreEqual(atendimento.AtendimentoInterno, atendimento2.AtendimentoInterno);
            Assert.AreEqual(atendimento.AtendimentoExterno, atendimento2.AtendimentoExterno);
            Assert.AreEqual(atendimento.DataHoraAtendimento, atendimento2.DataHoraAtendimento);

            cliente.Atendimentos.Clear();
            cliente.Salvar();

            Cliente cliente3 = new Cliente();
            cliente3.Id = cliente.Id;
            cliente3.Obter();
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Banco);

            Assert.AreEqual(0,cliente.Atendimentos.Count);

            cliente.Remover();
            Assert.IsNull(cliente.Id);
            Assert.AreEqual(cliente.OrigemDados, OrigemDados.Local);

            usuario.Remover();
            Assert.AreEqual(usuario.OrigemDados, OrigemDados.Local);
        }
        
    }
}
