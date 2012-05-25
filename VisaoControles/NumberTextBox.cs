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
    public partial class NumberTextBox : MaskedTextBox, INotifyPropertyChanged
    {
        int? _value = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int? Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value != _value)
                {
                    _value = value.HasValue ? value.Value : 0;                    
                    this.Text = value.HasValue ? Value.ToString() : String.Empty;
                    NotifyPropertyChanged("Value");
                }
            }
        }
        public NumberTextBox()
        {
            InitializeComponent();
            this.TextChanged += new EventHandler(NumberTextBox_TextChanged);
            this.Text = Value.ToString();
            this.Mask = "99999";
            this.PromptChar = " "[0];

        }

        void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(this.Text))
            {
                Value = null;
            }
            else
            {
                int result = 0;
                if (Int32.TryParse(this.Text, out result))
                {
                    Value = result;
                }
                else
                {
                    this.Text = Value.HasValue ? Value.ToString() : String.Empty;
                }
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
