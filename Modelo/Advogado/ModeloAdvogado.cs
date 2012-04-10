using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;
using System.ComponentModel;

namespace Modelo.Advogado
{
    public abstract partial class ModeloAdvogado : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        private int? _id;
        private string _oab;
        private string _cpf;
        private string _rg;
        private string _nome;
        private bool? _indicadorEstagiario;
        private EstadoCivil _estadoCivil;
        private string _naturalidade;
        private string _nacionalidade;
        private char _sexo;        
    }
}
