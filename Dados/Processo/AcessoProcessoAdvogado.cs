using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoProcessoAdvogado
    {
        public static void InserirProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado)
        {            
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Processo.Advogado.InserirProcessoAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdProcesso, processoAdvogado.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdAdvogado, processoAdvogado.Advogado.Id)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                processoAdvogado.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void RemoverProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Processo.Advogado.RemoverProcessoAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdProcesso, processoAdvogado.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdAdvogado, processoAdvogado.Advogado.Id)
                );
                processoAdvogado.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Modelo.Advogado.ModeloAdvogadoProcesso> ListarProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso buscaProcessoAdvogado, Func<Modelo.Advogado.ModeloAdvogadoProcesso> criacaoProcessoAdvogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.Advogado.ListarProcessoAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdProcesso, buscaProcessoAdvogado.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdAdvogado, buscaProcessoAdvogado.Advogado.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado = criacaoProcessoAdvogado();
                    processoAdvogado.Processo.Id = @dados.idProcesso;
                    AcessoProcesso.ObterProcesso(processoAdvogado.Processo);

                    processoAdvogado.Advogado.Id = @dados.idAdvogado;
                    AcessoAdvogado.ObterAdvogado(processoAdvogado.Advogado);

                    processoAdvogado.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return processoAdvogado;
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

        public static bool ObterProcessoAdvogado(Modelo.Advogado.ModeloAdvogadoProcesso processoAdvogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.Advogado.ListarProcessoAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdProcesso, processoAdvogado.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Advogado.IdAdvogado, processoAdvogado.Advogado.Id)
                    );

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    processoAdvogado.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    return true;
                }
                return false;
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
