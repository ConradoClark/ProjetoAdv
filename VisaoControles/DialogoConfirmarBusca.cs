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
    public partial class DialogoConfirmarBusca : Form
    {
        protected bool Drag { get; set; }
        protected int MouseX { get; set; }
        protected int MouseY { get; set; }
        protected object Data { get; set; }
        protected DataGridView Grid { get; set; }

        public DialogoConfirmarBusca()
        {
            InitializeComponent();
            Grid = dataGrid;
            Drag = false;
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            btnFechar.Click += (sender, args) => this.Close();
            btnOk.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); };
            btnCancelar.Click += (sender, args) => { DialogResult = System.Windows.Forms.DialogResult.Cancel; this.Close(); };

            painelJanela.MouseDown += dragMouseDown;
            painelJanela.MouseMove += dragMouseMove;
            painelJanela.MouseUp += dragMouseUp;
            lblTitulo.MouseDown += dragMouseDown;
            lblTitulo.MouseMove += dragMouseMove;
            lblTitulo.MouseUp += dragMouseUp;
        }

        private void DialogoConfirmaBusca_Paint(object sender, PaintEventArgs e)
        {
            //Declare and instantiate a drawing pen.
            System.Drawing.Pen myPen = new System.Drawing.Pen(Color.LightGray);
            myPen.Width = 2f;
            //Draw an aqua rectangle in the rectangle represented by the control.
            e.Graphics.DrawRectangle(myPen, new Rectangle(new Point(1, 1), new Size(this.Width - 2, this.Height - 2)));
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

        protected void dragMouseMove(object sender, MouseEventArgs e)
        {
            if (Drag)
            {
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

        public static KeyValuePair<DialogResult,T> Mostrar<T>(string titulo, string mensagem,ICollection<T> dataSource)
        {
            DialogoConfirmarBusca confirmaBusca = new DialogoConfirmarBusca();
            confirmaBusca.lblTitulo.Text = titulo;
            confirmaBusca.lblMensagem.Text = mensagem;
            confirmaBusca.Grid.DataSource = dataSource;
            confirmaBusca.ShowDialog();
            T obj = confirmaBusca.Grid.SelectedRows.Count > 0 ? (T) confirmaBusca.Grid.SelectedRows[0].DataBoundItem : default(T);
            return new KeyValuePair<DialogResult, T>(confirmaBusca.DialogResult, obj);
        }
    }
}
