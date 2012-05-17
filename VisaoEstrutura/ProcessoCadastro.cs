using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Estrutura;
using Modelo.Comum;
using VisaoControles;
using TXTextControl;
using System.Globalization;

namespace VisaoEstrutura
{
    public class ProcessoCadastro
    {
        TextBoxBase Busca_NumeroReferenciaInterna { get; set; }
        ButtonBase Botao_Busca { get; set; }
        ButtonBase Botao_Adicionar { get; set; }
        ButtonBase Botao_Salvar { get; set; }
        ButtonBase Botao_PDF { get; set; }
        ButtonBase Botao_Fechar { get; set; }
        ButtonBase Botao_Remover { get; set; }
        ButtonBase Botao_Cancelar { get; set; }
        ButtonBase Botao_Limpar { get; set; }
        Form Tela { get; set; }
        Processo ProcessoAtivo { get; set; }

        public delegate void single();
        public delegate bool resp();
        public event resp AntesDeSalvar;
        public event single AoSalvar;
        public event single AoRemover;
        public event single AoAdicionar;
        public event single AoBuscar;
        public event single AoLimpar;
        public event single AoCancelar;

         #region Construtores
        public ProcessoCadastro(Form tela, TextBoxBase buscaNumeroReferenciaInterna,
            ButtonBase botaoBusca, ButtonBase botaoAdicionar,
            ButtonBase botaoSalvar, ButtonBase botaoPDF, ButtonBase botaoFechar,
            ButtonBase botaoRemover, ButtonBase botaoCancelar, ButtonBase botaoLimpar)
        {
            this.Tela = tela;
            this.Busca_NumeroReferenciaInterna = buscaNumeroReferenciaInterna;
            this.Botao_Busca = botaoBusca;
            this.Botao_Adicionar = botaoAdicionar;
            this.Botao_Salvar = botaoSalvar;
            this.Botao_PDF = botaoPDF;
            this.Botao_Fechar = botaoFechar;
            this.Botao_Remover = botaoRemover;
            this.Botao_Cancelar = botaoCancelar;
            this.Botao_Limpar = botaoLimpar;
            Botao_Limpar.Enabled = true;
            Botao_Cancelar.Enabled = false;
            this.ProcessoAtivo = new Processo();
            ProcessoAtivo.IdAlterado += (antigo, novo) => buscaNumeroReferenciaInterna.Text = novo.ToString();
            this.AdicionarLink();
            ProcessoAtivo.OrigemDadosAlterado += (antigo, novo) =>
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
            AoSalvar += () => { };
            AoAdicionar += () => { };
            AoBuscar += () => { };
            AoCancelar += () => { };
            AoLimpar += () => { };
            AoRemover += () => { };
            AntesDeSalvar += () => { return true; };
        }
        #endregion

        #region Link
        public void AdicionarLink()
        {
            Botao_Busca.Click += new EventHandler(Botao_Busca_Click);
            Botao_Adicionar.Click += new EventHandler(Botao_Adicionar_Click);
            Botao_Salvar.Click += new EventHandler(Botao_Salvar_Click);
            Botao_Remover.Click += new EventHandler(Botao_Remover_Click);
            Botao_Cancelar.Click += new EventHandler(Botao_Cancelar_Click);
            Botao_Limpar.Click += new EventHandler(Botao_Limpar_Click);
        }

