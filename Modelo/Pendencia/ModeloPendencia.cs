﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Pendencia
{
    public abstract partial class ModeloPendencia : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        int? _id;
        string _descricao;
    }
}
