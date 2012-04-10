using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;

public class Conexao
{
    public static MySqlConnection ObterConexao()
    {
        string stringConexao = ConfigurationManager.ConnectionStrings[Constantes.Conexao.NomeConexao].ConnectionString;
        MySqlConnection conexao = new MySqlConnection(stringConexao);
        return conexao;
    }
}

