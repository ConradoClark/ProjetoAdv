using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Modelo.Comum
{
    public partial class ModeloGrauParentesco : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {
        public int Id{
            get;set;
        }
        public string Nome{
            get;set;
        }

        public ModeloGrauParentesco Self{
            get { return this; }
        }
        public ModeloGrauParentesco(int codigo, string nome){
            this.Id = codigo;
            this.Nome = nome;
        }

        public static implicit operator ModeloGrauParentesco(int gp)
        {
            return GrausParentesco.Lista.FirstOrDefault((g) => g.Id == gp);
        }
    }
    
}
