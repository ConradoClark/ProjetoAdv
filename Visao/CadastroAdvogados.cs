using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VisaoEstrutura;
using Modelo.Comum;

namespace Visao
{
    public partial class CadastroAdvogados : Form
    {
        public CadastroAdvogados()
        {
            InitializeComponent();

            estadoCivil.Items.AddRange(
                Enum.GetNames(typeof(EstadoCivil))
            );
            estadoCivil.SelectedIndex = 0;

            cmbSexo.Items.AddRange(
                    new char[] {'M','F' }.Cast<Object>().ToArray()
            );

            AdvogadoCadastro ac = new AdvogadoCadastro(this,
                codigoBusca,
                btnBuscar,
                btnAdicionar,
                btnSalvar,
                btnRemover,
                btnCancelar,
                btnLimpar,
                btnSalvarGrid,
                btnCancelarGrid,
                advogadosGridView);

            ac.PopularFormAdvogados(txtCodigoAdv,
                txtOAB,
                chkEstagiario,
               maskCPF,
               maskRG,
               txtNomeAdv,
               estadoCivil,
               txtNaturalidade,
               nacionalidade,
               cmbSexo);

            advogadosGridView.CellMouseDown += GridView_CellMouseDown;

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CadastroAdvogados_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

    }
}
