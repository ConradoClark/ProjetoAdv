		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Processo;
			using System.ComponentModel;
	
namespace Modelo.Advogado{
	public abstract partial class ModeloAdvogadoProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloAdvogadoProcesso(){
																		AdvogadoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ProcessoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Advogado
				public delegate void _advogadoAlterado(ModeloAdvogado valorAntigo, ModeloAdvogado valorNovo);
				public event _advogadoAlterado AdvogadoAlterado;				
			#endregion			
			#region Eventos do Processo
				public delegate void _processoAlterado(ModeloProcesso valorAntigo, ModeloProcesso valorNovo);
				public event _processoAlterado ProcessoAlterado;				
			#endregion			
									public ModeloAdvogado Advogado{
				get{
					return _advogado;
				}
				set{
					if (_advogado != value){
						if (AdvogadoAlterado != null){
							AdvogadoAlterado(_advogado,value);
							this.NotifyPropertyChanged("Advogado");
						}
						_advogado = value;
					}
				}
			}
					public ModeloProcesso Processo{
				get{
					return _processo;
				}
				set{
					if (_processo != value){
						if (ProcessoAlterado != null){
							ProcessoAlterado(_processo,value);
							this.NotifyPropertyChanged("Processo");
						}
						_processo = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Advogado.Limpar();
										
												
						Processo.Limpar();
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloAdvogadoProcesso Clone(Func< ModeloAdvogadoProcesso > criarObjeto){
				ModeloAdvogadoProcesso clone = criarObjeto();
									clone.Advogado = this.Advogado;
									clone.Processo = this.Processo;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																	 	}
}
