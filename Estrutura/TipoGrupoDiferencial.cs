using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dados;

namespace Estrutura
{
    public class TipoGrupoDiferencial : Modelo.GrupoDiferencial.ModeloGrupoDiferencial
    {
        public TipoGrupoDiferencial() : base() { }
        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            AcessoGrupoDiferencial.RemoverGrupoDiferencial(this);            
        }

        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            AcessoGrupoDiferencial.InserirGrupoDiferencial(this);
        }

        public void Alterar()
        {
            this.ConferirOrigemParaManipularDados();
            AcessoGrupoDiferencial.AlterarGrupoDiferencial(this);
        }

        public void Obter()
        {
            AcessoGrupoDiferencial.ObterGrupoDiferencial(this);
        }

        public int QuantidadeClientes
        {
            get
            {
                int count = 0;
                List<Modelo.Cliente.ModeloGrupoDiferencialCliente> lista = TiposGrupoDiferencial.ListarAssociacao().ToList();
                foreach (Modelo.Cliente.ModeloGrupoDiferencialCliente c in lista)
                {
                    if (c.GrupoDiferencial.Id == this.Id)
                    {
                        count++;
                    }
                }
                return count;
            }
        }
    }

    public static class TiposGrupoDiferencial
    {
        public static IEnumerable<Modelo.GrupoDiferencial.ModeloGrupoDiferencial> Listar()
        {
            return AcessoGrupoDiferencial.ListarGrupoDiferencial(() => (Modelo.GrupoDiferencial.ModeloGrupoDiferencial)new TipoGrupoDiferencial());
        }

        public static IEnumerable<Modelo.Cliente.ModeloGrupoDiferencialCliente> ListarAssociacao()
        {
            return AcessoGrupoDiferencial.ListarGrupoDiferencialAssociacao(() => new GrupoDiferencial(new TipoGrupoDiferencial(), null));
        }

        public static ListaAssociada<TipoGrupoDiferencial> ObterListaAssociada()
        {
            ListaAssociada<TipoGrupoDiferencial> grp
                = new ListaAssociada<TipoGrupoDiferencial>(() => new TipoGrupoDiferencial());

            foreach (Modelo.GrupoDiferencial.ModeloGrupoDiferencial grupo in
                AcessoGrupoDiferencial.ListarGrupoDiferencial(() => (Modelo.GrupoDiferencial.ModeloGrupoDiferencial)new TipoGrupoDiferencial()))
            {
                grp.Add((TipoGrupoDiferencial)grupo);
            }
            return grp;
        }

        public static IEnumerable<GrupoDiferencial> ListarPorCliente(Cliente cliente)
        {
            return AcessoGrupoDiferencial.ListarGrupoDiferencial(() => (Modelo.GrupoDiferencial.ModeloGrupoDiferencial)new TipoGrupoDiferencial())
                .Select((obj) => new GrupoDiferencial(obj, cliente));
        }


    }


}
