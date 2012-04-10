using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Dynamic;
using MySql.Data.MySqlClient;

namespace Dados
{
    public class ObjetoBanco : DynamicObject
    {
        private MySqlDataReader _reader;
        public MySqlDataReader Reader{
            get
            {
                return _reader;
            }
        }

        public ObjetoBanco(MySqlDataReader reader)
        {
            this._reader = reader;
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (_reader == null)
            {
                throw new Exception("Reader está nulo");
            }
            string column = binder.Name;
            try
            {
                result = _reader[column];
                if (result is DBNull)
                {
                    result = null;
                }
                return true;
            }
            catch (IndexOutOfRangeException)
            {
                throw new Exceptions.CampoNaoEncontrado(column);
            }
        }
    }
}
