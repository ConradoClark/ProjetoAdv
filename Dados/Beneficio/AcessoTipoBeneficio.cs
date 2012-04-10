using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoTipoBeneficio
    {

        public static bool ObterTipoBeneficioBeneficioCliente(Modelo.Cliente.ModeloBeneficioCliente beneficioCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.TipoBeneficio.ObterTipoBeneficio,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.IdTipoBeneficio, beneficioCliente.TipoBeneficio.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    beneficioCliente.TipoBeneficio.Descricao = @dados.descricao;
                    beneficioCliente.TipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterTipoBeneficio(Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.TipoBeneficio.ObterTipoBeneficio,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.IdTipoBeneficio, tipoBeneficio.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    tipoBeneficio.Descricao = @dados.descricao;
                    tipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Beneficio.ModeloTipoBeneficio> ListarTipoBeneficio(Func<Modelo.Beneficio.ModeloTipoBeneficio> criacaoTipoBeneficio)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.TipoBeneficio.ListarTipoBeneficio);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio = criacaoTipoBeneficio();
                    tipoBeneficio.Id = (int?)@dados.idTipoBeneficio;
                    tipoBeneficio.Descricao = @dados.descricao;
                    tipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return tipoBeneficio;
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

        public static IEnumerable<Modelo.Cliente.ModeloBeneficioCliente> ListarBeneficioAssociacao(Func<Modelo.Cliente.ModeloBeneficioCliente> criacaoBeneficioCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Beneficio.ListarBeneficioCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Beneficio.IdCliente, null));

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloBeneficioCliente beneficio = criacaoBeneficioCliente();
                    beneficio.TipoBeneficio.Id = @dados.idTipoBeneficio;
                    AcessoTipoBeneficio.ObterTipoBeneficio(beneficio.TipoBeneficio);
                    beneficio.Id = (int?)@dados.idClienteBeneficio;
                    beneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return beneficio;
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

        public static void InserirTipoBeneficio(Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.TipoBeneficio.InserirTipoBeneficio,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.Descricao, tipoBeneficio.Descricao)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                tipoBeneficio.Id = (int?)@dados.idTipoBeneficio;
                tipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarTipoBeneficio(Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.TipoBeneficio.AlterarTipoBeneficio,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.IdTipoBeneficio, tipoBeneficio.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.Descricao, tipoBeneficio.Descricao)
                );
                tipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                tipoBeneficio.Sujo = false;
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

        public static void RemoverTipoBeneficio(Modelo.Beneficio.ModeloTipoBeneficio tipoBeneficio)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.TipoBeneficio.RemoverTipoBeneficio,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoBeneficio.IdTipoBeneficio, tipoBeneficio.Id)
                );
                tipoBeneficio.Id = null;
                tipoBeneficio.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
