using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoTipoAcao
    {
        public static bool ObterTipoAcao(Modelo.Acao.ModeloTipoAcao tipoAcao)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.TipoAcao.ObterTipoAcao,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoAcao.IdAcao, tipoAcao.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    tipoAcao.Descricao = @dados.descricao;
                    tipoAcao.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Acao.ModeloTipoAcao> ListarTipoAcao(Func<Modelo.Acao.ModeloTipoAcao> criacaoTipoAcao)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.TipoAcao.ListarTipoAcao);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Acao.ModeloTipoAcao tipoAcao = criacaoTipoAcao();
                    tipoAcao.Id = (int?)@dados.idAcao;
                    tipoAcao.Descricao = @dados.descricao;
                    tipoAcao.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return tipoAcao;
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

        public static void InserirTipoAcao(Modelo.Acao.ModeloTipoAcao tipoAcao)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.TipoAcao.InserirTipoAcao,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoAcao.Descricao, tipoAcao.Descricao)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                tipoAcao.Id = (int?)@dados.idAcao;
                tipoAcao.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarTipoAcao(Modelo.Acao.ModeloTipoAcao tipoAcao)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.TipoAcao.AlterarTipoAcao,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoAcao.IdAcao, tipoAcao.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoAcao.Descricao, tipoAcao.Descricao)
                );
                tipoAcao.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                tipoAcao.Sujo = false;
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

        public static void RemoverTipoAcao(Modelo.Acao.ModeloTipoAcao tipoAcao)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.TipoAcao.RemoverTipoAcao,
                    new KeyValuePair<string, object>(Constantes.Parametros.TipoAcao.IdAcao, tipoAcao.Id)
                );
                tipoAcao.Id = null;
                tipoAcao.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
