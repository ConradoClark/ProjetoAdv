		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Comum{
	public abstract partial class ModeloBase: INotifyPropertyChanged
    {	
	        public   event PropertyChangedEventHandler PropertyChanged;
			public virtual bool Sujo{get;set;}
			public ModeloBase(){
																			
							OrigemDadosAlterado+= (_old,_new) =>Sujo=false;
							
								}
     		#region Eventos do OrigemDados
				public delegate void _origemDadosAlterado(OrigemDados valorAntigo, OrigemDados valorNovo);
				public event _origemDadosAlterado OrigemDadosAlterado;				
			#endregion			
									public OrigemDados OrigemDados{
				get{
					return _origemDados;
				}
				set{
					if (_origemDados != value){
						if (OrigemDadosAlterado != null){
							OrigemDadosAlterado(_origemDados,value);
							this.NotifyPropertyChanged("OrigemDados");
						}
						_origemDados = value;
					}
				}
			}
					public virtual void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															OrigemDados = default(OrigemDados);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloBase Clone(Func< ModeloBase > criarObjeto){
				ModeloBase clone = criarObjeto();
									clone.OrigemDados = this.OrigemDados;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
										 	}
}
