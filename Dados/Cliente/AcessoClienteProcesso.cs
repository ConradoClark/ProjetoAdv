using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoClienteProcesso
    {
        public static void InserirProcessoCliente(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Processo.InserirProcessoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdCliente, processoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdProcesso, processoCliente.Processo.Id)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                processoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Cliente.ModeloProcessoCliente> ListarProcessoCliente(Modelo.Cliente.ModeloCliente cliente, Func<Modelo.Cliente.ModeloProcessoCliente> criacaoProcessoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Processo.ListarProcessoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdCliente, cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdProcesso, null)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloProcessoCliente processoCliente = criacaoProcessoCliente();
                    processoCliente.Cliente = cliente;
                    processoCliente.Processo.Id = @dados.idProcesso;
                    AcessoProcesso.ObterProcesso(processoCliente.Processo);
                    processoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return processoCliente;
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

        public static void RemoverProcessoCliente(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.Processo.RemoverProcessoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdProcesso, processoCliente.Processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdCliente, processoCliente.Cliente.Id)
                );
                processoCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
