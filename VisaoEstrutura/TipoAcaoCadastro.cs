using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estrutura;
using System.Windows.Forms;
using VisaoControles;

namespace VisaoEstrutura
{
    public class TipoAcaoCadastro
    {
        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_Cancelar { get; set; }
        Form Tela { get; set; }
        ListaAssociada<TipoAcao> Tipos { get; set; }

        public delegate void single();
        public event single AoCancelar;

        public TipoAcaoCadastro(
            ButtonBase botaoSalvar,
            ButtonBase botaoCancelar,
            Form tela,
            DataGridView tipoAcaoGridView
            )
        {
            this.Botao_Salvar = botaoSalvar;
            this.Botao_Cancelar = botaoCancelar;
            this.Tela = tela;
            Tipos = TiposAcao.ObterListaAssociada();
            tipoAcaoGridView.AutoGenerateColumns = false;
            tipoAcaoGridView.DataSource = Tipos;
            Tipos.AddingNew += (sender, args) =>
            {
                if (tipoAcaoGridView.Rows.Count == Tipos.Count)
                {
                    Tipos.RemoveAt(Tipos.Count - 1);
                    return;
                } 
            };
            Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);
            AoCancelar += () =>
            {
                tipoAcaoGridView.DataSource = Tipos;
            };
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma cancelar alterações na tabela de Tipos de Ação?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                Tipos = TiposAcao.ObterListaAssociada();
                AoCancelar();
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar tabela de Tipos de Ação?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                foreach (TipoAcao tipo in Tipos.Where((t)=>!String.IsNullOrWhiteSpace(t.Descricao)))
                {
                    if (tipo.OrigemDados == Modelo.Comum.OrigemDados.Local)
                    {
                        tipo.Inserir();
                    }
                    else if (tipo.OrigemDados == Modelo.Comum.OrigemDados.Banco)
                    {
                        tipo.Alterar();
                    }
                }
                bool recarregar = false;
                ListaAssociada<TipoAcao> tiposDeletar = TiposAcao.ObterListaAssociada();
                foreach (TipoAcao tipo in tiposDeletar)
                {
                    if (Tipos.All((grp) => grp.Id != tipo.Id))
                    {
                        if (tipo.QuantidadeProcessos > 0)
                        {
                            DialogResult resp = DialogoAlerta.Mostrar("Confirmação",
                                                String.Format("O tipo de ação {0}, caso seja deletado, será removido dos processos que fazem parte dele. Confirma?", tipo.Descricao),
                                                                    MessageBoxIcon.Question,
                                                                    MessageBoxButtons.YesNo);
                            if (resp == DialogResult.Yes)
                            {
                                tipo.Remover();
                            }
                            else
                            {
                                recarregar = true;
                            }
                        }
                        else
                        {
                            tipo.Remover();
                        }
                    }
                }
                if (recarregar)
                {
                    Botao_Cancelar_Click(null, null);
                }
                DialogoAlerta.Mostrar("Sucesso",
                        "Tipos de ação salvos com sucesso.",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
            }
        }
    }
}
