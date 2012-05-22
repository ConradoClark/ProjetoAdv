using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Constantes
{
    public static class Conexao
    {
        public const string NomeConexao = "ArchConnectionString";
    }

    namespace Procedures
    {
        public static class Usuario
        {
            public const string ObterUsuario = "UsuarioObter";
            public const string InserirUsuario = "UsuarioInserir";
            public const string AlterarUsuario = "UsuarioAlterar";
            public const string RemoverUsuario = "UsuarioRemover";
            public const string ListarUsuario = "UsuarioListar";            
        }

        public static class Advogado
        {
            public const string ObterAdvogado = "AdvogadoObter";
            public const string InserirAdvogado = "AdvogadoInserir";
            public const string AlterarAdvogado = "AdvogadoAlterar";
            public const string RemoverAdvogado = "AdvogadoRemover";
            public const string ListarAdvogado = "AdvogadoListar";
        }

        public static class TipoAcao
        {
            public const string InserirTipoAcao = "TipoAcaoInserir";
            public const string AlterarTipoAcao = "TipoAcaoAlterar";
            public const string ObterTipoAcao = "TipoAcaoObter";
            public const string ListarTipoAcao = "TipoAcaoListar";
            public const string RemoverTipoAcao = "TipoAcaoRemover";
        }

        public static class Atendimento
        {
            public const string RegistrarAtendimento = "AtendimentoRegistrar";
            public const string ListarAtendimento = "AtendimentoListar";
        }

        public static class Pendencia
        {
            public const string InserirPendencia = "PendenciaInserir";
            public const string AlterarPendencia = "PendenciaAlterar";
            public const string RemoverPendencia = "PendenciaRemover";
            public const string ObterPendencia = "PendenciaObter";
            public const string ListarPendencia = "PendenciaListar";
        }

        public static class Cliente
        {
            public const string InserirCliente = "ClienteInserir";
            public const string AlterarCliente = "ClienteAlterar";
            public const string RemoverCliente = "ClienteRemover";
            public const string ObterCliente = "ClienteObter";
            public const string ListarCliente = "ClienteListar";
            public const string ListarClienteFullText = "ClienteListarFullText";
            public static class Atendimento
            {
                public const string InserirAtendimentoCliente = "ClienteAtendimentoInserir";
                public const string ListarAtendimentoCliente = "ClienteAtendimentoListar";
                public const string ObterAtendimentoCliente = "ClienteAtendimentoObter";
                public const string RemoverAtendimentoCliente = "ClienteAtendimentoRemover";
                public const string AlterarAtendimentoCliente = "ClienteAtendimentoAlterar";
            }
            public static class Beneficio
            {
                public const string InserirBeneficioCliente = "ClienteBeneficioInserir";
                public const string ListarBeneficioCliente = "ClienteBeneficioListar";
                public const string ObterBeneficioCliente = "ClienteBeneficioObter";
                public const string RemoverBeneficioCliente = "ClienteBeneficioRemover";
                public const string AlterarBeneficioCliente = "ClienteBeneficioAlterar";
            }
            public static class Contato
            {
                public const string InserirContatoCliente = "ClienteContatoInserir";
                public const string ListarContatoCliente = "ClienteContatoListar";
                public const string ObterContatoCliente = "ClienteContatoObter";
                public const string RemoverContatoCliente = "ClienteContatoRemover";
                public const string AlterarContatoCliente = "ClienteContatoAlterar";
            }
            public static class Dependente
            {
                public const string InserirDependenteCliente = "ClienteDependenteInserir";
                public const string ListarDependenteCliente = "ClienteDependenteListar";
                public const string ObterDependenteCliente = "ClienteDependenteObter";
                public const string RemoverDependenteCliente = "ClienteDependenteRemover";
                public const string AlterarDependenteCliente = "ClienteDependenteAlterar";
            }
            public static class GrupoDiferencial
            {
                public const string InserirGrupoDiferencialCliente = "ClienteGrupoDiferencialInserir";
                public const string ListarGrupoDiferencialCliente = "ClienteGrupoDiferencialListar";
                public const string ObterGrupoDiferencialCliente = "ClienteGrupoDiferencialObter";
                public const string RemoverGrupoDiferencialCliente = "ClienteGrupoDiferencialRemover";
                public const string AlterarGrupoDiferencialCliente = "ClienteGrupoDiferencialAlterar";
            }

            public static class Processo
            {
                public const string InserirProcessoCliente = "ClienteProcessoInserir";
                public const string ListarProcessoCliente = "ClienteProcessoListar";
                public const string RemoverProcessoCliente = "ClienteProcessoRemover";
            }
        }

        public static class Processo
        {
            public const string InserirProcesso = "ProcessoInserir";
            public const string AlterarProcesso = "ProcessoAlterar";
            public const string RemoverProcesso = "ProcessoRemover";
            public const string ObterProcesso = "ProcessoObter";
            public const string ListarProcesso = "ProcessoListar";

            public static class Recorte
            {
                public const string InserirRecorteProcesso = "ProcessoRecorteInserir";
                public const string AlterarRecorteProcesso = "ProcessoRecorteAlterar";
                public const string RemoverRecorteProcesso = "ProcessoRecorteRemover";
                public const string ObterRecorteProcesso = "ProcessoRecorteObter";
                public const string ListarRecorteProcesso = "ProcessoRecorteListar";
            }

            public static class Advogado
            {
                public const string InserirProcessoAdvogado = "ProcessoAdvogadoInserir";
                public const string RemoverProcessoAdvogado = "ProcessoAdvogadoRemover";
                public const string ListarProcessoAdvogado = "ProcessoAdvogadoListar";
            }
        }

        public static class TipoBeneficio
        {
            public const string InserirTipoBeneficio = "TipoBeneficioInserir";
            public const string ObterTipoBeneficio = "TipoBeneficioObter";
            public const string ListarTipoBeneficio = "TipoBeneficioListar";
            public const string RemoverTipoBeneficio = "TipoBeneficioRemover";
            public const string AlterarTipoBeneficio = "TipoBeneficioAlterar";            
        }

        public static class GrupoDiferencial
        {
            public const string InserirGrupoDiferencial = "GrupoDiferencialInserir";
            public const string ObterGrupoDiferencial = "GrupoDiferencialObter";
            public const string ListarGrupoDiferencial = "GrupoDiferencialListar";
            public const string RemoverGrupoDiferencial = "GrupoDiferencialRemover";
            public const string AlterarGrupoDiferencial = "GrupoDiferencialAlterar"; 
        }
    }

    namespace Parametros
    {
        public static class Usuario
        {
            public const string IdUsuario = "_idUsuario";
            public const string Nome = "_nome";
            public const string Login = "_login";
            public const string Senha = "_senha";
            public const string Permissao = "_permissao";
            public const string Status = "_status";
        }

        public static class Advogado
        {
            public const string IdAdvogado = "_idAdvogado";
            public const string OAB = "_oab";
            public const string CPF = "_cpf";
            public const string RG = "_rg";
            public const string Nome = "_nome";
            public const string IndEstagiario = "_indEstagiario";
            public const string EstadoCivil = "_estadoCivil";
            public const string Naturalidade = "_naturalidade";
            public const string Nacionalidade = "_nacionalidade";
            public const string Sexo = "_sexo";
        }

        public static class Cliente
        {
            public const string IdCliente = "_idCliente";
            public const string Nome = "_nome";
            public const string NomePai = "_nomePai";
            public const string NomeMae = "_nomeMae";
            public const string DataNascimento = "_dataNascimento";
            public const string Profissao = "_profissao";
            public const string CPF = "_cpf";
            public const string RG = "_rg";
            public const string OrgaoExpedidorRG = "_orgaoExpedidorRG";
            public const string DataEmissaoRG = "_dataEmissaoRg";
            public const string EstadoCivil = "_estadoCivil";
            public const string Nacionalidade = "_nacionalidade";
            public const string TextoBusca = "_texto";
            public static class Endereco
            {
                public const string Logradouro = "_enderecoLogradouro";
                public const string Numero = "_enderecoNumero";
                public const string Complemento = "_enderecoComplemento";
                public const string Bairro = "_enderecoBairro";
                public const string Cidade = "_enderecoCidade";
                public const string UF = "_enderecoUF";
                public const string CEP = "_enderecoCEP";
            }
            public const string TituloEleitor = "_tituloEleitor";
            public const string ZonaEleitoral = "_zonaEleitoral";
            public const string SecaoEleitoral = "_secaoEleitoral";
            public const string IndicadorGrupo = "_indGrupo";
            public const string IndicadorCliente = "_indCliente";
            public const string IndicadorContato = "_indContato";
            public const string IndicadorDependente = "_indDependente";
            public const string IndicadorPendencia = "_indPendencia";
            public const string IndicadorFalecido = "_indFalecido";
            public const string DataFalecimento = "_dataFalecimento";
            public const string Naturalidade = "_naturalidade";
            public const string CTPS1 = "_ctps1";
            public const string CTPS2 = "_ctps2";
            public const string CTPS3 = "_ctps3";
            public const string CTPS4 = "_ctps4";
            public const string CTPS5 = "_ctps5";
            public const string CTPSSerie1 = "_ctpsserie1";
            public const string CTPSSerie2 = "_ctpsserie2";
            public const string CTPSSerie3 = "_ctpsserie3";
            public const string CTPSSerie4 = "_ctpsserie4";
            public const string CTPSSerie5 = "_ctpsserie5";
            public const string PISPASEP1 = "_pispasep1";
            public const string PISPASEP2 = "_pispasep2";
            public const string PISPASEP3 = "_pispasep3";
            public const string PISPASEP4 = "_pispasep4";
            public const string NIT1 = "_nit1";
            public const string NIT2 = "_nit2";
            public const string NIT3 = "_nit3";
            public const string NIT4 = "_nit4";
            public const string Indicacao = "_indicacao";

            public static class Atendimento
            {
                public const string IdCliente = "_idCliente";
                public const string DataHoraAtendimento = "_dataHoraAtendimento";
                public const string IdUsuario = "_idUsuario";
                public const string AtendimentoInterno = "_atendimentoInterno";
                public const string AtendimentoExterno = "_atendimentoExterno";
            }

            public static class Beneficio
            {
                public const string IdClienteBeneficio = "_idClienteBeneficio";
                public const string IdCliente = "_idCliente";
                public const string IdTipoBeneficio = "_idTipoBeneficio";
                public const string Numero = "_numero";
                public const string TempoContribuicao = "_tempoContribuicao";
                public const string SomaSalariosContribuicao = "_somaSalariosContribuicao";
                public const string InicioBeneficio = "_inicioBeneficio";
                public const string RendaMensalInicial = "_rendaMensalInicial";
                public const string Divisor = "_divisor";
                public const string FatorPrevidenciario = "_fatorPrevidenciario";
                public const string SalarioBeneficio = "_salarioBeneficio";
                public const string CoeficienteCalculo = "_coeficienteCalculo";
                public const string Media = "_media";
            }

            public static class Contato
            {
                public const string IdContatoCliente = "_idContatoCliente";
                public const string IdCliente = "_idCliente";
                public const string TipoContato = "_tipoContato";
                public const string TextoContato = "_contato";
                public const string Observacao = "_observacao";
            }

            public static class Dependente
            {
                public const string IdClienteDependente = "_idClienteDependente";
                public const string IdCliente = "_idCliente";
                public const string Parentesco = "_parentesco";
                public const string NomeDependente = "_nomeDependente";
                public const string IndicadorCadastro = "_indCadastro";
                public const string Observacao = "_observacao";
            }

            public static class GrupoDiferencial
            {
                public const string IdGrupoDiferencial = "_idGrupoDiferencial";
                public const string IdCliente = "_idCliente";
            }

            public static class Processo
            {
                public const string IdProcesso = "_idProcesso";
                public const string IdCliente = "_idCliente";
            }
        }

        public static class Processo
        {
            public const string IdProcesso = "_idProcesso";
            public const string NumeroProcesso = "_numeroProcesso";
            public const string IdTipoAcao = "_idTipoAcao";
            public const string Objetivo = "_objetivo";
            public const string Vara = "_vara";
            public const string Cabeca = "_cabeca";
            public const string DataAjuizamentoAcao = "_dataAjuizamentoAcao";
            public const string Observacao = "_observacao";
            public const string Reu = "_reu";
            public const string NumeroOrdem = "_numeroOrdem";
            public const string QuantidadeDiasAlerta = "_qtdeDiasAlerta";
            public static class TipoAcao
            {
                public const string IdAcao = "_idAcao";
                public const string IdProcesso = "_idProcesso";
            }
            public static class Recorte
            {
                public const string IdProcesso = "_idProcesso";
                public const string DataInclusao = "_dataInclusao";
                public const string IdUsuario = "_idUsuario";
                public const string TextoRecorte = "_recorte";
            }
            public static class Advogado
            {
                public const string IdProcesso = "_idProcesso";
                public const string IdAdvogado = "_idAdvogado";
            }
        }

        public static class TipoAcao
        {
            public const string IdAcao = "_idAcao";
            public const string Descricao = "_descricao";
        }

        public static class TipoBeneficio
        {
            public const string IdTipoBeneficio = "_idTipoBeneficio";
            public const string Descricao = "_descricao";
        }

        public static class GrupoDiferencial
        {
            public const string IdGrupoDiferencial = "_idGrupoDiferencial";
            public const string Nome = "_nome";
        }

        public static class Atendimento
        {
            public const string IdCliente = "_idCliente";
            public const string IdUsuario = "_idUsuario";
            public const string AtendimentoInterno = "_atendimentoInterno";
            public const string AtendimentoExterno = "_atendimentoExterno";
        }

        public static class Pendencia
        {
            public const string IdPendencia = "_idPendencia";
            public const string Descricao = "_descricao";
        }

    }
}
