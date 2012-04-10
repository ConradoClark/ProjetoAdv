using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoClienteDependente
    {
        public static void InserirDependenteCliente(Modelo.Cliente.ModeloDependenteCliente DependenteCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Dependente.InserirDependenteCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdCliente, DependenteCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.Parentesco, DependenteCliente.GrauParentesco.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.NomeDependente, DependenteCliente.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IndicadorCadastro, DependenteCliente.IndCadastro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.Observacao, DependenteCliente.Observacao)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                DependenteCliente.Id = (int) @dados.idClienteDependente;
                DependenteCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static bool ObterDependenteCliente(Modelo.Cliente.ModeloDependenteCliente DependenteCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Dependente.ObterDependenteCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdClienteDependente, DependenteCliente.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    DependenteCliente.Cliente.Id = @dados.idCliente;
                    AcessoCliente.ObterCliente(DependenteCliente.Cliente);
                    DependenteCliente.GrauParentesco = Modelo.Comum.GrausParentesco.Lista.FirstOrDefault((g)=>g.Id == @dados.parentesco);
                    DependenteCliente.Nome = @dados.nomeDependente;
                    DependenteCliente.IndCadastro = Convert.ToBoolean(@dados.indCadastro);
                    DependenteCliente.Observacao = @dados.observacao;
                    DependenteCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static IEnumerable<Modelo.Cliente.ModeloDependenteCliente> ListarDependenteCliente(Modelo.Cliente.ModeloCliente cliente, Func<Modelo.Cliente.ModeloDependenteCliente> criacaoDependenteCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.Dependente.ListarDependenteCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdCliente, cliente.Id)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloDependenteCliente DependenteCliente = criacaoDependenteCliente();
                    DependenteCliente.Id = @dados.idClienteDependente;
                    DependenteCliente.Cliente = cliente;
                    DependenteCliente.GrauParentesco = Modelo.Comum.GrausParentesco.Lista.FirstOrDefault((g) => g.Id == @dados.parentesco);
                    DependenteCliente.Nome = @dados.nomeDependente;
                    DependenteCliente.IndCadastro = Convert.ToBoolean(@dados.indCadastro);
                    DependenteCliente.Observacao = @dados.observacao;
                    DependenteCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return DependenteCliente;
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

        public static void RemoverDependenteCliente(Modelo.Cliente.ModeloDependenteCliente DependenteCliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.Dependente.RemoverDependenteCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdClienteDependente, DependenteCliente.Id)
                );
                DependenteCliente.Id = null;
                DependenteCliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void AlterarDependenteCliente(Modelo.Cliente.ModeloDependenteCliente DependenteCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.Dependente.AlterarDependenteCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdClienteDependente, DependenteCliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IdCliente, DependenteCliente.Cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.Parentesco, DependenteCliente.GrauParentesco.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.NomeDependente, DependenteCliente.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.IndicadorCadastro, DependenteCliente.IndCadastro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Dependente.Observacao, DependenteCliente.Observacao)
                );
                DependenteCliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                DependenteCliente.Sujo = false;
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
