using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisaoControles
{
    class Test
    {
        static void Main(string[] args)
        {
            DialogResult dr = DialogoAlerta.Mostrar("Aviso","Testando o diálogo de alerta",System.Windows.Forms.MessageBoxIcon.Exclamation,MessageBoxButtons.OKCancel);
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("OK!");
            }else{
                MessageBox.Show("CANCEL!");
            }
        }
    }
}
