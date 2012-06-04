		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.GrupoDiferencial;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloGrupoDiferencialCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloGrupoDiferencialCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		GrupoDiferencialAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Cliente
				public delegate void _clienteAlterado(ModeloCliente valorAntigo, ModeloCliente valorNovo);
				public event _clienteAlterado ClienteAlterado;				
			#endregion			
			#region Eventos do GrupoDiferencial
				public delegate void _grupoDiferencialAlterado(ModeloGrupoDiferencial valorAntigo, ModeloGrupoDiferencial valorNovo);
				public event _grupoDiferencialAlterado GrupoDiferencialAlterado;				
			#endregion			
									
			
			public ModeloCliente Cliente{
				get{
					return _cliente;
				}
				set{
					if (_cliente != value){
						if (ClienteAlterado != null){
							ClienteAlterado(_cliente,value);
						}
						_cliente = value;
						this.NotifyPropertyChanged("Cliente");
					}
				}
			}
					
			
			public ModeloGrupoDiferencial GrupoDiferencial{
				get{
					return _grupoDiferencial;
				}
				set{
					if (_grupoDiferencial != value){
						if (GrupoDiferencialAlterado != null){
							GrupoDiferencialAlterado(_grupoDiferencial,value);
						}
						_grupoDiferencial = value;
						this.NotifyPropertyChanged("GrupoDiferencial");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Cliente.Limpar();
										
												
						GrupoDiferencial.Limpar();
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloGrupoDiferencialCliente Clone(Func< ModeloGrupoDiferencialCliente > criarObjeto){
				ModeloGrupoDiferencialCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.GrupoDiferencial = this.GrupoDiferencial;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																	 	}
}
