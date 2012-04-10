using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Modelo.Comum;

namespace Estrutura
{
    public class Advogado : Modelo.Advogado.ModeloAdvogado
    {

        public Advogado()
            : base()
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
                return 0;
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
