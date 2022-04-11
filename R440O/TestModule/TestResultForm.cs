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
        private string[] marksText = new string[5] {
            "неудовл",
            "неудовл",
            "удовл",
            "хор",
            "отл"
        };
        public TestResultForm(TestResult tr)
        {
            InitializeComponent();
            int markIndex = (int)tr.result - 1;
            ResultText.Text = marksText[markIndex];
            TimeResultText.Text = tr.testingTime.ToString("mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
