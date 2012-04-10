using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estrutura
{
    public static class ExtensoesEstrutura
    {
        public static void ConferirOrigemParaInserir(this Modelo.Comum.ModeloBase modelo){
            if (modelo.OrigemDados == Modelo.Comum.OrigemDados.Banco)
            {
                throw new ObjetoJaObtidoDoBancoException(modelo.GetType());
            }
        }
        public static void ConferirOrigemParaManipularDados(this Modelo.Comum.ModeloBase modelo)
        {
            if (modelo.OrigemDados == Modelo.Comum.OrigemDados.Local)
            {
                throw new ObjetoNaoObtidoDoBancoException(modelo.GetType());
            }
        }
    }
}
