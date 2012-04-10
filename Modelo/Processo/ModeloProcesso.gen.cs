		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Acao;
			using Modelo.Advogado;
			using System.ComponentModel;
	
namespace Modelo.Processo{
	public abstract partial class ModeloProcesso : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloProcesso(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NumeroProcessoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TipoAcaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ObjetivoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		VaraAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CabecaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataAjuizamentoAcaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ObservacaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ReuAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NumeroOrdemAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		QuantidadeDiasAlertaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do NumeroProcesso
				public delegate void _numeroProcessoAlterado(string valorAntigo, string valorNovo);
				public event _numeroProcessoAlterado NumeroProcessoAlterado;				
			#endregion			
			#region Eventos do TipoAcao
				public delegate void _tipoAcaoAlterado(ModeloTipoAcao valorAntigo, ModeloTipoAcao valorNovo);
				public event _tipoAcaoAlterado TipoAcaoAlterado;				
			#endregion			
			#region Eventos do Objetivo
				public delegate void _objetivoAlterado(string valorAntigo, string valorNovo);
				public event _objetivoAlterado ObjetivoAlterado;				
			#endregion			
			#region Eventos do Vara
				public delegate void _varaAlterado(string valorAntigo, string valorNovo);
				public event _varaAlterado VaraAlterado;				
			#endregion			
			#region Eventos do Cabeca
				public delegate void _cabecaAlterado(string valorAntigo, string valorNovo);
				public event _cabecaAlterado CabecaAlterado;				
			#endregion			
			#region Eventos do DataAjuizamentoAcao
				public delegate void _dataAjuizamentoAcaoAlterado(DateTime valorAntigo, DateTime valorNovo);
				public event _dataAjuizamentoAcaoAlterado DataAjuizamentoAcaoAlterado;				
			#endregion			
			#region Eventos do Observacao
				public delegate void _observacaoAlterado(string valorAntigo, string valorNovo);
				public event _observacaoAlterado ObservacaoAlterado;				
			#endregion			
			#region Eventos do Reu
				public delegate void _reuAlterado(string valorAntigo, string valorNovo);
				public event _reuAlterado ReuAlterado;				
			#endregion			
			#region Eventos do NumeroOrdem
				public delegate void _numeroOrdemAlterado(string valorAntigo, string valorNovo);
				public event _numeroOrdemAlterado NumeroOrdemAlterado;				
			#endregion			
			#region Eventos do QuantidadeDiasAlerta
				public delegate void _quantidadeDiasAlertaAlterado(int? valorAntigo, int? valorNovo);
				public event _quantidadeDiasAlertaAlterado QuantidadeDiasAlertaAlterado;				
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
					public string NumeroProcesso{
				get{
					return _numeroProcesso;
				}
				set{
					if (_numeroProcesso != value){
						if (NumeroProcessoAlterado != null){
							NumeroProcessoAlterado(_numeroProcesso,value);
							this.NotifyPropertyChanged("NumeroProcesso");
						}
						_numeroProcesso = value;
					}
				}
			}
					public ModeloTipoAcao TipoAcao{
				get{
					return _tipoAcao;
				}
				set{
					if (_tipoAcao != value){
						if (TipoAcaoAlterado != null){
							TipoAcaoAlterado(_tipoAcao,value);
							this.NotifyPropertyChanged("TipoAcao");
						}
						_tipoAcao = value;
					}
				}
			}
					public string Objetivo{
				get{
					return _objetivo;
				}
				set{
					if (_objetivo != value){
						if (ObjetivoAlterado != null){
							ObjetivoAlterado(_objetivo,value);
							this.NotifyPropertyChanged("Objetivo");
						}
						_objetivo = value;
					}
				}
			}
					public string Vara{
				get{
					return _vara;
				}
				set{
					if (_vara != value){
						if (VaraAlterado != null){
							VaraAlterado(_vara,value);
							this.NotifyPropertyChanged("Vara");
						}
						_vara = value;
					}
				}
			}
					public string Cabeca{
				get{
					return _cabeca;
				}
				set{
					if (_cabeca != value){
						if (CabecaAlterado != null){
							CabecaAlterado(_cabeca,value);
							this.NotifyPropertyChanged("Cabeca");
						}
						_cabeca = value;
					}
				}
			}
					public DateTime DataAjuizamentoAcao{
				get{
					return _dataAjuizamentoAcao;
				}
				set{
					if (_dataAjuizamentoAcao != value){
						if (DataAjuizamentoAcaoAlterado != null){
							DataAjuizamentoAcaoAlterado(_dataAjuizamentoAcao,value);
							this.NotifyPropertyChanged("DataAjuizamentoAcao");
						}
						_dataAjuizamentoAcao = value;
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
					public string Reu{
				get{
					return _reu;
				}
				set{
					if (_reu != value){
						if (ReuAlterado != null){
							ReuAlterado(_reu,value);
							this.NotifyPropertyChanged("Reu");
						}
						_reu = value;
					}
				}
			}
					public string NumeroOrdem{
				get{
					return _numeroOrdem;
				}
				set{
					if (_numeroOrdem != value){
						if (NumeroOrdemAlterado != null){
							NumeroOrdemAlterado(_numeroOrdem,value);
							this.NotifyPropertyChanged("NumeroOrdem");
						}
						_numeroOrdem = value;
					}
				}
			}
					public int? QuantidadeDiasAlerta{
				get{
					return _quantidadeDiasAlerta;
				}
				set{
					if (_quantidadeDiasAlerta != value){
						if (QuantidadeDiasAlertaAlterado != null){
							QuantidadeDiasAlertaAlterado(_quantidadeDiasAlerta,value);
							this.NotifyPropertyChanged("QuantidadeDiasAlerta");
						}
						_quantidadeDiasAlerta = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															NumeroProcesso = default(string);
										
												
						TipoAcao.Limpar();
										
															Objetivo = default(string);
										
															Vara = default(string);
										
															Cabeca = default(string);
										
															DataAjuizamentoAcao = default(DateTime);
										
															Observacao = default(string);
										
															Reu = default(string);
										
															NumeroOrdem = default(string);
										
															QuantidadeDiasAlerta = default(int?);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloProcesso Clone(Func< ModeloProcesso > criarObjeto){
				ModeloProcesso clone = criarObjeto();
									clone.Id = this.Id;
									clone.NumeroProcesso = this.NumeroProcesso;
									clone.TipoAcao = this.TipoAcao;
									clone.Objetivo = this.Objetivo;
									clone.Vara = this.Vara;
									clone.Cabeca = this.Cabeca;
									clone.DataAjuizamentoAcao = this.DataAjuizamentoAcao;
									clone.Observacao = this.Observacao;
									clone.Reu = this.Reu;
									clone.NumeroOrdem = this.NumeroOrdem;
									clone.QuantidadeDiasAlerta = this.QuantidadeDiasAlerta;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloProcesso){
							return this.Id == ((ModeloProcesso)obj).Id;
						}
						return false;
					}
																																																																													 	}
}
