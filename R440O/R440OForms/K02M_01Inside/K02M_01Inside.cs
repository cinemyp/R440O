//-----------------------------------------------------------------------
// <copyright file="K02M_01Inside.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using R440O.Parameters;

namespace R440O.R440OForms.K02M_01Inside
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма внутренней части блока К02-М-1
    /// </summary>
    public partial class K02M_01InsideForm : Form
    {
        public void RefreshFormElements()
        {
            ТумблерБ5.BackgroundImage = K02M_01InsideParameters.ТумблерБ5
                ? ControlElementImages.tumblerType7Left
                : ControlElementImages.tumblerType7Right;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K02M_01InsideForm"/>
        /// </summary>
        public K02M_01InsideForm()
        {
            K02M_01InsideParameters.ParameterChanged += RefreshFormElements;
            this.InitializeComponent();
            RefreshFormElements();
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void K02M_01InsideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void K02M_01InsideТумблерБ5_Click(object sender, System.EventArgs e)
        {
            K02M_01InsideParameters.ТумблерБ5 = !K02M_01InsideParameters.ТумблерБ5;
        }
    }
}