using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Estrutura;
using System.Windows.Forms;
using VisaoControles;

namespace VisaoEstrutura
{
    public class BeneficioCadastro
    {
        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_Cancelar { get; set; }
        Form Tela { get; set; }
        ListaAssociada<TipoBeneficio> Beneficios { get; set; }

        public delegate void single();
        public event single AoCancelar;
        public event single AoSalvar;

        public BeneficioCadastro(
            ButtonBase botaoSalvar,
            ButtonBase botaoCancelar,
            Form tela,
            DataGridView beneficioGridView
            )
        {
            this.Botao_Salvar = botaoSalvar;
            this.Botao_Cancelar = botaoCancelar;
            this.Tela = tela;
            Beneficios = TiposBeneficio.ObterListaAssociada();
            beneficioGridView.AutoGenerateColumns = false;
            beneficioGridView.DataSource = Beneficios;
            Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);

            Beneficios.AddingNew += (sender, args) =>
            {
                if (beneficioGridView.Rows.Count == Beneficios.Count)
                {
                    Beneficios.RemoveAt(Beneficios.Count - 1);
                    return;
                }
            };

            AoCancelar += () =>
            {
                beneficioGridView.DataSource = Beneficios;
            };
            AoSalvar += () =>
            {
                TiposBeneficio.DispararAtualizacao();
            };
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma cancelar alterações na tabela de Tipos de Benefício?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                Beneficios = TiposBeneficio.ObterListaAssociada();
                AoCancelar();
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            bool recarregar = false;
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar tabela de Tipos de Benefício?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                foreach (TipoBeneficio tipo in Beneficios.Where((b)=>!String.IsNullOrWhiteSpace(b.Descricao)))
                {
                    if (tipo.OrigemDados == Modelo.Comum.OrigemDados.Local)
                    {
                        if (!String.IsNullOrWhiteSpace(tipo.Descricao))
                        {
                            tipo.Inserir();
                        }
                        
                    }
                    else if (tipo.OrigemDados == Modelo.Comum.OrigemDados.Banco)
                    {
                        if (!String.IsNullOrWhiteSpace(tipo.Descricao))
                        {
                            tipo.Alterar();
                        }
                        else
                        {
                            tipo.Obter();
                            DialogResult resp = DialogoAlerta.Mostrar("Alerta",
                                                                            String.Format("O tipo de benefício {0}, não pode ser alterado para um texto vazio", tipo.Descricao),
                                                                                                MessageBoxIcon.Information,
                                                                                                MessageBoxButtons.OK);
                            recarregar = true;
                        }
                    }
                }
                
                ListaAssociada<TipoBeneficio> tiposDeletar = TiposBeneficio.ObterListaAssociada();
                foreach (TipoBeneficio tipo in tiposDeletar)
                {
                    if (Beneficios.All((grp) => grp.Id != tipo.Id))
                    {
                        if (tipo.QuantidadeClientes > 0)
                        {
                            DialogResult resp = DialogoAlerta.Mostrar("Confirmação",
                                                String.Format("O tipo de benefício {0}, caso seja deletado, será removido dos clientes que possuem algum benefício deste tipo. Confirma?", tipo.Descricao),
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
                        "Tipos de Beneficios salvos com sucesso.",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                AoSalvar();
            }
        }
    }
}
