		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Usuario{
	public abstract partial class ModeloUsuario : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloUsuario(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		LoginAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		SenhaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PermissaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		StatusAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do Nome
				public delegate void _nomeAlterado(string valorAntigo, string valorNovo);
				public event _nomeAlterado NomeAlterado;				
			#endregion			
			#region Eventos do Login
				public delegate void _loginAlterado(string valorAntigo, string valorNovo);
				public event _loginAlterado LoginAlterado;				
			#endregion			
			#region Eventos do Senha
				public delegate void _senhaAlterado(string valorAntigo, string valorNovo);
				public event _senhaAlterado SenhaAlterado;				
			#endregion			
			#region Eventos do Permissao
				public delegate void _permissaoAlterado(PermissaoUsuario valorAntigo, PermissaoUsuario valorNovo);
				public event _permissaoAlterado PermissaoAlterado;				
			#endregion			
			#region Eventos do Status
				public delegate void _statusAlterado(StatusUsuario valorAntigo, StatusUsuario valorNovo);
				public event _statusAlterado StatusAlterado;				
			#endregion			
									
			
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
					
			
			public string Nome{
				get{
					return _nome;
				}
				set{
					if (_nome != value){
						if (NomeAlterado != null){
							NomeAlterado(_nome,value);
							this.NotifyPropertyChanged("Nome");
						}
						_nome = value;
					}
				}
			}
					
			
			public string Login{
				get{
					return _login;
				}
				set{
					if (_login != value){
						if (LoginAlterado != null){
							LoginAlterado(_login,value);
							this.NotifyPropertyChanged("Login");
						}
						_login = value;
					}
				}
			}
					
			
			public string Senha{
				get{
					return _senha;
				}
				set{
					if (_senha != value){
						if (SenhaAlterado != null){
							SenhaAlterado(_senha,value);
							this.NotifyPropertyChanged("Senha");
						}
						_senha = value;
					}
				}
			}
					
			
			public PermissaoUsuario Permissao{
				get{
					return _permissao;
				}
				set{
					if (_permissao != value){
						if (PermissaoAlterado != null){
							PermissaoAlterado(_permissao,value);
							this.NotifyPropertyChanged("Permissao");
						}
						_permissao = value;
					}
				}
			}
					
			
			public StatusUsuario Status{
				get{
					return _status;
				}
				set{
					if (_status != value){
						if (StatusAlterado != null){
							StatusAlterado(_status,value);
							this.NotifyPropertyChanged("Status");
						}
						_status = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															Nome = default(string);
										
															Login = default(string);
										
															Senha = default(string);
										
															Permissao = default(PermissaoUsuario);
										
															Status = default(StatusUsuario);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloUsuario Clone(Func< ModeloUsuario > criarObjeto){
				ModeloUsuario clone = criarObjeto();
									clone.Id = this.Id;
									clone.Nome = this.Nome;
									clone.Login = this.Login;
									clone.Senha = this.Senha;
									clone.Permissao = this.Permissao;
									clone.Status = this.Status;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloUsuario){
							return this.Id == ((ModeloUsuario)obj).Id;
						}
						return false;
					}
																																										 	}
}
