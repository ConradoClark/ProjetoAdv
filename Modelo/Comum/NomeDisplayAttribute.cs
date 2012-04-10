using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo.Comum
{
    [AttributeUsage(AttributeTargets.Field)]
    public class NomeDisplayAttribute : Attribute
    {
        public string NomeDisplay { get; set; }

        public NomeDisplayAttribute(string nomeDisplay)
        {
            this.NomeDisplay = nomeDisplay;
        }
    }
}
