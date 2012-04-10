using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Visao
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new CadastroGrupoDiferencial());
            //Application.Run(new CadastroCliente());
            Application.Run(new TelaPrincipal());
        }
    }
}
