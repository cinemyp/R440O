//-----------------------------------------------------------------------
// <copyright file="K02M_02Inside.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using R440O.Parameters;

namespace R440O.R440OForms.K02M_02Inside
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма внутренней части блока К02-М-1
    /// </summary>
    public partial class K02M_02InsideForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K02M_02InsideForm"/>
        /// </summary>
        public K02M_02InsideForm()
        {
            this.InitializeComponent();
            K02M_02InsideТумблерБ5.BackgroundImage = K02M_02InsideParameters.K02M_02InsideТумблерБ5
                ? ControlElementImages.tumblerType7Left
                : ControlElementImages.tumblerType7Right;
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void K02M_02InsideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void K02M_02InsideТумблерБ5_Click(object sender, System.EventArgs e)
        {
            K02M_02InsideParameters.K02M_02InsideТумблерБ5 = !K02M_02InsideParameters.K02M_02InsideТумблерБ5;
           K02M_02InsideТумблерБ5.BackgroundImage = K02M_02InsideParameters.K02M_02InsideТумблерБ5
                ? ControlElementImages.tumblerType7Left
                : ControlElementImages.tumblerType7Right;
         
        }
    }
}