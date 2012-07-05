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

        public void CarregarProcesso(Modelo.Processo.ModeloProcesso processo)
        {
            ProcessoAtivo.Id = processo.Id;
            ProcessoAtivo.Obter();
            AoBuscar();
        }

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
            AoAdicionar();
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
                    AoBuscar();
                }
                else
                {
                    AoBuscar();
                }
            }
            else
            {
                DialogoAlerta.Mostrar("Erro", "O código digitado está em um formato inválido", MessageBoxIcon.Error);
                AoBuscar();
            }
        }

        #endregion

        #region Abas

        public void PopularAbaAndamento(
                    TextControl txtAndamento,
                    TextControl txtRegistroAndamento
                    )
        {
            AoBuscar += () => { GetRegistroAndamento(txtRegistroAndamento); };
            AoAdicionar += () => { GetRegistroAndamento(txtRegistroAndamento); };
            AoLimpar += () => { GetRegistroAndamento(txtRegistroAndamento); };
            AoCancelar += () => { GetRegistroAndamento(txtRegistroAndamento); };

            AntesDeSalvar += () =>
            {
                if (!String.IsNullOrWhiteSpace(txtAndamento.Text))
                {
                    Recorte recorte = new Recorte(ProcessoAtivo, Sessao.UsuarioAtual);
                    string result;
                    txtAndamento.Save(out result, StringStreamType.HTMLFormat);
                    recorte.TextoRecorte = result;
                    recorte.DataInclusao = DateTime.Now;
                    ProcessoAtivo.Recortes.Add(recorte);
                    txtAndamento.Text = String.Empty;
                    GetRegistroAndamento(txtRegistroAndamento);
                }
                return true;
            };
        }

        void GetRegistroAndamento(TextControl txtAtendimentosRealizados)
        {
            txtAtendimentosRealizados.Text = "";
            ProcessoAtivo.Recortes.OrderByDescending((re) => re.DataInclusao).ToList().ForEach((re) =>
            {
                if (re.DataInclusao.HasValue)
                {
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);
                    string append = re.DataInclusao.Value.ToString("dd/MM/yyyy hh:mm:ss") + " - " + re.UsuarioInclusao.Nome;

                    txtAtendimentosRealizados.Selection.Load(String.Concat("<p style='color:midnightblue;'>", append, "</p>"), StringStreamType.HTMLFormat);
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);

                    append = re.TextoRecorte;
                    txtAtendimentosRealizados.Selection.Load(append, StringStreamType.HTMLFormat);
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);
                }
            });
        }

        public void PopularAbaAutores(
            TextBoxBase txtPesquisa,
            ButtonBase btnPesquisar,
            ButtonBase btnAdicionarAutor,
            ButtonBase btnRemoverAutor,
            ButtonBase btnDefineCabeca,
            DataGridView gridPesquisaClientes,
            DataGridView gridAutoresProcesso)
        {

            gridAutoresProcesso.AutoGenerateColumns = false;
            gridAutoresProcesso.DataSource = ProcessoAtivo.Clientes;
            btnPesquisar.Click += (sender, args) =>
            {
                gridPesquisaClientes.AutoGenerateColumns = false;
                gridPesquisaClientes.DataSource = Clientes.PesquisarFullText(txtPesquisa.Text).ToList();
            };
            btnAdicionarAutor.Click += (sender, args) =>
            {
                foreach(DataGridViewRow row in gridPesquisaClientes.SelectedRows)
                {
                    if (row.DataBoundItem != null)
                    {
                        Cliente cliente = (Cliente)row.DataBoundItem;
                        if (ProcessoAtivo.Clientes.Count((cli) => cli.Id == cliente.Id)==0) { 
                            ProcessoAtivo.Clientes.Add(cliente);
                        }
                    }
                }
            };

            btnRemoverAutor.Click += (sender, args) =>
            {
                foreach (DataGridViewRow row in gridAutoresProcesso.SelectedRows)
                {
                    if (row.DataBoundItem != null)
                    {
                        Cliente cliente = (Cliente)row.DataBoundItem;
                        ProcessoAtivo.Clientes.Remove(cliente);
                    }
                }
            };

            btnDefineCabeca.Click += (sender, args) =>
            {
                if (gridAutoresProcesso.SelectedRows.Count != 1)
                {
                    DialogoAlerta.Mostrar("Erro", "Selecione um e apenas um autor na lista para ser definido como cabeça do processo",
                           MessageBoxIcon.Error,
                           MessageBoxButtons.OK);
                }
                else
                {
                    Cliente cliente = (Cliente)gridAutoresProcesso.SelectedRows[0].DataBoundItem;
                    DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Deseja definir o cliente {0} - {1} como cabeça do processo?", cliente.Id,cliente.Nome),
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
                    if (resposta == DialogResult.Yes) { 
                        ProcessoAtivo.Cabeca = cliente;
                    }
                }
            };
        }

        public void PopularAbaObservacao(
            TextControl observacao
            )
        {
            AoBuscar += () =>
            {
                CarregarObservacoes(observacao);
            };

            AoCancelar += () =>
            {
                CarregarObservacoes(observacao);
            };

            AntesDeSalvar += () =>
            {
                if (!String.IsNullOrWhiteSpace(observacao.Text))
                {
                    string result = String.Empty;
                    observacao.Save(out result, StringStreamType.HTMLFormat);
                    ProcessoAtivo.Observacao = result;
                    CarregarObservacoes(observacao);
                }
                return true;
            };
        }

        public void PopularAbaResponsavel(
            DataGridView responsavelGrid,
            DataGridViewComboBoxColumn advogadoColumn
            )
        {
            responsavelGrid.AutoGenerateColumns = false;
            responsavelGrid.DataSource = ProcessoAtivo.Responsaveis;
            advogadoColumn.DataSource = ProcessoAdvogado.ListarPorProcesso(ProcessoAtivo).ToList();            
            advogadoColumn.DisplayMember = "NomeAdvogado";
            advogadoColumn.ValueMember = "Advogado";
            responsavelGrid.DataError += responsavelGrid_DataError;
        }

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

            //Ao trocar o cabeça do processo, altera a referencia.
            ProcessoAtivo.CabecaAlterado += (antigo, novo) =>
            {
                cabeca.Text = novo.Nome;
            };

            //Ao Buscar, só altera os dados do cabeça.
            ProcessoAtivo.Cabeca.NomeAlterado += (antigo, novo) =>
            {
                cabeca.Text = novo;
            };

            processo.TextChanged += (sender, args) => { ProcessoAtivo.NumeroProcesso = processo.Text; };
            ProcessoAtivo.NumeroProcessoAlterado += (antigo, novo) => processo.Text = novo;

            nroordem.TextChanged += (sender, args) => { ProcessoAtivo.NumeroOrdem = nroordem.Text; };
            ProcessoAtivo.NumeroOrdemAlterado += (antigo, novo) => nroordem.Text = novo;

            reu.TextChanged += (sender, args) => { ProcessoAtivo.Reu = reu.Text; };
            ProcessoAtivo.ReuAlterado += (antigo, novo) => reu.Text = novo;

            forumVaraComarca.TextChanged += (sender, args) => { ProcessoAtivo.Vara = forumVaraComarca.Text; };
            ProcessoAtivo.VaraAlterado += (antigo, novo) => forumVaraComarca.Text = novo;

            tipoAcao.Items.AddRange(TiposAcao.Listar().ToArray());
            tipoAcao.SelectedIndexChanged += (sender, args) => { ProcessoAtivo.TipoAcao = tipoAcao.SelectedItem == null ? null : (TipoAcao)tipoAcao.SelectedItem; };
            ProcessoAtivo.TipoAcao.IdAlterado += (antigo, novo) =>
            {
                foreach (TipoAcao tpAcao in tipoAcao.Items)
                {
                    if (tpAcao.Id == novo)
                    {
                        tipoAcao.SelectedItem = tpAcao;
                        break;
                    }
                }
            };

            dataAjuizamento.TextChanged += (sender, args) =>
            {
                DateTime result = default(DateTime);
                if (DateTime.TryParseExact(dataAjuizamento.Text, "dd/MM/yyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                {
                    ProcessoAtivo.DataAjuizamentoAcao = result;
                }
            };
            ProcessoAtivo.DataAjuizamentoAcaoAlterado += (antigo, novo) => dataAjuizamento.Text = novo.HasValue ? novo.Value.ToString("ddMMyyyy") : null;

            alerta.TextChanged += (sender, args) => {
                int valor = 0;
                if (Int32.TryParse(alerta.Text, out valor))
                {
                    ProcessoAtivo.QuantidadeDiasAlerta = valor;
                }
                else if (String.IsNullOrWhiteSpace(alerta.Text))
                {
                    ProcessoAtivo.QuantidadeDiasAlerta = null;
                }
                else
                {
                    alerta.Text = ProcessoAtivo.QuantidadeDiasAlerta.HasValue ? ProcessoAtivo.QuantidadeDiasAlerta.Value.ToString() : String.Empty;
                }
            };
            ProcessoAtivo.QuantidadeDiasAlertaAlterado += (antigo, novo) => alerta.Text = novo.ToString();

            AoAdicionar += () => CarregarObjetivo(objetivo);
            AoLimpar += () => CarregarObjetivo(objetivo);
            AoBuscar += () =>
            {
                CarregarObjetivo(objetivo);
            };

            AoCancelar += () =>
            {
                CarregarObjetivo(objetivo);
            };

            AntesDeSalvar += () =>
            {
                if (ProcessoAtivo.Responsaveis.Distinct().Count() != ProcessoAtivo.Responsaveis.Count)
                {
                    DialogoAlerta.Mostrar("Erro", "Não é possível salvar um processo com 2 advogados iguais como responsáveis.",
                           MessageBoxIcon.Error,
                           MessageBoxButtons.OK);
                    return false;
                }
                if (!String.IsNullOrWhiteSpace(objetivo.Text))
                {                    
                    string result = String.Empty;
                    objetivo.Save(out result, StringStreamType.HTMLFormat);
                    ProcessoAtivo.Objetivo = result;
                    CarregarObjetivo(objetivo);
                }
                return true;
            };
        }

        protected void CarregarObjetivo(TextControl objetivo)
        {
            if (ProcessoAtivo.Objetivo == null)
            {
                objetivo.Text = String.Empty;
                return;
            }
            objetivo.Text = String.Empty;
            objetivo.Select(objetivo.Text.Length - 1, 1);
            objetivo.Selection.Load(ProcessoAtivo.Objetivo, StringStreamType.HTMLFormat);
        }

        protected void CarregarObservacoes(TextControl observacao)
        {
            observacao.Text = String.Empty;
            if (ProcessoAtivo.Observacao == null) return;            
            observacao.Select(observacao.Text.Length - 1, 1);
            observacao.Selection.Load(ProcessoAtivo.Observacao, StringStreamType.HTMLFormat);
        }

        void responsavelGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView view = sender as DataGridView;
            if (view.CurrentCell is DataGridViewComboBoxCell)
            {
                if (view.CurrentCell.RowIndex != e.RowIndex && view.CurrentCell.ColumnIndex != e.ColumnIndex)
                {
                    view.CurrentCell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    view.BeginEdit(true);
                    view.CurrentCell.Selected = true;

                    DialogoAlerta.Mostrar("Erro", "Um ou mais campos obtidos de outras tabelas (Grupos Diferenciais, Tipos de Benefícios, etc) foram deletados, verifique as informações do cliente antes de salvar.",
                                                            MessageBoxIcon.Error,
                                                            MessageBoxButtons.OK);
                }
            }
            else
            {
                if (view.CurrentCell.RowIndex != e.RowIndex && view.CurrentCell.ColumnIndex != e.ColumnIndex)
                {
                    view.CurrentCell = view.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    view.CurrentCell.Selected = true;
                    view.BeginEdit(true);
                }
                else
                {
                    DialogoAlerta.Mostrar("Erro", "Dados digitados inválidos para o campo, verifique o preenchimento.",
                        MessageBoxIcon.Error,
                        MessageBoxButtons.OK);
                }
            }
        }

        #endregion
    }
}
