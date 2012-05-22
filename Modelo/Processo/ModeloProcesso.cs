using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Acao;
using Modelo.Advogado;
using System.ComponentModel;

namespace Modelo.Processo
{
    public abstract partial class ModeloProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        int? _id;
        string _numeroProcesso;
        ModeloTipoAcao _tipoAcao;        
        string _objetivo;
        string _vara;
        Modelo.Cliente.ModeloCliente _cabeca;
        DateTime? _dataAjuizamentoAcao;
        string _observacao;
        string _reu;
        string _numeroOrdem;
        int? _quantidadeDiasAlerta;
    }
}
