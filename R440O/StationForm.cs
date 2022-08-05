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
using R440O.TestModule;
using R440O.ThirdParty;

namespace R440O
{
    public partial class StationForm : Form
    {
        private Timer таймерПоискаСервера = new Timer();
        private R440OForm r440OForm;

        private string IpAddress { get; set; }
        private bool IsLearning { get; set; }
        
        public StationForm()
        {
            InitializeComponent();
        }

        public void tick(object sender, EventArgs e)
        {
            if (!HttpHelper.ПоискИдет)
            {
                if (HttpHelper.СерверНайден)
                {
                    btnExaming.Enabled = true;
                    btnLearning.Enabled = true;
                    btnConnect.Enabled = true;

                    pbConnectionGot.Visible = true;
                    StopSearch(false);
                }
                else if (HttpHelper.ConnectError)
                {
                    StopSearch(true);
                }
                else
                {
                    HttpHelper.ПроверкаСервера(IpAddress);
                }
            }

        }

        public void RunR400O(bool isLearning)
        {
            таймерПоискаСервера.Stop();
            ParametersConfig.setIsLearning(IsLearning);
            ParametersConfig.IsTesting = !IsLearning;
            ParametersConfig.SetParameters();
            this.Hide();
            r440OForm = new R440OForm();
            r440OForm.FormClosedEvent += OnR440oFormClosed;
            r440OForm.Show();
            if(!isLearning)
            {
                TestMain.StartTest();
            }
        }
        
        private void OfflineWorkButton_Click(object sender, EventArgs e)
        {
            IsLearning = true;
            RunR400O(IsLearning);
        }

        private void OnR440oFormClosed()
        {
            this.Show();
        }

        private void btnLearning_Click(object sender, EventArgs e)
        {
            IsLearning = true;
            RunR400O(IsLearning);
        }

        private void btnExaming_Click(object sender, EventArgs e)
        {
            RunR400O(false);
        }

        private void StartSearch()
        {
            HttpHelper.StopSearch();

            таймерПоискаСервера.Enabled = true;
            таймерПоискаСервера.Interval = 3000;
            таймерПоискаСервера.Tick += tick;
            таймерПоискаСервера.Start();

            btnExaming.Enabled = false;
            btnLearning.Enabled = false;
            btnConnect.Enabled = false;

            pbConnectionError.Visible = false;
            pbConnectionGot.Visible = false;
        }

        private void StopSearch(bool error = false)
        {
            таймерПоискаСервера.Stop();
            btnLearning.Enabled = true;
            btnConnect.Enabled = true;

            if(error)
            {
                pbConnectionError.Visible = true;
                pbConnectionError.BringToFront();

                HttpHelper.StopSearch();
                return;
            }

            btnExaming.Enabled = true;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            var ip = tbIpAddress.Text;
            IpAddress = ip;

            StartSearch();
        }
    }
}
