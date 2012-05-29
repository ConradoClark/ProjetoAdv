using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisaoControles
{
    public partial class DialogoAlerta : Form
    {
        protected bool Drag { get; set; }
        protected int MouseX { get; set; }
        protected int MouseY { get; set; }

        private DialogoAlerta()
        {
            InitializeComponent();
            Drag = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnFechar.Click += (sender, args) => this.Close();
            btnOk.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); };
            btnCancelar.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.Cancel; this.Close(); };

            btnSim.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.Yes; this.Close(); };
            btnNao.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.No; this.Close(); };

            painelJanela.MouseDown += dragMouseDown;
            painelJanela.MouseMove += dragMouseMove;
            painelJanela.MouseUp += dragMouseUp;
            lblTitulo.MouseDown += dragMouseDown;
            lblTitulo.MouseMove += dragMouseMove;
            lblTitulo.MouseUp += dragMouseUp;
        }

        private void DialogoAlerta_Paint(object sender, PaintEventArgs e)
        {            
            //Declare and instantiate a drawing pen.
            System.Drawing.Pen myPen = new System.Drawing.Pen(Color.LightGray);
            myPen.Width = 2f;
            //Draw an aqua rectangle in the rectangle represented by the control.
            e.Graphics.DrawRectangle(myPen, new Rectangle(new Point(1, 1), new Size(this.Width - 2, this.Height - 2)));            
        }

        public static DialogResult Mostrar(string titulo, string mensagem)
        {
            DialogoAlerta alerta = new DialogoAlerta();
            alerta.lblTitulo.Text = titulo;
            alerta.lblMensagem.Text = mensagem;

            alerta.ShowDialog();
            return alerta.DialogResult;
        }

        public static DialogResult Mostrar(string titulo, string mensagem, MessageBoxIcon icon=MessageBoxIcon.Information,MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            DialogoAlerta alerta = new DialogoAlerta();
            alerta.lblTitulo.Text = titulo;
            alerta.lblMensagem.Text = mensagem;

            switch (icon)
            {
                case MessageBoxIcon.Information:
                    alerta.messageIcon.Image = VisaoControles.Properties.Resources.info;
                    break;
                case MessageBoxIcon.Exclamation:
                    alerta.messageIcon.Image = VisaoControles.Properties.Resources.exclamation;
                    break;
                case MessageBoxIcon.Error:
                    alerta.messageIcon.Image = VisaoControles.Properties.Resources.Close_2;
                    break;
                case MessageBoxIcon.Question:
                    alerta.messageIcon.Image = VisaoControles.Properties.Resources.Question;
                    break;
                default:
                    break;
            }

            switch (buttons)
            {
                case MessageBoxButtons.OK:
                    alerta.btnOk.Visible = true;
                    alerta.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    alerta.btnOk.Visible = true;
                    alerta.btnCancelar.Visible = true;
                    alerta.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
                case MessageBoxButtons.YesNo:
                    alerta.btnSim.Visible = true;
                    alerta.btnNao.Visible = true;
                    alerta.DialogResult = System.Windows.Forms.DialogResult.No;
                    break;
            }
            alerta.ShowDialog();
            return alerta.DialogResult;
        }

        protected void dragMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Drag = true;
                MouseX = System.Windows.Forms.Cursor.Position.X - this.Left;
                MouseY = System.Windows.Forms.Cursor.Position.Y - this.Top;
            }
        }

        protected void dragMouseMove(object sender, MouseEventArgs e){
            if (Drag){
                this.Top = System.Windows.Forms.Cursor.Position.Y - MouseY;
                this.Left = System.Windows.Forms.Cursor.Position.X - MouseX;
            }
        }

        protected void dragMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                Drag = false;
            }
        }

    }
}
