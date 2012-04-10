using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Processo;
using System.ComponentModel;

namespace Modelo.Advogado
{
    public abstract partial class ModeloAdvogadoProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloAdvogado _advogado;
        ModeloProcesso _processo;
    }
}
