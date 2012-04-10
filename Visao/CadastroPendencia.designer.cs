namespace Visao
{
    partial class CadastroPendencia
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtPendencia = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.pendenciaGridView = new System.Windows.Forms.DataGridView();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerLinhaContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pendenciaGridView)).BeginInit();
            this.menuGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1055, 427);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de Pendência";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.txtPendencia);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.btnLimpar);
            this.groupBox2.Controls.Add(this.button9);
            this.groupBox2.Controls.Add(this.pendenciaGridView);
            this.groupBox2.Controls.Add(this.btnAdicionar);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(20, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 402);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            // 
            // txtPendencia
            // 
            this.txtPendencia.Location = new System.Drawing.Point(10, 67);
            this.txtPendencia.Multiline = true;
            this.txtPendencia.Name = "txtPendencia";
            this.txtPendencia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPendencia.Size = new System.Drawing.Size(1003, 109);
            this.txtPendencia.TabIndex = 60;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(431, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Adicione pendências preenchendo a caixa de texto abaixo e clicando no botão Adici" +
    "onar.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 189);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(900, 13);
            this.label2.TabIndex = 58;
            this.label2.Text = "Para remover pendencias, pressione Delete ou clique com o botão direito do mouse " +
    "e exclua. Em seguida pressione salvar para realizar as alterações, ou cancelar p" +
    "ara cancelar a operação.";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Visao.Properties.Resources.canc24;
            this.btnCancelar.Location = new System.Drawing.Point(977, 182);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 28);
            this.btnCancelar.TabIndex = 57;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Visao.Properties.Resources.conf24;
            this.btnSalvar.Location = new System.Drawing.Point(941, 182);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(30, 28);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Image = global::Visao.Properties.Resources.limpar;
            this.btnLimpar.Location = new System.Drawing.Point(890, 19);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(30, 28);
            this.btnLimpar.TabIndex = 55;
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Image = global::Visao.Properties.Resources.sair24;
            this.button9.Location = new System.Drawing.Point(983, 19);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(30, 28);
            this.button9.TabIndex = 51;
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // pendenciaGridView
            // 
            this.pendenciaGridView.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pendenciaGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.pendenciaGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.pendenciaGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.pendenciaGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descricao});
            this.pendenciaGridView.ContextMenuStrip = this.menuGridView;
            this.pendenciaGridView.Location = new System.Drawing.Point(9, 217);
            this.pendenciaGridView.Name = "pendenciaGridView";
            this.pendenciaGridView.Size = new System.Drawing.Size(1004, 174);
            this.pendenciaGridView.TabIndex = 46;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descricao.HeaderText = "Pendências";
            this.Descricao.Name = "Descricao";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Image = global::Visao.Properties.Resources.add24;
            this.btnAdicionar.Location = new System.Drawing.Point(849, 19);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(30, 28);
            this.btnAdicionar.TabIndex = 45;
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição de Pendência";
            // 
            // menuGridView
            // 
            this.menuGridView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removerLinhaContextButton});
            this.menuGridView.Name = "menuGridView";
            this.menuGridView.Size = new System.Drawing.Size(154, 26);
            // 
            // removerLinhaContextButton
            // 
            this.removerLinhaContextButton.Name = "removerLinhaContextButton";
            this.removerLinhaContextButton.Size = new System.Drawing.Size(153, 22);
            this.removerLinhaContextButton.Text = "&Remover Linha";
            // 
            // CadastroPendencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1081, 451);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadastroPendencia";
            this.Text = "Cadastro de Pendências";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CadastroPendencia_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pendenciaGridView)).EndInit();
            this.menuGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView pendenciaGridView;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.TextBox txtPendencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.ContextMenuStrip menuGridView;
        private System.Windows.Forms.ToolStripMenuItem removerLinhaContextButton;
    }
}