namespace Visao
{
    partial class ConsultaSimples
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
            this.rbtConsultaCliente = new System.Windows.Forms.RadioButton();
            this.rbtConsultaProcesso = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSairCons = new System.Windows.Forms.Button();
            this.btnFichaCadastral = new System.Windows.Forms.Button();
            this.btnProcuracaoINSS = new System.Windows.Forms.Button();
            this.gridPesquisa = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtCodigoCliente = new VisaoControles.NumberTextBox();
            this.txtRGCliente = new System.Windows.Forms.MaskedTextBox();
            this.txtCPFCliente = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtCodigoProcesso = new VisaoControles.NumberTextBox();
            this.txtCabecaProcesso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroProcesso = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridPesquisa)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtConsultaCliente
            // 
            this.rbtConsultaCliente.AutoSize = true;
            this.rbtConsultaCliente.Location = new System.Drawing.Point(15, 19);
            this.rbtConsultaCliente.Name = "rbtConsultaCliente";
            this.rbtConsultaCliente.Size = new System.Drawing.Size(119, 17);
            this.rbtConsultaCliente.TabIndex = 0;
            this.rbtConsultaCliente.TabStop = true;
            this.rbtConsultaCliente.Text = "Consulta por Cliente";
            this.rbtConsultaCliente.UseVisualStyleBackColor = true;
            this.rbtConsultaCliente.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rbtConsultaProcesso
            // 
            this.rbtConsultaProcesso.AutoSize = true;
            this.rbtConsultaProcesso.Location = new System.Drawing.Point(157, 19);
            this.rbtConsultaProcesso.Name = "rbtConsultaProcesso";
            this.rbtConsultaProcesso.Size = new System.Drawing.Size(134, 17);
            this.rbtConsultaProcesso.TabIndex = 1;
            this.rbtConsultaProcesso.TabStop = true;
            this.rbtConsultaProcesso.Text = "Consultar por Processo";
            this.rbtConsultaProcesso.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.btnSairCons);
            this.groupBox1.Controls.Add(this.btnFichaCadastral);
            this.groupBox1.Controls.Add(this.btnProcuracaoINSS);
            this.groupBox1.Controls.Add(this.gridPesquisa);
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Controls.Add(this.btnPesquisar);
            this.groupBox1.Location = new System.Drawing.Point(6, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(712, 445);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btnSairCons
            // 
            this.btnSairCons.Image = global::Visao.Properties.Resources.sair24;
            this.btnSairCons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSairCons.Location = new System.Drawing.Point(636, 407);
            this.btnSairCons.Name = "btnSairCons";
            this.btnSairCons.Size = new System.Drawing.Size(67, 32);
            this.btnSairCons.TabIndex = 13;
            this.btnSairCons.Text = "Sair";
            this.btnSairCons.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnSairCons, "Voltar para Tela Principal");
            this.btnSairCons.UseVisualStyleBackColor = true;
            this.btnSairCons.Click += new System.EventHandler(this.btnSairCons_Click);
            // 
            // btnFichaCadastral
            // 
            this.btnFichaCadastral.Image = global::Visao.Properties.Resources.param24;
            this.btnFichaCadastral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFichaCadastral.Location = new System.Drawing.Point(9, 407);
            this.btnFichaCadastral.Name = "btnFichaCadastral";
            this.btnFichaCadastral.Size = new System.Drawing.Size(126, 32);
            this.btnFichaCadastral.TabIndex = 12;
            this.btnFichaCadastral.Text = "Ficha Cadastral";
            this.btnFichaCadastral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnFichaCadastral, "Direciona para Cadastro Cliente");
            this.btnFichaCadastral.UseVisualStyleBackColor = true;
            // 
            // btnProcuracaoINSS
            // 
            this.btnProcuracaoINSS.Image = global::Visao.Properties.Resources.ProcuracaoINSS24x24;
            this.btnProcuracaoINSS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcuracaoINSS.Location = new System.Drawing.Point(150, 407);
            this.btnProcuracaoINSS.Name = "btnProcuracaoINSS";
            this.btnProcuracaoINSS.Size = new System.Drawing.Size(135, 32);
            this.btnProcuracaoINSS.TabIndex = 11;
            this.btnProcuracaoINSS.Text = "Procuração INSS";
            this.btnProcuracaoINSS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnProcuracaoINSS, "Direciona para Procuração INSS");
            this.btnProcuracaoINSS.UseVisualStyleBackColor = true;
            // 
            // gridPesquisa
            // 
            this.gridPesquisa.AllowUserToAddRows = false;
            this.gridPesquisa.AllowUserToDeleteRows = false;
            this.gridPesquisa.AllowUserToOrderColumns = true;
            this.gridPesquisa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.gridPesquisa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridPesquisa.Location = new System.Drawing.Point(9, 239);
            this.gridPesquisa.MultiSelect = false;
            this.gridPesquisa.Name = "gridPesquisa";
            this.gridPesquisa.ReadOnly = true;
            this.gridPesquisa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.gridPesquisa.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.gridPesquisa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridPesquisa.Size = new System.Drawing.Size(697, 162);
            this.gridPesquisa.TabIndex = 9;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 19);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(697, 177);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtCodigoCliente);
            this.panel1.Controls.Add(this.txtRGCliente);
            this.panel1.Controls.Add(this.txtCPFCliente);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtNomeCliente);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(393, 173);
            this.panel1.TabIndex = 0;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(6, 27);
            this.txtCodigoCliente.Mask = "99999";
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.PromptChar = ' ';
            this.txtCodigoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCliente.TabIndex = 24;
            // 
            // txtRGCliente
            // 
            this.txtRGCliente.Location = new System.Drawing.Point(139, 136);
            this.txtRGCliente.Mask = "AA.AAA.AAA-A";
            this.txtRGCliente.Name = "txtRGCliente";
            this.txtRGCliente.Size = new System.Drawing.Size(110, 20);
            this.txtRGCliente.TabIndex = 23;
            this.txtRGCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCPFCliente
            // 
            this.txtCPFCliente.Location = new System.Drawing.Point(6, 136);
            this.txtCPFCliente.Mask = "999.999.999-99";
            this.txtCPFCliente.Name = "txtCPFCliente";
            this.txtCPFCliente.Size = new System.Drawing.Size(110, 20);
            this.txtCPFCliente.TabIndex = 22;
            this.txtCPFCliente.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(136, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "R.G";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "C.P.F";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(6, 81);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(383, 20);
            this.txtNomeCliente.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Nome do Cliente";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Código Cliente";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtCodigoProcesso);
            this.panel2.Controls.Add(this.txtCabecaProcesso);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.txtNumeroProcesso);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(402, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(292, 173);
            this.panel2.TabIndex = 1;
            // 
            // txtCodigoProcesso
            // 
            this.txtCodigoProcesso.Location = new System.Drawing.Point(6, 27);
            this.txtCodigoProcesso.Mask = "99999";
            this.txtCodigoProcesso.Name = "txtCodigoProcesso";
            this.txtCodigoProcesso.PromptChar = ' ';
            this.txtCodigoProcesso.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProcesso.TabIndex = 25;
            // 
            // txtCabecaProcesso
            // 
            this.txtCabecaProcesso.Location = new System.Drawing.Point(6, 136);
            this.txtCabecaProcesso.Name = "txtCabecaProcesso";
            this.txtCabecaProcesso.Size = new System.Drawing.Size(276, 20);
            this.txtCabecaProcesso.TabIndex = 23;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Cabeça do processo";
            // 
            // txtNumeroProcesso
            // 
            this.txtNumeroProcesso.Location = new System.Drawing.Point(6, 81);
            this.txtNumeroProcesso.Name = "txtNumeroProcesso";
            this.txtNumeroProcesso.Size = new System.Drawing.Size(119, 20);
            this.txtNumeroProcesso.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Processo Nº";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Código Processo";
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Visao.Properties.Resources.search_24x24;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(9, 202);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(91, 32);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnPesquisar, "Pesquisar Cliente ou Processo");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSair);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.rbtConsultaCliente);
            this.groupBox2.Controls.Add(this.rbtConsultaProcesso);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(734, 502);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Consulta Simples";
            // 
            // btnSair
            // 
            this.btnSair.Image = global::Visao.Properties.Resources.sair24;
            this.btnSair.Location = new System.Drawing.Point(683, 13);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(35, 28);
            this.btnSair.TabIndex = 45;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // ConsultaSimples
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 516);
            this.Controls.Add(this.groupBox2);
            this.Name = "ConsultaSimples";
            this.Text = "Consulta Simples";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ConsultaSimples_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridPesquisa)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtConsultaCliente;
        private System.Windows.Forms.RadioButton rbtConsultaProcesso;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtCabecaProcesso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroProcesso;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridPesquisa;
        private System.Windows.Forms.Button btnFichaCadastral;
        private System.Windows.Forms.Button btnProcuracaoINSS;
        private System.Windows.Forms.Button btnSairCons;
        private System.Windows.Forms.MaskedTextBox txtRGCliente;
        private System.Windows.Forms.MaskedTextBox txtCPFCliente;
        private System.Windows.Forms.ToolTip toolTip1;
        private VisaoControles.NumberTextBox txtCodigoCliente;
        private System.Windows.Forms.GroupBox groupBox2;
        private VisaoControles.NumberTextBox txtCodigoProcesso;
        private System.Windows.Forms.Button btnSair;
    }
}