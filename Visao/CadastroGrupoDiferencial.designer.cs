namespace Visao
{
    partial class CadastroGrupoDiferencial
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grupoGridView = new System.Windows.Forms.DataGridView();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantidadeCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.menuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerLinhaContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoGridView)).BeginInit();
            this.menuGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(701, 365);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro do Grupo Diferencial";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnFechar);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.grupoGridView);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(13, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(671, 331);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Visao.Properties.Resources.canc24;
            this.btnCancelar.Location = new System.Drawing.Point(541, 24);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 28);
            this.btnCancelar.TabIndex = 49;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::Visao.Properties.Resources.sair24;
            this.btnFechar.Location = new System.Drawing.Point(635, 24);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 28);
            this.btnFechar.TabIndex = 48;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.button9_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Visao.Properties.Resources.conf24;
            this.btnSalvar.Location = new System.Drawing.Point(505, 24);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(30, 28);
            this.btnSalvar.TabIndex = 47;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // grupoGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grupoGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grupoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grupoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grupo,
            this.QuantidadeCliente});
            this.grupoGridView.Location = new System.Drawing.Point(10, 70);
            this.grupoGridView.Name = "grupoGridView";
            this.grupoGridView.Size = new System.Drawing.Size(655, 252);
            this.grupoGridView.TabIndex = 2;
            // 
            // Grupo
            // 
            this.Grupo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Grupo.DataPropertyName = "Nome";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.MinimumWidth = 240;
            this.Grupo.Name = "Grupo";
            // 
            // QuantidadeCliente
            // 
            this.QuantidadeCliente.DataPropertyName = "QuantidadeClientes";
            this.QuantidadeCliente.HeaderText = "Quantidade de Clientes";
            this.QuantidadeCliente.MinimumWidth = 100;
            this.QuantidadeCliente.Name = "QuantidadeCliente";
            this.QuantidadeCliente.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Realize as alterações na tabela e clique para Salvar ou Cancelar";
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
            // CadastroGrupoDiferencial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(727, 396);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadastroGrupoDiferencial";
            this.Text = "Cadastro de Grupos Diferenciais";
            this.Load += new System.EventHandler(this.CadastroGrupoDiferencial_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grupoGridView)).EndInit();
            this.menuGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView grupoGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantidadeCliente;
        private System.Windows.Forms.ContextMenuStrip menuGridView;
        private System.Windows.Forms.ToolStripMenuItem removerLinhaContextButton;
    }
}