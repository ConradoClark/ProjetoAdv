using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados.Comum
{
    public static class Utils
    {
        public static void InicializarConexao()
        {
            Conexao.ObterConexao();
        }        
    }
}
