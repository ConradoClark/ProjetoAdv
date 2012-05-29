using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TXTextControl;
using Estrutura;
using VisaoControles;

namespace VisaoEstrutura
{
    public class ConsultaProcessoClienteEstrutura
    {

        Cliente ClientePesquisa { get; set; }
        int indiceProcessoAtual = 0;
        int IndiceProcessoAtual
        {
            get
            {
                return indiceProcessoAtual;
            }
            set
            {
                if (value < ListaProcessos.Count && value >= 0)
                {
                    indiceProcessoAtual = value;
                    CarregarProcesso();
                }                
            }
        }
        List<Processo> ListaProcessos { get; set; }
        Action CarregarProcesso { get; set; }
        Action LimparCampos { get; set; }

        public ConsultaProcessoClienteEstrutura(
            Form tela,
            Action<Modelo.Processo.ModeloProcesso> fichaProcesso,
            Label navegacao,
            NumberTextBox codigoCliente,
            TextBoxBase nomeCliente,
            TextBoxBase codigoProcesso,
            TextBoxBase numeroProcesso,
            TextBoxBase numeroOrdemProcesso,
            TextBoxBase varaProcesso,
            TextBoxBase cabecaProcesso,
            TextBoxBase tipoAcaoProcesso,
            TextBoxBase reuProcesso,
            TextBoxBase dataAjuizamentoProcesso,
            ListBox responsaveisProcesso,
            TextControl objetivoProcesso,
            TextControl andamentoProcesso,
            ButtonBase botaoPesquisar,
            ButtonBase botaoAnterior,
            ButtonBase botaoProximo,
            ButtonBase botaoFichaCompleta
            )
        {
            ListaProcessos = new List<Processo>();
            ClientePesquisa = new Cliente();

            codigoCliente.GotFocus += (sender, args) => tela.BeginInvoke(new Action(() => codigoCliente.SelectAll()));
            codigoCliente.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Value")
                {
                    ClientePesquisa.Id = codigoCliente.Value;
                }
            };
            ClientePesquisa.IdAlterado += (antigo, novo) => codigoCliente.Value = novo;

            nomeCliente.TextChanged += (sender, args) => ClientePesquisa.Nome = nomeCliente.Text;
            ClientePesquisa.NomeAlterado += (antigo, novo) => nomeCliente.Text = novo;

            botaoPesquisar.Click += new EventHandler(botaoPesquisar_Click);

            botaoAnterior.Click += (sender,args) => IndiceProcessoAtual--;
            botaoProximo.Click += (sender, args) => IndiceProcessoAtual++;

            botaoFichaCompleta.Click+= (sender,args)=>{
                Processo ProcessoAtual = ListaProcessos[IndiceProcessoAtual];
                if (ProcessoAtual == null) return;

                fichaProcesso(ListaProcessos[IndiceProcessoAtual]);
            };

            CarregarProcesso = new Action(() =>
            {
                if (ListaProcessos.Count > IndiceProcessoAtual)
                {
                    Processo ProcessoAtual = ListaProcessos[IndiceProcessoAtual];
                    if (ProcessoAtual == null) return;
                    ProcessoAtual.ObterColecoes();
                    codigoProcesso.Text = ProcessoAtual.Id.ToString();
                    cabecaProcesso.Text = ProcessoAtual.Cabeca.Nome;
                    numeroProcesso.Text = ProcessoAtual.NumeroProcesso;
                    numeroOrdemProcesso.Text = ProcessoAtual.NumeroOrdem;
                    reuProcesso.Text = ProcessoAtual.Reu;
                    varaProcesso.Text = ProcessoAtual.Vara;
                    var tiposAcao = TiposAcao.Listar();
                    foreach (TipoAcao tpAcao in tiposAcao)
                    {
                        if (tpAcao.Id == ProcessoAtual.TipoAcao.Id)
                        {
                            tipoAcaoProcesso.Text = tpAcao.Descricao;
                            break;
                        }
                    }
                    dataAjuizamentoProcesso.Text = ProcessoAtual.DataAjuizamentoAcao.HasValue ? ProcessoAtual.DataAjuizamentoAcao.Value.ToString("ddMMyyyy") : null;
                    responsaveisProcesso.Items.Clear();
                    responsaveisProcesso.Items.AddRange(ProcessoAtual.Responsaveis.Select((r)=>r.Advogado).ToArray());
                    CarregarObjetivo(ProcessoAtual, objetivoProcesso);
                    GetRegistroAndamento(ProcessoAtual, andamentoProcesso);
                }
                if (ListaProcessos.Count > 0)
                {
                    navegacao.Text = String.Format("{0} de {1}", IndiceProcessoAtual + 1, ListaProcessos.Count);
                }
                else
                {
                    navegacao.Text = "0 de 0";
                }
            });

            LimparCampos = new Action(() =>
            {
                codigoProcesso.Text = String.Empty;
                cabecaProcesso.Text = String.Empty;
                numeroProcesso.Text = String.Empty;
                numeroOrdemProcesso.Text = String.Empty;
                reuProcesso.Text = String.Empty;
                varaProcesso.Text = String.Empty;
                tipoAcaoProcesso.Text = String.Empty;
                dataAjuizamentoProcesso.Text = String.Empty;
            });
        }

        protected void CarregarObjetivo(Processo ProcessoAtivo, TextControl objetivo)
        {
            if (ProcessoAtivo.Objetivo == null) return;
            objetivo.Text = String.Empty;
            objetivo.Select(objetivo.Text.Length - 1, 1);
            objetivo.Selection.Load(ProcessoAtivo.Objetivo, StringStreamType.HTMLFormat);
        }

        void GetRegistroAndamento(Processo ProcessoAtivo, TextControl txtAtendimentosRealizados)
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

        void botaoPesquisar_Click(object sender, EventArgs e)
        {
            var pesquisa = Clientes.Pesquisar(ClientePesquisa).ToList();
            if (pesquisa.Count > 1)
            {
                var kvp = DialogoConfirmarBusca.Mostrar("Confirmação", "Foi encontrado mais de um cliente com o critério especificado. Favor selecionar o cliente desejado", pesquisa);
                if (kvp.Key == DialogResult.OK)
                {
                    if (kvp.Value != null)
                    {
                        LimparCampos();
                        ListaProcessos.Clear();
                        ListaProcessos.AddRange(Processos.PesquisarPorAutor(kvp.Value).Cast<Processo>());
                        IndiceProcessoAtual = 0;
                    }
                }
            }
            else if (pesquisa.Count==1)
            {
                LimparCampos();
                ListaProcessos.Clear();
                ListaProcessos.AddRange(Processos.PesquisarPorAutor(pesquisa[0]).Cast<Processo>());
                IndiceProcessoAtual = 0;
            }
            if (ListaProcessos.Count == 0)
            {
                DialogoAlerta.Mostrar("Informação",
                    "O cliente especificado não possui processos cadastrados",MessageBoxIcon.Information,MessageBoxButtons.OK);
            }
        }
    }
}
