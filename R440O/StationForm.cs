using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using R440O.R440OForms.R440O;
using R440O.ThirdParty;

namespace R440O
{
    public partial class StationForm : Form
    {
        private Timer таймерПоискаСервера = new Timer();
        private R440OForm r440OForm;

        public StationForm()
        {
            InitializeComponent();

            таймерПоискаСервера.Enabled = true;
            таймерПоискаСервера.Interval = 10000;
            таймерПоискаСервера.Tick += tick;
            таймерПоискаСервера.Start();
        }

        public void tick(object sender, EventArgs e)
        {
            if (!HttpHelper.ПоискИдет)
            {
                if (HttpHelper.СерверНайден)
                {
                    RunR400O();
                }
                else
                {
                    HttpHelper.ПоискСервера();
                }
            }
        }

        public void RunR400O()
        {
            таймерПоискаСервера.Stop();
            ParametersConfig.SetParameters();
            this.Hide();
            r440OForm = new R440OForm();
            r440OForm.FormClosedEvent += OnR440oFormClosed;
            r440OForm.Show();
        }

        private void OfflineWorkButton_Click(object sender, EventArgs e)
        {
            ParametersConfig.setIsLearning(true);
            RunR400O();
        }

        private void OnR440oFormClosed()
        {
            this.Close();
        }
    }
}
