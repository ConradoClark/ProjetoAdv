


		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Acao{
	public abstract partial class ModeloTipoAcao : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			public override bool Sujo{get;set;}
			public ModeloTipoAcao(){
																		IdAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
																		DescricaoAlterado+= (_old,_new) =>{if (_old!=_new) Sujo=true;};
							
								}
     		#region Eventos do Id
				public delegate void _idAlterado(int? valorAntigo, int? valorNovo);
				public event _idAlterado IdAlterado;				
			#endregion			
			#region Eventos do Descricao
				public delegate void _descricaoAlterado(string valorAntigo, string valorNovo);
				public event _descricaoAlterado DescricaoAlterado;				
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
					public string Descricao{
				get{
					return _descricao;
				}
				set{
					if (_descricao != value){
						if (DescricaoAlterado != null){
							DescricaoAlterado(_descricao,value);
							this.NotifyPropertyChanged("Descricao");
						}
						_descricao = value;
					}
				}
			}
					public override void Limpar(){
			    this.OrigemDados = Modelo.Comum.OrigemDados.Local;
															Id = default(int?);
										
															Descricao = default(string);
										
							}
			private void NotifyPropertyChanged(string name)
  			{
    			if(PropertyChanged != null)
      				PropertyChanged(this, new PropertyChangedEventArgs(name));
  			}
			public ModeloTipoAcao Clone(Func< ModeloTipoAcao > criarObjeto){
				ModeloTipoAcao clone = criarObjeto();
									clone.Id = this.Id;
									clone.Descricao = this.Descricao;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloTipoAcao){
							return this.Id == ((ModeloTipoAcao)obj).Id;
						}
						return false;
					}
														 	}
}
