using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace VisaoControles
{
    public partial class ImageButton : Button
    {
        public Size ButtonSize { get; set; }
        private bool IsButtonDown { get; set; }
        private bool IsMouseOver { get; set; }

        public ImageButton()
        {
            ButtonSize = new Size(24, 24);
            IsButtonDown = false;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.MouseDown += ((sender, args) => { IsButtonDown = true; this.Invalidate(); this.Refresh(); });
            this.MouseUp += ((sender, args) => { IsButtonDown = false; this.Invalidate(); this.Refresh(); });
            this.MouseEnter += ((sender, args) => { IsMouseOver = true; this.Invalidate(); this.Refresh(); });
            this.MouseLeave += ((sender, args) => { IsMouseOver = false; this.Invalidate(); this.Refresh(); });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaintBackground(e);
            if (this.Image != null)
            {
                RectangleF destRect = new RectangleF(0f, 0f, ButtonSize.Width, ButtonSize.Height);
                e.Graphics.DrawImage(this.Image, destRect);
                if (IsButtonDown)
                {
                    if (!String.IsNullOrWhiteSpace(this.Text))
                    {
                        Brush brush = new SolidBrush(Color.FromArgb(100, Color.Black));
                        e.Graphics.FillRectangle(brush, new Rectangle(0,0,this.Width,this.Height));

                        SolidBrush stringBrush = new SolidBrush(this.ForeColor);
                        int width = this.Image.Width;
                        int height = this.Height / 2 - (int)(this.Font.GetHeight() / 2);
                        e.Graphics.DrawString(this.Text, this.Font, stringBrush, new PointF(width, height));
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(this.Image);
                        ColorPalette palette = bmp.Palette;
                        for (int w = 0; w < bmp.Width; w++)
                        {
                            for (int h = 0; h < bmp.Height; h++)
                            {
                                Color col = bmp.GetPixel(w, h);
                                bmp.SetPixel(w, h, Color.FromArgb((int)(col.A * 0.5), (int)(col.R * 0.3), (int)(col.G * 0.59), (int)(col.B * 0.11)));
                            }
                        }
                        e.Graphics.DrawImage(bmp, destRect);
                    }
                }
                else if (IsMouseOver)
                {
                    if (!String.IsNullOrWhiteSpace(this.Text))
                    {
                        Brush brush = new SolidBrush(Color.FromArgb(25, Color.Black));
                        e.Graphics.FillRectangle(brush, new Rectangle(0, 0, this.Width, this.Height));

                        SolidBrush stringBrush = new SolidBrush(this.ForeColor);
                        int width = this.Image.Width;
                        int height = this.Height / 2 - (int)(this.Font.GetHeight() / 2);
                        e.Graphics.DrawString(this.Text, this.Font, stringBrush, new PointF(width, height));
                    }
                    else
                    {
                        Bitmap bmp = new Bitmap(this.Image);
                        ColorPalette palette = bmp.Palette;
                        for (int w = 0; w < bmp.Width; w++)
                        {
                            for (int h = 0; h < bmp.Height; h++)
                            {
                                Color col = bmp.GetPixel(w, h);
                                bmp.SetPixel(w, h, Color.FromArgb((int)(col.A * 0.25), (int)(col.R * 0.3), (int)(col.G * 0.59), (int)(col.B * 0.11)));
                            }
                        }
                        e.Graphics.DrawImage(bmp, destRect);
                    }
                }
                else
                {
                    if (!String.IsNullOrWhiteSpace(this.Text))
                    {
                        SolidBrush brush = new SolidBrush(this.ForeColor);
                        int width = this.Image.Width;
                        int height = this.Height / 2 - (int)(this.Font.GetHeight() / 2);
                        e.Graphics.DrawString(this.Text, this.Font, brush, new PointF(width, height));
                    }
                }
            }
            else
            {
                base.OnPaint(e);
            }

        }

    }
}
