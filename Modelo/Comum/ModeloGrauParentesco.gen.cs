		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Comum{
	public partial class ModeloGrauParentesco : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloGrauParentesco(){
								}
     								public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloGrauParentesco Clone(Func< ModeloGrauParentesco > criarObjeto){
				ModeloGrauParentesco clone = criarObjeto();
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
			 	}
}
