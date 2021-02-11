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
            N12SParameters.ParameterChanged += RefreshFormElements;
            this.RefreshFormElements();
        }

        #region Кнопка
        private void КнопкаУскор_Click(object sender, System.EventArgs e)
        {
            N12SParameters.КнопкаУскор = !N12SParameters.КнопкаУскор;
        }
        #endregion

        #region Тумблеры
        private void ТумблерА_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                N12SParameters.ТумблерА = -1;

            if (e.Button == MouseButtons.Right)
                N12SParameters.ТумблерА = 1;
        }

        private void ТумблерА_MouseUp(object sender, MouseEventArgs e)
        {
            N12SParameters.ТумблерА = 0;
        }

        private void ТумблерБ_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                N12SParameters.ТумблерБ = 1;

            if (e.Button == MouseButtons.Right)
                N12SParameters.ТумблерБ = -1;
        }

        private void ТумблерБ_MouseUp(object sender, MouseEventArgs e)
        {
            N12SParameters.ТумблерБ = 0;
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            N12SParameters.ТумблерСеть = !N12SParameters.ТумблерСеть;
        }
        #endregion

        public void RefreshFormElements()
        {
            ТумблерСеть.BackgroundImage = N12SParameters.ТумблерСеть
                ? ControlElementImages.tumblerType8Up
                : ControlElementImages.tumblerType8Down;

            КнопкаУскор.BackgroundImage = N12SParameters.КнопкаУскор
                ? ControlElementImages.buttonRoundType8
                : null;

            switch (N12SParameters.ТумблерА)
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

            switch (N12SParameters.ТумблерБ)
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

            var angle = N12SParameters.ИндикаторAlpha * (-36) + 36;
            ИндикаторAlphaCenter.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorCenter, angle);

            angle = -N12SParameters.ИндикаторAlpha - 67;
            ИндикаторAlpha.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorAlpha, angle);

            angle = N12SParameters.ИндикаторBeta * (-36) + 36;
            ИндикаторBetaCenter.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorCenter, angle);

            angle = -N12SParameters.ИндикаторBeta + 48;
            ИндикаторBeta.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.N12SIndicatorBeta, angle);

            //Потенциометры

            angle = N12SParameters.ПотенциометрBetaИ * 1.1F - 50;
            ПотенциометрBetaИ.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.ПотенциометрBetaV * 1.5F;
            ПотенциометрBetaV.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.ПотенциометрAlphaИ * 0.18F;
            ПотенциометрAlphaИ.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);

            angle = N12SParameters.ПотенциометрAlphaV * 1.5F;
            ПотенциометрAlphaV.BackgroundImage =
                   TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow, angle);


            ЛампочкаУпорА.BackgroundImage = N12SParameters.ЛампочкаУпорА
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаУпорБ.BackgroundImage = N12SParameters.ЛампочкаУпорБ
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаГотовность.BackgroundImage = (N12SParameters.ЛампочкаГотовность)
                ? ControlElementImages.lampType13OnGreen : null;
        }

        private void N12SForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            N12SParameters.ParameterChanged -= RefreshFormElements;
        }
    }
}