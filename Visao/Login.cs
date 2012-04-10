using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisaoEstrutura;
using VisaoControles;

namespace Visao
{
    public partial class Login : Form
    {
        bool login = false;
        public Login()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            if (Principal.Logar(txtUsuario.Text, txtSenha.Text))
            {
                login = true;
                LightBox.Hide();
                Close();
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogar_Click(txtSenha, new EventArgs());
            }
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!login) Application.Exit();
        }
    }
}
