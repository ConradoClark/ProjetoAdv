using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Usuario;
using System.ComponentModel;

namespace Modelo.Cliente
{
    public abstract partial class ModeloAtendimentoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloCliente _cliente;
        DateTime? _dataHoraAtendimento;
        ModeloUsuario _usuarioAtendimento;
        string _atendimentoInterno;
        string _atendimentoExterno;
    }
}
