using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Dados
{
    public static class ExecucaoProcedure
    {
        public static ObjetoBanco ExecutarQuery(string nomeProcedure, params KeyValuePair<String, Object>[] parametros)
        {
            MySqlConnection conexao = Conexao.ObterConexao();
            conexao.Open();
            MySqlCommand comando = new MySqlCommand(nomeProcedure, conexao);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> parametro in parametros)
            {
                comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
            return new ObjetoBanco(comando.ExecuteReader(System.Data.CommandBehavior.CloseConnection));
        }

        public static void ExecutarNonQuery(string nomeProcedure, params KeyValuePair<String, Object>[] parametros)
        {
            MySqlConnection conexao = null;
            try
            {
                conexao = Conexao.ObterConexao();
                conexao.Open();
                MySqlCommand comando = new MySqlCommand(nomeProcedure, conexao);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                foreach (KeyValuePair<string, object> parametro in parametros)
                {
                    comando.Parameters.AddWithValue(parametro.Key, parametro.Value);
                }
                comando.ExecuteNonQuery();
            }
            finally
            {
                if (conexao != null)
                {
                    conexao.Close();
                }
            }
        }
    }
}
