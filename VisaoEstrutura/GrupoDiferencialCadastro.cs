using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estrutura;
using System.Windows.Forms;
using VisaoControles;

namespace VisaoEstrutura
{
    public class GrupoDiferencialCadastro
    {
        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_Cancelar { get; set; }
        Form Tela { get; set; }
        ListaAssociada<TipoGrupoDiferencial> Grupos { get; set; }

        public delegate void single();
        public event single AoCancelar;

        public GrupoDiferencialCadastro(
            ButtonBase botaoSalvar,
            ButtonBase botaoCancelar,
            Form tela,
            DataGridView grupoGridView
            )
        {
            this.Botao_Salvar = botaoSalvar;
            this.Botao_Cancelar = botaoCancelar;
            this.Tela = tela;
            Grupos = TiposGrupoDiferencial.ObterListaAssociada();
            grupoGridView.AutoGenerateColumns = false;
            grupoGridView.DataSource = Grupos;
            Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);

            Grupos.AddingNew += (sender, args) =>
            {
                if (grupoGridView.Rows.Count == Grupos.Count)
                {
                    Grupos.RemoveAt(Grupos.Count - 1);
                    return;
                }
            };

            AoCancelar += () =>
            {
                grupoGridView.DataSource = Grupos;
            };
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma cancelar alterações na tabela de Grupos Diferenciais?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                Grupos = TiposGrupoDiferencial.ObterListaAssociada();
                AoCancelar();
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar tabela de Grupos Diferenciais?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                foreach (TipoGrupoDiferencial grupo in Grupos.Where((g)=>!String.IsNullOrWhiteSpace(g.Nome)))
                {
                    if (grupo.OrigemDados == Modelo.Comum.OrigemDados.Local)
                    {
                        grupo.Inserir();
                    }
                    else if (grupo.OrigemDados == Modelo.Comum.OrigemDados.Banco)
                    {
                        grupo.Alterar();
                    }
                }
                bool recarregar = false;
                ListaAssociada<TipoGrupoDiferencial> gruposDeletar = TiposGrupoDiferencial.ObterListaAssociada();
                foreach (TipoGrupoDiferencial tipo in gruposDeletar)
                {
                    if (Grupos.All((grp) => grp.Id != tipo.Id))
                    {
                        if (tipo.QuantidadeClientes > 0)
                        {
                            DialogResult resp = DialogoAlerta.Mostrar("Confirmação",
                                                String.Format("O grupo {0}, caso seja deletado, será removido dos clientes que fazem parte dele. Confirma?", tipo.Nome),
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
                        "Grupos salvos com sucesso.",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
            }
        }
    }
}
