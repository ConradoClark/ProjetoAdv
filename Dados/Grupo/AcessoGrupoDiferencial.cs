using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoGrupoDiferencial
    {
        public static bool ObterGrupoDiferencialGrupoCliente(Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.GrupoDiferencial.ObterGrupoDiferencial,
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencialCliente.GrupoDiferencial.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    grupoDiferencialCliente.GrupoDiferencial.Nome = @dados.nome;
                    grupoDiferencialCliente.GrupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterGrupoDiferencial(Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupoDiferencial)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.GrupoDiferencial.ObterGrupoDiferencial,
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencial.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    grupoDiferencial.Nome = @dados.nome;
                    grupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.GrupoDiferencial.ModeloGrupoDiferencial> ListarGrupoDiferencial(Func<Modelo.GrupoDiferencial.ModeloGrupoDiferencial> criacaoGrupoDiferencial)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.GrupoDiferencial.ListarGrupoDiferencial);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupoDiferencial = criacaoGrupoDiferencial();
                    grupoDiferencial.Id = (int?)@dados.idGrupoDiferencial;
                    grupoDiferencial.Nome = @dados.nome;
                    grupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return grupoDiferencial;
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

        public static IEnumerable<Modelo.Cliente.ModeloGrupoDiferencialCliente> ListarGrupoDiferencialAssociacao(Func<Modelo.Cliente.ModeloGrupoDiferencialCliente> criacaoGrupoDiferencialCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.GrupoDiferencial.ListarGrupoDiferencialCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.GrupoDiferencial.IdCliente, null));

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloGrupoDiferencialCliente grupoDiferencialCliente = criacaoGrupoDiferencialCliente();
                    grupoDiferencialCliente.GrupoDiferencial.Id = @dados.idGrupoDiferencial;
                    AcessoGrupoDiferencial.ObterGrupoDiferencial(grupoDiferencialCliente.GrupoDiferencial);
                    grupoDiferencialCliente.GrupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void InserirGrupoDiferencial(Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupoDiferencial)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.GrupoDiferencial.InserirGrupoDiferencial,
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.Nome, grupoDiferencial.Nome)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                grupoDiferencial.Id = (int?)@dados.idGrupoDiferencial;
                grupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarGrupoDiferencial(Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupoDiferencial)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.GrupoDiferencial.AlterarGrupoDiferencial,
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencial.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.Nome, grupoDiferencial.Nome)
                );
                grupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                grupoDiferencial.Sujo = false;
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

        public static void RemoverGrupoDiferencial(Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupoDiferencial)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.GrupoDiferencial.RemoverGrupoDiferencial,
                    new KeyValuePair<string, object>(Constantes.Parametros.GrupoDiferencial.IdGrupoDiferencial, grupoDiferencial.Id)
                );
                grupoDiferencial.Id = null;
                grupoDiferencial.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
