using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisaoEstrutura;
using Modelo.Cliente;
using Modelo.Processo;
namespace Visao
{
    public partial class ConsultaSimples : Form
    {
        public ConsultaSimples()
        {
            InitializeComponent();

            Action<ModeloCliente> formCliente = new Action<ModeloCliente>((cli) =>
            {
                CadastroCliente form = (this.MdiParent as TelaPrincipal).formCliente;
                if (form == null || form.IsDisposed)
                {
                    form = new CadastroCliente();
                    form.MdiParent = this.MdiParent;
                }
                if (form.Visible)
                {
                    form.BringToFront();
                }
                else
                {
                    form.Show();
                    form.Update();
                }
                form.Link.CarregarCliente(cli);
            });

            Action<ModeloProcesso> formProcesso = new Action<ModeloProcesso>((proc) =>
            {
                CadastroProcessos form = (this.MdiParent as TelaPrincipal).formProcesso;
                if (form == null || form.IsDisposed)
                {
                    form = new CadastroProcessos();
                    form.MdiParent = this.MdiParent;
                }
                if (form.Visible)
                {
                    form.BringToFront();
                }
                else
                {
                    form.Show();
                    form.Update();
                }
                form.Link.CarregarProcesso(proc);
            });

            ConsultaSimplesEstrutura cse = new ConsultaSimplesEstrutura(
                this,
                formCliente,formProcesso,
                rbtConsultaCliente, rbtConsultaProcesso,
                txtCodigoCliente, txtNomeCliente, txtCPFCliente, txtRGCliente,
                txtCodigoProcesso, txtNumeroProcesso, txtCabecaProcesso,
                btnPesquisar, btnFichaCadastral, btnProcuracaoINSS,
                gridPesquisa
                );
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtConsultaCliente.Checked == true)
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void btnSairCons_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ConsultaSimples_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
