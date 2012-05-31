namespace VisaoControles
{
    partial class DialogoAlerta
    {
        private System.Windows.Forms.FlowLayoutPanel grupoMensagem;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.FlowLayoutPanel grupoBotoes;
        private System.Windows.Forms.Label lblTitulo;

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.grupoMensagem = new System.Windows.Forms.FlowLayoutPanel();
            this.messageIcon = new System.Windows.Forms.PictureBox();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.grupoBotoes = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.painelJanela = new System.Windows.Forms.Panel();
            this.btnFechar = new VisaoControles.ImageButton();
            this.btnOk = new VisaoControles.ImageButton();
            this.btnCancelar = new VisaoControles.ImageButton();
            this.btnSim = new VisaoControles.ImageButton();
            this.btnNao = new VisaoControles.ImageButton();
            this.grupoMensagem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).BeginInit();
            this.grupoBotoes.SuspendLayout();
            this.painelJanela.SuspendLayout();
            this.SuspendLayout();
            // 
            // grupoMensagem
            // 
            this.grupoMensagem.BackColor = System.Drawing.Color.Transparent;
            this.grupoMensagem.Controls.Add(this.messageIcon);
            this.grupoMensagem.Controls.Add(this.lblMensagem);
            this.grupoMensagem.Location = new System.Drawing.Point(0, 28);
            this.grupoMensagem.Name = "grupoMensagem";
            this.grupoMensagem.Padding = new System.Windows.Forms.Padding(10, 10, 1, 0);
            this.grupoMensagem.Size = new System.Drawing.Size(305, 74);
            this.grupoMensagem.TabIndex = 1;
            // 
            // messageIcon
            // 
            this.messageIcon.Image = global::VisaoControles.Properties.Resources.info;
            this.messageIcon.Location = new System.Drawing.Point(13, 13);
            this.messageIcon.Name = "messageIcon";
            this.messageIcon.Size = new System.Drawing.Size(32, 32);
            this.messageIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.messageIcon.TabIndex = 1;
            this.messageIcon.TabStop = false;
            // 
            // lblMensagem
            // 
            this.grupoMensagem.SetFlowBreak(this.lblMensagem, true);
            this.lblMensagem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensagem.Location = new System.Drawing.Point(58, 10);
            this.lblMensagem.Margin = new System.Windows.Forms.Padding(10, 0, 10, 10);
            this.lblMensagem.Name = "lblMensagem";
            this.lblMensagem.Size = new System.Drawing.Size(235, 57);
            this.lblMensagem.TabIndex = 0;
            this.lblMensagem.Text = "mensagem";
            // 
            // grupoBotoes
            // 
            this.grupoBotoes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grupoBotoes.BackColor = System.Drawing.Color.Lavender;
            this.grupoBotoes.Controls.Add(this.btnOk);
            this.grupoBotoes.Controls.Add(this.btnCancelar);
            this.grupoBotoes.Controls.Add(this.btnSim);
            this.grupoBotoes.Controls.Add(this.btnNao);
            this.grupoBotoes.Location = new System.Drawing.Point(2, 104);
            this.grupoBotoes.Name = "grupoBotoes";
            this.grupoBotoes.Size = new System.Drawing.Size(301, 33);
            this.grupoBotoes.TabIndex = 2;
            this.grupoBotoes.WrapContents = false;
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
            this.painelJanela.Size = new System.Drawing.Size(301, 30);
            this.painelJanela.TabIndex = 6;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Transparent;
            this.btnFechar.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnFechar.Image = global::VisaoControles.Properties.Resources.Windows_Close_Program;
            this.btnFechar.Location = new System.Drawing.Point(277, 1);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(24, 24);
            this.btnFechar.TabIndex = 5;
            this.btnFechar.UseVisualStyleBackColor = true;
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
            this.btnOk.Visible = false;
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
            this.btnCancelar.Visible = false;
            // 
            // btnSim
            // 
            this.btnSim.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSim.Image = global::VisaoControles.Properties.Resources.Actions_dialog_ok_apply;
            this.btnSim.Location = new System.Drawing.Point(202, 7);
            this.btnSim.Margin = new System.Windows.Forms.Padding(7);
            this.btnSim.Name = "btnSim";
            this.btnSim.Size = new System.Drawing.Size(75, 23);
            this.btnSim.TabIndex = 2;
            this.btnSim.Text = "Sim";
            this.btnSim.UseVisualStyleBackColor = true;
            this.btnSim.Visible = false;
            // 
            // btnNao
            // 
            this.btnNao.ButtonSize = new System.Drawing.Size(24, 24);
            this.btnNao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNao.Image = global::VisaoControles.Properties.Resources.Actions_dialog_cancel;
            this.btnNao.Location = new System.Drawing.Point(291, 7);
            this.btnNao.Margin = new System.Windows.Forms.Padding(7);
            this.btnNao.Name = "btnNao";
            this.btnNao.Size = new System.Drawing.Size(75, 23);
            this.btnNao.TabIndex = 3;
            this.btnNao.Text = "Não";
            this.btnNao.UseVisualStyleBackColor = true;
            this.btnNao.Visible = false;
            // 
            // DialogoAlerta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(305, 140);
            this.Controls.Add(this.painelJanela);
            this.Controls.Add(this.grupoBotoes);
            this.Controls.Add(this.grupoMensagem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DialogoAlerta";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "titulo";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.DialogoAlerta_Paint);
            this.grupoMensagem.ResumeLayout(false);
            this.grupoMensagem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.messageIcon)).EndInit();
            this.grupoBotoes.ResumeLayout(false);
            this.painelJanela.ResumeLayout(false);
            this.painelJanela.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ImageButton btnFechar;
        private System.Windows.Forms.Panel painelJanela;
        private ImageButton btnOk;
        private System.Windows.Forms.PictureBox messageIcon;
        private ImageButton btnCancelar;
        private ImageButton btnSim;
        private ImageButton btnNao;

    }
}