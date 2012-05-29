namespace Visao
{
    partial class ConsultaProcessoCliente
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFichaCadastral = new System.Windows.Forms.Button();
            this.lblNavegacao = new System.Windows.Forms.Label();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtAndamento = new TXTextControl.TextControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtObjetivo = new TXTextControl.TextControl();
            this.btnProximo = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstResponsaveis = new System.Windows.Forms.ListBox();
            this.txtTipoAcao = new System.Windows.Forms.TextBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtReu = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDataAjuizamento = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCabeca = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtVara = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNumeroOrdem = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNumeroProcesso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCodigoProcesso = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeCliente = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtCodigoCliente = new VisaoControles.NumberTextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Cliente";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFichaCadastral);
            this.groupBox1.Controls.Add(this.lblNavegacao);
            this.groupBox1.Controls.Add(this.btnExportarPDF);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.btnProximo);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtTipoAcao);
            this.groupBox1.Controls.Add(this.btnAnterior);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtReu);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtDataAjuizamento);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCabeca);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtVara);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtNumeroOrdem);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNumeroProcesso);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCodigoProcesso);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(9, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 477);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processos";
            // 
            // btnFichaCadastral
            // 
            this.btnFichaCadastral.Image = global::Visao.Properties.Resources.param16;
            this.btnFichaCadastral.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFichaCadastral.Location = new System.Drawing.Point(476, 19);
            this.btnFichaCadastral.Name = "btnFichaCadastral";
            this.btnFichaCadastral.Size = new System.Drawing.Size(109, 23);
            this.btnFichaCadastral.TabIndex = 26;
            this.btnFichaCadastral.Text = "Ficha Completa";
            this.btnFichaCadastral.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnFichaCadastral, "Direciona para Cadastro Cliente");
            this.btnFichaCadastral.UseVisualStyleBackColor = true;
            // 
            // lblNavegacao
            // 
            this.lblNavegacao.AutoSize = true;
            this.lblNavegacao.Location = new System.Drawing.Point(97, 24);
            this.lblNavegacao.Name = "lblNavegacao";
            this.lblNavegacao.Size = new System.Drawing.Size(37, 13);
            this.lblNavegacao.TabIndex = 25;
            this.lblNavegacao.Text = "0 de 0";
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Image = global::Visao.Properties.Resources.pdf_16x16;
            this.btnExportarPDF.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnExportarPDF.Location = new System.Drawing.Point(591, 19);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(102, 23);
            this.btnExportarPDF.TabIndex = 7;
            this.btnExportarPDF.Text = "Exportar PDF";
            this.btnExportarPDF.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnExportarPDF, "Exportar PDF");
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtAndamento);
            this.groupBox4.Location = new System.Drawing.Point(15, 301);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(678, 164);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Andamento do Processo";
            // 
            // txtAndamento
            // 
            this.txtAndamento.BackColor = System.Drawing.SystemColors.Control;
            this.txtAndamento.EditMode = TXTextControl.EditMode.ReadAndSelect;
            this.txtAndamento.Font = new System.Drawing.Font("Arial", 10F);
            this.txtAndamento.Location = new System.Drawing.Point(6, 19);
            this.txtAndamento.Name = "txtAndamento";
            this.txtAndamento.Size = new System.Drawing.Size(666, 139);
            this.txtAndamento.TabIndex = 1;
            this.txtAndamento.TextBackColor = System.Drawing.SystemColors.Control;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtObjetivo);
            this.groupBox3.Location = new System.Drawing.Point(357, 199);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(336, 96);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Objetivo do Processo";
            // 
            // txtObjetivo
            // 
            this.txtObjetivo.BackColor = System.Drawing.SystemColors.Control;
            this.txtObjetivo.EditMode = TXTextControl.EditMode.ReadAndSelect;
            this.txtObjetivo.Font = new System.Drawing.Font("Arial", 10F);
            this.txtObjetivo.Location = new System.Drawing.Point(7, 21);
            this.txtObjetivo.Name = "txtObjetivo";
            this.txtObjetivo.Size = new System.Drawing.Size(323, 69);
            this.txtObjetivo.TabIndex = 0;
            this.txtObjetivo.TextBackColor = System.Drawing.SystemColors.Control;
            // 
            // btnProximo
            // 
            this.btnProximo.Image = global::Visao.Properties.Resources.next16;
            this.btnProximo.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnProximo.Location = new System.Drawing.Point(153, 19);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(75, 23);
            this.btnProximo.TabIndex = 6;
            this.btnProximo.Text = "Próximo";
            this.btnProximo.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.toolTip1.SetToolTip(this.btnProximo, "Próximo Processo Cliente");
            this.btnProximo.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstResponsaveis);
            this.groupBox2.Location = new System.Drawing.Point(15, 199);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 96);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsáveis";
            // 
            // lstResponsaveis
            // 
            this.lstResponsaveis.BackColor = System.Drawing.SystemColors.Control;
            this.lstResponsaveis.FormattingEnabled = true;
            this.lstResponsaveis.Location = new System.Drawing.Point(6, 21);
            this.lstResponsaveis.Name = "lstResponsaveis";
            this.lstResponsaveis.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstResponsaveis.Size = new System.Drawing.Size(324, 69);
            this.lstResponsaveis.TabIndex = 0;
            // 
            // txtTipoAcao
            // 
            this.txtTipoAcao.Location = new System.Drawing.Point(488, 131);
            this.txtTipoAcao.Name = "txtTipoAcao";
            this.txtTipoAcao.ReadOnly = true;
            this.txtTipoAcao.Size = new System.Drawing.Size(205, 20);
            this.txtTipoAcao.TabIndex = 21;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = global::Visao.Properties.Resources.back16;
            this.btnAnterior.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAnterior.Location = new System.Drawing.Point(9, 19);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(75, 23);
            this.btnAnterior.TabIndex = 5;
            this.btnAnterior.Text = "Anterior";
            this.btnAnterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnAnterior, "Anterior Processo Cliente");
            this.btnAnterior.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(426, 135);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Tipo Ação";
            // 
            // txtReu
            // 
            this.txtReu.Location = new System.Drawing.Point(50, 167);
            this.txtReu.Name = "txtReu";
            this.txtReu.ReadOnly = true;
            this.txtReu.Size = new System.Drawing.Size(370, 20);
            this.txtReu.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Réu";
            // 
            // txtDataAjuizamento
            // 
            this.txtDataAjuizamento.Location = new System.Drawing.Point(522, 167);
            this.txtDataAjuizamento.Mask = "00/00/0000";
            this.txtDataAjuizamento.Name = "txtDataAjuizamento";
            this.txtDataAjuizamento.ReadOnly = true;
            this.txtDataAjuizamento.Size = new System.Drawing.Size(69, 20);
            this.txtDataAjuizamento.TabIndex = 17;
            this.txtDataAjuizamento.ValidatingType = typeof(System.DateTime);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(426, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Data Ajuizamento";
            // 
            // txtCabeca
            // 
            this.txtCabeca.Location = new System.Drawing.Point(62, 131);
            this.txtCabeca.Name = "txtCabeca";
            this.txtCabeca.ReadOnly = true;
            this.txtCabeca.Size = new System.Drawing.Size(358, 20);
            this.txtCabeca.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Cabeça";
            // 
            // txtVara
            // 
            this.txtVara.Location = new System.Drawing.Point(128, 97);
            this.txtVara.Name = "txtVara";
            this.txtVara.ReadOnly = true;
            this.txtVara.Size = new System.Drawing.Size(565, 20);
            this.txtVara.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Fórum/Vara/Comarca";
            // 
            // txtNumeroOrdem
            // 
            this.txtNumeroOrdem.Location = new System.Drawing.Point(522, 57);
            this.txtNumeroOrdem.Name = "txtNumeroOrdem";
            this.txtNumeroOrdem.ReadOnly = true;
            this.txtNumeroOrdem.Size = new System.Drawing.Size(171, 20);
            this.txtNumeroOrdem.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(463, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Nº Ordem";
            // 
            // txtNumeroProcesso
            // 
            this.txtNumeroProcesso.Location = new System.Drawing.Point(251, 57);
            this.txtNumeroProcesso.Name = "txtNumeroProcesso";
            this.txtNumeroProcesso.ReadOnly = true;
            this.txtNumeroProcesso.Size = new System.Drawing.Size(206, 20);
            this.txtNumeroProcesso.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Nº Processo";
            // 
            // txtCodigoProcesso
            // 
            this.txtCodigoProcesso.Location = new System.Drawing.Point(57, 57);
            this.txtCodigoProcesso.Name = "txtCodigoProcesso";
            this.txtCodigoProcesso.ReadOnly = true;
            this.txtCodigoProcesso.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoProcesso.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome ";
            // 
            // txtNomeCliente
            // 
            this.txtNomeCliente.Location = new System.Drawing.Point(96, 56);
            this.txtNomeCliente.Name = "txtNomeCliente";
            this.txtNomeCliente.Size = new System.Drawing.Size(443, 20);
            this.txtNomeCliente.TabIndex = 4;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Image = global::Visao.Properties.Resources.search_16x16;
            this.btnPesquisar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPesquisar.Location = new System.Drawing.Point(638, 54);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(75, 23);
            this.btnPesquisar.TabIndex = 6;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip1.SetToolTip(this.btnPesquisar, "Anterior Processo Cliente");
            this.btnPesquisar.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox5.Controls.Add(this.txtCodigoCliente);
            this.groupBox5.Controls.Add(this.btnPesquisar);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.groupBox1);
            this.groupBox5.Controls.Add(this.txtNomeCliente);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(11, 17);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(720, 580);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Consulta de Processos por Cliente";
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Location = new System.Drawing.Point(96, 28);
            this.txtCodigoCliente.Mask = "99999";
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.PromptChar = ' ';
            this.txtCodigoCliente.Size = new System.Drawing.Size(100, 20);
            this.txtCodigoCliente.TabIndex = 25;
            // 
            // ConsultaProcessoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 609);
            this.Controls.Add(this.groupBox5);
            this.Name = "ConsultaProcessoCliente";
            this.Text = "Consulta de Processo por Cliente";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeCliente;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.TextBox txtTipoAcao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtReu;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtDataAjuizamento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCabeca;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtVara;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNumeroOrdem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumeroProcesso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCodigoProcesso;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblNavegacao;
        private System.Windows.Forms.ListBox lstResponsaveis;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnPesquisar;
        private TXTextControl.TextControl txtAndamento;
        private TXTextControl.TextControl txtObjetivo;
        private System.Windows.Forms.Button btnFichaCadastral;
        private VisaoControles.NumberTextBox txtCodigoCliente;
    }
}