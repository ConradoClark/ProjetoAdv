using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Estrutura;
using VisaoControles;
using Modelo.Cliente;
using Modelo.Processo;
namespace VisaoEstrutura
{
    public class ConsultaSimplesEstrutura
    {
        enum eTipoConsulta
        {
            Cliente,
            Processo
        }

        Form Tela { get; set; }
        Action<ModeloCliente> TelaCliente { get; set; }
        Action<ModeloProcesso> TelaProcesso { get; set; }
        eTipoConsulta TipoConsulta { get; set; }
        Cliente ClientePesquisa { get; set; }
        Processo ProcessoPesquisa { get; set; }
        DataGridView GridPesquisa { get; set; }

        Cliente ClienteSelecionado { get; set; }
        Processo ProcessoSelecionado { get; set; }

        public ConsultaSimplesEstrutura(
            Form tela,
            Action<ModeloCliente> telaCliente,
            Action<ModeloProcesso> telaProcesso,
            RadioButton opcaoPesquisaCliente,
            RadioButton opcaoPesquisaProcesso,
            NumberTextBox codigoCliente,
            TextBoxBase nomeCliente,
            TextBoxBase cpfCliente,
            TextBoxBase rgCliente,
            NumberTextBox codigoProcesso,
            TextBoxBase numeroProcesso,
            TextBoxBase cabecaProcesso,
            ButtonBase botaoPesquisar,
            ButtonBase botaoFichaCadastral,
            ButtonBase botaoProcuracaoINSS,
            DataGridView gridPesquisa
            )
        {
            ClientePesquisa = new Cliente();
            ProcessoPesquisa = new Processo();
            GridPesquisa = gridPesquisa;
            Tela = tela;
            TelaCliente = telaCliente;
            TelaProcesso = telaProcesso;

            opcaoPesquisaCliente.CheckedChanged += (sender, args) =>
            {
                GridPesquisa.DataSource = null;
                TipoConsulta = opcaoPesquisaCliente.Checked ? eTipoConsulta.Cliente : eTipoConsulta.Processo;
            };
            opcaoPesquisaProcesso.CheckedChanged += (sender, args) =>
            {
                GridPesquisa.DataSource = null;
                TipoConsulta = opcaoPesquisaProcesso.Checked ? eTipoConsulta.Processo : eTipoConsulta.Cliente;
            };

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

            cpfCliente.TextChanged += (sender, args) => ClientePesquisa.Cpf = cpfCliente.Text;
            ClientePesquisa.CpfAlterado += (antigo, novo) => cpfCliente.Text = novo;

            rgCliente.TextChanged += (sender, args) => ClientePesquisa.Rg = rgCliente.Text;
            ClientePesquisa.RgAlterado += (antigo, novo) => rgCliente.Text = novo;

            codigoProcesso.GotFocus += (sender, args) => tela.BeginInvoke(new Action(() => codigoProcesso.SelectAll()));
            codigoProcesso.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "Value")
                {
                    ProcessoPesquisa.Id = codigoProcesso.Value;
                }
            };
            ProcessoPesquisa.IdAlterado += (antigo, novo) => codigoProcesso.Text = novo.ToString();

            numeroProcesso.TextChanged += (sender, args) => ProcessoPesquisa.NumeroProcesso = numeroProcesso.Text;
            ProcessoPesquisa.NumeroProcessoAlterado += (antigo, novo) => numeroProcesso.Text = novo;

            cabecaProcesso.TextChanged += (sender, args) => ProcessoPesquisa.Cabeca.Nome = cabecaProcesso.Text;
            ProcessoPesquisa.Cabeca.NomeAlterado += (antigo, novo) => cabecaProcesso.Text = novo;

            botaoPesquisar.Click += new EventHandler(botaoPesquisar_Click);
            botaoFichaCadastral.Click += new EventHandler(botaoFichaCadastral_Click);
        }

        void botaoFichaCadastral_Click(object sender, EventArgs e)
        {
            if (GridPesquisa.SelectedRows.Count <= 0)
            {
                switch (TipoConsulta)
                {
                    case eTipoConsulta.Cliente:
                        DialogoAlerta.Mostrar("Erro",
                                "Selecione um Cliente para ir para a ficha cadastral",
                                MessageBoxIcon.Error,
                                MessageBoxButtons.OK);
                        break;
                    case eTipoConsulta.Processo:
                        DialogoAlerta.Mostrar("Erro",
                                "Selecione um Processo para ir para a ficha cadastral",
                                MessageBoxIcon.Error,
                                MessageBoxButtons.OK);
                        break;
                }
            }
            switch (TipoConsulta)
            {
                case eTipoConsulta.Cliente:
                    TelaCliente((Cliente)GridPesquisa.SelectedRows[0].DataBoundItem);
                    break;
                case eTipoConsulta.Processo:
                    TelaProcesso((Processo)GridPesquisa.SelectedRows[0].DataBoundItem);
                    break;
            }
        }

        private void botaoPesquisar_Click(object sender, EventArgs e)
        {
            switch (TipoConsulta)
            {
                case eTipoConsulta.Cliente:
                    GridPesquisa.DataSource = Clientes.Pesquisar(ClientePesquisa).ToList();
                    GridPesquisa.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
                case eTipoConsulta.Processo:
                    GridPesquisa.DataSource = Processos.Pesquisar(ProcessoPesquisa).ToList();
                    GridPesquisa.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                    break;
            }
        }
    }
}
