		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Usuario;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloAtendimentoCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloAtendimentoCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataHoraAtendimentoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		UsuarioAtendimentoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		AtendimentoInternoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		AtendimentoExternoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Cliente
				public delegate void _clienteAlterado(ModeloCliente valorAntigo, ModeloCliente valorNovo);
				public event _clienteAlterado ClienteAlterado;				
			#endregion			
			#region Eventos do DataHoraAtendimento
				public delegate void _dataHoraAtendimentoAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _dataHoraAtendimentoAlterado DataHoraAtendimentoAlterado;				
			#endregion			
			#region Eventos do UsuarioAtendimento
				public delegate void _usuarioAtendimentoAlterado(ModeloUsuario valorAntigo, ModeloUsuario valorNovo);
				public event _usuarioAtendimentoAlterado UsuarioAtendimentoAlterado;				
			#endregion			
			#region Eventos do AtendimentoInterno
				public delegate void _atendimentoInternoAlterado(string valorAntigo, string valorNovo);
				public event _atendimentoInternoAlterado AtendimentoInternoAlterado;				
			#endregion			
			#region Eventos do AtendimentoExterno
				public delegate void _atendimentoExternoAlterado(string valorAntigo, string valorNovo);
				public event _atendimentoExternoAlterado AtendimentoExternoAlterado;				
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
					
			
			public DateTime? DataHoraAtendimento{
				get{
					return _dataHoraAtendimento;
				}
				set{
					if (_dataHoraAtendimento != value){
						if (DataHoraAtendimentoAlterado != null){
							DataHoraAtendimentoAlterado(_dataHoraAtendimento,value);
						}
						_dataHoraAtendimento = value;
						this.NotifyPropertyChanged("DataHoraAtendimento");
					}
				}
			}
					
			
			public ModeloUsuario UsuarioAtendimento{
				get{
					return _usuarioAtendimento;
				}
				set{
					if (_usuarioAtendimento != value){
						if (UsuarioAtendimentoAlterado != null){
							UsuarioAtendimentoAlterado(_usuarioAtendimento,value);
						}
						_usuarioAtendimento = value;
						this.NotifyPropertyChanged("UsuarioAtendimento");
					}
				}
			}
					
			
			public string AtendimentoInterno{
				get{
					return _atendimentoInterno;
				}
				set{
					if (_atendimentoInterno != value){
						if (AtendimentoInternoAlterado != null){
							AtendimentoInternoAlterado(_atendimentoInterno,value);
						}
						_atendimentoInterno = value;
						this.NotifyPropertyChanged("AtendimentoInterno");
					}
				}
			}
					
			
			public string AtendimentoExterno{
				get{
					return _atendimentoExterno;
				}
				set{
					if (_atendimentoExterno != value){
						if (AtendimentoExternoAlterado != null){
							AtendimentoExternoAlterado(_atendimentoExterno,value);
						}
						_atendimentoExterno = value;
						this.NotifyPropertyChanged("AtendimentoExterno");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Cliente.Limpar();
										
															DataHoraAtendimento = default(DateTime?);
										
												
						UsuarioAtendimento.Limpar();
										
															AtendimentoInterno = default(string);
										
															AtendimentoExterno = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloAtendimentoCliente Clone(Func< ModeloAtendimentoCliente > criarObjeto){
				ModeloAtendimentoCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.DataHoraAtendimento = this.DataHoraAtendimento;
									clone.UsuarioAtendimento = this.UsuarioAtendimento;
									clone.AtendimentoInterno = this.AtendimentoInterno;
									clone.AtendimentoExterno = this.AtendimentoExterno;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																																						 	}
}
