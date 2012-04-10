using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;
using System.ComponentModel;

namespace Modelo.Cliente
{
    #pragma warning disable 0169
    public abstract partial class ModeloContatoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        int? _id;
        string _tipoContato;
        string _contato;
        string _observacao;
    }
    #pragma warning restore 0169
}
