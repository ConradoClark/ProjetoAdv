		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Comum{
	public abstract partial class ModeloEndereco : ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloEndereco(){
																		LogradouroAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NumeroAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ComplementoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		BairroAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CidadeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		UfAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CepAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Logradouro
				public delegate void _logradouroAlterado(string valorAntigo, string valorNovo);
				public event _logradouroAlterado LogradouroAlterado;				
			#endregion			
			#region Eventos do Numero
				public delegate void _numeroAlterado(string valorAntigo, string valorNovo);
				public event _numeroAlterado NumeroAlterado;				
			#endregion			
			#region Eventos do Complemento
				public delegate void _complementoAlterado(string valorAntigo, string valorNovo);
				public event _complementoAlterado ComplementoAlterado;				
			#endregion			
			#region Eventos do Bairro
				public delegate void _bairroAlterado(string valorAntigo, string valorNovo);
				public event _bairroAlterado BairroAlterado;				
			#endregion			
			#region Eventos do Cidade
				public delegate void _cidadeAlterado(string valorAntigo, string valorNovo);
				public event _cidadeAlterado CidadeAlterado;				
			#endregion			
			#region Eventos do Uf
				public delegate void _ufAlterado(string valorAntigo, string valorNovo);
				public event _ufAlterado UfAlterado;				
			#endregion			
			#region Eventos do Cep
				public delegate void _cepAlterado(string valorAntigo, string valorNovo);
				public event _cepAlterado CepAlterado;				
			#endregion			
									public string Logradouro{
				get{
					return _logradouro;
				}
				set{
					if (_logradouro != value){
						if (LogradouroAlterado != null){
							LogradouroAlterado(_logradouro,value);
							this.NotifyPropertyChanged("Logradouro");
						}
						_logradouro = value;
					}
				}
			}
					public string Numero{
				get{
					return _numero;
				}
				set{
					if (_numero != value){
						if (NumeroAlterado != null){
							NumeroAlterado(_numero,value);
							this.NotifyPropertyChanged("Numero");
						}
						_numero = value;
					}
				}
			}
					public string Complemento{
				get{
					return _complemento;
				}
				set{
					if (_complemento != value){
						if (ComplementoAlterado != null){
							ComplementoAlterado(_complemento,value);
							this.NotifyPropertyChanged("Complemento");
						}
						_complemento = value;
					}
				}
			}
					public string Bairro{
				get{
					return _bairro;
				}
				set{
					if (_bairro != value){
						if (BairroAlterado != null){
							BairroAlterado(_bairro,value);
							this.NotifyPropertyChanged("Bairro");
						}
						_bairro = value;
					}
				}
			}
					public string Cidade{
				get{
					return _cidade;
				}
				set{
					if (_cidade != value){
						if (CidadeAlterado != null){
							CidadeAlterado(_cidade,value);
							this.NotifyPropertyChanged("Cidade");
						}
						_cidade = value;
					}
				}
			}
					public string Uf{
				get{
					return _uf;
				}
				set{
					if (_uf != value){
						if (UfAlterado != null){
							UfAlterado(_uf,value);
							this.NotifyPropertyChanged("Uf");
						}
						_uf = value;
					}
				}
			}
					public string Cep{
				get{
					return _cep;
				}
				set{
					if (_cep != value){
						if (CepAlterado != null){
							CepAlterado(_cep,value);
							this.NotifyPropertyChanged("Cep");
						}
						_cep = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Logradouro = default(string);
										
															Numero = default(string);
										
															Complemento = default(string);
										
															Bairro = default(string);
										
															Cidade = default(string);
										
															Uf = default(string);
										
															Cep = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloEndereco Clone(Func< ModeloEndereco > criarObjeto){
				ModeloEndereco clone = criarObjeto();
									clone.Logradouro = this.Logradouro;
									clone.Numero = this.Numero;
									clone.Complemento = this.Complemento;
									clone.Bairro = this.Bairro;
									clone.Cidade = this.Cidade;
									clone.Uf = this.Uf;
									clone.Cep = this.Cep;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																																																				 	}
}
