using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoPendencia
    {
        public static bool ObterPendencia(Modelo.Pendencia.ModeloPendencia pendencia)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Pendencia.ObterPendencia,
                    new KeyValuePair<string, object>(Constantes.Parametros.Pendencia.IdPendencia, pendencia.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    pendencia.Descricao = @dados.descricao;
                    pendencia.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Pendencia.ModeloPendencia> ListarPendencia(Func<Modelo.Pendencia.ModeloPendencia> criacaoPendencia)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Pendencia.ListarPendencia);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Pendencia.ModeloPendencia pendencia = criacaoPendencia();
                    pendencia.Id = (int?)@dados.idPendencia;
                    pendencia.Descricao = @dados.descricao;
                    pendencia.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return pendencia;
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

        public static void InserirPendencia(Modelo.Pendencia.ModeloPendencia Pendencia)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Pendencia.InserirPendencia,
                    new KeyValuePair<string, object>(Constantes.Parametros.Pendencia.Descricao, Pendencia.Descricao)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                Pendencia.Id = (int?)@dados.idPendencia;
                Pendencia.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarPendencia(Modelo.Pendencia.ModeloPendencia Pendencia)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Pendencia.AlterarPendencia,
                    new KeyValuePair<string, object>(Constantes.Parametros.Pendencia.IdPendencia, Pendencia.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Pendencia.Descricao, Pendencia.Descricao)
                );
                Pendencia.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                Pendencia.Sujo = false;
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

        public static void RemoverPendencia(Modelo.Pendencia.ModeloPendencia Pendencia)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Pendencia.RemoverPendencia,
                    new KeyValuePair<string, object>(Constantes.Parametros.Pendencia.IdPendencia, Pendencia.Id)
                );
                Pendencia.Id = null;
                Pendencia.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
