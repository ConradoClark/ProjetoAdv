		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Comum;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloContatoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloContatoCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TipoContatoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ContatoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ObservacaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Cliente
				public delegate void _clienteAlterado(ModeloCliente valorAntigo, ModeloCliente valorNovo);
				public event _clienteAlterado ClienteAlterado;				
			#endregion			
			#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do TipoContato
				public delegate void _tipoContatoAlterado(string valorAntigo, string valorNovo);
				public event _tipoContatoAlterado TipoContatoAlterado;				
			#endregion			
			#region Eventos do Contato
				public delegate void _contatoAlterado(string valorAntigo, string valorNovo);
				public event _contatoAlterado ContatoAlterado;				
			#endregion			
			#region Eventos do Observacao
				public delegate void _observacaoAlterado(string valorAntigo, string valorNovo);
				public event _observacaoAlterado ObservacaoAlterado;				
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
					
			
			public int? Id{
				get{
					return _id;
				}
				set{
					if (_id != value){
						if (IdAlterado != null){
							IdAlterado(_id,value);
							this.NotifyPropertyChanged("Id");
						}
						_id = value;
					}
				}
			}
					
			
			public string TipoContato{
				get{
					return _tipoContato;
				}
				set{
					if (_tipoContato != value){
						if (TipoContatoAlterado != null){
							TipoContatoAlterado(_tipoContato,value);
							this.NotifyPropertyChanged("TipoContato");
						}
						_tipoContato = value;
					}
				}
			}
					
			
			public string Contato{
				get{
					return _contato;
				}
				set{
					if (_contato != value){
						if (ContatoAlterado != null){
							ContatoAlterado(_contato,value);
							this.NotifyPropertyChanged("Contato");
						}
						_contato = value;
					}
				}
			}
					
			
			public string Observacao{
				get{
					return _observacao;
				}
				set{
					if (_observacao != value){
						if (ObservacaoAlterado != null){
							ObservacaoAlterado(_observacao,value);
							this.NotifyPropertyChanged("Observacao");
						}
						_observacao = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Cliente.Limpar();
										
															Id = default(int?);
										
															TipoContato = default(string);
										
															Contato = default(string);
										
															Observacao = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloContatoCliente Clone(Func< ModeloContatoCliente > criarObjeto){
				ModeloContatoCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.Id = this.Id;
									clone.TipoContato = this.TipoContato;
									clone.Contato = this.Contato;
									clone.Observacao = this.Observacao;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																			public override bool Equals(object obj){
						if (obj is ModeloContatoCliente){
							return this.Id == ((ModeloContatoCliente)obj).Id;
						}
						return false;
					}
																												 	}
}
