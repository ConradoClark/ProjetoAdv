using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exceptions
{
    public class CampoNaoEncontrado : Exception
    {

        private string _campo;

        public CampoNaoEncontrado(string campo)
        {
            this._campo = campo;
        }
        public override string Message
        {
            get
            {
                return String.Format("Campo {0} não encontrado na query executada", _campo);
            }
        }
    }
}
