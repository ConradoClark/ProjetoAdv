using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;

namespace Dados
{
    public static class AcessoClienteContato
    {
        public static void InserirContatoCliente(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Contato.InserirContatoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdCliente, contatoCliente.Cliente.Id),                   
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.TipoContato, contatoCliente.TipoContato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.TextoContato, contatoCliente.Contato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.Observacao, contatoCliente.Observacao)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                contatoCliente.Id = (int?)@dados.idContatoCliente;
                contatoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterContatoCliente(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Contato.ObterContatoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdContatoCliente, contatoCliente.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    contatoCliente.Cliente.Id = @dados.idCliente;
                    AcessoCliente.ObterCliente(contatoCliente.Cliente);
                    contatoCliente.TipoContato = @dados.tipoContato;
                    contatoCliente.Contato = @dados.contato;
                    contatoCliente.Observacao = @dados.observacao;
                    contatoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Cliente.ModeloContatoCliente> ListarContatoCliente(Modelo.Cliente.ModeloCliente cliente, Func<Modelo.Cliente.ModeloContatoCliente> criacaoContatoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Contato.ListarContatoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdCliente, cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloContatoCliente contatoCliente = criacaoContatoCliente();
                    contatoCliente.Id = @dados.idContatoCliente;
                    contatoCliente.Cliente = cliente;
                    contatoCliente.TipoContato = @dados.tipoContato;
                    contatoCliente.Contato = @dados.contato;
                    contatoCliente.Observacao = @dados.observacao;                    
                    contatoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return contatoCliente;
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

        public static void RemoverContatoCliente(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.Contato.RemoverContatoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdContatoCliente, contatoCliente.Id)
                );
                contatoCliente.Id = null;
                contatoCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlterarContatoCliente(Modelo.Cliente.ModeloContatoCliente contatoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Contato.AlterarContatoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdContatoCliente, contatoCliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.IdCliente, contatoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.TipoContato, contatoCliente.TipoContato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.TextoContato, contatoCliente.Contato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Contato.Observacao, contatoCliente.Observacao)
                );
                contatoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                contatoCliente.Sujo = false;
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
