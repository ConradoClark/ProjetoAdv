using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoClienteGrupoDiferencial
    {
        public static void InserirGrupoDiferencialCliente(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.GrupoDiferencial.InserirGrupoDiferencialCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdCliente, grupoDiferencialCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencialCliente.GrupoDiferencial.Id)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                grupoDiferencialCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        //acho que não precisa disso
        /*public static bool ObterGrupoDiferencialCliente(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.GrupoDiferencial.ObterGrupoDiferencialCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencialCliente.GrupoDiferencial.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdCliente, grupoDiferencialCliente.Cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    grupoDiferencialCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        }*/

        public static IEnumerable<Modelo.Cliente.ModeloGrupoDiferencialCliente> ListarGrupoDiferencialCliente(Modelo.Cliente.ModeloCliente cliente, Func<Modelo.Cliente.ModeloGrupoDiferencialCliente> criacaoGrupoDiferencialCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.GrupoDiferencial.ListarGrupoDiferencialCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdCliente, cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente = criacaoGrupoDiferencialCliente();
                    grupoDiferencialCliente.Cliente = cliente;
                    grupoDiferencialCliente.GrupoDiferencial.Id = @dados.idGrupoDiferencial;
                    AcessoGrupoDiferencial.ObterGrupoDiferencial(grupoDiferencialCliente.GrupoDiferencial);
                    grupoDiferencialCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return grupoDiferencialCliente;
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

        public static void RemoverGrupoDiferencialCliente(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.GrupoDiferencial.RemoverGrupoDiferencialCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencialCliente.GrupoDiferencial.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdCliente, grupoDiferencialCliente.Cliente.Id)
                );
                grupoDiferencialCliente.GrupoDiferencial.Id = null;
                grupoDiferencialCliente.GrupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Local;
                grupoDiferencialCliente.Cliente.Id = null;
                grupoDiferencialCliente.Cliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
                grupoDiferencialCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
