using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Beneficio;
using System.ComponentModel;

namespace Modelo.Cliente
{
    public abstract partial class ModeloBeneficioCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        int? _id;
        ModeloTipoBeneficio _tipoBeneficio;
        string _numero;
        string _tempoContribuicao;
        decimal? _somaSalariosContribuicao;
        DateTime? _inicioBeneficio;
        decimal? _rendaMensalInicial;
        decimal? _divisor;
        decimal? _fatorPrevidenciario;
        decimal? _salarioBeneficio;
        decimal? _coeficienteCalculo;
        decimal? _media;
    }
}
