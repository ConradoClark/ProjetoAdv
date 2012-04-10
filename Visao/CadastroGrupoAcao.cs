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
    public partial class CadastroGrupoAcao : Form
    {
        public CadastroGrupoAcao()
        {
            InitializeComponent();

            TipoAcaoCadastro tac = new TipoAcaoCadastro(
                btnSalvar,
                btnCancelar,
                this,
                tipoAcaoGridView);

            tipoAcaoGridView.CellMouseDown += GridView_CellMouseDown;
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

        private void CadastroGrupoAcao_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
