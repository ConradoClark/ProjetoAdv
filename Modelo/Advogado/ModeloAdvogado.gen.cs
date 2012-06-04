		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Comum;
			using System.ComponentModel;
	
namespace Modelo.Advogado{
	public abstract partial class ModeloAdvogado : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloAdvogado(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		OabAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CpfAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		RgAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndicadorEstagiarioAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		EstadoCivilAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NaturalidadeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NacionalidadeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		SexoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do Oab
				public delegate void _oabAlterado(string valorAntigo, string valorNovo);
				public event _oabAlterado OabAlterado;				
			#endregion			
			#region Eventos do Cpf
				public delegate void _cpfAlterado(string valorAntigo, string valorNovo);
				public event _cpfAlterado CpfAlterado;				
			#endregion			
			#region Eventos do Rg
				public delegate void _rgAlterado(string valorAntigo, string valorNovo);
				public event _rgAlterado RgAlterado;				
			#endregion			
			#region Eventos do Nome
				public delegate void _nomeAlterado(string valorAntigo, string valorNovo);
				public event _nomeAlterado NomeAlterado;				
			#endregion			
			#region Eventos do IndicadorEstagiario
				public delegate void _indicadorEstagiarioAlterado(bool? valorAntigo, bool? valorNovo);
				public event _indicadorEstagiarioAlterado IndicadorEstagiarioAlterado;				
			#endregion			
			#region Eventos do EstadoCivil
				public delegate void _estadoCivilAlterado(EstadoCivil valorAntigo, EstadoCivil valorNovo);
				public event _estadoCivilAlterado EstadoCivilAlterado;				
			#endregion			
			#region Eventos do Naturalidade
				public delegate void _naturalidadeAlterado(string valorAntigo, string valorNovo);
				public event _naturalidadeAlterado NaturalidadeAlterado;				
			#endregion			
			#region Eventos do Nacionalidade
				public delegate void _nacionalidadeAlterado(string valorAntigo, string valorNovo);
				public event _nacionalidadeAlterado NacionalidadeAlterado;				
			#endregion			
			#region Eventos do Sexo
				public delegate void _sexoAlterado(char valorAntigo, char valorNovo);
				public event _sexoAlterado SexoAlterado;				
			#endregion			
									
			
			public int? Id{
				get{
					return _id;
				}
				set{
					if (_id != value){
						if (IdAlterado != null){
							IdAlterado(_id,value);
						}
						_id = value;
						this.NotifyPropertyChanged("Id");
					}
				}
			}
					
			
			public string Oab{
				get{
					return _oab;
				}
				set{
					if (_oab != value){
						if (OabAlterado != null){
							OabAlterado(_oab,value);
						}
						_oab = value;
						this.NotifyPropertyChanged("Oab");
					}
				}
			}
					
			
			public string Cpf{
				get{
					return _cpf;
				}
				set{
					if (_cpf != value){
						if (CpfAlterado != null){
							CpfAlterado(_cpf,value);
						}
						_cpf = value;
						this.NotifyPropertyChanged("Cpf");
					}
				}
			}
					
			
			public string Rg{
				get{
					return _rg;
				}
				set{
					if (_rg != value){
						if (RgAlterado != null){
							RgAlterado(_rg,value);
						}
						_rg = value;
						this.NotifyPropertyChanged("Rg");
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
						}
						_nome = value;
						this.NotifyPropertyChanged("Nome");
					}
				}
			}
					
			
			public bool? IndicadorEstagiario{
				get{
					return _indicadorEstagiario;
				}
				set{
					if (_indicadorEstagiario != value){
						if (IndicadorEstagiarioAlterado != null){
							IndicadorEstagiarioAlterado(_indicadorEstagiario,value);
						}
						_indicadorEstagiario = value;
						this.NotifyPropertyChanged("IndicadorEstagiario");
					}
				}
			}
					
			
			public EstadoCivil EstadoCivil{
				get{
					return _estadoCivil;
				}
				set{
					if (_estadoCivil != value){
						if (EstadoCivilAlterado != null){
							EstadoCivilAlterado(_estadoCivil,value);
						}
						_estadoCivil = value;
						this.NotifyPropertyChanged("EstadoCivil");
					}
				}
			}
					
			
			public string Naturalidade{
				get{
					return _naturalidade;
				}
				set{
					if (_naturalidade != value){
						if (NaturalidadeAlterado != null){
							NaturalidadeAlterado(_naturalidade,value);
						}
						_naturalidade = value;
						this.NotifyPropertyChanged("Naturalidade");
					}
				}
			}
					
			
			public string Nacionalidade{
				get{
					return _nacionalidade;
				}
				set{
					if (_nacionalidade != value){
						if (NacionalidadeAlterado != null){
							NacionalidadeAlterado(_nacionalidade,value);
						}
						_nacionalidade = value;
						this.NotifyPropertyChanged("Nacionalidade");
					}
				}
			}
					
			
			public char Sexo{
				get{
					return _sexo;
				}
				set{
					if (_sexo != value){
						if (SexoAlterado != null){
							SexoAlterado(_sexo,value);
						}
						_sexo = value;
						this.NotifyPropertyChanged("Sexo");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															Oab = default(string);
										
															Cpf = default(string);
										
															Rg = default(string);
										
															Nome = default(string);
										
															IndicadorEstagiario = default(bool?);
										
															EstadoCivil = default(EstadoCivil);
										
															Naturalidade = default(string);
										
															Nacionalidade = default(string);
										
															Sexo = default(char);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloAdvogado Clone(Func< ModeloAdvogado > criarObjeto){
				ModeloAdvogado clone = criarObjeto();
									clone.Id = this.Id;
									clone.Oab = this.Oab;
									clone.Cpf = this.Cpf;
									clone.Rg = this.Rg;
									clone.Nome = this.Nome;
									clone.IndicadorEstagiario = this.IndicadorEstagiario;
									clone.EstadoCivil = this.EstadoCivil;
									clone.Naturalidade = this.Naturalidade;
									clone.Nacionalidade = this.Nacionalidade;
									clone.Sexo = this.Sexo;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloAdvogado){
							return this.Id == ((ModeloAdvogado)obj).Id;
						}
						return false;
					}
																																																																						 	}
}
