using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;
using System.ComponentModel;

namespace Modelo.Cliente
{
    #pragma warning disable 0169
    public abstract partial class ModeloCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {        
        private int? _id;
        private string _nome;
        [NomeDisplay("Nome do Pai")]
        private string _nomePai;
        [NomeDisplay("Nome da Mãe")]
        private string _nomeMae;
        [NomeDisplay("Data de Nascimento")]
        private DateTime? _dataNascimento;
        [NomeDisplay("Profissão")]
        private string _profissao;
        [Browsable(false)]
        [NomeDisplay("Tipo de Pessoa")]        
        private char? _tipoPessoa;
        [NomeDisplay("CPF")]
        private string _cpf;
        [NomeDisplay("CNPJ")]
        private string _cnpj;
        [NomeDisplay("RG")]
        private string _rg;
        [NomeDisplay("Data de Emissão do RG")]
        private DateTime? _dataEmissaoRG;
        [NomeDisplay("Órgão Expedidor do RG")]
        private string _orgaoExpedidorRG;
        [NomeDisplay("Estado Civil")]
        private EstadoCivil _estadoCivil;
        private string _nacionalidade;
        private ModeloEndereco _endereco;
        [NomeDisplay("Título de Eleitor")]
        private string _tituloEleitor;
        [NomeDisplay("Zona Eleitoral")]
        private string _zonaEleitoral;
        [NomeDisplay("Seção Eleitoral")]
        private string _secaoEleitoral;
        private string _ctps1;
        private string _ctps2;
        private string _ctps3;
        private string _ctps4;
        private string _ctps5;
        [Browsable(false)]
        private bool _indGrupo;
        [Browsable(false)]
        private bool _indCliente;
        [Browsable(false)]
        private bool _indContato;
        [Browsable(false)]
        private bool _indDependente;
        [Browsable(false)]
        private bool _indPendencia;
        [Browsable(false)]
        [NomeDisplay("Falecido?")]
        private bool _indFalecido;
        [NomeDisplay("Data do Falecimento")]
        private DateTime? _dataFalecimento;
        private string _naturalidade;
        private string _pisPasep1;
        private string _pisPasep2;
        private string _pisPasep3;
        private string _pisPasep4;
        private string _nit1;
        private string _nit2;
        private string _nit3;
        private string _nit4;
        private string _ctpsSerie1;
        private string _ctpsSerie2;
        private string _ctpsSerie3;
        private string _ctpsSerie4;
        private string _ctpsSerie5;
        [NomeDisplay("Indicado Por?")]
        private string _nomeClienteIndicacao;
        [Browsable(false)]
        private string _atendimento;
    }
    #pragma warning restore 0169
}
