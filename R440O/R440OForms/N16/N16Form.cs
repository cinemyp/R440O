//-----------------------------------------------------------------------
// <copyright file="N16Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using R440O.R440OForms.N13_1;
using R440O.ThirdParty;

namespace R440O.R440OForms.N16
{
    using System;
    using System.Windows.Forms;
    using BaseClasses;
    /// <summary>
    /// Форма блока Н-16
    /// </summary>
    public partial class N16Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N16Form"/>
        /// </summary>
        public N16Form()
        {
            InitializeComponent();

            N16Parameters.ParameterChanged += RefreshFormElements;
            N16Parameters.IndicatorChanged += RefreshIndicators;
            RefreshFormElements();
        }

        public void RefreshIndicators()
        {
            var angle = N16Parameters.ИндикаторМощностьНагрузки * 1.05F - 52;
            ИндикаторМощностьНагрузки.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);

            angle = N16Parameters.ИндикаторМощностьВыхода * 1.05F - 52;
            ИндикаторМощностьВыхода.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        public void RefreshFormElements()
        {
            RefreshIndicators();
            КнопкаВкл.BackgroundImage = !N16Parameters.КнопкаВкл
                ? ControlElementImages.buttonSquareBlackLarge
                : null;
            КнопкаН13_12.BackgroundImage = !N16Parameters.КнопкаН13_12
                ? ControlElementImages.buttonSquareBlackLarge
                : null;
            КнопкаН13_1.BackgroundImage = !N16Parameters.КнопкаН13_1
                ? ControlElementImages.buttonSquareBlackLarge
                : null;
            КнопкаН13_2.BackgroundImage = !N16Parameters.КнопкаН13_2
                ? ControlElementImages.buttonSquareBlackLarge
                : null;
            КнопкаАнтенна.BackgroundImage = !N16Parameters.КнопкаАнтенна
                ? ControlElementImages.buttonSquareBlackLarge
                : null;
            КнопкаЭквивалент.BackgroundImage = !N16Parameters.КнопкаЭквивалент
                ? ControlElementImages.buttonSquareBlackLarge
                : null;

            ЛампочкаН13_12.BackgroundImage = N16Parameters.ЛампочкаН13_12
                ? ControlElementImages.lampType6OnRed
                : null;
            ЛампочкаН13_1.BackgroundImage = N16Parameters.ЛампочкаН13_1
                ? ControlElementImages.lampType6OnRed
                : null;
            ЛампочкаН13_2.BackgroundImage = N16Parameters.ЛампочкаН13_2
                ? ControlElementImages.lampType6OnRed
                : null;
            ЛампочкаАнтенна.BackgroundImage = N16Parameters.ЛампочкаАнтенна
                ? ControlElementImages.lampType6OnRed
                : null;
            ЛампочкаЭквивалент.BackgroundImage = N16Parameters.ЛампочкаЭквивалент
                ? ControlElementImages.lampType6OnRed
                : null;
        }

        #region Тумблеры
        private void ТумблерУровень1_MouseUp(object sender, MouseEventArgs e)
        {
            N16Parameters.ТумблерУровень1 = 0;
            ТумблерУровень1.BackgroundImage = null;
        }

        private void ТумблерУровень1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N16Parameters.ТумблерУровень1 = 1;
                ТумблерУровень1.BackgroundImage = ControlElementImages.tumblerType6Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N16Parameters.ТумблерУровень1 = -1;
                ТумблерУровень1.BackgroundImage = ControlElementImages.tumblerType6Up;
            }
        }

        private void ТумблерФаза_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N16Parameters.ТумблерФаза = 1;
                ТумблерФаза.BackgroundImage = ControlElementImages.tumblerType6Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N16Parameters.ТумблерФаза = -1;
                ТумблерФаза.BackgroundImage = ControlElementImages.tumblerType6Up;
            }
        }

        private void ТумблерФаза_MouseUp(object sender, MouseEventArgs e)
        {
            N16Parameters.ТумблерФаза = 0;
            ТумблерФаза.BackgroundImage = null;
        }

        private void ТумблерУровень2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N16Parameters.ТумблерУровень2 = 1;
                ТумблерУровень2.BackgroundImage = ControlElementImages.tumblerType6Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N16Parameters.ТумблерУровень2 = -1;
                ТумблерУровень2.BackgroundImage = ControlElementImages.tumblerType6Up;
            }
        }

        private void ТумблерУровень2_MouseUp(object sender, MouseEventArgs e)
        {
            N16Parameters.ТумблерУровень2 = 0;
            ТумблерУровень2.BackgroundImage = null;
        }

        #endregion

        #region Кнопки
        private void КнопкаН13_12_Click(object sender, EventArgs e)
        {
            N16Parameters.КнопкаН13_12 = !N16Parameters.КнопкаН13_12;
        }

        private void КнопкаН13_1_Click(object sender, EventArgs e)
        {
            N16Parameters.КнопкаН13_1 = !N16Parameters.КнопкаН13_1;
        }

        private void КнопкаН13_2_Click(object sender, EventArgs e)
        {
            N16Parameters.КнопкаН13_2 = !N16Parameters.КнопкаН13_2;
        }

        private void КнопкаАнтенна_Click(object sender, EventArgs e)
        {
            N16Parameters.КнопкаАнтенна = !N16Parameters.КнопкаАнтенна;
        }

        private void КнопкаЭквивалент_Click(object sender, EventArgs e)
        {
            N16Parameters.КнопкаЭквивалент = !N16Parameters.КнопкаЭквивалент;
        }

        private void КнопкаВкл_Click(object sender, EventArgs e)
        {
            if (!N16Parameters.КнопкаВкл) N16Parameters.КнопкаВкл = true;
        }

        private void КнопкаОткл_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОткл.BackgroundImage = null;
            N16Parameters.КнопкаВкл = false;
        }

        private void КнопкаОткл_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОткл.BackgroundImage = ControlElementImages.buttonSquareRedLarge;
        }
        #endregion

        private void N16Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            N16Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}