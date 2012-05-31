namespace Launcher
{
    partial class Atualizacao
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
            this.progress = new System.Windows.Forms.ProgressBar();
            this.lblProgresso = new System.Windows.Forms.Label();
            this.textWorker = new System.ComponentModel.BackgroundWorker();
            this.progressWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 50);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(259, 23);
            this.progress.TabIndex = 0;
            // 
            // lblProgresso
            // 
            this.lblProgresso.AutoSize = true;
            this.lblProgresso.Location = new System.Drawing.Point(21, 20);
            this.lblProgresso.Name = "lblProgresso";
            this.lblProgresso.Size = new System.Drawing.Size(10, 13);
            this.lblProgresso.TabIndex = 1;
            this.lblProgresso.Text = " ";
            // 
            // Atualizacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 85);
            this.ControlBox = false;
            this.Controls.Add(this.lblProgresso);
            this.Controls.Add(this.progress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Atualizacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Atualizando programa...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label lblProgresso;
        private System.ComponentModel.BackgroundWorker textWorker;
        private System.ComponentModel.BackgroundWorker progressWorker;
    }
}