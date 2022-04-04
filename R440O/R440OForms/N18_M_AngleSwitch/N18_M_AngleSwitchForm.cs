using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace R440O.R440OForms.N18_M_AngleSwitch
{
    public partial class N18_M_AngleSwitchForm : Form
    {
        public N18_M_AngleSwitchForm()
        {
            InitializeComponent();
            N18_M_AngleSwitchParameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        public void RefreshFormElements()
        {
            foreach (Control control in Controls)
            {
                var parameter = typeof(N18_M_AngleSwitchParameters).GetProperty(control.Name);
                var block = N18_M_AngleSwitchParameters.getInstance();
                switch ((int)parameter.GetValue(block))
                {
                    case 1: control.BackgroundImage = ControlElementImages.kabelInputK11;
                        break;
                    case 2: control.BackgroundImage = ControlElementImages.kabelInputK12;
                        break;
                    default:
                        control.BackgroundImage = null;
                        break;
                }
            }
        }

        private void OnButtonClick(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var parametersList = typeof(N18_M_AngleSwitchParameters).GetProperties();
                var parameter = typeof(N18_M_AngleSwitchParameters).GetProperty(button.Name);
                var block = N18_M_AngleSwitchParameters.getInstance();

                int newValue = 0;

                if (e.Button == MouseButtons.Left)
                {
                    newValue = ((int)parameter.GetValue(block) != 1) ? 1 : 0;
                }
                if (e.Button == MouseButtons.Right)
                {
                    newValue = ((int)parameter.GetValue(block) != 2) ? 2 : 0;
                }
                parameter.SetValue(block, newValue);
            }
        }
    }
}
