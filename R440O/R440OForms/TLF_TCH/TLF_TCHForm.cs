using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using R440O.R440OForms.BMA_M_1;
namespace R440O.R440OForms.TLF_TCH
{
    public partial class TLF_TCHForm : Form
    {
        public TLF_TCHForm()
        {
            InitializeComponent();
            TLF_TCHParametrs.ParameterChanged += RefreshElements;
        }

        public void RefreshElements()
        {
            ОтрисовкаШтырей();
            ОтрисовкаГнезд();
        }

        private void TLF_TCHForm_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void ОтрисовкаШтырей()
        {
            bool соединен;
            foreach (Control item in Panel.Controls)
            {
                соединен = false;
                foreach (int номер in TLF_TCHParametrs.НомераСоединений)
                {
                    if (item.Name == ("Штырь" + номер))
                    {
                        item.BackgroundImage = ControlElementImages.ShellCabelConnect;
                        соединен = true;
                        break;
                    }
                }
                if (!соединен && item.Name.Contains("Штырь"))
                    item.BackgroundImage = null;
            }
        }
        private void ОтрисовкаГнезд()
        {
            bool соединен;
            foreach (Control item in Panel.Controls)
            {
                соединен = false;
                foreach (int номер in TLF_TCHParametrs.НомераСоединений)
                {
                    if (item.Name == ("Гнездо" + номер))
                    {
                        item.BackgroundImage = ControlElementImages.ShellCabelConnect;
                        соединен = true;
                        break;
                    }
                }
                if (!соединен && item.Name.Contains("Гнездо"))
                    item.BackgroundImage = null;
            }
        }

        private void Штырь_Click(object sender, EventArgs e)
        {
            var СвязанныйШтырь = sender as Button;
            var text = СвязанныйШтырь.Name;
            int НомерШтыря = text.Length == 6 ?
                (int)char.GetNumericValue(text[5]) :
                10 * (int)char.GetNumericValue(text[5]) + (int)char.GetNumericValue(text[6]);
            TLF_TCHParametrs.Соеденить(НомерШтыря);

        }

        private void Гнездо_Click(object sender, EventArgs e)
        {
            var СвязанноеГнездо = sender as Button;
            var text = СвязанноеГнездо.Name;
            int НомерГнезда = text.Length == 7 ?
                (int)char.GetNumericValue(text[6]) :
                10 * (int)char.GetNumericValue(text[6]) + (int)char.GetNumericValue(text[7]);
            TLF_TCHParametrs.Соеденить(НомерГнезда);
        }
    }
}
