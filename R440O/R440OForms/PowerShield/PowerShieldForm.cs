//-----------------------------------------------------------------------
// <copyright file="PowerShieldForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

namespace R440O.R440OForms.PowerShield
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока щит питания
    /// </summary>
    public partial class PowerShieldForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PowerShieldForm"/>
        /// </summary>
        public PowerShieldForm()
        {
            this.InitializeComponent();
        }

        private void КнопкаТЛФ_ТЧ_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form thisForm = new TLF_TCH.TLF_TCHForm();
            thisForm.Show(this);
        }
    }
}