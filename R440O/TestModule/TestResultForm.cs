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
    public partial class TestResultForm : Form
    {
        public TestResultForm(TestResult tr)
        {
            InitializeComponent();
            ResultText.Text = tr.result.ToString();
            TimeResultText.Text = tr.testingTime.ToShortTimeString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
