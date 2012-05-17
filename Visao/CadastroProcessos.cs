using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisaoEstrutura;

namespace Visao
{
    public partial class CadastroProcessos : Form
    {
        public CadastroProcessos()
        {
            InitializeComponent();
            ProcessoCadastro pc = new ProcessoCadastro(
                this,                
                codigoBusca,
                btnPesquisar,
                btnNovo,
                btnSalvar,
                btnPDF,
                btnSair,
                btnExcluir,
                btnCancelar,
                btnLimpar);

            pc.PopularAbaPrincipal(
                codigo,
                txtCabecaProc,
                txtNroProc,
                txtNroOrdem,
                txtReuPro,
                txtForumProc,
                cbTipoAcao,
                txtDataProc,
                txtAlertaProc,
                txtObjetivo
                );

            colorComboBox.SelectedIndexChanged += (sender, args) =>
            {
                txtObjetivo.Selection.ForeColor = colorComboBox.SelectedColor;
            };

            txtObjetivo.Changed += (sender, args) =>
            {
                colorComboBox.SelectedColor = txtObjetivo.Selection.ForeColor;
            }; 
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadastroProcessos_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
