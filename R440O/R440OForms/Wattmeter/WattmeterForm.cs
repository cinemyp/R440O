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
    using global::R440O.TestModule;
    using System;

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
            WattmeterParameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
            
        }

        /// <summary>
        /// Установка переключателей в положение последней их установки
        /// </summary>
        public void RefreshFormElements()
        {
            var angle = WattmeterParameters.getInstance().ПереключательРежимРаботы * 30 - 105;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);

            ТумблерСеть.BackgroundImage = WattmeterParameters.getInstance().ТумблерСеть
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
                            item.BackgroundImage = TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, System.Convert.ToInt32(property.GetValue(WattmeterParameters.getInstance())));
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
            property.SetValue(WattmeterParameters.getInstance(), angle);

            button.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, (int)property.GetValue(WattmeterParameters.getInstance()));
        }

        private void ПереключательРежимРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                WattmeterParameters.getInstance().ПереключательРежимРаботы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                WattmeterParameters.getInstance().ПереключательРежимРаботы -= 1;
            }
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            WattmeterParameters.getInstance().ТумблерСеть = !WattmeterParameters.getInstance().ТумблерСеть;
        }

        private void WattmeterForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WattmeterParameters.getInstance().ParameterChanged -= RefreshFormElements;
            if (ParametersConfig.IsTesting)
            {
                var blockParams = WattmeterParameters.getInstance();
                if(TestMain.IsCheck)
                {
                    bool def = !blockParams.ТумблерСеть;

                    TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.Check_Wattmeter, Value = Convert.ToInt32(def) });
                } else
                {
                    bool def = blockParams.ТумблерСеть;

                    TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.Wattmeter_Power, Value = Convert.ToInt32(def) });
                }
                
            }
        }



    }
}