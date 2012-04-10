using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;

namespace Estrutura
{
    public class TipoBeneficio : Modelo.Beneficio.ModeloTipoBeneficio
    {
        public TipoBeneficio(): base(){}

        public Modelo.Beneficio.ModeloTipoBeneficio Self
        {
            get { return this; }
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            AcessoTipoBeneficio.RemoverTipoBeneficio(this);
        }

        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            AcessoTipoBeneficio.InserirTipoBeneficio(this);
        }

        public void Alterar()
        {
            this.ConferirOrigemParaManipularDados();
            AcessoTipoBeneficio.AlterarTipoBeneficio(this);
        }

        public void Obter()
        {
            AcessoTipoBeneficio.ObterTipoBeneficio(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is TipoBeneficio)
            {
                return this.Id == ((TipoBeneficio)obj).Id;
            }
            return base.Equals(obj);
        }

        public int QuantidadeClientes
        {
            get
            {
                int count = 0;
                List<Modelo.Cliente.ModeloBeneficioCliente> lista = 
                    TiposBeneficio.ListarAssociacao().ToList();
                foreach (Modelo.Cliente.ModeloBeneficioCliente c in lista)
                {
                    if (c.TipoBeneficio.Id == this.Id)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }

    public static class TiposBeneficio
    {
        public delegate void single();
        public static event single Atualizar;

        static TiposBeneficio()
        {
            Atualizar += () => { };
        }

        public static void DispararAtualizacao(){
            Atualizar();
        }

        public static IEnumerable<Modelo.Beneficio.ModeloTipoBeneficio> Listar()
        {
            return AcessoTipoBeneficio.ListarTipoBeneficio(() => new TipoBeneficio());
        }

        public static IEnumerable<Modelo.Cliente.ModeloBeneficioCliente> ListarAssociacao()
        {
            return AcessoTipoBeneficio.ListarBeneficioAssociacao(() => new Beneficio(new TipoBeneficio(),null));
        }

        public static ListaAssociada<TipoBeneficio> ObterListaAssociada()
        {
            ListaAssociada<TipoBeneficio> grp
                = new ListaAssociada<TipoBeneficio>(() => new TipoBeneficio());

            foreach (Modelo.Beneficio.ModeloTipoBeneficio grupo in
                AcessoTipoBeneficio.ListarTipoBeneficio(() => (Modelo.Beneficio.ModeloTipoBeneficio)new TipoBeneficio()))
            {
                grp.Add((TipoBeneficio)grupo);
            }
            return grp;
        }
    }
}
