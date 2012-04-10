using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Acao
{
    public abstract partial class ModeloTipoAcao : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        int? _id;
        string _descricao;
    }
}
