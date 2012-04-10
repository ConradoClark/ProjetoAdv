using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estrutura;
using System.Windows.Forms;
using VisaoControles;
using TXTextControl;

namespace VisaoEstrutura
{
    public class PendenciaCadastro
    {
        ButtonBase Botao_Adicionar { get; set; }
        ButtonBase Botao_Limpar { get; set; }

        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_Cancelar { get; set; }

        TextBoxBase Texto_Pendencia { get; set; }

        Form Tela { get; set; }
        ListaAssociada<Pendencia> ListaPendencias { get; set; }

        public delegate void single();
        public event single AoCancelar;

        public PendenciaCadastro(
            ButtonBase botaoAdicionar,
            ButtonBase botaoLimpar,
            ButtonBase botaoSalvar,
            ButtonBase botaoCancelar,
            Form tela,
            DataGridView pendenciaGridView,
            TextBoxBase txtPendencia
            )
        {
            this.Botao_Adicionar = botaoAdicionar;
            this.Botao_Limpar = botaoLimpar;
            this.Botao_Cancelar = botaoCancelar;
            this.Botao_Salvar = botaoSalvar;
            this.Tela = tela;
            this.Texto_Pendencia = txtPendencia;
            this.ListaPendencias = Pendencias.ListarAssociado();

            pendenciaGridView.AutoGenerateColumns = false;
            pendenciaGridView.DataSource = ListaPendencias;

            ListaPendencias.AddingNew += (sender, args) =>
            {
                if (pendenciaGridView.Rows.Count == ListaPendencias.Count)
                {
                    ListaPendencias.RemoveAt(ListaPendencias.Count - 1);
                    return;
                }
            };

            this.Botao_Adicionar.Click += new EventHandler(Botao_Adicionar_Click);
            this.Botao_Limpar.Click += new EventHandler(Botao_Limpar_Click);
            this.Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            this.Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);            

            AoCancelar += () =>
            {
                pendenciaGridView.DataSource = ListaPendencias;
            };
        }

        void Botao_Limpar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma limpar o editor de texto?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                Texto_Pendencia.Text = "";
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar tabela de Pendencias?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                ListaAssociada<Pendencia> pendenciasDeletar = Pendencias.ListarAssociado();
                foreach (Pendencia pendencia in pendenciasDeletar)
                {
                    if (ListaPendencias.All((pen) => pen.Id != pendencia.Id))
                    {
                        pendencia.Remover();
                    }
                }
                DialogoAlerta.Mostrar("Sucesso",
                        "Pendencias salvas com sucesso.",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
            }
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma cancelar alterações na tabela de Pendencias?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                this.ListaPendencias = Pendencias.ListarAssociado();
                AoCancelar();
            }
        }

        void Botao_Adicionar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma adicionar a Pendência descrita abaixo?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                Pendencia pend = new Pendencia()
                {
                    Descricao = Texto_Pendencia.Text
                };
                pend.Inserir();
                ListaPendencias.Add(pend);
            }
        }
    }
}
