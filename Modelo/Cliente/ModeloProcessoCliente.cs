using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Processo;
using System.ComponentModel;

namespace Modelo.Cliente
{
    public abstract partial class ModeloProcessoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        ModeloProcesso _processo;
    }
}
