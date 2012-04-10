using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VisaoControles
{
    public partial class ColorComboBox : ComboBox
    {
        Dictionary<String, Color> Colors { get; set; }
        private Color selectedColor;
        public Color SelectedColor
        {
            get
            {
                return selectedColor;
            }
            set
            {
                Color c= FindKnownColor(value);
                if (selectedColor != c)
                {
                    selectedColor = c;
                    if (selectedColor.IsNamedColor)
                    {
                        this.SelectedItem = selectedColor.Name;
                    }
                }
            }
        }
        public ColorComboBox()
        {
            Colors = getAllColors();
            InitializeComponent();
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DrawItem += new DrawItemEventHandler(ColorComboBox_DrawItem);
            this.Items.Clear();
            this.Items.AddRange(Colors.Keys.ToArray());

            SelectedColor = Colors["Black"];
            this.SelectedItem = "Black";
            this.SelectedIndexChanged += (sender, args) =>
            {
                this.SelectedColor = Colors[SelectedItem.ToString()];
            };

        }

        void ColorComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Get the Graphics Object (aka. CDC or Device Context Object )
            // passed via the DrawItemEventArgs parameter
            Graphics g = e.Graphics;

            // Get the bounding rectangle of the item currently being painted
            Rectangle r = e.Bounds;

            if (e.Index >= 0)
            {
                e.DrawBackground();
                Rectangle rd = r;
                rd.Width = 30;

                Rectangle rt = new Rectangle(rd.Right, r.Top, r.Width, r.Height);

                // Get the brush object, at the specifid index in the colorArray
                SolidBrush b = new SolidBrush(Colors[this.Items[e.Index].ToString()]);
                // Fill a portion of the rectangle with the selected brush
                g.FillRectangle(b, rd);

                // Set the string format options
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Near;

                Console.WriteLine(e.State.ToString());

                // Draw the rectangle
                e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2), rd);

                if (e.State == (DrawItemState.NoAccelerator | DrawItemState.NoFocusRect))
                {
                    // if the item is not selected draw it with a different color
                    //e.Graphics.FillRectangle(b, r);
                    e.Graphics.DrawString(b.Color.Name, new Font("Arial", 8, FontStyle.Bold), new SolidBrush(Color.Black), rt, sf);
                    e.DrawFocusRectangle();
                }
                else
                {
                    // if the item is selected draw it with a different color
                    //e.Graphics.FillRectangle(b, r);
                    e.Graphics.DrawString(b.Color.Name, new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), rt, sf);
                    e.DrawFocusRectangle();
                }
            }
        }

        const int RGBMAX = 255;
        Color InvertMeAColour(Color ColourToInvert)
        {
            return Color.FromArgb(RGBMAX - ColourToInvert.R,
              RGBMAX - ColourToInvert.G, RGBMAX - ColourToInvert.B);
        }

        Dictionary<String, Color> getAllColors()
        {
            Dictionary<String, Color> dict = new Dictionary<string, Color>();
            KnownColor[] colors = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            foreach (KnownColor knowColor in colors)
            {
                Color c =Color.FromKnownColor(knowColor);
                if (!c.IsSystemColor){
                    dict.Add(Name = knowColor.ToString(),c );
                }
            }
            return dict;
        }

        Color FindKnownColor(Color baseColor){
            foreach(Color c in Colors.Values){
                if (c.R == baseColor.R &&
                    c.G == baseColor.G &&
                    c.B == baseColor.B &&
                    c.A == baseColor.A){
                    return c;
                }
            }
            return baseColor;
        }
    }
}
