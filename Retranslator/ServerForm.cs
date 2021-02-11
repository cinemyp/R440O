using System;
using System.Linq;
using System.Windows.Forms;

namespace Retranslator
{
    public partial class ServerForm : Form
    {
        private Server server;

        public ServerForm()
        {
            InitializeComponent();

            server = new Server();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            const string privateNameColumn = "PrivateName";
            const string stationWaveColumn = "Wave";
            const string stationPowerColumn = "Power";
            const string stationModulationColumn = "Modulation";
            const string stationGroupSpeedColumn = "GroupSpeed";

            server.ClearStantionList();

            var stations = server.OrderSchemePairs.SelectMany(pair =>
                   new[] { pair.GetStationOrderScheme1(), pair.GetStationOrderScheme2() })
                   .Where(s => s.Item1 != null)
                   .ToList();

            foreach (var row in this.dataGridView1.Rows.Cast<DataGridViewRow>())
            {
                if (!stations.Any(s => s.Item2.ИндивидуальныйПозывной.ToString() ==
                    (string)row.Cells[privateNameColumn].Value))
                {
                    this.dataGridView1.Rows.Remove(row);
                }
            }

            foreach (var station in stations)
            {
                var row = this.dataGridView1.Rows.Cast<DataGridViewRow>()
                    .FirstOrDefault(r => r.Cells[privateNameColumn].Value.ToString() ==
                        station.Item2.ИндивидуальныйПозывной.ToString());
                if (row == null)
                {
                    int index = this.dataGridView1.Rows.Add();
                    row = this.dataGridView1.Rows[index];
                }
                row.Cells[privateNameColumn].Value = station.Item2.ИндивидуальныйПозывной.ToString();
                row.Cells[stationWaveColumn].Value = station.Item1.Signal == null
                    ? "no signal"
                    : (station.Item1.Signal.Wave + 1500).ToString();
                row.Cells[stationPowerColumn].Value = station.Item1.Signal == null
                    ? "no signal"
                    : station.Item1.Signal.Power.ToString();
                row.Cells[stationModulationColumn].Value = station.Item1.Signal == null
                    ? "no signal"
                    : station.Item1.Signal.Modulation.ToString();
                row.Cells[stationGroupSpeedColumn].Value = station.Item1.Signal == null
                    ? "no signal"
                    : station.Item1.Signal.GroupSpeed.ToString();
            }
        }
    }
}
