using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estrutura
{
    public class ObjetoJaObtidoDoBancoException : Exception
    {
        Type type;
        public ObjetoJaObtidoDoBancoException(Type type)
        {
            this.type = type;
        }

        public override string Message
        {
            get
            {
                return String.Format("Operação inserir não permitida, pois o objeto {0} já foi obtido do banco. Crie um novo objeto para inserir.",type);
            }
        }
    }
}
