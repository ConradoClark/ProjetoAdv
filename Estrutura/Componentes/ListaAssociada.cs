using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Estrutura
{
    public class ListaAssociada<T> : BindingList<T>
    {
        private Func<T> CriacaoObjeto { get; set; }
        private Func<T, object> CriacaoObjeto2 { get; set; }

        public ListaAssociada(Func<T> criacaoObjeto)
        {
            CriacaoObjeto = criacaoObjeto;
            this.AllowNew = true;
        }

        protected override object AddNewCore()
        {
            lock (this)
            {
                T obj = CriacaoObjeto();
                this.OnAddingNew(new AddingNewEventArgs(obj));
                this.Add(obj);
                return obj;
            }
        }
        protected override bool SupportsChangeNotificationCore
        {
            get
            {
                return true;
            }
        }
    }
}
