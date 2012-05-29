using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisaoEstrutura;
using Modelo.Processo;

namespace Visao
{
    public partial class ConsultaProcessoCliente : Form
    {
        public ConsultaProcessoCliente()
        {
            InitializeComponent();

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

            ConsultaProcessoClienteEstrutura cpce = new ConsultaProcessoClienteEstrutura
                (this, formProcesso,lblNavegacao,txtCodigoCliente, txtNomeCliente,
                txtCodigoProcesso, txtNumeroProcesso, txtNumeroOrdem,
                txtVara, txtCabeca, txtTipoAcao, txtReu, txtDataAjuizamento,
                lstResponsaveis,txtObjetivo, txtAndamento, btnPesquisar, btnAnterior,
                btnProximo,btnFichaCadastral);           

        }
    }
}
