using System;
using System.Windows.Forms;

namespace R440O.LearnModule
{
    public partial class LearnTypeSelector : Form
    {
        public LearnTypeSelector()
        {
            InitializeComponent();
        }

        private void oneChannelTypeButton_Click(object sender, EventArgs e)
        {
            LearnMain.globalIntent = GlobalIntentEnum.OneChannel;
            LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            Close();
        }

        private void DiscreteTypeButton_Click(object sender, EventArgs e)
        {
            LearnMain.globalIntent = GlobalIntentEnum.Discrete;
            LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            Close();
        }

        private void DUB5Button_Click(object sender, EventArgs e)
        {
            LearnMain.globalIntent = GlobalIntentEnum.DUB5;
            LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            Close();
        }

        private void SHPSButton_Click(object sender, EventArgs e)
        {
            LearnMain.globalIntent = GlobalIntentEnum.SHPS;
            LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            Close();
        }

       
    }
}
