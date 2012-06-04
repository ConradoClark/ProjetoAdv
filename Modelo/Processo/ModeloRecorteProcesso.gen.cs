		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Processo{
	public abstract partial class ModeloRecorteProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloRecorteProcesso(){
																		ProcessoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataInclusaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		UsuarioInclusaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TextoRecorteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Processo
				public delegate void _processoAlterado(ModeloProcesso valorAntigo, ModeloProcesso valorNovo);
				public event _processoAlterado ProcessoAlterado;				
			#endregion			
			#region Eventos do DataInclusao
				public delegate void _dataInclusaoAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _dataInclusaoAlterado DataInclusaoAlterado;				
			#endregion			
			#region Eventos do UsuarioInclusao
				public delegate void _usuarioInclusaoAlterado(Modelo.Usuario.ModeloUsuario valorAntigo, Modelo.Usuario.ModeloUsuario valorNovo);
				public event _usuarioInclusaoAlterado UsuarioInclusaoAlterado;				
			#endregion			
			#region Eventos do TextoRecorte
				public delegate void _textoRecorteAlterado(string valorAntigo, string valorNovo);
				public event _textoRecorteAlterado TextoRecorteAlterado;				
			#endregion			
									
			
			public ModeloProcesso Processo{
				get{
					return _processo;
				}
				set{
					if (_processo != value){
						if (ProcessoAlterado != null){
							ProcessoAlterado(_processo,value);
						}
						_processo = value;
						this.NotifyPropertyChanged("Processo");
					}
				}
			}
					
			
			public DateTime? DataInclusao{
				get{
					return _dataInclusao;
				}
				set{
					if (_dataInclusao != value){
						if (DataInclusaoAlterado != null){
							DataInclusaoAlterado(_dataInclusao,value);
						}
						_dataInclusao = value;
						this.NotifyPropertyChanged("DataInclusao");
					}
				}
			}
					
			
			public Modelo.Usuario.ModeloUsuario UsuarioInclusao{
				get{
					return _usuarioInclusao;
				}
				set{
					if (_usuarioInclusao != value){
						if (UsuarioInclusaoAlterado != null){
							UsuarioInclusaoAlterado(_usuarioInclusao,value);
						}
						_usuarioInclusao = value;
						this.NotifyPropertyChanged("UsuarioInclusao");
					}
				}
			}
					
			
			public string TextoRecorte{
				get{
					return _textoRecorte;
				}
				set{
					if (_textoRecorte != value){
						if (TextoRecorteAlterado != null){
							TextoRecorteAlterado(_textoRecorte,value);
						}
						_textoRecorte = value;
						this.NotifyPropertyChanged("TextoRecorte");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Processo.Limpar();
										
															DataInclusao = default(DateTime?);
										
												
						UsuarioInclusao.Limpar();
										
															TextoRecorte = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloRecorteProcesso Clone(Func< ModeloRecorteProcesso > criarObjeto){
				ModeloRecorteProcesso clone = criarObjeto();
									clone.Processo = this.Processo;
									clone.DataInclusao = this.DataInclusao;
									clone.UsuarioInclusao = this.UsuarioInclusao;
									clone.TextoRecorte = this.TextoRecorte;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																															 	}
}
