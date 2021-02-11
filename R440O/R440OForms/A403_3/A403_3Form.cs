//-----------------------------------------------------------------------
// <copyright file="A403_3Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;

namespace R440O.R440OForms.A403_3
{
    using System.Windows.Forms;
    using BaseClasses;

    /// <summary>
    /// Форма блока A403-3
    /// </summary>
    public partial class A403_3Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="A403_3Form"/>.
        /// </summary>
        public A403_3Form()
        {
            InitializeComponent();
            A403_3Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        /// <summary>
        /// Задание начального положения тумблера для выбора комплекта блока
        /// </summary>
        public void RefreshFormElements()
        {
            ТублерКомплект.BackgroundImage = A403_3Parameters.ТублерКомплект
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        }

        private void ТублерКомплект_Click(object sender, System.EventArgs e)
        {
            A403_3Parameters.ТублерКомплект = !A403_3Parameters.ТублерКомплект;
        }

        private void A403_3Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            A403_3Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}