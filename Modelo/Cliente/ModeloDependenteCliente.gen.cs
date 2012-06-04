		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using Modelo.Comum;
			using System.ComponentModel;
	
namespace Modelo.Cliente{
	public abstract partial class ModeloDependenteCliente : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloDependenteCliente(){
																		ClienteAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		GrauParentescoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		IndCadastroAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
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
			#region Eventos do GrauParentesco
				public delegate void _grauParentescoAlterado(ModeloGrauParentesco valorAntigo, ModeloGrauParentesco valorNovo);
				public event _grauParentescoAlterado GrauParentescoAlterado;				
			#endregion			
			#region Eventos do Nome
				public delegate void _nomeAlterado(string valorAntigo, string valorNovo);
				public event _nomeAlterado NomeAlterado;				
			#endregion			
			#region Eventos do IndCadastro
				public delegate void _indCadastroAlterado(bool? valorAntigo, bool? valorNovo);
				public event _indCadastroAlterado IndCadastroAlterado;				
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
						}
						_cliente = value;
						this.NotifyPropertyChanged("Cliente");
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
						}
						_id = value;
						this.NotifyPropertyChanged("Id");
					}
				}
			}
					
			
			public ModeloGrauParentesco GrauParentesco{
				get{
					return _grauParentesco;
				}
				set{
					if (_grauParentesco != value){
						if (GrauParentescoAlterado != null){
							GrauParentescoAlterado(_grauParentesco,value);
						}
						_grauParentesco = value;
						this.NotifyPropertyChanged("GrauParentesco");
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
					
			
			public bool? IndCadastro{
				get{
					return _indCadastro;
				}
				set{
					if (_indCadastro != value){
						if (IndCadastroAlterado != null){
							IndCadastroAlterado(_indCadastro,value);
						}
						_indCadastro = value;
						this.NotifyPropertyChanged("IndCadastro");
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
						}
						_observacao = value;
						this.NotifyPropertyChanged("Observacao");
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
												
						Cliente.Limpar();
										
															Id = default(int?);
										
												
						GrauParentesco.Limpar();
										
															Nome = default(string);
										
															IndCadastro = default(bool?);
										
															Observacao = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloDependenteCliente Clone(Func< ModeloDependenteCliente > criarObjeto){
				ModeloDependenteCliente clone = criarObjeto();
									clone.Cliente = this.Cliente;
									clone.Id = this.Id;
									clone.GrauParentesco = this.GrauParentesco;
									clone.Nome = this.Nome;
									clone.IndCadastro = this.IndCadastro;
									clone.Observacao = this.Observacao;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
																			public override bool Equals(object obj){
						if (obj is ModeloDependenteCliente){
							return this.Id == ((ModeloDependenteCliente)obj).Id;
						}
						return false;
					}
																																			 	}
}
