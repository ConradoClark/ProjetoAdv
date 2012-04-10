using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Estrutura;
using Modelo.Comum;
using VisaoControles;

namespace VisaoEstrutura
{
    public class AdvogadoCadastro
    {
        TextBoxBase Busca_NumeroReferenciaInterna { get; set; }
        ButtonBase Botao_Busca { get; set; }
        ButtonBase Botao_Adicionar { get; set; }
        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_Remover { get; set; }
        ButtonBase Botao_Cancelar { get; set; }
        ButtonBase Botao_Limpar { get; set; }

        ButtonBase Botao_SalvarGrid { get; set; }
        ButtonBase Botao_CancelarGrid { get; set; }

        Form Tela { get; set; }
        Advogado AdvogadoAtivo { get; set; }

        ListaAssociada<Advogado> ListaAdvogados { get; set; }

        public delegate void single();
        public delegate bool resp();
        public event resp AntesDeSalvar;
        public event single AoSalvar;
        public event single AoRemover;
        public event single AoAdicionar;
        public event single AoBuscar;
        public event single AoLimpar;
        public event single AoCancelar;

        public AdvogadoCadastro(Form tela, TextBoxBase buscaNumeroReferenciaInterna,
            ButtonBase botaoBusca, ButtonBase botaoAdicionar,
            ButtonBase botaoSalvar, ButtonBase botaoRemover,
            ButtonBase botaoCancelar, ButtonBase botaoLimpar,
            ButtonBase botaoSalvarGrid, ButtonBase botaoCancelarGrid,
            DataGridView advogadoGridView)
        {
            this.Tela = tela;
            this.Busca_NumeroReferenciaInterna = buscaNumeroReferenciaInterna;
            this.Botao_Busca = botaoBusca;
            this.Botao_Adicionar = botaoAdicionar;
            this.Botao_Salvar = botaoSalvar;
            this.Botao_Remover = botaoRemover;
            this.Botao_Cancelar = botaoCancelar;
            this.Botao_Limpar = botaoLimpar;
            this.Botao_SalvarGrid = botaoSalvarGrid;
            this.Botao_CancelarGrid = botaoCancelarGrid;

            ListaAdvogados = Advogados.ObterListaAssociada();
            advogadoGridView.AutoGenerateColumns = false;
            advogadoGridView.DataSource = ListaAdvogados;
            advogadoGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advogadoGridView.MultiSelect = false;
            advogadoGridView.SelectionChanged += (sender, args) =>
            {
                if (advogadoGridView.SelectedRows.Count > 0)
                {
                    if (AdvogadoAtivo.Sujo)
                    {
                        DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                                           "Clicar em um advogado na lista cancelará a edição do advogado atual. Confirma?",
                                                   MessageBoxIcon.Question,
                                                   MessageBoxButtons.YesNo);
                        if (resposta == DialogResult.No)
                        {
                            return;
                        }
                    }
                    AdvogadoAtivo.Id = ListaAdvogados[advogadoGridView.SelectedRows[0].Index].Id;
                    AdvogadoAtivo.Obter();
                }
            };

            advogadoGridView.CellClick += (sender, args) =>
            {
                if (args.RowIndex == -1) return;
                if (AdvogadoAtivo.Sujo)
                {
                    DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                                       "Clicar em um advogado na lista cancelará a edição do advogado atual. Confirma?",
                                               MessageBoxIcon.Question,
                                               MessageBoxButtons.YesNo);
                    if (resposta == DialogResult.No)
                    {
                        return;
                    }
                }
                AdvogadoAtivo.Id = ListaAdvogados[args.RowIndex].Id;
                AdvogadoAtivo.Obter();
            };

