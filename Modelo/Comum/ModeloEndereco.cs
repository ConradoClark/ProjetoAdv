using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Comum
{
    #pragma warning disable 0169
    public abstract partial class ModeloEndereco : ModeloBase, INotifyPropertyChanged
    {
        private string _logradouro;
        private string _numero;
        private string _complemento;
        private string _bairro;
        private string _cidade;
        private string _uf;
        private string _cep;
    }
    #pragma warning restore 0169
}
