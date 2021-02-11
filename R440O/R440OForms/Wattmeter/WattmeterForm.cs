//-----------------------------------------------------------------------
// <copyright file="WattmeterForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;

namespace R440O.R440OForms.Wattmeter
{
    using System.Windows.Forms;
    using ThirdParty;
    using System.Reflection;
    using BaseClasses;
    using global::R440O.LearnModule;

    /// <summary>
    /// Форма блока ватметр
    /// </summary>
    public partial class WattmeterForm : Form, IRefreshableForm
    {
        private static bool isManipulation = false;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="WattmeterForm"/>
        /// </summary>
        public WattmeterForm()
        {
            InitializeComponent();
            WattmeterParameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
            
        }

        /// <summary>
        /// Установка переключателей в положение последней их установки
        /// </summary>
        public void RefreshFormElements()
        {
            var angle = WattmeterParameters.ПереключательРежимРаботы * 30 - 105;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);

            ТумблерСеть.BackgroundImage = WattmeterParameters.ТумблерСеть
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Регулятор"))
                {
                    PropertyInfo[] fieldList = typeof(WattmeterParameters).GetProperties();
                    foreach (PropertyInfo property in fieldList)
                    {
                        if (item.Name == property.Name)
                        {
                            item.BackgroundImage = TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, System.Convert.ToInt32(property.GetValue(null)));
                            break;
                        }
                    }
                }
            }
        }

        private void Регулятор_MouseUp(object sender, MouseEventArgs e)
        {
            isManipulation = false;
        }

        private void Регулятор_MouseDown(object sender, MouseEventArgs e)
        {
            isManipulation = true;
        }

        private void Регулятор_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            var property = typeof(WattmeterParameters).GetProperty(button.Name);
            property.SetValue(null, angle);

            button.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, (int)property.GetValue(null));
        }

        private void ПереключательРежимРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WattmeterParameters.ПереключательРежимРаботы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                WattmeterParameters.ПереключательРежимРаботы -= 1;
            }
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            WattmeterParameters.ТумблерСеть = !WattmeterParameters.ТумблерСеть;
        }

        private void WattmeterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WattmeterParameters.ParameterChanged -= RefreshFormElements;
           
        }



    }
}