        void Botao_Limpar_Click(object sender, EventArgs e)
        {
            if (ProcessoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma limpar os dados da tela?",
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ProcessoAtivo.Limpar();
                    AoLimpar();
                }
            }
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            if (ProcessoAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   String.Format("Confirma cancelar edição do processo {0} e restaurar dados originais?"
                           , ProcessoAtivo.Id),
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ProcessoAtivo.Obter();
                    AoCancelar();
                }
            }
        }

        void Botao_Remover_Click(object sender, EventArgs e)
        {
            if (ProcessoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogoAlerta.Mostrar("Operação Inválida", "Remoção não permitida de um item não salvo",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.OK);
            }
            else if (ProcessoAtivo.OrigemDados == OrigemDados.Banco)
            {
                int idProcesso = ProcessoAtivo.Id.Value;
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma excluir o processo {0}? Esta operação é irreversível, e removerá todas as informações pertinentes ao processo."
                            , idProcesso),
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ProcessoAtivo.Remover();
                    AoRemover();
                    ProcessoAtivo.Limpar();
                    DialogoAlerta.Mostrar("Sucesso", String.Format("Remoção efetuada com sucesso do processo {0}.", idProcesso),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                }
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            if (ProcessoAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar novo processo?",
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
                    ProcessoAtivo.Inserir();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Processo {0} incluído com sucesso.", ProcessoAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
            else if (ProcessoAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma salvar dados do processo {0}?", ProcessoAtivo.Id),
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
                    ProcessoAtivo.Salvar();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Processo {0} salvo com sucesso.", ProcessoAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
        }

        void Botao_Adicionar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Informação", "Informações não salvas serão perdidas! Confirma criar novo processo?",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.YesNo);

            if (resposta == DialogResult.No) return;
            ProcessoAtivo.Limpar();
        }

        void Botao_Busca_Click(object sender, EventArgs e)
        {
            string _textoReferenciaInterna = Busca_NumeroReferenciaInterna.Text;
            int _numeroReferenciaInterna = -1;
            if (Int32.TryParse(_textoReferenciaInterna, out _numeroReferenciaInterna))
            {
                int? oldId = ProcessoAtivo.Id;
                ProcessoAtivo.Id = _numeroReferenciaInterna;
                if (!ProcessoAtivo.Obter())
                {
                    ProcessoAtivo.Id = oldId;
                    DialogoAlerta.Mostrar("Informação", "Processo não encontrado!", MessageBoxIcon.Exclamation);
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

        #endregion

        #region Abas
        public void PopularAbaPrincipal(
                        TextBoxBase codigo,
                        TextBoxBase cabeca,
                        TextBoxBase processo,
                        TextBoxBase nroordem,
                        TextBoxBase reu,
                        TextBoxBase forumVaraComarca,
                        ComboBox tipoAcao,
                        MaskedTextBox dataAjuizamento,
                        TextBoxBase alerta,
                        TextControl objetivo)
        {
            //Bindings
            ProcessoAtivo.IdAlterado += (antigo, novo) => codigo.Text = novo.ToString();

            cabeca.TextChanged += (sender, args) => { ProcessoAtivo.Cabeca = cabeca.Text; };
            ProcessoAtivo.CabecaAlterado += (antigo, novo) => cabeca.Text = novo;

            processo.TextChanged += (sender, args) => { ProcessoAtivo.NumeroProcesso = processo.Text; };
            ProcessoAtivo.NumeroProcessoAlterado += (antigo, novo) => processo.Text = novo;

            nroordem.TextChanged += (sender, args) => { ProcessoAtivo.NumeroOrdem = nroordem.Text; };
            ProcessoAtivo.NumeroOrdemAlterado += (antigo, novo) => nroordem.Text = novo;

            reu.TextChanged += (sender, args) => { ProcessoAtivo.Reu = reu.Text; };
            ProcessoAtivo.ReuAlterado += (antigo, novo) => reu.Text = novo;

            forumVaraComarca.TextChanged += (sender, args) => { ProcessoAtivo.Vara = forumVaraComarca.Text; };
            ProcessoAtivo.VaraAlterado += (antigo, novo) => forumVaraComarca.Text = novo;

            tipoAcao.SelectedIndexChanged += (sender, args) => { ProcessoAtivo.TipoAcao = tipoAcao.SelectedItem == null ? null : (TipoAcao) tipoAcao.SelectedItem; };
            ProcessoAtivo.TipoAcaoAlterado += (antigo, novo) => tipoAcao.SelectedItem = novo;

            dataAjuizamento.TextChanged += (sender, args) =>
            {
                DateTime result = default(DateTime);
                if (DateTime.TryParseExact(dataAjuizamento.Text, "ddMMyyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                {
                    ProcessoAtivo.DataAjuizamentoAcao = result;
                }
            };
            ProcessoAtivo.DataAjuizamentoAcaoAlterado += (antigo, novo) => dataAjuizamento.Text = novo.HasValue ? novo.Value.ToString("ddMMyyyy") : null;

            alerta.TextChanged += (sender, args) => { ProcessoAtivo.QuantidadeDiasAlerta = Int32.Parse(alerta.Text); };
            ProcessoAtivo.QuantidadeDiasAlertaAlterado += (antigo, novo) => alerta.Text = novo.ToString();

            AoBuscar += () =>
            {
                CarregarObjetivo(objetivo);
            };

            AoCancelar+= ()=>{
                CarregarObjetivo(objetivo);
            };
            
            AntesDeSalvar += () =>
            {
                if (!String.IsNullOrWhiteSpace(objetivo.Text))
                {
                    string result = String.Empty;
                    objetivo.Save(out result, StringStreamType.HTMLFormat);
                    ProcessoAtivo.Objetivo = result;
                    objetivo.Text = String.Empty;
                    CarregarObjetivo(objetivo);
                }
                return true;
            };
        }

        protected void CarregarObjetivo(TextControl objetivo)
        {
            objetivo.Select(objetivo.Text.Length - 1, 1);
            objetivo.Selection.Load(ProcessoAtivo.Objetivo, StringStreamType.HTMLFormat);
        }
        #endregion
    }
}
