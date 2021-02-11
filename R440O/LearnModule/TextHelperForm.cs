using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R440O.LearnModule
{
    public partial class TextHelperForm : Form
    {
        public TextHelperForm()
        {

            TopMost = true;
            InitializeComponent();
        }

        private void TextHelperForm_Load(object sender, EventArgs e)
        {
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
        }
    }
}
