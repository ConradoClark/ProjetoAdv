using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;

namespace Dados
{
    public static class AcessoAdvogado
    {
        public static void InserirAdvogado(Modelo.Advogado.ModeloAdvogado advogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Advogado.InserirAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.OAB, advogado.Oab),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.CPF, advogado.Cpf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.RG, advogado.Rg),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Nome, advogado.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.IndEstagiario, advogado.IndicadorEstagiario),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.EstadoCivil, advogado.EstadoCivil),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Naturalidade, advogado.Naturalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Nacionalidade, advogado.Nacionalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Sexo, advogado.Sexo)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                advogado.Id = (int?)@dados.idAdvogado;
                advogado.OrigemDados = OrigemDados.Banco;
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

        public static void AlterarAdvogado(Modelo.Advogado.ModeloAdvogado advogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Advogado.AlterarAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.IdAdvogado, advogado.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.OAB, advogado.Oab), 
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.CPF, advogado.Cpf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.RG, advogado.Rg),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Nome, advogado.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.IndEstagiario, advogado.IndicadorEstagiario),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.EstadoCivil, advogado.EstadoCivil),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Naturalidade, advogado.Naturalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Nacionalidade, advogado.Nacionalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.Sexo, advogado.Sexo)
                );
                advogado.OrigemDados = OrigemDados.Banco;
                advogado.Sujo = false;
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

        public static IEnumerable<Modelo.Advogado.ModeloAdvogado> ListarAdvogado(Func<Modelo.Advogado.ModeloAdvogado> criacaoAdvogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Advogado.ListarAdvogado);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Advogado.ModeloAdvogado advogado = criacaoAdvogado();
                    advogado.Id = @dados.idAdvogado;
                    advogado.Oab = @dados.oab;
                    advogado.Cpf = @dados.cpf;
                    advogado.Rg = @dados.rg;
                    advogado.Nome = @dados.nome;
                    advogado.IndicadorEstagiario = Convert.ToBoolean(@dados.indEstagiario);
                    Modelo.Comum.EstadoCivil estadoCivil;
                    if (Enum.TryParse(@dados.estadoCivil, out estadoCivil))
                    {
                        advogado.EstadoCivil = estadoCivil;
                    }
                    advogado.Naturalidade = @dados.naturalidade;
                    advogado.Nacionalidade = @dados.nacionalidade;
                    advogado.Sexo = Convert.ToChar(@dados.sexo);
                    advogado.OrigemDados = OrigemDados.Banco;
                    yield return advogado;
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

        public static bool ObterAdvogado(Modelo.Advogado.ModeloAdvogado advogado)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Advogado.ObterAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.IdAdvogado, advogado.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    advogado.Id = @dados.idAdvogado;
                    advogado.Oab = @dados.oab;
                    advogado.Cpf = @dados.cpf;
                    advogado.Rg = @dados.rg;
                    advogado.Nome = @dados.nome;
                    advogado.IndicadorEstagiario = Convert.ToBoolean(@dados.indEstagiario);
                    Modelo.Comum.EstadoCivil estadoCivil;
                    if (Enum.TryParse(@dados.estadoCivil, out estadoCivil))
                    {
                        advogado.EstadoCivil = estadoCivil;
                    }
                    advogado.Naturalidade = @dados.naturalidade;
                    advogado.Nacionalidade = @dados.nacionalidade;
                    advogado.Sexo = Convert.ToChar(@dados.sexo);
                    advogado.OrigemDados = OrigemDados.Banco;
                    advogado.Sujo = false;
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

        public static void RemoverAdvogado(Modelo.Advogado.ModeloAdvogado advogado)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Advogado.RemoverAdvogado,
                    new KeyValuePair<string, object>(Constantes.Parametros.Advogado.IdAdvogado, advogado.Id)
                );
                advogado.Id = null;
                advogado.OrigemDados = OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
