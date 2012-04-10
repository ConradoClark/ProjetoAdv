using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados.Comum;

namespace Estrutura
{
    public static class Sessao
    {
        public delegate void _usuarioAlterado(Usuario valorAntigo, Usuario valorNovo);
        public static event _usuarioAlterado UsuarioAlterado;

        private static Usuario _usuario;
        public static Usuario UsuarioAtual
        {
            get
            {
                return _usuario;
            }
            set {
                if (!Usuario.ReferenceEquals(_usuario,value))
                {
                    if (UsuarioAlterado != null)
                    {
                        UsuarioAlterado(_usuario,value);
                    }
                    _usuario = value;
                }
            }
        }

        public static bool AceitarUsuario(Usuario usuario)
        {
            bool result = Dados.AcessoUsuario.PopularUsuario(usuario);
            UsuarioAtual = usuario;
            return result;
        }

        public static IEnumerable<Usuario> ListarUsuarios()
        {
            try
            {
                return Dados.AcessoUsuario.ListarUsuario(() => (Modelo.Usuario.ModeloUsuario)new Usuario()).Cast<Usuario>();
            }
            catch
            {
                throw;
            }
        }

        public static void InicializarConexao(){
            Utils.InicializarConexao();
        }
    }
}
