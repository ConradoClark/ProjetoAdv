		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Beneficio;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloBeneficioCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloBeneficioCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TipoBeneficioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NumeroAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TempoContribuicaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		SomaSalariosContribuicaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		InicioBeneficioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		RendaMensalInicialAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DivisorAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		FatorPrevidenciarioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		SalarioBeneficioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CoeficienteCalculoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		MediaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Cliente
				public delegate void _clienteAlterado(ModeloCliente valorAntigo, ModeloCliente valorNovo);
				public event _clienteAlterado ClienteAlterado;				
			#endregion			
			#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do TipoBeneficio
				public delegate void _tipoBeneficioAlterado(ModeloTipoBeneficio valorAntigo, ModeloTipoBeneficio valorNovo);
				public event _tipoBeneficioAlterado TipoBeneficioAlterado;				
			#endregion			
			#region Eventos do Numero
				public delegate void _numeroAlterado(string valorAntigo, string valorNovo);
				public event _numeroAlterado NumeroAlterado;				
			#endregion			
			#region Eventos do TempoContribuicao
				public delegate void _tempoContribuicaoAlterado(string valorAntigo, string valorNovo);
				public event _tempoContribuicaoAlterado TempoContribuicaoAlterado;				
			#endregion			
			#region Eventos do SomaSalariosContribuicao
				public delegate void _somaSalariosContribuicaoAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _somaSalariosContribuicaoAlterado SomaSalariosContribuicaoAlterado;				
			#endregion			
			#region Eventos do InicioBeneficio
				public delegate void _inicioBeneficioAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _inicioBeneficioAlterado InicioBeneficioAlterado;				
			#endregion			
			#region Eventos do RendaMensalInicial
				public delegate void _rendaMensalInicialAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _rendaMensalInicialAlterado RendaMensalInicialAlterado;				
			#endregion			
			#region Eventos do Divisor
				public delegate void _divisorAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _divisorAlterado DivisorAlterado;				
			#endregion			
			#region Eventos do FatorPrevidenciario
				public delegate void _fatorPrevidenciarioAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _fatorPrevidenciarioAlterado FatorPrevidenciarioAlterado;				
			#endregion			
			#region Eventos do SalarioBeneficio
				public delegate void _salarioBeneficioAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _salarioBeneficioAlterado SalarioBeneficioAlterado;				
			#endregion			
			#region Eventos do CoeficienteCalculo
				public delegate void _coeficienteCalculoAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _coeficienteCalculoAlterado CoeficienteCalculoAlterado;				
			#endregion			
			#region Eventos do Media
				public delegate void _mediaAlterado(decimal? valorAntigo, decimal? valorNovo);
				public event _mediaAlterado MediaAlterado;				
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
					public ModeloTipoBeneficio TipoBeneficio{
				get{
					return _tipoBeneficio;
				}
				set{
					if (_tipoBeneficio != value){
						if (TipoBeneficioAlterado != null){
							TipoBeneficioAlterado(_tipoBeneficio,value);
							this.NotifyPropertyChanged("TipoBeneficio");
						}
						_tipoBeneficio = value;
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
					public string TempoContribuicao{
				get{
					return _tempoContribuicao;
				}
				set{
					if (_tempoContribuicao != value){
						if (TempoContribuicaoAlterado != null){
							TempoContribuicaoAlterado(_tempoContribuicao,value);
							this.NotifyPropertyChanged("TempoContribuicao");
						}
						_tempoContribuicao = value;
					}
				}
			}
					public decimal? SomaSalariosContribuicao{
				get{
					return _somaSalariosContribuicao;
				}
				set{
					if (_somaSalariosContribuicao != value){
						if (SomaSalariosContribuicaoAlterado != null){
							SomaSalariosContribuicaoAlterado(_somaSalariosContribuicao,value);
							this.NotifyPropertyChanged("SomaSalariosContribuicao");
						}
						_somaSalariosContribuicao = value;
					}
				}
			}
					public DateTime? InicioBeneficio{
				get{
					return _inicioBeneficio;
				}
				set{
					if (_inicioBeneficio != value){
						if (InicioBeneficioAlterado != null){
							InicioBeneficioAlterado(_inicioBeneficio,value);
							this.NotifyPropertyChanged("InicioBeneficio");
						}
						_inicioBeneficio = value;
					}
				}
			}
					public decimal? RendaMensalInicial{
				get{
					return _rendaMensalInicial;
				}
				set{
					if (_rendaMensalInicial != value){
						if (RendaMensalInicialAlterado != null){
							RendaMensalInicialAlterado(_rendaMensalInicial,value);
							this.NotifyPropertyChanged("RendaMensalInicial");
						}
						_rendaMensalInicial = value;
					}
				}
			}
					public decimal? Divisor{
				get{
					return _divisor;
				}
				set{
					if (_divisor != value){
						if (DivisorAlterado != null){
							DivisorAlterado(_divisor,value);
							this.NotifyPropertyChanged("Divisor");
						}
						_divisor = value;
					}
				}
			}
					public decimal? FatorPrevidenciario{
				get{
					return _fatorPrevidenciario;
				}
				set{
					if (_fatorPrevidenciario != value){
						if (FatorPrevidenciarioAlterado != null){
							FatorPrevidenciarioAlterado(_fatorPrevidenciario,value);
							this.NotifyPropertyChanged("FatorPrevidenciario");
						}
						_fatorPrevidenciario = value;
					}
				}
			}
					public decimal? SalarioBeneficio{
				get{
					return _salarioBeneficio;
				}
				set{
					if (_salarioBeneficio != value){
						if (SalarioBeneficioAlterado != null){
							SalarioBeneficioAlterado(_salarioBeneficio,value);
							this.NotifyPropertyChanged("SalarioBeneficio");
						}
						_salarioBeneficio = value;
					}
				}
			}
					public decimal? CoeficienteCalculo{
				get{
					return _coeficienteCalculo;
				}
				set{
					if (_coeficienteCalculo != value){
						if (CoeficienteCalculoAlterado != null){
							CoeficienteCalculoAlterado(_coeficienteCalculo,value);
							this.NotifyPropertyChanged("CoeficienteCalculo");
						}
						_coeficienteCalculo = value;
					}
				}
			}
					public decimal? Media{
				get{
					return _media;
				}
				set{
					if (_media != value){
						if (MediaAlterado != null){
							MediaAlterado(_media,value);
							this.NotifyPropertyChanged("Media");
						}
						_media = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Cliente.Limpar();
										
															Id = default(int?);
										
												
						TipoBeneficio.Limpar();
										
															Numero = default(string);
										
															TempoContribuicao = default(string);
										
															SomaSalariosContribuicao = default(decimal?);
										
															InicioBeneficio = default(DateTime?);
										
															RendaMensalInicial = default(decimal?);
										
															Divisor = default(decimal?);
										
															FatorPrevidenciario = default(decimal?);
										
															SalarioBeneficio = default(decimal?);
										
															CoeficienteCalculo = default(decimal?);
										
															Media = default(decimal?);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloBeneficioCliente Clone(Func< ModeloBeneficioCliente > criarObjeto){
				ModeloBeneficioCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.Id = this.Id;
									clone.TipoBeneficio = this.TipoBeneficio;
									clone.Numero = this.Numero;
									clone.TempoContribuicao = this.TempoContribuicao;
									clone.SomaSalariosContribuicao = this.SomaSalariosContribuicao;
									clone.InicioBeneficio = this.InicioBeneficio;
									clone.RendaMensalInicial = this.RendaMensalInicial;
									clone.Divisor = this.Divisor;
									clone.FatorPrevidenciario = this.FatorPrevidenciario;
									clone.SalarioBeneficio = this.SalarioBeneficio;
									clone.CoeficienteCalculo = this.CoeficienteCalculo;
									clone.Media = this.Media;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																			public override bool Equals(object obj){
						if (obj is ModeloBeneficioCliente){
							return this.Id == ((ModeloBeneficioCliente)obj).Id;
						}
						return false;
					}
																																																																																				 	}
}
