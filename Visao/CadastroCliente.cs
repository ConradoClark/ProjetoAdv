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
    public partial class CadastroCliente : Form
    {
        public ClienteCadastro Link { get; set; }
        public CadastroCliente()
        {
            InitializeComponent();

            beneficiosGridView.ContextMenuStrip = menuGridView;
            contatoGridView.ContextMenuStrip = menuGridView;
            dependenteGridView.ContextMenuStrip = menuGridView;
            grupoGridView.ContextMenuStrip = menuGridView;

            beneficiosGridView.CellMouseDown += GridView_CellMouseDown;
            contatoGridView.CellMouseDown += GridView_CellMouseDown;
            dependenteGridView.CellMouseDown += GridView_CellMouseDown;
            grupoGridView.CellMouseDown += GridView_CellMouseDown;

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

            Link = new ClienteCadastro(
                this,
                codigoBusca,
                btnPesquisar,
                btnNovo,
                btnSalvar,
                btnPDF,
                btnSair,
                btnExcluir,
                btnCancelar,
                btnLimpar
                );

            Link.PopularAbaPrincipal(
                codigo,
                nome,
                profissao,
                naturalidade,
                dataNascimento,
                indFalecido,
                dataFalecimento,
                estadoCivil,
                nomePai,
                nomeMae,
                endereco,
                enderecoNumero,
                enderecoComplemento,
                enderecoBairro,
                enderecoCidade,
                enderecoUF,
                enderecoCEP,
                cpf,
                rg,
                orgaoExpedidorRG,
                dataEmissaoRG,
                tituloEleitor,
                zonaEleitoral,
                secaoEleitoral
                );

            Link.PopularAbaDocumentosAdicionais(
                    ctps1, ctps2, ctps3, ctps4, ctps5,
                    ctpsSerie1, ctpsSerie2, ctpsSerie3, ctpsSerie4, ctpsSerie5,
                    nit1, nit2, nit3, nit4,
                    pispasep1, pispasep2, pispasep3, pispasep4
                );

            Link.PopularAbaContato(contatoGridView);

            Link.PopularAbaDependente(dependenteGridView,
                depParentesco);

            Link.PopularAbaBeneficio(beneficiosGridView,
                benTipoBeneficio);

            Link.PopularAbaGrupoDiferencial(grupoGridView,
                grpNome);

            Link.PopularAbaAtendimento(
                txtAtendimento,
                txtAtendimentoRealizado);

            estadoCivil.Items.AddRange(
                Enum.GetNames(typeof(EstadoCivil))
                );

            colorComboBox1.SelectedIndexChanged += (sender, args) =>
            {
                txtAtendimento.Selection.ForeColor = colorComboBox1.SelectedColor;
            };

            txtAtendimento.Changed += (sender, args) =>
            {
                colorComboBox1.SelectedColor = txtAtendimento.Selection.ForeColor;                
            };            
        }

        public CadastroCliente(Modelo.Cliente.ModeloCliente cliente) : this()
        {
            Link.CarregarCliente(cliente);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //TX Text Control Init Workaround
            tabControl1.SelectTab(tabPage7);
            tabControl1.SelectTab(tabPage1);
            this.WindowState = FormWindowState.Maximized;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

