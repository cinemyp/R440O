using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R440O.TestModule
{
    public partial class TestHelper : Form
    {
        public TestHelper()
        {
            InitializeComponent();
        }
        public void SetIntent(ShareTypes.ModulesEnum intent)
        {
            labelCurrentIntent.Text = intent.ToString();
        }
    }
}
