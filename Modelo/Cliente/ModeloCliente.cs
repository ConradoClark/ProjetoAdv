﻿using System;
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
        private string _nomePai;
        private string _nomeMae;
        private DateTime? _dataNascimento;
        private string _profissao;
        private string _cpf;
        private string _rg;
        private DateTime? _dataEmissaoRG;
        private string _orgaoExpedidorRG;
        private EstadoCivil _estadoCivil;
        private string _nacionalidade;
        private ModeloEndereco _endereco;
        private string _tituloEleitor;
        private string _zonaEleitoral;
        private string _secaoEleitoral;
        private string _ctps1;
        private string _ctps2;
        private string _ctps3;
        private string _ctps4;
        private string _ctps5;
        private bool _indGrupo;
        private bool _indCliente;
        private bool _indContato;
        private bool _indDependente;
        private bool _indPendencia;
        private bool _indFalecido;
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
        private string _nomeClienteIndicacao;
    }
    #pragma warning restore 0169
}