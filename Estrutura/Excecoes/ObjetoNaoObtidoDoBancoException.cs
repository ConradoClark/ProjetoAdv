using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estrutura
{
    public class ObjetoNaoObtidoDoBancoException : Exception
    {
        Type type;
        public ObjetoNaoObtidoDoBancoException(Type type)
        {
            this.type = type;
        }

        public override string Message
        {
            get
            {
                return String.Format("Operação remover/alterar não permitida, pois o objeto {0} não foi obtido do banco",type);
            }
        }
    }
}
