using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Beneficio
{
    public abstract partial class ModeloTipoBeneficio : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        int? _id;
        string _descricao;
    }
}