            Botao_Limpar.Enabled = true;
            Botao_Cancelar.Enabled = false;
            this.AdvogadoAtivo = new Advogado();
            AdvogadoAtivo.IdAlterado += (antigo, novo) => buscaNumeroReferenciaInterna.Text = novo.ToString();
            this.AdicionarLink();
            AdvogadoAtivo.OrigemDadosAlterado += (antigo, novo) =>
            {
                if (novo == OrigemDados.Local)
                {
                    Botao_Limpar.Enabled = true;
                    Botao_Cancelar.Enabled = false;
                }
                else if (novo == OrigemDados.Banco)
                {
                    Botao_Limpar.Enabled = false;
                    Botao_Cancelar.Enabled = true;
                }
            };
            AoSalvar += () =>
            {
                ListaAdvogados = Advogados.ObterListaAssociada();
                advogadoGridView.DataSource = ListaAdvogados;
            };
            AoAdicionar += () => { };
            AoBuscar += () => { };
            AoCancelar += () => { };
            AoLimpar += () => { };
            AoRemover += () =>
            {
                ListaAdvogados = Advogados.ObterListaAssociada();
                advogadoGridView.DataSource = ListaAdvogados;
            };
            AntesDeSalvar += () => { return true; };
        }

        public void AdicionarLink()
        {
            Botao_Busca.Click += new EventHandler(Botao_Busca_Click);
            Botao_Adicionar.Click += new EventHandler(Botao_Adicionar_Click);
            Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            Botao_Remover.Click += new EventHandler(Botao_Remover_Click);
            Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);
            Botao_Limpar.Click += new EventHandler(Botao_Limpar_Click);
            Botao_SalvarGrid.Click += new EventHandler(Botao_SalvarGrid_Click);
            Botao_CancelarGrid.Click += new EventHandler(Botao_CancelarGrid_Click);
        }

        public void PopularFormAdvogados(
            TextBoxBase codigo,
            TextBoxBase oab,
            CheckBox estagiario,
            MaskedTextBox cpf,
            MaskedTextBox rg,
            TextBoxBase nome,
            ComboBox estadoCivil,
            TextBoxBase naturalidade,
            TextBoxBase nacionalidade,
            ComboBox sexo
            )
        {

            //Bindings
            AdvogadoAtivo.IdAlterado += (antigo, novo) => codigo.Text = novo.ToString();

            oab.TextChanged += (sender, args) => { AdvogadoAtivo.Oab = oab.Text; };
            AdvogadoAtivo.OabAlterado += (antigo, novo) => oab.Text = novo;

            estagiario.CheckedChanged += (sender, args) => { AdvogadoAtivo.IndicadorEstagiario = estagiario.Checked; };
            AdvogadoAtivo.IndicadorEstagiarioAlterado += (antigo, novo) => estagiario.Checked = novo.GetValueOrDefault(false);

            cpf.TextChanged += (sender, args) =>
            {
                AdvogadoAtivo.Cpf = cpf.Text;
            };
            AdvogadoAtivo.CpfAlterado += (antigo, novo) => cpf.Text = novo;

            rg.TextChanged += (sender, args) =>
            {
                AdvogadoAtivo.Rg = rg.Text;
            };
            AdvogadoAtivo.RgAlterado += (antigo, novo) => rg.Text = novo;

            nome.TextChanged += (sender, args) => { AdvogadoAtivo.Nome = nome.Text; };
            AdvogadoAtivo.NomeAlterado += (antigo, novo) => nome.Text = novo;

            estadoCivil.SelectedIndexChanged += (sender, args) => { AdvogadoAtivo.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), (string)estadoCivil.SelectedItem); };
            AdvogadoAtivo.EstadoCivilAlterado += (antigo, novo) =>
                estadoCivil.SelectedItem = novo.ToString();

            naturalidade.TextChanged += (sender, args) => { AdvogadoAtivo.Naturalidade = naturalidade.Text; };
            AdvogadoAtivo.NaturalidadeAlterado += (antigo, novo) => naturalidade.Text = novo;

            nacionalidade.TextChanged += (sender, args) => { AdvogadoAtivo.Nacionalidade = nacionalidade.Text; };
            AdvogadoAtivo.NacionalidadeAlterado += (antigo, novo) => nacionalidade.Text = novo;

            sexo.SelectedIndexChanged += (sender, args) => { 
                AdvogadoAtivo.Sexo = (char) sexo.SelectedItem;
                Console.WriteLine(AdvogadoAtivo.Sexo);
            };
            AdvogadoAtivo.SexoAlterado += (antigo, novo) =>
                sexo.SelectedItem = novo;

        }

        void Botao_CancelarGrid_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   "Confirma cancelar alterações na tabela de Advogados?",
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                ListaAdvogados = Advogados.ObterListaAssociada();
                AoCancelar();
            }
        }

        void Botao_SalvarGrid_Click(object sender, EventArgs e)
        {
            bool recarregar = false;
            DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar tabela de Advogados?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                foreach (Advogado adv in ListaAdvogados.Where((a) => !String.IsNullOrWhiteSpace(a.Nome)))
                {
                    if (adv.OrigemDados == Modelo.Comum.OrigemDados.Local)
                    {
                        if (!String.IsNullOrWhiteSpace(adv.Nome))
                        {
                            adv.Inserir();
                        }

                    }
                    else if (adv.OrigemDados == Modelo.Comum.OrigemDados.Banco)
                    {
                        adv.Salvar();
                    }
                }

                ListaAssociada<Advogado> advogadosDeletar = Advogados.ObterListaAssociada();
                foreach (Advogado adv in advogadosDeletar)
                {
                    if (ListaAdvogados.All((ad) => ad.Id != adv.Id))
                    {
                        if (adv.QuantidadeProcessos > 0)
                        {
                            DialogResult resp = DialogoAlerta.Mostrar("Confirmação",
                                                String.Format("O advogado {0}, caso seja deletado, será desvinculado dos processos que o pertencem. Confirma?", adv.Nome),
                                                                    MessageBoxIcon.Question,
                                                                    MessageBoxButtons.YesNo);
                            if (resp == DialogResult.Yes)
                            {
                                adv.Remover();
                            }
                            else
                            {
                                recarregar = true;
                            }
                        }
                        else
                        {
                            adv.Remover();
                        }
                    }
                }
                if (recarregar)
                {
                    Botao_Cancelar_Click(null, null);
                }
                DialogoAlerta.Mostrar("Sucesso",
                        "Advogados salvos com sucesso.",
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                AoSalvar();
            }
        }

        void Botao_Limpar_Click(object sender, EventArgs e)
        {
            if (AdvogadoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma limpar os dados da tela?",
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    AdvogadoAtivo.Limpar();
                    AoLimpar();
                }
            }
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            if (AdvogadoAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   String.Format("Confirma cancelar edição do advogado {0} e restaurar dados originais?"
                           , AdvogadoAtivo.Id),
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    AdvogadoAtivo.Obter();
                    AoCancelar();
                }
            }
        }

        void Botao_Remover_Click(object sender, EventArgs e)
        {
            if (AdvogadoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogoAlerta.Mostrar("Operação Inválida", "Remoção não permitida de um item não buscado",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.OK);
            }
            else if (AdvogadoAtivo.OrigemDados == OrigemDados.Banco)
            {
                int advogadoId = AdvogadoAtivo.Id.Value;
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma excluir o advogado {0}? Esta operação é irreversível, e removerá todas as informações pertinentes ao advogado."
                            , advogadoId),
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    AdvogadoAtivo.Remover();
                    AoRemover();
                    AdvogadoAtivo.Limpar();
                    DialogoAlerta.Mostrar("Sucesso", String.Format("Remoção efetuada com sucesso do advogado {0}.", advogadoId),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                }
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            if (AdvogadoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar novo advogado?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    foreach (resp metodo in AntesDeSalvar.GetInvocationList())
                    {
                        if (!metodo())
                        {
                            return;
                        }
                    }
                    AdvogadoAtivo.Inserir();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Advogado {0} incluído com sucesso.", AdvogadoAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
            else if (AdvogadoAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma salvar dados do advogado {0}?", AdvogadoAtivo.Id),
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    foreach (resp metodo in AntesDeSalvar.GetInvocationList())
                    {
                        if (!metodo())
                        {
                            return;
                        }
                    }
                    AdvogadoAtivo.Salvar();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Advogado {0} salvo com sucesso.", AdvogadoAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
        }

        void Botao_Adicionar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Informação", "Informações não salvas serão perdidas! Confirma criar novo advogado?",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.YesNo);

            if (resposta == DialogResult.No) return;
            AdvogadoAtivo.Limpar();
        }

        void Botao_Busca_Click(object sender, EventArgs e)
        {
            string _textoReferenciaInterna = Busca_NumeroReferenciaInterna.Text;
            int _numeroReferenciaInterna = -1;
            if (Int32.TryParse(_textoReferenciaInterna, out _numeroReferenciaInterna))
            {
                int? oldId = AdvogadoAtivo.Id;
                AdvogadoAtivo.Id = _numeroReferenciaInterna;
                if (!AdvogadoAtivo.Obter())
                {
                    AdvogadoAtivo.Id = oldId;
                    DialogoAlerta.Mostrar("Informação", "Advogado não encontrado!", MessageBoxIcon.Exclamation);
                }
                else
                {
                    AoBuscar();
                }
            }
            else
            {
                DialogoAlerta.Mostrar("Erro", "O código digitado está em um formato inválido", MessageBoxIcon.Error);
            }
        }
    }
}
