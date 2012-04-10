using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoUsuario
    {
        public static bool PopularUsuario(Modelo.Usuario.ModeloUsuario usuario)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                Constantes.Procedures.Usuario.ObterUsuario,
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.IdUsuario,null),
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Login, usuario.Login),
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Senha, usuario.Senha));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    usuario.Id = (int?)@dados.idUsuario;
                    usuario.Nome = @dados.nome;
                    usuario.Permissao = (Modelo.Usuario.PermissaoUsuario)@dados.permissao;
                    usuario.Status = (Modelo.Usuario.StatusUsuario)@dados.status;
                    usuario.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    return true;
                }
                else return false;
                
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

        public static void ObterUsuario(Modelo.Usuario.ModeloUsuario usuario)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                Constantes.Procedures.Usuario.ObterUsuario,
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.IdUsuario, usuario.Id),
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Login,null),
                new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Senha, null));

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                usuario.Id = (int?)@dados.idUsuario;
                usuario.Nome = @dados.nome;
                usuario.Permissao = (Modelo.Usuario.PermissaoUsuario)@dados.permissao;
                usuario.Status = (Modelo.Usuario.StatusUsuario)@dados.status;
                usuario.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void InserirUsuario(Modelo.Usuario.ModeloUsuario usuario)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Usuario.InserirUsuario,
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Nome, usuario.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Login, usuario.Login),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Senha, usuario.Senha),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Permissao, (Modelo.Usuario.PermissaoUsuario)usuario.Permissao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Status, (Modelo.Usuario.StatusUsuario)usuario.Status)
                );

                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                usuario.Id = (int?) @dados.idUsuario;
                usuario.OrigemDados = Modelo.Comum.OrigemDados.Banco;
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

        public static void AlterarUsuario(Modelo.Usuario.ModeloUsuario usuario)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Usuario.AlterarUsuario,
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.IdUsuario, usuario.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Nome, usuario.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Login, usuario.Login),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Senha, usuario.Senha),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Permissao, (Modelo.Usuario.PermissaoUsuario)usuario.Permissao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.Status, (Modelo.Usuario.StatusUsuario)usuario.Status)
                );
                usuario.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                usuario.Sujo = false;
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

        public static IEnumerable<Modelo.Usuario.ModeloUsuario> ListarUsuario(Func<Modelo.Usuario.ModeloUsuario> criacaoUsuario)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Usuario.ListarUsuario);

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Usuario.ModeloUsuario usuario = criacaoUsuario();
                    usuario.Id = (int?) @dados.idUsuario;
                    usuario.Nome = @dados.nome;
                    usuario.Login = @dados.login;
                    usuario.Senha = @dados.senha;
                    usuario.Permissao = (Modelo.Usuario.PermissaoUsuario)@dados.permissao;
                    usuario.Status = (Modelo.Usuario.StatusUsuario)@dados.status;
                    usuario.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return usuario;
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

        public static void RemoverUsuario(Modelo.Usuario.ModeloUsuario usuario)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Usuario.RemoverUsuario,
                    new KeyValuePair<string, object>(Constantes.Parametros.Usuario.IdUsuario, usuario.Id)
                );
                usuario.Id = null;
                usuario.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
