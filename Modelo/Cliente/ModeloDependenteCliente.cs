using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;
using System.ComponentModel;

namespace Modelo.Cliente
{
    public abstract partial class ModeloDependenteCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        int? _id;
        ModeloGrauParentesco _grauParentesco;
        string _nome;
        bool? _indCadastro;
        string _observacao;
    }
}
