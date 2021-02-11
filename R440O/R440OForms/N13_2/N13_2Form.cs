//-----------------------------------------------------------------------
// <copyright file="N13_2Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using R440O.ThirdParty;

namespace R440O.R440OForms.N13_2
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока Н-13-2
    /// </summary>
    public partial class N13_2Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N13_2Form"/>
        /// </summary>
        public N13_2Form()
        {
            InitializeComponent();

            N13_2Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        public void RefreshFormElements()
        {
            ЛампочкаАнодВключен.BackgroundImage = N13_2Parameters.ЛампочкаАнодВключен
                ? ControlElementImages.lampType5OnRed
                : null;

            ЛампочкаПерегрузкаИстКоллектора.BackgroundImage = N13_2Parameters.ЛампочкаПерегрузкаИстКоллектора
                ? ControlElementImages.lampType5OnRed
                : null;

            var angle = N13_2Parameters.ИндикаторТокЗамедлСистемы * 8F - 60;
            ИндикаторТокЗамедлСистемы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);

            angle = N13_2Parameters.ИндикаторТокКоллектора * 0.43F - 60;
            ИндикаторТокКоллектора.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        private void N13_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            N13_2Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}