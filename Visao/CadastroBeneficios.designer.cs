namespace Visao
{
    partial class CadastroBeneficios
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.beneficiosGridView = new System.Windows.Forms.DataGridView();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuGridView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removerLinhaContextButton = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosGridView)).BeginInit();
            this.menuGridView.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(742, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cadastro de Benefícios";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnCancelar);
            this.groupBox2.Controls.Add(this.btnFechar);
            this.groupBox2.Controls.Add(this.btnSalvar);
            this.groupBox2.Controls.Add(this.beneficiosGridView);
            this.groupBox2.Location = new System.Drawing.Point(13, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 407);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 13);
            this.label1.TabIndex = 59;
            this.label1.Text = "Realize as alterações na tabela e clique para Salvar ou Cancelar";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::Visao.Properties.Resources.canc24;
            this.btnCancelar.Location = new System.Drawing.Point(553, 19);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(35, 28);
            this.btnCancelar.TabIndex = 58;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::Visao.Properties.Resources.sair24;
            this.btnFechar.Location = new System.Drawing.Point(663, 19);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(30, 28);
            this.btnFechar.TabIndex = 57;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::Visao.Properties.Resources.conf24;
            this.btnSalvar.Location = new System.Drawing.Point(517, 19);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(30, 28);
            this.btnSalvar.TabIndex = 56;
            this.btnSalvar.UseVisualStyleBackColor = true;
            // 
            // beneficiosGridView
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.beneficiosGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.beneficiosGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.beneficiosGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Descricao,
            this.TotalCliente});
            this.beneficiosGridView.Location = new System.Drawing.Point(9, 53);
            this.beneficiosGridView.Name = "beneficiosGridView";
            this.beneficiosGridView.Size = new System.Drawing.Size(684, 329);
            this.beneficiosGridView.TabIndex = 51;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Nome";
            this.Descricao.MinimumWidth = 300;
            this.Descricao.Name = "Descricao";
            // 
            // TotalCliente
            // 
            this.TotalCliente.DataPropertyName = "QuantidadeClientes";
            this.TotalCliente.HeaderText = "Total de Clientes";
            this.TotalCliente.MinimumWidth = 100;
            this.TotalCliente.Name = "TotalCliente";
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
            // CadastroBeneficios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(770, 465);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CadastroBeneficios";
            this.Text = "CadastroBeneficios";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CadastroBeneficios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.beneficiosGridView)).EndInit();
            this.menuGridView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView beneficiosGridView;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCliente;
        private System.Windows.Forms.ContextMenuStrip menuGridView;
        private System.Windows.Forms.ToolStripMenuItem removerLinhaContextButton;
    }
}