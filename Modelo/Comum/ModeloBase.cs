﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Comum
{
    public abstract partial class ModeloBase: INotifyPropertyChanged
    {
        OrigemDados _origemDados;
    }
}
