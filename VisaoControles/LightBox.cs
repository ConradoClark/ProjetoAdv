using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace VisaoControles
{
    public class LightBox : Form
    {
        public LightBox()
        {
            FormBorderStyle = FormBorderStyle.None;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.Manual;
            MaximizeBox = false;
            MinimizeBox = false;
            ShowInTaskbar = false;
            BackColor = Color.Black;
            Opacity = 0.5f;
        }

        static LightBox lb = null;
        public static void Show(Rectangle pos)
        {
            lb = new LightBox();
            lb.Bounds = pos;
            lb.Show();
        }

        public new static void Hide()
        {
            if (lb != null)
            {
                (lb as Form).Hide();
            }
        }

        public new static void Activate()
        {
            if (lb != null)
            {
                (lb as Form).Activate();
            }
        }
        
    }

}
