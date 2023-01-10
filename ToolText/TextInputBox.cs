using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolText
{
    public partial class TextInputBox : Form
    {
        private Form1 parent;
        public TextInputBox(Form1 _parent)
        {
            InitializeComponent();
            parent = _parent;
        }

        private void checkButton1_Click(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private void checkButton2_Click(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private void checkButton3_Click(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private void checkButton4_Click(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private void TextInputBox_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
            {
                comboBox1.Items.Add(font.Name);
            }
            comboBox1.Text = "Arial";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            parent.DrawUpdater();
        }

        private bool _underline
        {
            get
            {
                return checkButton4.Checked;
            }
        }
        private bool _bold
        {
            get
            {
                return checkButton1.Checked;
            }
        }
        private bool _italic
        {
            get
            {
                return checkButton2.Checked;
            }
        }
        private bool _strike
        {
            get
            {
                return checkButton3.Checked;
            }
        }

        private Font CreateFont()
        {
            Font cfont = null;
            FontStyle fs = FontStyle.Regular;
            if (_underline)
            {
                fs |= FontStyle.Underline;
            }
            if (_bold)
            {
                fs |= FontStyle.Bold;
            }
            if (_italic)
            {
                fs |= FontStyle.Italic;
            }
            if (_strike)
            {
                fs |= FontStyle.Strikeout;
            }
            cfont = new Font(comboBox1.Text, (float)numericUpDown1.Value, fs);
            return cfont;
        }

        public Font ChoosenFont
        {
            get
            {
                return CreateFont();
            }
        }

        
    }
}
