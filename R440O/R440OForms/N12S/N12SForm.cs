//-----------------------------------------------------------------------
// <copyright file="N12SForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using ShareTypes.SignalTypes;
using R440O.Parameters;
using R440O.ThirdParty;
using R440O.BaseClasses;

namespace R440O.R440OForms.N12S
{
    using global::R440O.TestModule;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока Н-12-С
    /// </summary>
    public partial class N12SForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N12SForm"/>
        /// </summary>
        public N12SForm()
        {
            this.InitializeComponent();
            N12SParameters.getInstance().ParameterChanged += RefreshFormElements;
            this.RefreshFormElements();
        }

        #region Кнопка
        private void КнопкаУскор_Click(object sender, System.EventArgs e)
        {
            N12SParameters.getInstance().КнопкаУскор = !N12SParameters.getInstance().КнопкаУскор;
        }
        #endregion

        #region Тумблеры
        private void ТумблерА_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                N12SParameters.getInstance().ТумблерА = -1;

            if (e.Button == MouseButtons.Right)
                N12SParameters.getInstance().ТумблерА = 1;
        }

        private void ТумблерА_MouseUp(object sender, MouseEventArgs e)
        {
            N12SParameters.getInstance().ТумблерА = 0;
        }

        private void ТумблерБ_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                N12SParameters.getInstance().ТумблерБ = 1;

            if (e.Button == MouseButtons.Right)
                N12SParameters.getInstance().ТумблерБ = -1;
        }

        private void ТумблерБ_MouseUp(object sender, MouseEventArgs e)
        {
            N12SParameters.getInstance().ТумблерБ = 0;
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            N12SParameters.getInstance().ТумблерСеть = !N12SParameters.getInstance().ТумблерСеть;
        }
        #endregion

        public void RefreshFormElements()
        {
            ТумблерСеть.BackgroundImage = N12SParameters.getInstance().ТумблерСеть
                ? ControlElementImages.tumblerType8Up
                : ControlElementImages.tumblerType8Down;

            КнопкаУскор.BackgroundImage = N12SParameters.getInstance().КнопкаУскор
                ? ControlElementImages.buttonRoundType8
                : null;

            switch (N12SParameters.getInstance().ТумблерА)
            {
                case -1:
                    ТумблерА.BackgroundImage = ControlElementImages.tumblerType8Left;
                    break;
                case 0:
                    ТумблерА.BackgroundImage = null;
                    break;
                case 1:
                    ТумблерА.BackgroundImage = ControlElementImages.tumblerType8Right;
                    break;
            }

            switch (N12SParameters.getInstance().ТумблерБ)
            {
                case -1:
                    ТумблерБ.BackgroundImage = ControlElementImages.tumblerType8Down;
                    break;
                case 0:
                    ТумблерБ.BackgroundImage = null;
                    break;
                case 1:
                    ТумблерБ.BackgroundImage = ControlElementImages.tumblerType8Up;
                    break;
            }

            //Индикаторы

            var angle = N12SParameters.getInstance().ИндикаторAlpha * (-36) + 36;
            ИндикаторAlphaCenter.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorCenter, angle);

            angle = -N12SParameters.getInstance().ИндикаторAlpha - 67;
            ИндикаторAlpha.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorAlpha, angle);

            angle = N12SParameters.getInstance().ИндикаторBeta * (-36) + 36;
            ИндикаторBetaCenter.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorCenter, angle);

            angle = -N12SParameters.getInstance().ИндикаторBeta + 48;
            ИндикаторBeta.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorBeta, angle);

            //Потенциометры

            angle = N12SParameters.getInstance().ПотенциометрBetaИ * 1.1F - 50;
            ПотенциометрBetaИ.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.getInstance().ПотенциометрBetaV * 1.5F;
            ПотенциометрBetaV.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.getInstance().ПотенциометрAlphaИ * 0.18F;
            ПотенциометрAlphaИ.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.getInstance().ПотенциометрAlphaV * 1.5F;
            ПотенциометрAlphaV.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);


            ЛампочкаУпорА.BackgroundImage = N12SParameters.getInstance().ЛампочкаУпорА
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаУпорБ.BackgroundImage = N12SParameters.getInstance().ЛампочкаУпорБ
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаГотовность.BackgroundImage = (N12SParameters.getInstance().ЛампочкаГотовность)
                ? ControlElementImages.lampType13OnGreen : null;
        }

        private void N12SForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = N12SParameters.getInstance();
                bool def = blockParams.ТумблерСеть;

                TestMain.Action(new JsonAdapter.ActionStation() { Name = "Н502Б", Value = Convert.ToInt32(def) });
            }
            N12SParameters.getInstance().ParameterChanged -= RefreshFormElements;
        }
    }
}