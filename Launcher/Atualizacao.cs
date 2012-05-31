using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Shell32;
using System.Diagnostics;

namespace Launcher
{
    public partial class Atualizacao : Form
    {
        private int _progress;
        public int Progress
        {
            get { return _progress; }
            set
            {
                if (value != _progress)
                {
                    _progress = value;
                    progress.Value = _progress;
                }
            }
        }

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set
            {
                if (value != _texto)
                {
                    _texto = value;
                    lblProgresso.Text = _texto;
                }
            }
        }

        public int ProgressMax { get; set; }
        public Atualizacao(string versaoFile, List<KeyValuePair<string, string>> patchesNaoAplicados)
        {
            InitializeComponent();
            ProgressMax = progress.Maximum;

            Thread t = new Thread(new ThreadStart(() => {
                patchesNaoAplicados.Sort(new DateModifiedComparer());
                float i = 0;
                foreach (KeyValuePair<string, string> file in patchesNaoAplicados)
                {
                    this.Invoke(new Action(() => Texto = "Instalando patch: " + Path.GetFileName(file.Value)));
                    if (file.Value.EndsWith(".zip"))
                    {
                        if (ExpandFolder(file.Value, Path.Combine(Environment.CurrentDirectory, "Arch")))
                        {
                            string a = File.ReadAllText(versaoFile, Encoding.Unicode);
                            Console.WriteLine(a);
                            using (FileStream fs = File.OpenWrite(versaoFile))
                            {
                                string add = a+String.Format("[{0}]\n", file.Key);
                                fs.Write(Encoding.Unicode.GetBytes(add), 0, Encoding.Unicode.GetByteCount(add));
                                fs.Close();
                            }
                        }
                    }
                    i++;
                    this.Invoke(new Action(() => Progress = (int)((i / (float)patchesNaoAplicados.Count) * ProgressMax)));
                }
                Thread.Sleep(1000);
                Process app = new Process();
                app.StartInfo = new ProcessStartInfo(Path.Combine(Environment.CurrentDirectory, "Arch", "Visao.exe"));
                app.Start();
                this.Invoke(new Action(() => this.Close()));
            }));
            t.Start();
        }

        static bool ExpandFolder(string CompressedFileName, string ExpandedFolder)
        {
            Shell Sh = new Shell();
            Folder SF = Sh.NameSpace(CompressedFileName);
            Folder DF = Sh.NameSpace(ExpandedFolder);
            if (DF == null)
            {
                return false;
            }
            foreach (FolderItem F in SF.Items()) DF.CopyHere(F, 20);
            return true;
        }

        public class DateModifiedComparer : IComparer<KeyValuePair<string, string>>
        {
            #region IComparer<string> Members
            public int Compare(KeyValuePair<string, string> x, KeyValuePair<string, string> y)
            {
                DateTime dx = File.GetCreationTimeUtc(x.Value);
                DateTime dy = File.GetCreationTimeUtc(y.Value);
                if (dx >= dy)
                {
                    return 1;
                }
                return -1;
            }
            #endregion
        }
    }
}
