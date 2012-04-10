using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoClienteAtendimento
    {
        public static void InserirAtendimentoCliente(Modelo.Cliente.ModeloAtendimentoCliente atendimentoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Atendimento.InserirAtendimentoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdCliente, atendimentoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdUsuario, atendimentoCliente.UsuarioAtendimento.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.AtendimentoInterno, atendimentoCliente.AtendimentoInterno),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.AtendimentoExterno, atendimentoCliente.AtendimentoExterno)                    
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                atendimentoCliente.DataHoraAtendimento = @dados.dataHoraAtendimento;
                atendimentoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterAtendimentoCliente(Modelo.Cliente.ModeloAtendimentoCliente atendimentoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Atendimento.ObterAtendimentoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdCliente, atendimentoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.DataHoraAtendimento, atendimentoCliente.DataHoraAtendimento)
                    );

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    atendimentoCliente.Cliente.Id = @dados.idCliente;
                    if (atendimentoCliente.Cliente.OrigemDados == Modelo.Comum.OrigemDados.Local)
                    {
                        AcessoCliente.ObterCliente(atendimentoCliente.Cliente);
                    }
                    atendimentoCliente.UsuarioAtendimento.Id = @dados.idUsuario;
                    AcessoUsuario.ObterUsuario(atendimentoCliente.UsuarioAtendimento);
                    atendimentoCliente.AtendimentoInterno = @dados.atendimentoInterno;
                    atendimentoCliente.AtendimentoExterno = @dados.atendimentoExterno;                    
                    atendimentoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Cliente.ModeloAtendimentoCliente> ListarAtendimentoCliente(Modelo.Cliente.ModeloCliente cliente, Func<Modelo.Cliente.ModeloAtendimentoCliente> criacaoAtendimentoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Atendimento.ListarAtendimentoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdCliente, cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloAtendimentoCliente atendimentoCliente = criacaoAtendimentoCliente();
                    atendimentoCliente.Cliente = cliente;
                    atendimentoCliente.UsuarioAtendimento.Id = @dados.idUsuario;
                    AcessoUsuario.ObterUsuario(atendimentoCliente.UsuarioAtendimento);
                    atendimentoCliente.DataHoraAtendimento = @dados.dataHoraAtendimento;
                    atendimentoCliente.AtendimentoInterno = @dados.atendimentoInterno;
                    atendimentoCliente.AtendimentoExterno = @dados.atendimentoExterno;
                    atendimentoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return atendimentoCliente;
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

        public static void RemoverAtendimentoCliente(Modelo.Cliente.ModeloAtendimentoCliente atendimentoCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.Atendimento.RemoverAtendimentoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdCliente, atendimentoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.DataHoraAtendimento, atendimentoCliente.DataHoraAtendimento)
                );
                atendimentoCliente.DataHoraAtendimento = null;
                atendimentoCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlterarAtendimentoCliente(Modelo.Cliente.ModeloAtendimentoCliente atendimentoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Atendimento.AlterarAtendimentoCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.DataHoraAtendimento, atendimentoCliente.DataHoraAtendimento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdCliente, atendimentoCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.AtendimentoInterno, atendimentoCliente.AtendimentoInterno),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.AtendimentoExterno, atendimentoCliente.AtendimentoExterno),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento.IdUsuario, atendimentoCliente.UsuarioAtendimento.Id)
                );
                atendimentoCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                atendimentoCliente.Sujo = false;
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
