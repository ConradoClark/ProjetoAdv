namespace VisaoControles
{
    partial class DialogoConfirmarBusca
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
            this.painelJanela = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnFechar = new VisaoControles.ImageButton();
            this.grupoBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new VisaoControles.ImageButton();
            this.btnCancelar = new VisaoControles.ImageButton();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.messageIcon = new System.Windows.Forms.PictureBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.painelJanela.SuspendLayout();
            this.grupoBotoes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // painelJanela
            // 
            this.painelJanela.AutoSize = true;
            this.painelJanela.BackColor = System.Drawing.Color.AliceBlue;
            this.painelJanela.Controls.Add(this.lblTitulo);
            this.painelJanela.Controls.Add(this.btnFechar);
            this.painelJanela.Dock = System.Windows.Forms.DockStyle.Top;
            this.painelJanela.Location = new System.Drawing.Point(2, 2);
            this.painelJanela.Name = "painelJanela";
            this.painelJanela.Padding = new System.Windows.Forms.Padding(2);
            this.painelJanela.Size = new System.Drawing.Size(545, 33);
            this.painelJanela.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(6, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(41, 15);
            this.lblTitulo.TabIndex = 4;
            this.lblTitulo.Text = "titulo";
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnFechar.Image = global::VisaoControles.Properties.Resources.Windows_Close_Program;
            this.btnFechar.Location = new System.Drawing.Point(512, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(24, 24);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // grupoBotoes
            // 
            this.grupoBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupoBotoes.BackColor = System.Drawing.Color.Lavender;
            this.grupoBotoes.Controls.Add(this.btnOk);
            this.grupoBotoes.Controls.Add(this.btnCancelar);
            this.grupoBotoes.Location = new System.Drawing.Point(2, 301);
            this.grupoBotoes.Name = "grupoBotoes";
            this.grupoBotoes.Size = new System.Drawing.Size(545, 36);
            this.grupoBotoes.TabIndex = 8;
            this.grupoBotoes.WrapContents = false;
            // 
            // btnOk
            // 
            this.btnOk.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Image = global::VisaoControles.Properties.Resources.Actions_dialog_ok_apply;
            this.btnOk.Location = new System.Drawing.Point(7, 7);
            this.btnOk.Margin = new System.Windows.Forms.Padding(7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(65, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.Image = global::VisaoControles.Properties.Resources.Actions_dialog_cancel;
            this.btnCancelar.Location = new System.Drawing.Point(86, 7);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(102, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblMensagem
            // 
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.Location = new System.Drawing.Point(42, 36);
            this.lblMensagem.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(487, 63);
            this.lblMensagem.TabIndex = 9;
            this.lblMensagem.Text = "mensagem";
            // 
            // messageIcon
            // 
            this.messageIcon.Image = global::VisaoControles.Properties.Resources.confirm;
            this.messageIcon.Location = new System.Drawing.Point(9, 38);
            this.messageIcon.Name = "messageIcon";
            this.messageIcon.Size = new System.Drawing.Size(32, 32);
            this.messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.messageIcon.TabIndex = 10;
            this.messageIcon.TabStop = false;
            // 
            // dataGrid
            // 
            this.dataGrid.AllowUserToAddRows = false;
            this.dataGrid.AllowUserToDeleteRows = false;
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(9, 112);
            this.dataGrid.MultiSelect = false;
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.ReadOnly = true;
            this.dataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGrid.Size = new System.Drawing.Size(520, 170);
            this.dataGrid.TabIndex = 11;
            // 
            // DialogoConfirmarBusca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 338);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.messageIcon);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.grupoBotoes);
            this.Controls.Add(this.painelJanela);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogoConfirmarBusca";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DialogoConfirmarBusca";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DialogoConfirmaBusca_Paint);
            this.painelJanela.ResumeLayout(false);
            this.painelJanela.PerformLayout();
            this.grupoBotoes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel painelJanela;
        private System.Windows.Forms.Label lblTitulo;
        private ImageButton btnFechar;
        private System.Windows.Forms.FlowLayoutPanel grupoBotoes;
        private ImageButton btnOk;
        private ImageButton btnCancelar;
        private System.Windows.Forms.PictureBox messageIcon;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.DataGridView dataGrid;
    }
}