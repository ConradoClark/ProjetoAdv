		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Comum;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloCliente(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomePaiAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeMaeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataNascimentoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ProfissaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TipoPessoaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CpfAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CnpjAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		RgAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataEmissaoRGAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		OrgaoExpedidorRGAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		EstadoCivilAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NacionalidadeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		EnderecoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		TituloEleitorAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		ZonaEleitoralAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		SecaoEleitoralAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Ctps1Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Ctps2Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Ctps3Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Ctps4Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Ctps5Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndGrupoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndContatoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndDependenteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndPendenciaAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndFalecidoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DataFalecimentoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NaturalidadeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PisPasep1Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PisPasep2Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PisPasep3Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		PisPasep4Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Nit1Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Nit2Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Nit3Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		Nit4Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CtpsSerie1Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CtpsSerie2Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CtpsSerie3Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CtpsSerie4Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		CtpsSerie5Alterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeClienteIndicacaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do Nome
				public delegate void _nomeAlterado(string valorAntigo, string valorNovo);
				public event _nomeAlterado NomeAlterado;				
			#endregion			
			#region Eventos do NomePai
				public delegate void _nomePaiAlterado(string valorAntigo, string valorNovo);
				public event _nomePaiAlterado NomePaiAlterado;				
			#endregion			
			#region Eventos do NomeMae
				public delegate void _nomeMaeAlterado(string valorAntigo, string valorNovo);
				public event _nomeMaeAlterado NomeMaeAlterado;				
			#endregion			
			#region Eventos do DataNascimento
				public delegate void _dataNascimentoAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _dataNascimentoAlterado DataNascimentoAlterado;				
			#endregion			
			#region Eventos do Profissao
				public delegate void _profissaoAlterado(string valorAntigo, string valorNovo);
				public event _profissaoAlterado ProfissaoAlterado;				
			#endregion			
			#region Eventos do TipoPessoa
				public delegate void _tipoPessoaAlterado(char? valorAntigo, char? valorNovo);
				public event _tipoPessoaAlterado TipoPessoaAlterado;				
			#endregion			
			#region Eventos do Cpf
				public delegate void _cpfAlterado(string valorAntigo, string valorNovo);
				public event _cpfAlterado CpfAlterado;				
			#endregion			
			#region Eventos do Cnpj
				public delegate void _cnpjAlterado(string valorAntigo, string valorNovo);
				public event _cnpjAlterado CnpjAlterado;				
			#endregion			
			#region Eventos do Rg
				public delegate void _rgAlterado(string valorAntigo, string valorNovo);
				public event _rgAlterado RgAlterado;				
			#endregion			
			#region Eventos do DataEmissaoRG
				public delegate void _dataEmissaoRGAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _dataEmissaoRGAlterado DataEmissaoRGAlterado;				
			#endregion			
			#region Eventos do OrgaoExpedidorRG
				public delegate void _orgaoExpedidorRGAlterado(string valorAntigo, string valorNovo);
				public event _orgaoExpedidorRGAlterado OrgaoExpedidorRGAlterado;				
			#endregion			
			#region Eventos do EstadoCivil
				public delegate void _estadoCivilAlterado(EstadoCivil valorAntigo, EstadoCivil valorNovo);
				public event _estadoCivilAlterado EstadoCivilAlterado;				
			#endregion			
			#region Eventos do Nacionalidade
				public delegate void _nacionalidadeAlterado(string valorAntigo, string valorNovo);
				public event _nacionalidadeAlterado NacionalidadeAlterado;				
			#endregion			
			#region Eventos do Endereco
				public delegate void _enderecoAlterado(ModeloEndereco valorAntigo, ModeloEndereco valorNovo);
				public event _enderecoAlterado EnderecoAlterado;				
			#endregion			
			#region Eventos do TituloEleitor
				public delegate void _tituloEleitorAlterado(string valorAntigo, string valorNovo);
				public event _tituloEleitorAlterado TituloEleitorAlterado;				
			#endregion			
			#region Eventos do ZonaEleitoral
				public delegate void _zonaEleitoralAlterado(string valorAntigo, string valorNovo);
				public event _zonaEleitoralAlterado ZonaEleitoralAlterado;				
			#endregion			
			#region Eventos do SecaoEleitoral
				public delegate void _secaoEleitoralAlterado(string valorAntigo, string valorNovo);
				public event _secaoEleitoralAlterado SecaoEleitoralAlterado;				
			#endregion			
			#region Eventos do Ctps1
				public delegate void _ctps1Alterado(string valorAntigo, string valorNovo);
				public event _ctps1Alterado Ctps1Alterado;				
			#endregion			
			#region Eventos do Ctps2
				public delegate void _ctps2Alterado(string valorAntigo, string valorNovo);
				public event _ctps2Alterado Ctps2Alterado;				
			#endregion			
			#region Eventos do Ctps3
				public delegate void _ctps3Alterado(string valorAntigo, string valorNovo);
				public event _ctps3Alterado Ctps3Alterado;				
			#endregion			
			#region Eventos do Ctps4
				public delegate void _ctps4Alterado(string valorAntigo, string valorNovo);
				public event _ctps4Alterado Ctps4Alterado;				
			#endregion			
			#region Eventos do Ctps5
				public delegate void _ctps5Alterado(string valorAntigo, string valorNovo);
				public event _ctps5Alterado Ctps5Alterado;				
			#endregion			
			#region Eventos do IndGrupo
				public delegate void _indGrupoAlterado(bool valorAntigo, bool valorNovo);
				public event _indGrupoAlterado IndGrupoAlterado;				
			#endregion			
			#region Eventos do IndCliente
				public delegate void _indClienteAlterado(bool valorAntigo, bool valorNovo);
				public event _indClienteAlterado IndClienteAlterado;				
			#endregion			
			#region Eventos do IndContato
				public delegate void _indContatoAlterado(bool valorAntigo, bool valorNovo);
				public event _indContatoAlterado IndContatoAlterado;				
			#endregion			
			#region Eventos do IndDependente
				public delegate void _indDependenteAlterado(bool valorAntigo, bool valorNovo);
				public event _indDependenteAlterado IndDependenteAlterado;				
			#endregion			
			#region Eventos do IndPendencia
				public delegate void _indPendenciaAlterado(bool valorAntigo, bool valorNovo);
				public event _indPendenciaAlterado IndPendenciaAlterado;				
			#endregion			
			#region Eventos do IndFalecido
				public delegate void _indFalecidoAlterado(bool valorAntigo, bool valorNovo);
				public event _indFalecidoAlterado IndFalecidoAlterado;				
			#endregion			
			#region Eventos do DataFalecimento
				public delegate void _dataFalecimentoAlterado(DateTime? valorAntigo, DateTime? valorNovo);
				public event _dataFalecimentoAlterado DataFalecimentoAlterado;				
			#endregion			
			#region Eventos do Naturalidade
				public delegate void _naturalidadeAlterado(string valorAntigo, string valorNovo);
				public event _naturalidadeAlterado NaturalidadeAlterado;				
			#endregion			
			#region Eventos do PisPasep1
				public delegate void _pisPasep1Alterado(string valorAntigo, string valorNovo);
				public event _pisPasep1Alterado PisPasep1Alterado;				
			#endregion			
			#region Eventos do PisPasep2
				public delegate void _pisPasep2Alterado(string valorAntigo, string valorNovo);
				public event _pisPasep2Alterado PisPasep2Alterado;				
			#endregion			
			#region Eventos do PisPasep3
				public delegate void _pisPasep3Alterado(string valorAntigo, string valorNovo);
				public event _pisPasep3Alterado PisPasep3Alterado;				
			#endregion			
			#region Eventos do PisPasep4
				public delegate void _pisPasep4Alterado(string valorAntigo, string valorNovo);
				public event _pisPasep4Alterado PisPasep4Alterado;				
			#endregion			
			#region Eventos do Nit1
				public delegate void _nit1Alterado(string valorAntigo, string valorNovo);
				public event _nit1Alterado Nit1Alterado;				
			#endregion			
			#region Eventos do Nit2
				public delegate void _nit2Alterado(string valorAntigo, string valorNovo);
				public event _nit2Alterado Nit2Alterado;				
			#endregion			
			#region Eventos do Nit3
				public delegate void _nit3Alterado(string valorAntigo, string valorNovo);
				public event _nit3Alterado Nit3Alterado;				
			#endregion			
			#region Eventos do Nit4
				public delegate void _nit4Alterado(string valorAntigo, string valorNovo);
				public event _nit4Alterado Nit4Alterado;				
			#endregion			
			#region Eventos do CtpsSerie1
				public delegate void _ctpsSerie1Alterado(string valorAntigo, string valorNovo);
				public event _ctpsSerie1Alterado CtpsSerie1Alterado;				
			#endregion			
			#region Eventos do CtpsSerie2
				public delegate void _ctpsSerie2Alterado(string valorAntigo, string valorNovo);
				public event _ctpsSerie2Alterado CtpsSerie2Alterado;				
			#endregion			
			#region Eventos do CtpsSerie3
				public delegate void _ctpsSerie3Alterado(string valorAntigo, string valorNovo);
				public event _ctpsSerie3Alterado CtpsSerie3Alterado;				
			#endregion			
			#region Eventos do CtpsSerie4
				public delegate void _ctpsSerie4Alterado(string valorAntigo, string valorNovo);
				public event _ctpsSerie4Alterado CtpsSerie4Alterado;				
			#endregion			
			#region Eventos do CtpsSerie5
				public delegate void _ctpsSerie5Alterado(string valorAntigo, string valorNovo);
				public event _ctpsSerie5Alterado CtpsSerie5Alterado;				
			#endregion			
			#region Eventos do NomeClienteIndicacao
				public delegate void _nomeClienteIndicacaoAlterado(string valorAntigo, string valorNovo);
				public event _nomeClienteIndicacaoAlterado NomeClienteIndicacaoAlterado;				
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
					[DisplayName("Nome do Pai")]
			
			public string NomePai{
				get{
					return _nomePai;
				}
				set{
					if (_nomePai != value){
						if (NomePaiAlterado != null){
							NomePaiAlterado(_nomePai,value);
						}
						_nomePai = value;
						this.NotifyPropertyChanged("NomePai");
					}
				}
			}
					[DisplayName("Nome da Mãe")]
			
			public string NomeMae{
				get{
					return _nomeMae;
				}
				set{
					if (_nomeMae != value){
						if (NomeMaeAlterado != null){
							NomeMaeAlterado(_nomeMae,value);
						}
						_nomeMae = value;
						this.NotifyPropertyChanged("NomeMae");
					}
				}
			}
					[DisplayName("Data de Nascimento")]
			
			public DateTime? DataNascimento{
				get{
					return _dataNascimento;
				}
				set{
					if (_dataNascimento != value){
						if (DataNascimentoAlterado != null){
							DataNascimentoAlterado(_dataNascimento,value);
						}
						_dataNascimento = value;
						this.NotifyPropertyChanged("DataNascimento");
					}
				}
			}
					[DisplayName("Profissão")]
			
			public string Profissao{
				get{
					return _profissao;
				}
				set{
					if (_profissao != value){
						if (ProfissaoAlterado != null){
							ProfissaoAlterado(_profissao,value);
						}
						_profissao = value;
						this.NotifyPropertyChanged("Profissao");
					}
				}
			}
					
			[Browsable(false)]
			public char? TipoPessoa{
				get{
					return _tipoPessoa;
				}
				set{
					if (_tipoPessoa != value){
						if (TipoPessoaAlterado != null){
							TipoPessoaAlterado(_tipoPessoa,value);
						}
						_tipoPessoa = value;
						this.NotifyPropertyChanged("TipoPessoa");
					}
				}
			}
					[DisplayName("CPF")]
			
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
					[DisplayName("CNPJ")]
			
			public string Cnpj{
				get{
					return _cnpj;
				}
				set{
					if (_cnpj != value){
						if (CnpjAlterado != null){
							CnpjAlterado(_cnpj,value);
						}
						_cnpj = value;
						this.NotifyPropertyChanged("Cnpj");
					}
				}
			}
					[DisplayName("RG")]
			
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
					[DisplayName("Data de Emissão do RG")]
			
			public DateTime? DataEmissaoRG{
				get{
					return _dataEmissaoRG;
				}
				set{
					if (_dataEmissaoRG != value){
						if (DataEmissaoRGAlterado != null){
							DataEmissaoRGAlterado(_dataEmissaoRG,value);
						}
						_dataEmissaoRG = value;
						this.NotifyPropertyChanged("DataEmissaoRG");
					}
				}
			}
					[DisplayName("Órgão Expedidor do RG")]
			
			public string OrgaoExpedidorRG{
				get{
					return _orgaoExpedidorRG;
				}
				set{
					if (_orgaoExpedidorRG != value){
						if (OrgaoExpedidorRGAlterado != null){
							OrgaoExpedidorRGAlterado(_orgaoExpedidorRG,value);
						}
						_orgaoExpedidorRG = value;
						this.NotifyPropertyChanged("OrgaoExpedidorRG");
					}
				}
			}
					[DisplayName("Estado Civil")]
			
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
					
			
			public ModeloEndereco Endereco{
				get{
					return _endereco;
				}
				set{
					if (_endereco != value){
						if (EnderecoAlterado != null){
							EnderecoAlterado(_endereco,value);
						}
						_endereco = value;
						this.NotifyPropertyChanged("Endereco");
					}
				}
			}
					[DisplayName("Título de Eleitor")]
			
			public string TituloEleitor{
				get{
					return _tituloEleitor;
				}
				set{
					if (_tituloEleitor != value){
						if (TituloEleitorAlterado != null){
							TituloEleitorAlterado(_tituloEleitor,value);
						}
						_tituloEleitor = value;
						this.NotifyPropertyChanged("TituloEleitor");
					}
				}
			}
					[DisplayName("Zona Eleitoral")]
			
			public string ZonaEleitoral{
				get{
					return _zonaEleitoral;
				}
				set{
					if (_zonaEleitoral != value){
						if (ZonaEleitoralAlterado != null){
							ZonaEleitoralAlterado(_zonaEleitoral,value);
						}
						_zonaEleitoral = value;
						this.NotifyPropertyChanged("ZonaEleitoral");
					}
				}
			}
					[DisplayName("Seção Eleitoral")]
			
			public string SecaoEleitoral{
				get{
					return _secaoEleitoral;
				}
				set{
					if (_secaoEleitoral != value){
						if (SecaoEleitoralAlterado != null){
							SecaoEleitoralAlterado(_secaoEleitoral,value);
						}
						_secaoEleitoral = value;
						this.NotifyPropertyChanged("SecaoEleitoral");
					}
				}
			}
					
			
			public string Ctps1{
				get{
					return _ctps1;
				}
				set{
					if (_ctps1 != value){
						if (Ctps1Alterado != null){
							Ctps1Alterado(_ctps1,value);
						}
						_ctps1 = value;
						this.NotifyPropertyChanged("Ctps1");
					}
				}
			}
					
			
			public string Ctps2{
				get{
					return _ctps2;
				}
				set{
					if (_ctps2 != value){
						if (Ctps2Alterado != null){
							Ctps2Alterado(_ctps2,value);
						}
						_ctps2 = value;
						this.NotifyPropertyChanged("Ctps2");
					}
				}
			}
					
			
			public string Ctps3{
				get{
					return _ctps3;
				}
				set{
					if (_ctps3 != value){
						if (Ctps3Alterado != null){
							Ctps3Alterado(_ctps3,value);
						}
						_ctps3 = value;
						this.NotifyPropertyChanged("Ctps3");
					}
				}
			}
					
			
			public string Ctps4{
				get{
					return _ctps4;
				}
				set{
					if (_ctps4 != value){
						if (Ctps4Alterado != null){
							Ctps4Alterado(_ctps4,value);
						}
						_ctps4 = value;
						this.NotifyPropertyChanged("Ctps4");
					}
				}
			}
					
			
			public string Ctps5{
				get{
					return _ctps5;
				}
				set{
					if (_ctps5 != value){
						if (Ctps5Alterado != null){
							Ctps5Alterado(_ctps5,value);
						}
						_ctps5 = value;
						this.NotifyPropertyChanged("Ctps5");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndGrupo{
				get{
					return _indGrupo;
				}
				set{
					if (_indGrupo != value){
						if (IndGrupoAlterado != null){
							IndGrupoAlterado(_indGrupo,value);
						}
						_indGrupo = value;
						this.NotifyPropertyChanged("IndGrupo");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndCliente{
				get{
					return _indCliente;
				}
				set{
					if (_indCliente != value){
						if (IndClienteAlterado != null){
							IndClienteAlterado(_indCliente,value);
						}
						_indCliente = value;
						this.NotifyPropertyChanged("IndCliente");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndContato{
				get{
					return _indContato;
				}
				set{
					if (_indContato != value){
						if (IndContatoAlterado != null){
							IndContatoAlterado(_indContato,value);
						}
						_indContato = value;
						this.NotifyPropertyChanged("IndContato");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndDependente{
				get{
					return _indDependente;
				}
				set{
					if (_indDependente != value){
						if (IndDependenteAlterado != null){
							IndDependenteAlterado(_indDependente,value);
						}
						_indDependente = value;
						this.NotifyPropertyChanged("IndDependente");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndPendencia{
				get{
					return _indPendencia;
				}
				set{
					if (_indPendencia != value){
						if (IndPendenciaAlterado != null){
							IndPendenciaAlterado(_indPendencia,value);
						}
						_indPendencia = value;
						this.NotifyPropertyChanged("IndPendencia");
					}
				}
			}
					
			[Browsable(false)]
			public bool IndFalecido{
				get{
					return _indFalecido;
				}
				set{
					if (_indFalecido != value){
						if (IndFalecidoAlterado != null){
							IndFalecidoAlterado(_indFalecido,value);
						}
						_indFalecido = value;
						this.NotifyPropertyChanged("IndFalecido");
					}
				}
			}
					[DisplayName("Data do Falecimento")]
			
			public DateTime? DataFalecimento{
				get{
					return _dataFalecimento;
				}
				set{
					if (_dataFalecimento != value){
						if (DataFalecimentoAlterado != null){
							DataFalecimentoAlterado(_dataFalecimento,value);
						}
						_dataFalecimento = value;
						this.NotifyPropertyChanged("DataFalecimento");
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
					
			
			public string PisPasep1{
				get{
					return _pisPasep1;
				}
				set{
					if (_pisPasep1 != value){
						if (PisPasep1Alterado != null){
							PisPasep1Alterado(_pisPasep1,value);
						}
						_pisPasep1 = value;
						this.NotifyPropertyChanged("PisPasep1");
					}
				}
			}
					
			
			public string PisPasep2{
				get{
					return _pisPasep2;
				}
				set{
					if (_pisPasep2 != value){
						if (PisPasep2Alterado != null){
							PisPasep2Alterado(_pisPasep2,value);
						}
						_pisPasep2 = value;
						this.NotifyPropertyChanged("PisPasep2");
					}
				}
			}
					
			
			public string PisPasep3{
				get{
					return _pisPasep3;
				}
				set{
					if (_pisPasep3 != value){
						if (PisPasep3Alterado != null){
							PisPasep3Alterado(_pisPasep3,value);
						}
						_pisPasep3 = value;
						this.NotifyPropertyChanged("PisPasep3");
					}
				}
			}
					
			
			public string PisPasep4{
				get{
					return _pisPasep4;
				}
				set{
					if (_pisPasep4 != value){
						if (PisPasep4Alterado != null){
							PisPasep4Alterado(_pisPasep4,value);
						}
						_pisPasep4 = value;
						this.NotifyPropertyChanged("PisPasep4");
					}
				}
			}
					
			
			public string Nit1{
				get{
					return _nit1;
				}
				set{
					if (_nit1 != value){
						if (Nit1Alterado != null){
							Nit1Alterado(_nit1,value);
						}
						_nit1 = value;
						this.NotifyPropertyChanged("Nit1");
					}
				}
			}
					
			
			public string Nit2{
				get{
					return _nit2;
				}
				set{
					if (_nit2 != value){
						if (Nit2Alterado != null){
							Nit2Alterado(_nit2,value);
						}
						_nit2 = value;
						this.NotifyPropertyChanged("Nit2");
					}
				}
			}
					
			
			public string Nit3{
				get{
					return _nit3;
				}
				set{
					if (_nit3 != value){
						if (Nit3Alterado != null){
							Nit3Alterado(_nit3,value);
						}
						_nit3 = value;
						this.NotifyPropertyChanged("Nit3");
					}
				}
			}
					
			
			public string Nit4{
				get{
					return _nit4;
				}
				set{
					if (_nit4 != value){
						if (Nit4Alterado != null){
							Nit4Alterado(_nit4,value);
						}
						_nit4 = value;
						this.NotifyPropertyChanged("Nit4");
					}
				}
			}
					
			
			public string CtpsSerie1{
				get{
					return _ctpsSerie1;
				}
				set{
					if (_ctpsSerie1 != value){
						if (CtpsSerie1Alterado != null){
							CtpsSerie1Alterado(_ctpsSerie1,value);
						}
						_ctpsSerie1 = value;
						this.NotifyPropertyChanged("CtpsSerie1");
					}
				}
			}
					
			
			public string CtpsSerie2{
				get{
					return _ctpsSerie2;
				}
				set{
					if (_ctpsSerie2 != value){
						if (CtpsSerie2Alterado != null){
							CtpsSerie2Alterado(_ctpsSerie2,value);
						}
						_ctpsSerie2 = value;
						this.NotifyPropertyChanged("CtpsSerie2");
					}
				}
			}
					
			
			public string CtpsSerie3{
				get{
					return _ctpsSerie3;
				}
				set{
					if (_ctpsSerie3 != value){
						if (CtpsSerie3Alterado != null){
							CtpsSerie3Alterado(_ctpsSerie3,value);
						}
						_ctpsSerie3 = value;
						this.NotifyPropertyChanged("CtpsSerie3");
					}
				}
			}
					
			
			public string CtpsSerie4{
				get{
					return _ctpsSerie4;
				}
				set{
					if (_ctpsSerie4 != value){
						if (CtpsSerie4Alterado != null){
							CtpsSerie4Alterado(_ctpsSerie4,value);
						}
						_ctpsSerie4 = value;
						this.NotifyPropertyChanged("CtpsSerie4");
					}
				}
			}
					
			
			public string CtpsSerie5{
				get{
					return _ctpsSerie5;
				}
				set{
					if (_ctpsSerie5 != value){
						if (CtpsSerie5Alterado != null){
							CtpsSerie5Alterado(_ctpsSerie5,value);
						}
						_ctpsSerie5 = value;
						this.NotifyPropertyChanged("CtpsSerie5");
					}
				}
			}
					[DisplayName("Indicado Por?")]
			
			public string NomeClienteIndicacao{
				get{
					return _nomeClienteIndicacao;
				}
				set{
					if (_nomeClienteIndicacao != value){
						if (NomeClienteIndicacaoAlterado != null){
							NomeClienteIndicacaoAlterado(_nomeClienteIndicacao,value);
						}
						_nomeClienteIndicacao = value;
						this.NotifyPropertyChanged("NomeClienteIndicacao");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															Nome = default(string);
										
															NomePai = default(string);
										
															NomeMae = default(string);
										
															DataNascimento = default(DateTime?);
										
															Profissao = default(string);
										
															TipoPessoa = default(char?);
										
															Cpf = default(string);
										
															Cnpj = default(string);
										
															Rg = default(string);
										
															DataEmissaoRG = default(DateTime?);
										
															OrgaoExpedidorRG = default(string);
										
															EstadoCivil = default(EstadoCivil);
										
															Nacionalidade = default(string);
										
												
						Endereco.Limpar();
										
															TituloEleitor = default(string);
										
															ZonaEleitoral = default(string);
										
															SecaoEleitoral = default(string);
										
															Ctps1 = default(string);
										
															Ctps2 = default(string);
										
															Ctps3 = default(string);
										
															Ctps4 = default(string);
										
															Ctps5 = default(string);
										
															IndGrupo = default(bool);
										
															IndCliente = default(bool);
										
															IndContato = default(bool);
										
															IndDependente = default(bool);
										
															IndPendencia = default(bool);
										
															IndFalecido = default(bool);
										
															DataFalecimento = default(DateTime?);
										
															Naturalidade = default(string);
										
															PisPasep1 = default(string);
										
															PisPasep2 = default(string);
										
															PisPasep3 = default(string);
										
															PisPasep4 = default(string);
										
															Nit1 = default(string);
										
															Nit2 = default(string);
										
															Nit3 = default(string);
										
															Nit4 = default(string);
										
															CtpsSerie1 = default(string);
										
															CtpsSerie2 = default(string);
										
															CtpsSerie3 = default(string);
										
															CtpsSerie4 = default(string);
										
															CtpsSerie5 = default(string);
										
															NomeClienteIndicacao = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloCliente Clone(Func< ModeloCliente > criarObjeto){
				ModeloCliente clone = criarObjeto();
									clone.Id = this.Id;
									clone.Nome = this.Nome;
									clone.NomePai = this.NomePai;
									clone.NomeMae = this.NomeMae;
									clone.DataNascimento = this.DataNascimento;
									clone.Profissao = this.Profissao;
									clone.TipoPessoa = this.TipoPessoa;
									clone.Cpf = this.Cpf;
									clone.Cnpj = this.Cnpj;
									clone.Rg = this.Rg;
									clone.DataEmissaoRG = this.DataEmissaoRG;
									clone.OrgaoExpedidorRG = this.OrgaoExpedidorRG;
									clone.EstadoCivil = this.EstadoCivil;
									clone.Nacionalidade = this.Nacionalidade;
									clone.Endereco = this.Endereco;
									clone.TituloEleitor = this.TituloEleitor;
									clone.ZonaEleitoral = this.ZonaEleitoral;
									clone.SecaoEleitoral = this.SecaoEleitoral;
									clone.Ctps1 = this.Ctps1;
									clone.Ctps2 = this.Ctps2;
									clone.Ctps3 = this.Ctps3;
									clone.Ctps4 = this.Ctps4;
									clone.Ctps5 = this.Ctps5;
									clone.IndGrupo = this.IndGrupo;
									clone.IndCliente = this.IndCliente;
									clone.IndContato = this.IndContato;
									clone.IndDependente = this.IndDependente;
									clone.IndPendencia = this.IndPendencia;
									clone.IndFalecido = this.IndFalecido;
									clone.DataFalecimento = this.DataFalecimento;
									clone.Naturalidade = this.Naturalidade;
									clone.PisPasep1 = this.PisPasep1;
									clone.PisPasep2 = this.PisPasep2;
									clone.PisPasep3 = this.PisPasep3;
									clone.PisPasep4 = this.PisPasep4;
									clone.Nit1 = this.Nit1;
									clone.Nit2 = this.Nit2;
									clone.Nit3 = this.Nit3;
									clone.Nit4 = this.Nit4;
									clone.CtpsSerie1 = this.CtpsSerie1;
									clone.CtpsSerie2 = this.CtpsSerie2;
									clone.CtpsSerie3 = this.CtpsSerie3;
									clone.CtpsSerie4 = this.CtpsSerie4;
									clone.CtpsSerie5 = this.CtpsSerie5;
									clone.NomeClienteIndicacao = this.NomeClienteIndicacao;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloCliente){
							return this.Id == ((ModeloCliente)obj).Id;
						}
						return false;
					}
																																																																																																																																																																																																																																																																																																																											 	}
}
