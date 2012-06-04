		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.GrupoDiferencial{
	public abstract partial class ModeloGrupoDiferencial : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloGrupoDiferencial(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		NomeAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do Nome
				public delegate void _nomeAlterado(string valorAntigo, string valorNovo);
				public event _nomeAlterado NomeAlterado;				
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
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															Nome = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloGrupoDiferencial Clone(Func< ModeloGrupoDiferencial > criarObjeto){
				ModeloGrupoDiferencial clone = criarObjeto();
									clone.Id = this.Id;
									clone.Nome = this.Nome;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloGrupoDiferencial){
							return this.Id == ((ModeloGrupoDiferencial)obj).Id;
						}
						return false;
					}
														 	}
}
