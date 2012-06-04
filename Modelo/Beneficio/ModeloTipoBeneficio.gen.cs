		using System;
			using System.Collections.Generic;
			using System.Linq;
			using System.Text;
			using System.ComponentModel;
	
namespace Modelo.Beneficio{
	public abstract partial class ModeloTipoBeneficio : Modelo.Comum.ModeloBase, INotifyPropertyChanged
    {	
	        public  new event PropertyChangedEventHandler PropertyChanged;
			[Browsable(false)]
			public override bool Sujo{get;set;}
			public ModeloTipoBeneficio(){
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
						}
						_id = value;
						this.NotifyPropertyChanged("Id");
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
						}
						_descricao = value;
						this.NotifyPropertyChanged("Descricao");
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
			public ModeloTipoBeneficio Clone(Func< ModeloTipoBeneficio > criarObjeto){
				ModeloTipoBeneficio clone = criarObjeto();
									clone.Id = this.Id;
									clone.Descricao = this.Descricao;
								clone.OrigemDados = this.OrigemDados;
				return clone;
			}
												public override bool Equals(object obj){
						if (obj is ModeloTipoBeneficio){
							return this.Id == ((ModeloTipoBeneficio)obj).Id;
						}
						return false;
					}
														 	}
}
