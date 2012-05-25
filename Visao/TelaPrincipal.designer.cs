namespace Visao
{
    partial class TelaPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaPrincipal));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.Cadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.Cliente = new System.Windows.Forms.ToolStripMenuItem();
            this.Processos = new System.Windows.Forms.ToolStripMenuItem();
            this.Consulta = new System.Windows.Forms.ToolStripMenuItem();
            this.cONSULTASIMPLESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROCESSOSPARADOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Documentos = new System.Windows.Forms.ToolStripMenuItem();
            this.hONORÁRIOSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pROCURAÇÕESToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Ferramentas = new System.Windows.Forms.ToolStripMenuItem();
            this.GrupoDiferencial = new System.Windows.Forms.ToolStripMenuItem();
            this.Pendencias = new System.Windows.Forms.ToolStripMenuItem();
            this.TipoAcao = new System.Windows.Forms.ToolStripMenuItem();
            this.Advogados = new System.Windows.Forms.ToolStripMenuItem();
            this.Beneficios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Preferencias = new System.Windows.Forms.ToolStripMenuItem();
            this.ReativacaoCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.Historico = new System.Windows.Forms.ToolStripMenuItem();
            this.Sair = new System.Windows.Forms.ToolStripMenuItem();
            this.EfetuarLogoff = new System.Windows.Forms.ToolStripMenuItem();
            this.SairPrograma = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fecharToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 720);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1016, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cadastro,
            this.Consulta,
            this.Documentos,
            this.Ferramentas,
            this.Sair});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MaximumSize = new System.Drawing.Size(0, 50);
            this.menuStrip.MdiWindowListItem = this.Sair;
            this.menuStrip.MinimumSize = new System.Drawing.Size(0, 50);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1016, 50);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.ItemAdded += new System.Windows.Forms.ToolStripItemEventHandler(this.menuStrip_ItemAdded);
            // 
            // Cadastro
            // 
            this.Cadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cliente,
            this.Processos});
            this.Cadastro.Image = global::Visao.Properties.Resources.cad32;
            this.Cadastro.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cadastro.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder;
            this.Cadastro.Name = "Cadastro";
            this.Cadastro.Size = new System.Drawing.Size(112, 46);
            this.Cadastro.Text = "CADASTRO";
            // 
            // Cliente
            // 
            this.Cliente.Image = global::Visao.Properties.Resources.usuario24;
            this.Cliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Cliente.ImageTransparentColor = System.Drawing.Color.Black;
            this.Cliente.Name = "Cliente";
            this.Cliente.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.Cliente.Size = new System.Drawing.Size(170, 30);
            this.Cliente.Text = "CLIENTE";
            this.Cliente.Click += new System.EventHandler(this.Cliente_Click);
            // 
            // Processos
            // 
            this.Processos.Image = global::Visao.Properties.Resources.processo24;
            this.Processos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Processos.Name = "Processos";
            this.Processos.Size = new System.Drawing.Size(170, 30);
            this.Processos.Text = "PROCESSOS";
            this.Processos.Click += new System.EventHandler(this.Processos_Click);
            // 
            // Consulta
            // 
            this.Consulta.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cONSULTASIMPLESToolStripMenuItem,
            this.pROCESSOSPARADOSToolStripMenuItem});
            this.Consulta.Image = global::Visao.Properties.Resources.search_32x32;
            this.Consulta.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Consulta.Name = "Consulta";
            this.Consulta.Size = new System.Drawing.Size(112, 46);
            this.Consulta.Text = "CONSULTA";
            // 
            // cONSULTASIMPLESToolStripMenuItem
            // 
            this.cONSULTASIMPLESToolStripMenuItem.Image = global::Visao.Properties.Resources.ConsSimples24x24;
            this.cONSULTASIMPLESToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cONSULTASIMPLESToolStripMenuItem.Name = "cONSULTASIMPLESToolStripMenuItem";
            this.cONSULTASIMPLESToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.cONSULTASIMPLESToolStripMenuItem.Text = "CONSULTA SIMPLES";
            this.cONSULTASIMPLESToolStripMenuItem.Click += new System.EventHandler(this.cONSULTASIMPLESToolStripMenuItem_Click);
            // 
            // pROCESSOSPARADOSToolStripMenuItem
            // 
            this.pROCESSOSPARADOSToolStripMenuItem.Image = global::Visao.Properties.Resources.ConsProcessoCliente24x24;
            this.pROCESSOSPARADOSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pROCESSOSPARADOSToolStripMenuItem.Name = "pROCESSOSPARADOSToolStripMenuItem";
            this.pROCESSOSPARADOSToolStripMenuItem.Size = new System.Drawing.Size(220, 30);
            this.pROCESSOSPARADOSToolStripMenuItem.Text = "PROCESSOS POR CLIENTE";
            this.pROCESSOSPARADOSToolStripMenuItem.Click += new System.EventHandler(this.pROCESSOSPARADOSToolStripMenuItem_Click);
            // 
            // Documentos
            // 
            this.Documentos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hONORÁRIOSToolStripMenuItem,
            this.pROCURAÇÕESToolStripMenuItem});
            this.Documentos.Image = global::Visao.Properties.Resources.hist32;
            this.Documentos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Documentos.Name = "Documentos";
            this.Documentos.Size = new System.Drawing.Size(132, 46);
            this.Documentos.Text = "DOCUMENTOS";
            // 
            // hONORÁRIOSToolStripMenuItem
            // 
            this.hONORÁRIOSToolStripMenuItem.Image = global::Visao.Properties.Resources.Honorarios24x24;
            this.hONORÁRIOSToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.hONORÁRIOSToolStripMenuItem.Name = "hONORÁRIOSToolStripMenuItem";
            this.hONORÁRIOSToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.hONORÁRIOSToolStripMenuItem.Text = "HONORÁRIOS";
            this.hONORÁRIOSToolStripMenuItem.Click += new System.EventHandler(this.hONORÁRIOSToolStripMenuItem_Click);
            // 
            // pROCURAÇÕESToolStripMenuItem
            // 
            this.pROCURAÇÕESToolStripMenuItem.Image = global::Visao.Properties.Resources.ProcuracaoINSS24x24;
            this.pROCURAÇÕESToolStripMenuItem.Name = "pROCURAÇÕESToolStripMenuItem";
            this.pROCURAÇÕESToolStripMenuItem.Size = new System.Drawing.Size(196, 30);
            this.pROCURAÇÕESToolStripMenuItem.Text = "PROCURAÇÃO - INSS";
            this.pROCURAÇÕESToolStripMenuItem.Click += new System.EventHandler(this.pROCURAÇÕESToolStripMenuItem_Click);
            // 
            // Ferramentas
            // 
            this.Ferramentas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GrupoDiferencial,
            this.Pendencias,
            this.TipoAcao,
            this.Advogados,
            this.Beneficios,
            this.toolStripSeparator1,
            this.Preferencias,
            this.ReativacaoCliente,
            this.Historico});
            this.Ferramentas.Image = global::Visao.Properties.Resources.TOOL_32x32;
            this.Ferramentas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Ferramentas.Name = "Ferramentas";
            this.Ferramentas.Size = new System.Drawing.Size(132, 46);
            this.Ferramentas.Text = "FERRAMENTAS";
            // 
            // GrupoDiferencial
            // 
            this.GrupoDiferencial.Image = global::Visao.Properties.Resources.grupo24;
            this.GrupoDiferencial.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.GrupoDiferencial.Name = "GrupoDiferencial";
            this.GrupoDiferencial.Size = new System.Drawing.Size(218, 30);
            this.GrupoDiferencial.Text = "GRUPO DIFERENCIAL";
            this.GrupoDiferencial.Click += new System.EventHandler(this.GrupoDiferencial_Click);
            // 
            // Pendencias
            // 
            this.Pendencias.Image = global::Visao.Properties.Resources.pend24;
            this.Pendencias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Pendencias.Name = "Pendencias";
            this.Pendencias.Size = new System.Drawing.Size(218, 30);
            this.Pendencias.Text = "PENDÊNCIAS";
            this.Pendencias.Click += new System.EventHandler(this.Pendencias_Click);
            // 
            // TipoAcao
            // 
            this.TipoAcao.Image = global::Visao.Properties.Resources.param24;
            this.TipoAcao.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TipoAcao.Name = "TipoAcao";
            this.TipoAcao.Size = new System.Drawing.Size(218, 30);
            this.TipoAcao.Text = "TIPO DE AÇÃO";
            this.TipoAcao.Click += new System.EventHandler(this.TipoAcao_Click);
            // 
            // Advogados
            // 
            this.Advogados.Image = global::Visao.Properties.Resources.Advogado24x24;
            this.Advogados.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Advogados.Name = "Advogados";
            this.Advogados.Size = new System.Drawing.Size(218, 30);
            this.Advogados.Text = "ADVOGADOS";
            this.Advogados.Click += new System.EventHandler(this.Advogados_Click);
            // 
            // Beneficios
            // 
            this.Beneficios.Image = global::Visao.Properties.Resources.abono24;
            this.Beneficios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Beneficios.Name = "Beneficios";
            this.Beneficios.Size = new System.Drawing.Size(218, 30);
            this.Beneficios.Text = "BENEFÍCIO";
            this.Beneficios.Click += new System.EventHandler(this.Beneficios_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(215, 6);
            // 
            // Preferencias
            // 
            this.Preferencias.Image = global::Visao.Properties.Resources.ferramentas24;
            this.Preferencias.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Preferencias.Name = "Preferencias";
            this.Preferencias.Size = new System.Drawing.Size(218, 30);
            this.Preferencias.Text = "PREFERÊNCIAS";
            this.Preferencias.Click += new System.EventHandler(this.Preferencias_Click);
            // 
            // ReativacaoCliente
            // 
            this.ReativacaoCliente.Name = "ReativacaoCliente";
            this.ReativacaoCliente.Size = new System.Drawing.Size(218, 30);
            this.ReativacaoCliente.Text = "REATIVAÇÃO DE CLIENTE";
            // 
            // Historico
            // 
            this.Historico.Name = "Historico";
            this.Historico.Size = new System.Drawing.Size(218, 30);
            this.Historico.Text = "HISTÓRICO";
            // 
            // Sair
            // 
            this.Sair.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EfetuarLogoff,
            this.SairPrograma,
            this.toolStripSeparator2});
            this.Sair.Image = global::Visao.Properties.Resources.sair32;
            this.Sair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Sair.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.Sair.Name = "Sair";
            this.Sair.Size = new System.Drawing.Size(127, 46);
            this.Sair.Text = "  JANELA/SAIR";
            // 
            // EfetuarLogoff
            // 
            this.EfetuarLogoff.Image = global::Visao.Properties.Resources.Logout24x24;
            this.EfetuarLogoff.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EfetuarLogoff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EfetuarLogoff.Name = "EfetuarLogoff";
            this.EfetuarLogoff.Size = new System.Drawing.Size(194, 30);
            this.EfetuarLogoff.Text = "EFETUAR LOGOFF";
            this.EfetuarLogoff.Click += new System.EventHandler(this.EfetuarLogoff_Click);
            // 
            // SairPrograma
            // 
            this.SairPrograma.Image = global::Visao.Properties.Resources.SairPrograma24x24;
            this.SairPrograma.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SairPrograma.Name = "SairPrograma";
            this.SairPrograma.Size = new System.Drawing.Size(194, 30);
            this.SairPrograma.Text = "SAIR DO PROGRAMA";
            this.SairPrograma.Click += new System.EventHandler(this.sAIRDOPROGRAMAToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(191, 6);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Visao";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.fecharToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(110, 48);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // fecharToolStripMenuItem
            // 
            this.fecharToolStripMenuItem.Name = "fecharToolStripMenuItem";
            this.fecharToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.fecharToolStripMenuItem.Text = "Fechar";
            this.fecharToolStripMenuItem.Click += new System.EventHandler(this.fecharToolStripMenuItem_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Visao.Properties.Resources.Logo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1016, 742);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "TelaPrincipal";
            this.Text = "Tela Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.TelaPrincipal_Activated);
            this.SizeChanged += new System.EventHandler(this.TelaPrincipal_SizeChanged);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem Cadastro;
        private System.Windows.Forms.ToolStripMenuItem Cliente;
        private System.Windows.Forms.ToolStripMenuItem Processos;
        private System.Windows.Forms.ToolStripMenuItem Consulta;
        private System.Windows.Forms.ToolStripMenuItem Ferramentas;
        private System.Windows.Forms.ToolStripMenuItem GrupoDiferencial;
        private System.Windows.Forms.ToolStripMenuItem Sair;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem cONSULTASIMPLESToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROCESSOSPARADOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Pendencias;
        private System.Windows.Forms.ToolStripMenuItem TipoAcao;
        private System.Windows.Forms.ToolStripMenuItem Advogados;
        private System.Windows.Forms.ToolStripMenuItem Beneficios;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Preferencias;
        private System.Windows.Forms.ToolStripMenuItem ReativacaoCliente;
        private System.Windows.Forms.ToolStripMenuItem Historico;
        private System.Windows.Forms.ToolStripMenuItem EfetuarLogoff;
        private System.Windows.Forms.ToolStripMenuItem SairPrograma;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Documentos;
        private System.Windows.Forms.ToolStripMenuItem hONORÁRIOSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pROCURAÇÕESToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fecharToolStripMenuItem;
    }
}



