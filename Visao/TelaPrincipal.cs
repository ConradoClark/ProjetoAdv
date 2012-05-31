using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using VisaoEstrutura;
using VisaoControles;
using System.Reflection;

namespace Visao
{
    public partial class TelaPrincipal : Form
    {
       public CadastroPendencia cp { get; set; }
       public CadastroGrupoDiferencial cgd { get; set; }
       public CadastroCliente formCliente { get; set; }
       public CadastroBeneficios ben { get; set; }
       public CadastroGrupoAcao cga { get; set; }
       public CadastroAdvogados ca { get; set; }
       public CadastroProcessos formProcesso { get; set; }
       public ConsultaSimples cs { get; set; }
       public ConsultaProcessoCliente cpc { get; set; }
       Login login;

        public TelaPrincipal()
        {
            TelaCarregamento loading = new TelaCarregamento();

            this.Hide();
            loading.ShowDialog();

            Principal.InicializarConexao();

            this.
            InitializeComponent();

            this.Show();

            LightBox.ShowLightBox(this.Bounds);
            login = new Login();
            login.ShowDialog();

            Assembly assembly = Assembly.GetEntryAssembly();
            AssemblyFileVersionAttribute[] attributes =
                assembly.GetCustomAttributes(typeof(AssemblyFileVersionAttribute), false)
                    as AssemblyFileVersionAttribute[];

            if (attributes != null && attributes.Length == 1)
            {
                toolStripStatusLabel.Text  = attributes[0].Version;
            }
        }

        private void Cliente_Click(object sender, EventArgs e)
        {
            if (formCliente == null || formCliente.IsDisposed)
            {
                formCliente = new CadastroCliente();
                formCliente.MdiParent = this;
            }
            if (formCliente.Visible)
            {
                formCliente.BringToFront();
            }
            else
            {
                formCliente.Show();
                formCliente.Update();
            }
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void sAIRDOPROGRAMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void mINIMIZARToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void sYSTEMTRAYToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja Fechar o Programa?", "Confirmação?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) ;
            Application.Exit();
        }

        private void cONSULTASIMPLESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cs == null || cs.IsDisposed)
            {
                cs = new ConsultaSimples();
                cs.MdiParent = this;
            }
            if (cs.Visible)
            {
                cs.BringToFront();
            }
            else
            {
                cs.Show();
                cs.Update();
            }
        }

        private void pROCESSOSPARADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cpc == null || cpc.IsDisposed)
            {
                cpc = new ConsultaProcessoCliente();
                cpc.MdiParent = this;
            }
            if (cpc.Visible)
            {
                cpc.BringToFront();
            }
            else
            {
                cpc.Show();
                cpc.Update();
            }
        }

        private void cONSULTAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //PesquisaAvancadaCliente pac = new PesquisaAvancadaCliente();
            //pac.MdiParent = this;
            //pac.Show();
        }

        private void hONORÁRIOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Honorarios h = new Honorarios();
            //h.MdiParent = this;
            //h.Show();

        }

        private void pROCURAÇÕESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ProcuracaoInss pi = new ProcuracaoInss();
            //pi.MdiParent = this;
            //pi.Show();
        }

        private void GrupoDiferencial_Click(object sender, EventArgs e)
        {
            if (cgd == null || cgd.IsDisposed)
            {
                cgd = new CadastroGrupoDiferencial();
                cgd.MdiParent = this;
            }
            if (cgd.Visible)
            {
                cgd.BringToFront();
            }
            else
            {
                cgd.Show();
                //cgd.WindowState = FormWindowState.Maximized;
            }
        }

        private void Pendencias_Click(object sender, EventArgs e)
        {
            if (cp == null || cp.IsDisposed)
            {
                cp = new CadastroPendencia();
                cp.MdiParent = this;
            }
            if (cp.Visible)
            {
                cp.BringToFront();
            }
            else
            {
                cp.Show();
                //cp.WindowState = FormWindowState.Maximized;
            }
        }

        private void Advogados_Click(object sender, EventArgs e)
        {
            if (ca == null || ca.IsDisposed)
            {
                ca = new CadastroAdvogados();
                ca.MdiParent = this;
            }
            if (ca.Visible)
            {
                ca.BringToFront();
            }
            else
            {
                ca.Show();
                ca.Update();
            }
        }

        private void TipoAcao_Click(object sender, EventArgs e)
        {
            if (cga == null || cga.IsDisposed)
            {
                cga = new CadastroGrupoAcao();
                cga.MdiParent = this;
            }
            if (cga.Visible)
            {
                cga.BringToFront();
            }
            else
            {
                cga.Show();
                cga.Update();
            }
        }

        private void Beneficios_Click(object sender, EventArgs e)
        {
            if (ben == null || ben.IsDisposed)
            {
                ben = new CadastroBeneficios();
                ben.MdiParent = this;
            }
            if (ben.Visible)
            {
                ben.BringToFront();
            }
            else
            {
                ben.Show();
                ben.Update();
            }
        }

        private void Preferencias_Click(object sender, EventArgs e)
        {
            //Configuracao config = new Configuracao();
            //config.MdiParent = this;
            //config.Show();
        }

        private void menuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            string s = (e.Item.GetType().ToString());
            if (s == "System.Windows.Forms.MdiControlStrip+ControlBoxMenuItem")
            {
                e.Item.Visible = false;
            }
        }

        private void TelaPrincipal_SizeChanged(object sender, EventArgs e)
        {

        }

        private void EfetuarLogoff_Click(object sender, EventArgs e)
        {
            if (DialogoAlerta.Mostrar("Confirmação", "Deseja mesmo efetuar logoff?", MessageBoxIcon.Question, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) { 
                LightBox.ShowLightBox(this.Bounds);
                login = new Login();
                login.ShowDialog();
            }
        }

        private void TelaPrincipal_Activated(object sender, EventArgs e)
        {
            if (login != null)
            {
                if (login.Visible)
                {
                    LightBox.Activate();
                    login.Activate();                    
                }
            }
        }

        private void Processos_Click(object sender, EventArgs e)
        {
            if (formProcesso == null || formProcesso.IsDisposed)
            {
                formProcesso = new CadastroProcessos();
                formProcesso.MdiParent = this;
            }
            if (formProcesso.Visible)
            {
                formProcesso.BringToFront();
            }
            else
            {
                formProcesso.Show();
                formProcesso.Update();
            }
        }
    }
}
