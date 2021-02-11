using System;
using System.Windows.Forms;

namespace R440O.R440OForms.N18_M_H28
{
    public partial class N18_M_H28Form : Form
    {
        public N18_M_H28Form()
        {
            InitializeComponent();
            N18_M_H28Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        public void RefreshFormElements()
        {
            КабельК11.Visible = N18_M_H28Parameters.АктивныйКабель != 1;
            КабельК12.Visible = N18_M_H28Parameters.АктивныйКабель != 2;

            АктивныйКабель.Visible = true;
            switch (N18_M_H28Parameters.АктивныйКабель)
            {
                case 1: АктивныйКабель.BackgroundImage = ControlElementImages.kabelInputK11; break;
                case 2: АктивныйКабель.BackgroundImage = ControlElementImages.kabelInputK12; break;
                default: АктивныйКабель.Visible = false;
                    break;
            }
        }

        private void КабельК11_Click(object sender, EventArgs e)
        {
            N18_M_H28Parameters.АктивныйКабель = 1;
        }

        private void КабельК12_Click(object sender, EventArgs e)
        {
            N18_M_H28Parameters.АктивныйКабель = 2;
        }

        private void АктивныйКабель_Click(object sender, EventArgs e)
        {
            N18_M_H28Parameters.АктивныйКабель = 0;
        }
    }
}
