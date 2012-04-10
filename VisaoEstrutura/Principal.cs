﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estrutura;
using VisaoControles;
using System.Windows.Forms;

namespace VisaoEstrutura
{
    public class Principal
    {
        public static void InicializarConexao()
        {
            Sessao.InicializarConexao();
        }

        public static bool Logar(string usuario, string senha)
        {
            Usuario user = new Usuario();
            user.Login = usuario;
            user.Senha = senha;
            if (Sessao.AceitarUsuario(user))
            {
                DialogoAlerta.Mostrar("Login", "Bem-vindo(a), " +user.Nome, MessageBoxIcon.Information, MessageBoxButtons.OK);
                return true;
            }
            DialogoAlerta.Mostrar("Erro", "Login e/ou senha inválidos!", MessageBoxIcon.Error, MessageBoxButtons.OK);
            return false;
        }
    }
}
