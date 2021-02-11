using ShareTypes.SignalTypes;
using R440O.BaseClasses;

namespace R440O.R440OForms.C300PM_2
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока С300ПМ-2
    /// </summary>
    public partial class C300PM_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="C300PM_2Form"/>
        /// </summary>
        public C300PM_2Form()
        {
            InitializeComponent();
            C300PM_2Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        /// <summary>
        /// Инициализирует начальное состояние ламп блока.
        /// </summary>
        public void RefreshFormElements()
        {
            ЛампочкаКомплект1.BackgroundImage = C300PM_2Parameters.ЛампочкаКомплект1
                ? ControlElementImages.lampType10OnGreen
                : null;
            ЛампочкаКомплект2.BackgroundImage = C300PM_2Parameters.ЛампочкаКомплект2
                ? ControlElementImages.lampType10OnGreen
                : null;
        }

        private void C300PM_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            C300PM_2Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}