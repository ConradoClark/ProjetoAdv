using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoProcessoRecorte
    {
        public static void InserirRecorteProcesso(Modelo.Processo.ModeloRecorteProcesso recorteProcesso)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Processo.Recorte.InserirRecorteProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdProcesso, recorteProcesso.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdUsuario, recorteProcesso.UsuarioInclusao.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.TextoRecorte, recorteProcesso.TextoRecorte)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                recorteProcesso.DataInclusao = @dados.dataInclusao;
                recorteProcesso.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterRecorteProcesso(Modelo.Processo.ModeloRecorteProcesso recorteProcesso)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.Recorte.ObterRecorteProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdProcesso, recorteProcesso.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.DataInclusao, recorteProcesso.DataInclusao)
                    );

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    recorteProcesso.UsuarioInclusao.Id = @dados.idUsuario;
                    AcessoUsuario.ObterUsuario(recorteProcesso.UsuarioInclusao);
                    recorteProcesso.TextoRecorte = @dados.recorte;
                    recorteProcesso.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Processo.ModeloRecorteProcesso> ListarRecorteProcesso(Modelo.Processo.ModeloProcesso processo, Func<Modelo.Processo.ModeloRecorteProcesso> criacaoRecorteProcesso)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.Recorte.ListarRecorteProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdProcesso, processo.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {                    
                    Modelo.Processo.ModeloRecorteProcesso recorteProcesso = criacaoRecorteProcesso();
                    recorteProcesso.Processo = processo;
                    recorteProcesso.DataInclusao = @dados.dataInclusao;
                    recorteProcesso.UsuarioInclusao.Id = @dados.idUsuario;
                    AcessoUsuario.ObterUsuario(recorteProcesso.UsuarioInclusao);                    
                    recorteProcesso.TextoRecorte = @dados.recorte;
                    recorteProcesso.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return recorteProcesso;
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

        public static void RemoverRecorteProcesso(Modelo.Processo.ModeloRecorteProcesso recorteProcesso)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Processo.Recorte.RemoverRecorteProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdProcesso, recorteProcesso.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.DataInclusao, recorteProcesso.DataInclusao)
                );
                recorteProcesso.DataInclusao = null;
                recorteProcesso.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlterarRecorteProcesso(Modelo.Processo.ModeloRecorteProcesso recorteProcesso)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Processo.Recorte.AlterarRecorteProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdProcesso, recorteProcesso.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.DataInclusao, recorteProcesso.DataInclusao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.IdUsuario, recorteProcesso.UsuarioInclusao.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Recorte.TextoRecorte, recorteProcesso.TextoRecorte)
                );
                recorteProcesso.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                recorteProcesso.Sujo = false;
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
