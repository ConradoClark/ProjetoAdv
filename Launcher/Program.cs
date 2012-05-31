using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;

namespace Launcher
{
    class Program
    {
        static void Main(string[] args)
        {
            string versaoFile = Path.Combine(Environment.CurrentDirectory, "versao.ini");
            string versao = File.ReadAllText(versaoFile,Encoding.Unicode);
            string path = ConfigurationManager.AppSettings["PatchPath"];
            List<KeyValuePair<string, string>> patchesNaoAplicados = new List<KeyValuePair<string, string>>();
            bool update = false;

            if (!String.IsNullOrWhiteSpace(path))
            {
                foreach (String file in Directory.EnumerateFiles(Path.Combine(Environment.CurrentDirectory, path)))
                {
                    string hash = Encoding.Unicode.GetString(GetFileHash(file));
                    if (!versao.Contains(String.Format("[{0}]", hash)))
                    {
                        patchesNaoAplicados.Add(new KeyValuePair<string, string>(hash, file));
                        update = true;
                    }
                }
            }

            if (update)
            {
                Atualizacao form = new Atualizacao(versaoFile, patchesNaoAplicados);
                Application.Run(form);
            }
            else
            {
                Process app = new Process();
                app.StartInfo = new ProcessStartInfo(Path.Combine(Environment.CurrentDirectory, "Arch", "Visao.exe"));
                app.Start();
            }
        }

        static byte[] GetFileHash(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                return System.Security.Cryptography.MD5.Create().ComputeHash(fs);
            }
        }        
    }
}
