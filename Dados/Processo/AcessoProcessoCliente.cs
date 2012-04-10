using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoProcessoCliente
    {
        public static bool ObterClienteProcesso(Modelo.Cliente.ModeloProcessoCliente processoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Processo.ListarProcessoCliente,
                                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdProcesso, processoCliente.Processo.Id),
                                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdCliente, processoCliente.Cliente.Id)
                                    );
                if (objeto.Reader.Read())
                {
                    processoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    return true;
                }
                else {
                    return false;
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

        public static IEnumerable<Modelo.Cliente.ModeloProcessoCliente> ListarClienteProcesso(Modelo.Processo.ModeloProcesso processo, Func<Modelo.Cliente.ModeloProcessoCliente> criacaoProcessoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Processo.ListarProcessoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdProcesso, processo.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Processo.IdCliente, null)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloProcessoCliente processoCliente = criacaoProcessoCliente();
                    processoCliente.Cliente.Id = @dados.idCliente;
                    AcessoCliente.ObterCliente(processoCliente.Cliente);
                    processoCliente.Processo = processo;
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
    }
}
