using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoProcesso
    {
        public static void InserirProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Processo.InserirProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.NumeroProcesso, processo.NumeroProcesso),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdTipoAcao, processo.TipoAcao.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Objetivo, processo.Objetivo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Vara, processo.Vara),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Cabeca, processo.Cabeca.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.DataAjuizamentoAcao, processo.DataAjuizamentoAcao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Observacao, processo.Observacao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Reu, processo.Reu),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.NumeroOrdem, processo.NumeroOrdem),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.QuantidadeDiasAlerta, processo.QuantidadeDiasAlerta)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                processo.Id = (int?)@dados.idProcesso;
                processo.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Processo.AlterarProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdProcesso, processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.NumeroProcesso, processo.NumeroProcesso),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdTipoAcao, processo.TipoAcao.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Objetivo, processo.Objetivo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Vara, processo.Vara),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Cabeca, processo.Cabeca.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.DataAjuizamentoAcao, processo.DataAjuizamentoAcao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Observacao, processo.Observacao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Reu, processo.Reu),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.NumeroOrdem, processo.NumeroOrdem),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.QuantidadeDiasAlerta, processo.QuantidadeDiasAlerta)
                );
                processo.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                processo.Sujo = false;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static bool ObterProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.ObterProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdProcesso, processo.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    processo.NumeroProcesso = @dados.numeroProcesso;
                    processo.TipoAcao.Id = @dados.idTipoAcao;
                    AcessoTipoAcao.ObterTipoAcao(processo.TipoAcao);
                    processo.Objetivo = @dados.objetivo;
                    processo.Vara = @dados.vara;
                    processo.Cabeca.Id = @dados.cabeca;
                    AcessoCliente.ObterCliente(processo.Cabeca);
                    processo.DataAjuizamentoAcao = @dados.dataAjuizamentoAcao;
                    processo.Observacao = @dados.observacao;
                    processo.Reu = @dados.reu;
                    processo.NumeroOrdem = @dados.numeroOrdem;
                    processo.QuantidadeDiasAlerta = @dados.qtdeDiasAlerta;
                    processo.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void RemoverProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Processo.RemoverProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdProcesso, processo.Id)
                );
                processo.Id = null;
                processo.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Modelo.Processo.ModeloProcesso> PesquisarProcesso(Modelo.Processo.ModeloProcesso processoBase, Func<Modelo.Processo.ModeloProcesso> criacaoProcesso)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Processo.ListarProcesso,
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.IdProcesso, processoBase.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.NumeroProcesso, processoBase.NumeroProcesso),
                    new KeyValuePair<string, object>(Constantes.Parametros.Processo.Cabeca, processoBase.Cabeca.Nome)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Processo.ModeloProcesso processo = criacaoProcesso();
                    processo.Id = @dados.idProcesso;
                    processo.NumeroProcesso = @dados.numeroProcesso;
                    processo.TipoAcao.Id = @dados.idTipoAcao;
                    AcessoTipoAcao.ObterTipoAcao(processo.TipoAcao);
                    processo.Objetivo = @dados.objetivo;
                    processo.Vara = @dados.vara;
                    processo.Cabeca.Id = @dados.cabeca;
                    AcessoCliente.ObterCliente(processo.Cabeca);
                    processo.DataAjuizamentoAcao = @dados.dataAjuizamentoAcao;
                    processo.Observacao = @dados.observacao;
                    processo.Reu = @dados.reu;
                    processo.NumeroOrdem = @dados.numeroOrdem;
                    processo.QuantidadeDiasAlerta = @dados.qtdeDiasAlerta;
                    processo.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return processo;
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
    }
}
