using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;
using System.Collections.ObjectModel;

namespace Estrutura
{
    public class Advogado : Modelo.Advogado.ModeloAdvogado
    {
        public ObservableCollection<ProcessoAdvogado> Processos { get; private set; }        

        public Advogado()
            : base()
        {                        
            this.Processos = new ObservableCollection<ProcessoAdvogado>();
            this.Processos.CollectionChanged += (sender, args) => Processos.ToList().ForEach((proadv) =>
            {
                switch (args.Action)
                {
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                        if (proadv.Advogado != this)
                        {
                            proadv.Advogado = this;
                        }
                        break;
                    case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                        if (proadv.Advogado == this)
                        {
                            proadv.Advogado = null;
                        }
                        break;
                }
            });
        }

        public Advogado(Processo processo)
            : this()
        {
        }

        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            Dados.AcessoAdvogado.InserirAdvogado(this);
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoAdvogado.RemoverAdvogado(this);
            this.Id = null;
        }

        public void Salvar()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoAdvogado.AlterarAdvogado(this);
        }

        public bool Obter()
        {
            return Dados.AcessoAdvogado.ObterAdvogado(this);
        }

        public int QuantidadeProcessos
        {
            get
            {
                return Processos.Count;
            }
        }

        public Modelo.Advogado.ModeloAdvogado Self
        {
            get
            {
                return (Modelo.Advogado.ModeloAdvogado) this;
            }
        }
    }

    public static class Advogados
    {
        public static IEnumerable<Modelo.Advogado.ModeloAdvogado> Listar()
        {
            return Dados.AcessoAdvogado.ListarAdvogado(() => (Modelo.Advogado.ModeloAdvogado)new Advogado());
        }

        public static ListaAssociada<Advogado> ObterListaAssociada()
        {
            ListaAssociada<Advogado> adv
                = new ListaAssociada<Advogado>(() => new Advogado());

            foreach (Modelo.Advogado.ModeloAdvogado advogado in
                Dados.AcessoAdvogado.ListarAdvogado(() => (Modelo.Advogado.ModeloAdvogado)new Advogado()))
            {
                adv.Add((Advogado)advogado);
            }
            return adv;
        }
    }
}
