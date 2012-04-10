using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Usuario
{
    #pragma warning disable 0169
    public abstract partial class ModeloUsuario : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        private int? _id;
        private string _nome;
        private string _login;
        private string _senha;
        private PermissaoUsuario _permissao;
        private StatusUsuario _status;
    }
    #pragma warning restore 0169
}
