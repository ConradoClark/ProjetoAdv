using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.GrupoDiferencial;
using System.ComponentModel;

namespace Modelo.Cliente
{
    public abstract partial class ModeloGrupoDiferencialCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        ModeloGrupoDiferencial _grupoDiferencial;        
    }
}
