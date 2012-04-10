using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Processo
{
    public abstract partial class ModeloRecorteProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloProcesso _processo;
        DateTime? _dataInclusao;
        Modelo.Usuario.ModeloUsuario _usuarioInclusao;
        string _textoRecorte;
    }
}
