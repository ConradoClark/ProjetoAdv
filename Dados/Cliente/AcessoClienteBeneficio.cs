using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoClienteBeneficio
    {
        public static void InserirBeneficioCliente(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Beneficio.InserirBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdCliente, beneficioCliente.Cliente.Id),                    
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdTipoBeneficio, beneficioCliente.TipoBeneficio.Id),                    
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Numero, beneficioCliente.Numero),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.TempoContribuicao, beneficioCliente.TempoContribuicao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.SomaSalariosContribuicao, beneficioCliente.SomaSalariosContribuicao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.InicioBeneficio, beneficioCliente.InicioBeneficio),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.RendaMensalInicial, beneficioCliente.RendaMensalInicial),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Divisor, beneficioCliente.Divisor),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.FatorPrevidenciario, beneficioCliente.FatorPrevidenciario),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.SalarioBeneficio, beneficioCliente.SalarioBeneficio),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.CoeficienteCalculo, beneficioCliente.CoeficienteCalculo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Media, beneficioCliente.Media)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                beneficioCliente.Id = (int?)@dados.idClienteBeneficio;
                beneficioCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static bool ObterBeneficioCliente(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {            
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Beneficio.ObterBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdClienteBeneficio, beneficioCliente.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    beneficioCliente.TipoBeneficio.Id = @dados.idTipoBeneficio;
                    AcessoTipoBeneficio.ObterTipoBeneficioBeneficioCliente(beneficioCliente);
                    beneficioCliente.Cliente.Id = @dados.idCliente;
                    AcessoCliente.ObterCliente(beneficioCliente.Cliente);                                        
                    beneficioCliente.Numero = @dados.numero;
                    beneficioCliente.TempoContribuicao = @dados.tempoContribuicao;
                    beneficioCliente.SomaSalariosContribuicao = @dados.somaSalariosContribuicao;
                    beneficioCliente.InicioBeneficio = @dados.inicioBeneficio;
                    beneficioCliente.RendaMensalInicial = @dados.rendaMensalInicial;
                    beneficioCliente.Divisor = @dados.divisor;
                    beneficioCliente.FatorPrevidenciario = @dados.fatorPrevidenciario;
                    beneficioCliente.SalarioBeneficio = @dados.salarioBeneficio;
                    beneficioCliente.CoeficienteCalculo = @dados.coeficienteCalculo;
                    beneficioCliente.Media = @dados.media;
                    beneficioCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    return true;
                }
                else return false;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        
        }

        public static IEnumerable<Modelo.Cliente.ModeloBeneficioCliente> ListarBeneficioCliente(Modelo.Cliente.ModeloCliente cliente,Func<Modelo.Cliente.ModeloBeneficioCliente> criacaoBeneficioCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Beneficio.ListarBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdCliente, cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloBeneficioCliente beneficioCliente = criacaoBeneficioCliente();

                    beneficioCliente.TipoBeneficio.Id = @dados.idTipoBeneficio;
                    AcessoTipoBeneficio.ObterTipoBeneficioBeneficioCliente(beneficioCliente);
                    beneficioCliente.TipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;                    
                    beneficioCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;

                    beneficioCliente.Id = @dados.idClienteBeneficio;
                    beneficioCliente.Numero = @dados.numero;
                    beneficioCliente.TempoContribuicao = @dados.tempoContribuicao;
                    beneficioCliente.SomaSalariosContribuicao = @dados.somaSalariosContribuicao;
                    beneficioCliente.InicioBeneficio = @dados.inicioBeneficio;
                    beneficioCliente.RendaMensalInicial = @dados.rendaMensalInicial;
                    beneficioCliente.Divisor = @dados.divisor;
                    beneficioCliente.FatorPrevidenciario = @dados.fatorPrevidenciario;
                    beneficioCliente.SalarioBeneficio = @dados.salarioBeneficio;
                    beneficioCliente.CoeficienteCalculo = @dados.coeficienteCalculo;
                    beneficioCliente.Media = @dados.media;
                    yield return beneficioCliente;
                }
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static void RemoverBeneficioCliente(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.Beneficio.RemoverBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdClienteBeneficio, beneficioCliente.Id)
                );
                beneficioCliente.Id = null;
                beneficioCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlterarBeneficioCliente(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Beneficio.AlterarBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdClienteBeneficio, beneficioCliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdCliente, beneficioCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdTipoBeneficio, beneficioCliente.TipoBeneficio.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Numero, beneficioCliente.Numero),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.TempoContribuicao, beneficioCliente.TempoContribuicao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.SomaSalariosContribuicao, beneficioCliente.SomaSalariosContribuicao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.InicioBeneficio, beneficioCliente.InicioBeneficio),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.RendaMensalInicial, beneficioCliente.RendaMensalInicial),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Divisor, beneficioCliente.Divisor),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.FatorPrevidenciario, beneficioCliente.FatorPrevidenciario),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.SalarioBeneficio, beneficioCliente.SalarioBeneficio),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.CoeficienteCalculo, beneficioCliente.CoeficienteCalculo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.Media, beneficioCliente.Media)
                );
                beneficioCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                beneficioCliente.Sujo = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }
    }
}
