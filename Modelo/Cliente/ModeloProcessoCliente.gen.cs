		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Processo;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloProcessoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloProcessoCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ProcessoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Cliente
				public delegate void _clienteAlterado(ModeloCliente valorAntigo, ModeloCliente valorNovo);
				public event _clienteAlterado ClienteAlterado;				
			#endregion			
			#region Eventos do Processo
				public delegate void _processoAlterado(ModeloProcesso valorAntigo, ModeloProcesso valorNovo);
				public event _processoAlterado ProcessoAlterado;				
			#endregion			
									public ModeloCliente Cliente{
				get{
					return _cliente;
				}
				set{
					if (_cliente != value){
						if (ClienteAlterado != null){
							ClienteAlterado(_cliente,value);
							this.NotifyPropertyChanged("Cliente");
						}
						_cliente = value;
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
												
						Cliente.Limpar();
										
												
						Processo.Limpar();
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloProcessoCliente Clone(Func< ModeloProcessoCliente > criarObjeto){
				ModeloProcessoCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.Processo = this.Processo;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																	 	}
}
