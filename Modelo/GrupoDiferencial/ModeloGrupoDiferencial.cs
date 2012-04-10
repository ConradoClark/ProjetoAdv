using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.GrupoDiferencial
{
    public abstract partial class ModeloGrupoDiferencial : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        int? _id;
        string _nome;
    }
}
