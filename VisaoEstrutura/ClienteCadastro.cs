using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Estrutura;
using VisaoControles;
using Modelo.Comum;
using System.Globalization;
using System.Drawing;
using TXTextControl;
namespace VisaoEstrutura
{
    public class ClienteCadastro
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
        Cliente ClienteAtivo { get; set; }

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
        public ClienteCadastro(Form tela, TextBoxBase buscaNumeroReferenciaInterna,
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
            this.ClienteAtivo = new Cliente();
            ClienteAtivo.IdAlterado += (antigo, novo) => buscaNumeroReferenciaInterna.Text = novo.ToString();
            this.AdicionarLink();
            ClienteAtivo.OrigemDadosAlterado += (antigo, novo) =>
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
            AntesDeSalvar += () => {
                foreach (Beneficio ben in ClienteAtivo.Beneficios)
                {
                    if (ben.TipoBeneficio == null)
                    {
                        DialogoAlerta.Mostrar("Erro", 
                            "Selecione o Tipo de Beneficio na Aba Benefícios",
                                                MessageBoxIcon.Error,
                                                MessageBoxButtons.OK);
                        return false;
                    }                    
                }
                foreach (Dependente dep in ClienteAtivo.Dependentes)
                {
                    if (dep.GrauParentesco == null)
                    {
                        DialogoAlerta.Mostrar("Erro",
                                                    "Selecione o Grau de Parentesco na Aba Dependentes",
                                                                        MessageBoxIcon.Error,
                                                                        MessageBoxButtons.OK);
                        return false;
                    }
                }
                return true;
            };
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
            if (ClienteAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma limpar os dados da tela?",
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ClienteAtivo.Limpar();
                    AoLimpar();
                }
            }
        }

        void Botao_Cancelar_Click(object sender, EventArgs e)
        {
            if (ClienteAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                   String.Format("Confirma cancelar edição do cliente {0} e restaurar dados originais?"
                           , ClienteAtivo.Id),
                           MessageBoxIcon.Question,
                           MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ClienteAtivo.Obter();
                    AoCancelar();
                }
            }
        }

        void Botao_Remover_Click(object sender, EventArgs e)
        {
            if (ClienteAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogoAlerta.Mostrar("Operação Inválida", "Remoção não permitida de um item não buscado",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.OK);
            }
            else if (ClienteAtivo.OrigemDados == OrigemDados.Banco)
            {
                int clienteId = ClienteAtivo.Id.Value;
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma excluir o cliente {0}? Esta operação é irreversível, e removerá todas as informações pertinentes ao cliente."
                            , clienteId),
                            MessageBoxIcon.Question,
                            MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    ClienteAtivo.Remover();
                    AoRemover();
                    ClienteAtivo.Limpar();
                    DialogoAlerta.Mostrar("Sucesso", String.Format("Remoção efetuada com sucesso do cliente {0}.", clienteId),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                }
            }
        }

        void Botao_Salvar_Click(object sender, EventArgs e)
        {
            if (ClienteAtivo.OrigemDados == OrigemDados.Local)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    "Confirma salvar novo cliente?",
                                        MessageBoxIcon.Question,
                                        MessageBoxButtons.YesNo);
                if (resposta == DialogResult.Yes)
                {
                    foreach(resp metodo in AntesDeSalvar.GetInvocationList())
                    {
                        if (!metodo())
                        {
                            return;
                        }
                    }
                    ClienteAtivo.Inserir();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Cliente {0} incluído com sucesso.", ClienteAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
            else if (ClienteAtivo.OrigemDados == OrigemDados.Banco)
            {
                DialogResult resposta = DialogoAlerta.Mostrar("Confirmação",
                    String.Format("Confirma salvar dados do cliente {0}?", ClienteAtivo.Id),
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
                    ClienteAtivo.Salvar();
                    DialogoAlerta.Mostrar("Sucesso",
                        String.Format("Cliente {0} salvo com sucesso.", ClienteAtivo.Id),
                            MessageBoxIcon.Information,
                            MessageBoxButtons.OK);
                    AoSalvar();
                }
            }
        }

        void Botao_Adicionar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = DialogoAlerta.Mostrar("Informação", "Informações não salvas serão perdidas! Confirma criar novo cliente?",
                        MessageBoxIcon.Exclamation,
                        MessageBoxButtons.YesNo);

            if (resposta == DialogResult.No) return;
            ClienteAtivo.Limpar();
        }

        void Botao_Busca_Click(object sender, EventArgs e)
        {
            string _textoReferenciaInterna = Busca_NumeroReferenciaInterna.Text;
            int _numeroReferenciaInterna = -1;
            if (Int32.TryParse(_textoReferenciaInterna, out _numeroReferenciaInterna))
            {
                int? oldId = ClienteAtivo.Id;
                ClienteAtivo.Id = _numeroReferenciaInterna;
                if (!ClienteAtivo.Obter())
                {
                    ClienteAtivo.Id = oldId;
                    DialogoAlerta.Mostrar("Informação", "Cliente não encontrado!", MessageBoxIcon.Exclamation);
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
                        TextBoxBase nome,
                        TextBoxBase profissao,
                        TextBoxBase naturalidade,
                        TextBoxBase dataNascimento,
                        CheckBox indFalecimento,
                        TextBoxBase dataFalecimento,
                        ComboBox estadoCivil,
                        TextBoxBase pai,
                        TextBoxBase mae,
                        TextBoxBase endereco,
                        TextBoxBase numero,
                        TextBoxBase complemento,
                        TextBoxBase bairro,
                        TextBoxBase cidade,
                        ComboBox UF,
                        TextBoxBase CEP,
                        MaskedTextBox CPF,
                        MaskedTextBox RG,
                        TextBoxBase orgaoExpedidorRG,
                        TextBoxBase dataEmissaoRG,
                        TextBoxBase tituloEleitor,
                        TextBoxBase zonaTituloEleitor,
                        TextBoxBase secaoTituloEleitor)
        {
            //Bindings
            ClienteAtivo.IdAlterado += (antigo, novo) => codigo.Text = novo.ToString();

            nome.TextChanged += (sender, args) => { ClienteAtivo.Nome = nome.Text; };
            ClienteAtivo.NomeAlterado += (antigo, novo) => nome.Text = novo;

            profissao.TextChanged += (sender, args) => { ClienteAtivo.Profissao = profissao.Text; };
            ClienteAtivo.ProfissaoAlterado += (antigo, novo) => profissao.Text = novo;

            naturalidade.TextChanged += (sender, args) => { ClienteAtivo.Naturalidade = naturalidade.Text; };
            ClienteAtivo.NaturalidadeAlterado += (antigo, novo) => naturalidade.Text = novo;

            dataNascimento.TextChanged += (sender, args) =>
            {
                DateTime result = default(DateTime);
                if (DateTime.TryParseExact(dataNascimento.Text, "ddMMyyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                {
                    ClienteAtivo.DataNascimento = result;
                }
            };
            ClienteAtivo.DataNascimentoAlterado += (antigo, novo) => dataNascimento.Text = novo.HasValue ? novo.Value.ToString("ddMMyyyy") : null;

            dataFalecimento.TextChanged += (sender, args) =>
            {
                DateTime result = default(DateTime);
                if (DateTime.TryParseExact(dataFalecimento.Text, "ddMMyyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                {
                    ClienteAtivo.DataFalecimento = result;
                }
            };
            ClienteAtivo.DataFalecimentoAlterado += (antigo, novo) =>
                {
                    dataFalecimento.Text = novo.HasValue ? novo.Value.ToString("ddMMyyyy") : null;
                };

            indFalecimento.CheckedChanged += (sender, args) =>
            {
                ClienteAtivo.IndFalecido = indFalecimento.Checked;
                dataFalecimento.Enabled = indFalecimento.Checked;
            };
            ClienteAtivo.IndFalecidoAlterado += (antigo, novo) => indFalecimento.Checked = novo;

            estadoCivil.SelectedIndexChanged += (sender, args) => { ClienteAtivo.EstadoCivil = (EstadoCivil)Enum.Parse(typeof(EstadoCivil), (string)estadoCivil.SelectedItem); };
            ClienteAtivo.EstadoCivilAlterado += (antigo, novo) => estadoCivil.SelectedItem = novo;

            pai.TextChanged += (sender, args) => { ClienteAtivo.NomePai = pai.Text; };
            ClienteAtivo.NomePaiAlterado += (antigo, novo) => pai.Text = novo;

            mae.TextChanged += (sender, args) => { ClienteAtivo.NomeMae = mae.Text; };
            ClienteAtivo.NomeMaeAlterado += (antigo, novo) => mae.Text = novo;

            endereco.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Logradouro = endereco.Text; };
            ClienteAtivo.Endereco.LogradouroAlterado += (antigo, novo) => endereco.Text = novo;

            numero.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Numero = numero.Text; };
            ClienteAtivo.Endereco.NumeroAlterado += (antigo, novo) => numero.Text = novo;

            complemento.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Complemento = complemento.Text; };
            ClienteAtivo.Endereco.ComplementoAlterado += (antigo, novo) => complemento.Text = novo;

            bairro.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Bairro = bairro.Text; };
            ClienteAtivo.Endereco.BairroAlterado += (antigo, novo) => bairro.Text = novo;

            cidade.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Cidade = cidade.Text; };
            ClienteAtivo.Endereco.CidadeAlterado += (antigo, novo) => cidade.Text = novo;

            UF.SelectedIndexChanged += (sender, args) => { ClienteAtivo.Endereco.Uf = UF.SelectedItem == null ? "" : UF.SelectedItem.ToString(); };
            ClienteAtivo.Endereco.UfAlterado += (antigo, novo) => UF.SelectedItem = novo;

            CEP.TextChanged += (sender, args) => { ClienteAtivo.Endereco.Cep = CEP.Text; };
            ClienteAtivo.Endereco.CepAlterado += (antigo, novo) => CEP.Text = novo;

            CPF.TextChanged += (sender, args) =>
            {
                ClienteAtivo.Cpf = CPF.Text;
            };
            ClienteAtivo.CpfAlterado += (antigo, novo) => CPF.Text = novo;

            RG.TextChanged += (sender, args) =>
            {
                ClienteAtivo.Rg = RG.Text;
            };
            ClienteAtivo.RgAlterado += (antigo, novo) => RG.Text = novo;

            orgaoExpedidorRG.TextChanged += (sender, args) => { ClienteAtivo.OrgaoExpedidorRG = orgaoExpedidorRG.Text; };
            ClienteAtivo.OrgaoExpedidorRGAlterado += (antigo, novo) => orgaoExpedidorRG.Text = novo;

            dataEmissaoRG.TextChanged += (sender, args) =>
            {
                DateTime result = default(DateTime);
                if (DateTime.TryParseExact(dataEmissaoRG.Text, "ddMMyyyy", CultureInfo.CurrentCulture, DateTimeStyles.AllowWhiteSpaces, out result))
                {
                    ClienteAtivo.DataEmissaoRG = result;
                }
                ;
            };
            ClienteAtivo.DataEmissaoRGAlterado += (antigo, novo) => dataEmissaoRG.Text = novo.HasValue ? novo.Value.ToString("ddMMyyyy") : null;

            tituloEleitor.TextChanged += (sender, args) => { ClienteAtivo.TituloEleitor = tituloEleitor.Text; };
            ClienteAtivo.TituloEleitorAlterado += (antigo, novo) => tituloEleitor.Text = novo;

            zonaTituloEleitor.TextChanged += (sender, args) => { ClienteAtivo.ZonaEleitoral = zonaTituloEleitor.Text; };
            ClienteAtivo.ZonaEleitoralAlterado += (antigo, novo) => zonaTituloEleitor.Text = novo;

            secaoTituloEleitor.TextChanged += (sender, args) => { ClienteAtivo.SecaoEleitoral = secaoTituloEleitor.Text; };
            ClienteAtivo.SecaoEleitoralAlterado += (antigo, novo) => secaoTituloEleitor.Text = novo;
        }

        public void PopularAbaDocumentosAdicionais(
            TextBoxBase ctps1,
            TextBoxBase ctps2,
            TextBoxBase ctps3,
            TextBoxBase ctps4,
            TextBoxBase ctps5,
            TextBoxBase ctpsserie1,
            TextBoxBase ctpsserie2,
            TextBoxBase ctpsserie3,
            TextBoxBase ctpsserie4,
            TextBoxBase ctpsserie5,
            TextBoxBase nit1,
            TextBoxBase nit2,
            TextBoxBase nit3,
            TextBoxBase nit4,
            TextBoxBase pispasep1,
            TextBoxBase pispasep2,
            TextBoxBase pispasep3,
            TextBoxBase pispasep4
            )
        {
            ctps1.TextChanged += (sender, args) => { ClienteAtivo.Ctps1 = ctps1.Text; };
            ClienteAtivo.Ctps1Alterado += (antigo, novo) => ctps1.Text = novo;

            ctps2.TextChanged += (sender, args) => { ClienteAtivo.Ctps2 = ctps2.Text; };
            ClienteAtivo.Ctps2Alterado += (antigo, novo) => ctps2.Text = novo;

            ctps3.TextChanged += (sender, args) => { ClienteAtivo.Ctps3 = ctps3.Text; };
            ClienteAtivo.Ctps3Alterado += (antigo, novo) => ctps3.Text = novo;

            ctps4.TextChanged += (sender, args) => { ClienteAtivo.Ctps4 = ctps4.Text; };
            ClienteAtivo.Ctps4Alterado += (antigo, novo) => ctps4.Text = novo;

            ctps5.TextChanged += (sender, args) => { ClienteAtivo.Ctps5 = ctps5.Text; };
            ClienteAtivo.Ctps5Alterado += (antigo, novo) => ctps5.Text = novo;

            ctpsserie1.TextChanged += (sender, args) => { ClienteAtivo.CtpsSerie1 = ctpsserie1.Text; };
            ClienteAtivo.CtpsSerie1Alterado += (antigo, novo) => ctpsserie1.Text = novo;

            ctpsserie2.TextChanged += (sender, args) => { ClienteAtivo.CtpsSerie2 = ctpsserie2.Text; };
            ClienteAtivo.CtpsSerie2Alterado += (antigo, novo) => ctpsserie2.Text = novo;

            ctpsserie3.TextChanged += (sender, args) => { ClienteAtivo.CtpsSerie3 = ctpsserie3.Text; };
            ClienteAtivo.CtpsSerie3Alterado += (antigo, novo) => ctpsserie3.Text = novo;

            ctpsserie4.TextChanged += (sender, args) => { ClienteAtivo.CtpsSerie4 = ctpsserie4.Text; };
            ClienteAtivo.CtpsSerie4Alterado += (antigo, novo) => ctpsserie4.Text = novo;

            ctpsserie5.TextChanged += (sender, args) => { ClienteAtivo.CtpsSerie5 = ctpsserie5.Text; };
            ClienteAtivo.CtpsSerie5Alterado += (antigo, novo) => ctpsserie5.Text = novo;

            nit1.TextChanged += (sender, args) => { ClienteAtivo.Nit1 = nit1.Text; };
            ClienteAtivo.Nit1Alterado += (antigo, novo) => nit1.Text = novo;

            nit2.TextChanged += (sender, args) => { ClienteAtivo.Nit2 = nit2.Text; };
            ClienteAtivo.Nit2Alterado += (antigo, novo) => nit2.Text = novo;

            nit3.TextChanged += (sender, args) => { ClienteAtivo.Nit3 = nit3.Text; };
            ClienteAtivo.Nit3Alterado += (antigo, novo) => nit3.Text = novo;

            nit4.TextChanged += (sender, args) => { ClienteAtivo.Nit4 = nit4.Text; };
            ClienteAtivo.Nit4Alterado += (antigo, novo) => nit4.Text = novo;

            pispasep1.TextChanged += (sender, args) => { ClienteAtivo.PisPasep1 = pispasep1.Text; };
            ClienteAtivo.PisPasep1Alterado += (antigo, novo) => pispasep1.Text = novo;

            pispasep2.TextChanged += (sender, args) => { ClienteAtivo.PisPasep2 = pispasep2.Text; };
            ClienteAtivo.PisPasep2Alterado += (antigo, novo) => pispasep2.Text = novo;

            pispasep3.TextChanged += (sender, args) => { ClienteAtivo.PisPasep3 = pispasep3.Text; };
            ClienteAtivo.PisPasep3Alterado += (antigo, novo) => pispasep3.Text = novo;

            pispasep4.TextChanged += (sender, args) => { ClienteAtivo.PisPasep4 = pispasep4.Text; };
            ClienteAtivo.PisPasep4Alterado += (antigo, novo) => pispasep4.Text = novo;
        }

        public void PopularAbaContato(
            DataGridView contatoGrid
            )
        {
            contatoGrid.AutoGenerateColumns = false;
            contatoGrid.DataSource = ClienteAtivo.Contatos;
        }

        public void PopularAbaDependente(
            DataGridView dependenteGrid,
            DataGridViewComboBoxColumn parentescoColumn
            )
        {
            dependenteGrid.AutoGenerateColumns = false;
            dependenteGrid.DataSource = ClienteAtivo.Dependentes;
            parentescoColumn.DataSource = GrausParentesco.Lista;
            parentescoColumn.DisplayMember = "Nome";
            parentescoColumn.ValueMember = "Self";
        }

        public void PopularAbaBeneficio(
            DataGridView beneficioGrid,
            DataGridViewComboBoxColumn tipoBeneficioColumn
            )
        {
            beneficioGrid.AutoGenerateColumns = false;
            beneficioGrid.DataSource = ClienteAtivo.Beneficios;
            TiposBeneficio.Atualizar += () => {
                tipoBeneficioColumn.DataSource = TiposBeneficio.Listar().Cast<TipoBeneficio>().ToList();              
            };
            tipoBeneficioColumn.DataSource = TiposBeneficio.Listar().Cast<TipoBeneficio>().ToList();
            tipoBeneficioColumn.DisplayMember = "Descricao";
            tipoBeneficioColumn.ValueMember = "Self";
            beneficioGrid.DataError += new DataGridViewDataErrorEventHandler(beneficioGrid_DataError);
        }

        public void PopularAbaGrupoDiferencial(
            DataGridView grupoGrid,
            DataGridViewComboBoxColumn grupoColumn
            )
        {
            grupoGrid.AutoGenerateColumns = false;
            grupoGrid.DataSource = ClienteAtivo.GruposDiferenciais;
            grupoColumn.DataSource = TiposGrupoDiferencial.ListarPorCliente(ClienteAtivo).ToList();
            grupoColumn.DisplayMember = "Nome";
            grupoColumn.ValueMember = "Grupo";
        }

        public void PopularAbaAtendimento(
            TextControl txtAtendimento,
            TextControl txtAtendimentosRealizados
            )
        {
            AoBuscar += () => { getAtendimentos(txtAtendimentosRealizados); };
            AoAdicionar += () => { getAtendimentos(txtAtendimentosRealizados); };
            AoLimpar += () => { getAtendimentos(txtAtendimentosRealizados); };
            AoCancelar += () => { getAtendimentos(txtAtendimentosRealizados); };
            
            AntesDeSalvar += () =>
            {
                if (!String.IsNullOrWhiteSpace(txtAtendimento.Text))
                {
                    Atendimento atendimento = new Atendimento(ClienteAtivo,Sessao.UsuarioAtual);
                    string result;
                    txtAtendimento.Save(out result, StringStreamType.HTMLFormat);
                    atendimento.AtendimentoExterno = result;
                    atendimento.DataHoraAtendimento = DateTime.Now;
                    ClienteAtivo.Atendimentos.Add(atendimento);
                    txtAtendimento.Text = String.Empty;
                    getAtendimentos(txtAtendimentosRealizados);
                }
                return true;
            };
        }

        void getAtendimentos(TextControl txtAtendimentosRealizados)
        {    
            txtAtendimentosRealizados.Text = "";
            ClienteAtivo.Atendimentos.OrderByDescending((at)=>at.DataHoraAtendimento).ToList().ForEach((ate) =>    
            {                
                if (ate.DataHoraAtendimento.HasValue)
                {
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);            

                    string append = ate.DataHoraAtendimento.Value.ToString("dd/MM/yyyy hh:mm:ss");
                    
                    txtAtendimentosRealizados.Selection.Load(String.Concat("<p style='color:midnightblue;'>",append,"</p>"),StringStreamType.HTMLFormat);
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);                    

                    append = ate.AtendimentoExterno;
                    txtAtendimentosRealizados.Selection.Load(append, StringStreamType.HTMLFormat);
                    txtAtendimentosRealizados.Select(txtAtendimentosRealizados.Text.Length - 1, 1);
                    
                }
            });
        }

        void allowRows(DataGridView grid)
        {
            grid.AllowUserToAddRows = true;
        }

        void beneficioGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
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
            else {
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
