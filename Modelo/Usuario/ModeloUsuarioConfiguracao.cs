using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Usuario
{
    public abstract partial class ModeloUsuarioConfiguracao : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        ModeloUsuario _usuario;
        string _pastaFicha;
        string _pastaProcesso;
        string _pastaLog;
        string _pastaExtrato;
        double _margemEsquerda;
        double _margemDireita;
        double _margemSuperior;
        double _margemInferior;
    }
}
