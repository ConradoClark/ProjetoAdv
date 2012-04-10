using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estrutura
{
    public class Pendencia : Modelo.Pendencia.ModeloPendencia
    {
        public Pendencia()
            : base()
        {            
        }
        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            Dados.AcessoPendencia.InserirPendencia(this);

        }
        public void Alterar()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoPendencia.AlterarPendencia(this);
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoPendencia.RemoverPendencia(this);
        }
        public bool Obter()
        {
            return Dados.AcessoPendencia.ObterPendencia(this);
        }
    }

    public static class Pendencias
    {
        public static IEnumerable<Modelo.Pendencia.ModeloPendencia> Listar(Func<Modelo.Pendencia.ModeloPendencia> criacaoPendencia)
        {
            return Dados.AcessoPendencia.ListarPendencia(criacaoPendencia);
        }

        public static ListaAssociada<Pendencia> ListarAssociado()
        {
            Func<Pendencia> func = () => new Pendencia();
            ListaAssociada<Pendencia> pend = new ListaAssociada<Pendencia>(func);
            foreach (Modelo.Pendencia.ModeloPendencia pendencia in Dados.AcessoPendencia.ListarPendencia(func)){
                pend.Add((Pendencia)pendencia);
            }
            return pend;
        }
    }
}
