		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Usuario{
	public abstract partial class ModeloUsuarioConfiguracao : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloUsuarioConfiguracao(){
																		UsuarioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PastaFichaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PastaProcessoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PastaLogAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PastaExtratoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		MargemEsquerdaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		MargemDireitaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		MargemSuperiorAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		MargemInferiorAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Usuario
				public delegate void _usuarioAlterado(ModeloUsuario valorAntigo, ModeloUsuario valorNovo);
				public event _usuarioAlterado UsuarioAlterado;				
			#endregion			
			#region Eventos do PastaFicha
				public delegate void _pastaFichaAlterado(string valorAntigo, string valorNovo);
				public event _pastaFichaAlterado PastaFichaAlterado;				
			#endregion			
			#region Eventos do PastaProcesso
				public delegate void _pastaProcessoAlterado(string valorAntigo, string valorNovo);
				public event _pastaProcessoAlterado PastaProcessoAlterado;				
			#endregion			
			#region Eventos do PastaLog
				public delegate void _pastaLogAlterado(string valorAntigo, string valorNovo);
				public event _pastaLogAlterado PastaLogAlterado;				
			#endregion			
			#region Eventos do PastaExtrato
				public delegate void _pastaExtratoAlterado(string valorAntigo, string valorNovo);
				public event _pastaExtratoAlterado PastaExtratoAlterado;				
			#endregion			
			#region Eventos do MargemEsquerda
				public delegate void _margemEsquerdaAlterado(double valorAntigo, double valorNovo);
				public event _margemEsquerdaAlterado MargemEsquerdaAlterado;				
			#endregion			
			#region Eventos do MargemDireita
				public delegate void _margemDireitaAlterado(double valorAntigo, double valorNovo);
				public event _margemDireitaAlterado MargemDireitaAlterado;				
			#endregion			
			#region Eventos do MargemSuperior
				public delegate void _margemSuperiorAlterado(double valorAntigo, double valorNovo);
				public event _margemSuperiorAlterado MargemSuperiorAlterado;				
			#endregion			
			#region Eventos do MargemInferior
				public delegate void _margemInferiorAlterado(double valorAntigo, double valorNovo);
				public event _margemInferiorAlterado MargemInferiorAlterado;				
			#endregion			
									public ModeloUsuario Usuario{
				get{
					return _usuario;
				}
				set{
					if (_usuario != value){
						if (UsuarioAlterado != null){
							UsuarioAlterado(_usuario,value);
							this.NotifyPropertyChanged("Usuario");
						}
						_usuario = value;
					}
				}
			}
					public string PastaFicha{
				get{
					return _pastaFicha;
				}
				set{
					if (_pastaFicha != value){
						if (PastaFichaAlterado != null){
							PastaFichaAlterado(_pastaFicha,value);
							this.NotifyPropertyChanged("PastaFicha");
						}
						_pastaFicha = value;
					}
				}
			}
					public string PastaProcesso{
				get{
					return _pastaProcesso;
				}
				set{
					if (_pastaProcesso != value){
						if (PastaProcessoAlterado != null){
							PastaProcessoAlterado(_pastaProcesso,value);
							this.NotifyPropertyChanged("PastaProcesso");
						}
						_pastaProcesso = value;
					}
				}
			}
					public string PastaLog{
				get{
					return _pastaLog;
				}
				set{
					if (_pastaLog != value){
						if (PastaLogAlterado != null){
							PastaLogAlterado(_pastaLog,value);
							this.NotifyPropertyChanged("PastaLog");
						}
						_pastaLog = value;
					}
				}
			}
					public string PastaExtrato{
				get{
					return _pastaExtrato;
				}
				set{
					if (_pastaExtrato != value){
						if (PastaExtratoAlterado != null){
							PastaExtratoAlterado(_pastaExtrato,value);
							this.NotifyPropertyChanged("PastaExtrato");
						}
						_pastaExtrato = value;
					}
				}
			}
					public double MargemEsquerda{
				get{
					return _margemEsquerda;
				}
				set{
					if (_margemEsquerda != value){
						if (MargemEsquerdaAlterado != null){
							MargemEsquerdaAlterado(_margemEsquerda,value);
							this.NotifyPropertyChanged("MargemEsquerda");
						}
						_margemEsquerda = value;
					}
				}
			}
					public double MargemDireita{
				get{
					return _margemDireita;
				}
				set{
					if (_margemDireita != value){
						if (MargemDireitaAlterado != null){
							MargemDireitaAlterado(_margemDireita,value);
							this.NotifyPropertyChanged("MargemDireita");
						}
						_margemDireita = value;
					}
				}
			}
					public double MargemSuperior{
				get{
					return _margemSuperior;
				}
				set{
					if (_margemSuperior != value){
						if (MargemSuperiorAlterado != null){
							MargemSuperiorAlterado(_margemSuperior,value);
							this.NotifyPropertyChanged("MargemSuperior");
						}
						_margemSuperior = value;
					}
				}
			}
					public double MargemInferior{
				get{
					return _margemInferior;
				}
				set{
					if (_margemInferior != value){
						if (MargemInferiorAlterado != null){
							MargemInferiorAlterado(_margemInferior,value);
							this.NotifyPropertyChanged("MargemInferior");
						}
						_margemInferior = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Usuario.Limpar();
										
															PastaFicha = default(string);
										
															PastaProcesso = default(string);
										
															PastaLog = default(string);
										
															PastaExtrato = default(string);
										
															MargemEsquerda = default(double);
										
															MargemDireita = default(double);
										
															MargemSuperior = default(double);
										
															MargemInferior = default(double);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloUsuarioConfiguracao Clone(Func< ModeloUsuarioConfiguracao > criarObjeto){
				ModeloUsuarioConfiguracao clone = criarObjeto();
									clone.Usuario = this.Usuario;
									clone.PastaFicha = this.PastaFicha;
									clone.PastaProcesso = this.PastaProcesso;
									clone.PastaLog = this.PastaLog;
									clone.PastaExtrato = this.PastaExtrato;
									clone.MargemEsquerda = this.MargemEsquerda;
									clone.MargemDireita = this.MargemDireita;
									clone.MargemSuperior = this.MargemSuperior;
									clone.MargemInferior = this.MargemInferior;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																																																																		 	}
}
