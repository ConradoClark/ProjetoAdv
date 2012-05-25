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
        public ProcessoCadastro Link { get; set; }
        public CadastroProcessos()
        {
            InitializeComponent();
            Link = new ProcessoCadastro(
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

            Link.PopularAbaPrincipal(
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

            Link.PopularAbaResponsavel(responsavelGridView, gridColumnAdvogado);

            Link.PopularAbaObservacao(txtObservacao);

            Link.PopularAbaAutores(txtPesquisaClienAut, btnPesquisaAutores, btnAdicionaAutor, btnExcluiAutor, btnDefineCabeca, gridPesquisaClientes, gridAutoresProcesso);

            Link.PopularAbaAndamento(txtAndamento, txtAndamentoRealizado);

            colorComboBox.SelectedIndexChanged += (sender, args) =>
            {
                txtObjetivo.Selection.ForeColor = colorComboBox.SelectedColor;
            };

            txtObjetivo.Changed += (sender, args) =>
            {
                colorComboBox.SelectedColor = txtObjetivo.Selection.ForeColor;
            };

            obsColorComboBox.SelectedIndexChanged += (sender, args) =>
            {
                txtObservacao.Selection.ForeColor = obsColorComboBox.SelectedColor;
            };

            txtObservacao.Changed += (sender, args) =>
            {
                obsColorComboBox.SelectedColor = txtObservacao.Selection.ForeColor;
            };

            responsavelGridView.CellMouseDown += GridView_CellMouseDown;

            removerLinhaContextButton.Click += (sender, args) =>
            {
                ToolStripMenuItem ts = (ToolStripMenuItem)sender;
                ContextMenuStrip cms = ts.Owner as ContextMenuStrip;
                DataGridView dg = cms.SourceControl as DataGridView;
                List<int> list = new List<int>();
                foreach (DataGridViewCell a in dg.SelectedCells)
                {
                    list.Add(a.RowIndex);
                }
                List<int> result = list.Distinct().ToList();
                result.Sort();
                result.Reverse();
                result.ForEach((n) =>
                {
                    DataGridViewRow row = dg.Rows[n];
                    if (!row.IsNewRow)
                    {
                        dg.Rows.Remove(row);
                    }
                });
            };
        }

        void GridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                DataGridView dg = sender as DataGridView;
                foreach (DataGridViewCell cell in dg.Rows[e.RowIndex].Cells)
                {
                    if (cell.Selected)
                    {
                        return;
                    }
                }
                foreach (DataGridViewRow r in dg.Rows)
                {
                    if ((System.Windows.Forms.Control.ModifierKeys & Keys.Shift) != Keys.Shift)
                    {
                        r.Selected = false;
                    }
                    if (r.Index == e.RowIndex)
                    {
                        r.Selected = true;
                    }
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadastroProcessos_Load(object sender, EventArgs e)
        {
            //TX Text Control Init Workaround
            tabControl1.SelectTab(tabPage3);
            tabControl1.SelectTab(tabPage5);
            tabControl1.SelectTab(tabPage1);
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
