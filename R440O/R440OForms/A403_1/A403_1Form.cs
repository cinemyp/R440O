﻿//-----------------------------------------------------------------------
// <copyright file="A403_1Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using ShareTypes.SignalTypes;
using R440O.BaseClasses;
using R440O.Properties;

namespace R440O.R440OForms.A403_1
{
    using System.Windows.Forms;
    using Parameters;
    using ThirdParty;
    using BaseClasses;
    using global::R440O.TestModule;
    using ShareTypes.JsonAdapter;
    using ShareTypes;

    /// <summary>
    /// Форма блока А403-1
    /// </summary>
    public partial class A403_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="A403_1Form"/>.
        /// </summary>
        public A403_1Form()
        {
            InitializeComponent();
            A403_1Parameters.getInstance().ParameterChanged += RefreshFormElements;
            A403_1Parameters.getInstance().DisplayChanged += RefreshDisplay;
            RefreshFormElements();
            FillValues();
        }

        #region Обновление Формы

        public void RefreshDisplay()
        {
            //для разного отображения пустой строки при выключенном и включенном питании
            Дисплей.Text = A403_1Parameters.getInstance().Включен ? FormatString(A403_1Parameters.getInstance().Дисплей) : "";

            //получим значение если зажата кнопка параметров
            if (A403_1Parameters.getInstance().КнопкиПараметры.PressedButton == -1 || A403_1Parameters.getInstance().Дисплей != "" ||
                !A403_1Parameters.getInstance().Включен) return;

            if (A403_1Parameters.getInstance().ТумблерКомплект)
                Дисплей.Text =
                    FormatString(A403_1Parameters.getInstance().ДисплейЗначения1К[(A403_1Parameters.getInstance().ТумблерГруппа) ? 0 : 1,
                        A403_1Parameters.getInstance().КнопкиПараметры.PressedButton]);
            else
                Дисплей.Text =
                    FormatString(A403_1Parameters.getInstance().ДисплейЗначения2К[(A403_1Parameters.getInstance().ТумблерГруппа) ? 0 : 1,
                        A403_1Parameters.getInstance().КнопкиПараметры.PressedButton]);
        }

        /// <summary>
        /// обновление формы
        /// </summary>
        public void RefreshFormElements()
        {
            RefreshDisplay();

            ЛампочкаКомплект1.BackgroundImage = A403_1Parameters.getInstance().ЛампочкаКомплект1
                ? ControlElementImages.lampType12OnRed
                : null;

            ЛампочкаКомплект2.BackgroundImage = A403_1Parameters.getInstance().ЛампочкаКомплект2
                ? ControlElementImages.lampType12OnRed
                : null;

            ТумблерСеть.BackgroundImage = A403_1Parameters.getInstance().ТумблерСеть
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;

            ТумблерКомплект.BackgroundImage = A403_1Parameters.getInstance().ТумблерКомплект
                ? ControlElementImages.tumblerType5Left
                : ControlElementImages.tumblerType5Right;

            ТумблерГотов.BackgroundImage = A403_1Parameters.getInstance().ТумблерГотов
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерГруппа.BackgroundImage = A403_1Parameters.getInstance().ТумблерГруппа
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерАвтКоррекция.BackgroundImage = A403_1Parameters.getInstance().ТумблерАвтКоррекция
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            var angle = A403_1Parameters.getInstance().ПереключательРежимРаботы * 34 - 165;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);


            angle = A403_1Parameters.getInstance().ПереключательПроверка * 32 - 185;
            ////Смещение т.к форма не хорошо нарисована
            if (A403_1Parameters.getInstance().ПереключательПроверка <= 6) angle -= 6;
            if (A403_1Parameters.getInstance().ПереключательПроверка == 4 || A403_1Parameters.getInstance().ПереключательПроверка == 5) angle -= 6;
            ПереключательПроверка.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            //отрисовка кнопок параметров
            foreach (
                Control item in
                    Panel.Controls.Cast<Control>()
                        .Where(item => item.Name.Contains("КнопкаПараметры") && !item.Name.Contains("Сброс")))
            {
                item.BackgroundImage = A403_1Parameters.getInstance().КнопкиПараметры[int.Parse(item.Name[15].ToString())]
                    ? null
                    : ControlElementImages.buttonSquareWhite;
            }
        }

        #endregion

        #region Тумблеры

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            A403_1Parameters.getInstance().ТумблерСеть = !A403_1Parameters.getInstance().ТумблерСеть;
        }

        private void ТумблерКомплект_Click(object sender, System.EventArgs e)
        {
            A403_1Parameters.getInstance().ТумблерКомплект = !A403_1Parameters.getInstance().ТумблерКомплект;
        }

        private void ТумблерГотов_Click(object sender, System.EventArgs e)
        {
            A403_1Parameters.getInstance().ТумблерГотов = !A403_1Parameters.getInstance().ТумблерГотов;
        }

        private void ТумблерГруппа_Click(object sender, System.EventArgs e)
        {
            A403_1Parameters.getInstance().ТумблерГруппа = !A403_1Parameters.getInstance().ТумблерГруппа;
        }

        private void ТумблерАвтКоррекция_Click(object sender, System.EventArgs e)
        {
            A403_1Parameters.getInstance().ТумблерАвтКоррекция = !A403_1Parameters.getInstance().ТумблерАвтКоррекция;
        }

        #endregion

        #region Кнопки

        #region Кнопки выбора параметров

        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки параметров
        /// </summary>
        private void КнопкаПараметры_Click(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            int buttonNumber = int.Parse(button.Name[15].ToString());
            A403_1Parameters.getInstance().КнопкиПараметры[buttonNumber] = true;
            A403_1Parameters.getInstance().Значение = "";
        }

        private void КнопкаПараметрыСброс_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаПараметрыСброс.BackgroundImage = null;
            A403_1Parameters.getInstance().КнопкиПараметры[9] = true;
        }

        private void КнопкаПараметрыСброс_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаПараметрыСброс.BackgroundImage = ControlElementImages.buttonSquareLightBlue;
            A403_1Parameters.getInstance().КнопкиПараметры[9] = false;
        }

        #endregion

        #region Кнопки набора значений

        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки набора значений
        /// </summary>
        private void КнопкаНабора_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            button.BackgroundImage = null;
            button.Text = string.Empty;
        }

        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки набора значений
        /// </summary>
        private void КнопкаНабора_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            //Названия всех кнопок отличаются лишь на один 6 символ (Исключение КнопкаМинус)
            char number = button.Name[6];
            button.BackgroundImage = ControlElementImages.buttonSquareWhite;
            //Восстановление текста над кнопкой после отжатия (КнопкаМинус, как отдельный случай)
            button.Text = (number == 'М')
                ? "-"
                : Convert.ToString(number);

            //Записываем значение
            if (A403_1Parameters.getInstance().Значение.Length == 0)
                A403_1Parameters.getInstance().Значение = "+"; //явно укажем знак числа

            if (A403_1Parameters.getInstance().Значение.Length > 0)
                if (number == 'М')
                    A403_1Parameters.getInstance().Значение = (A403_1Parameters.getInstance().Значение[0] == '+')
                        ? "-" + A403_1Parameters.getInstance().Значение.Substring(1)
                        : "+" + A403_1Parameters.getInstance().Значение.Substring(1);
                else
                    A403_1Parameters.getInstance().Значение += Convert.ToString(number);
        }

        #endregion

        private void КнопкаУстВремени_MouseDown(object sender, MouseEventArgs e)
        {
            A403_1Parameters.getInstance().КнопкаУстВремени = true;
            КнопкаУстВремени.BackgroundImage = null;
        }

        private void КнопкаУстВремени_MouseUp(object sender, MouseEventArgs e)
        {
            A403_1Parameters.getInstance().КнопкаУстВремени = false;
            КнопкаУстВремени.BackgroundImage = ControlElementImages.buttonSquareLightBlue;
        }

        #endregion

        #region Переключатели

        private void ПереключательРежимРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                A403_1Parameters.getInstance().ПереключательРежимРаботы += 1;

            if (e.Button == MouseButtons.Right)
                A403_1Parameters.getInstance().ПереключательРежимРаботы -= 1;
        }

        private void ПереключательПроверка_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                A403_1Parameters.getInstance().ПереключательПроверка += 1;

            if (e.Button == MouseButtons.Right)
                A403_1Parameters.getInstance().ПереключательПроверка -= 1;
        }

        #endregion

        #region Табло

        /// <summary>
        /// функция форматирования для табло
        /// </summary>
        private string FormatString(string inputStr)
        {
            string minus = "  ";
            if (inputStr.Length > 0)
                minus = (inputStr[0] == '-') ? "* " : "  ";

            switch (inputStr.Length)
            {
                case 0:
                    return ("  _ _ _ _ _ _");
                case 1:
                    return (minus + "_ _ _ _ _ _");
                case 2:
                    return (minus + inputStr[1] + " _ _ _ _ _");
                case 3:
                    return (minus + inputStr[1] + " " + inputStr[2] + " _ _ _ _");
                case 4:
                    return (minus + inputStr[1] + " " + inputStr[2] + " " + inputStr[3] + " _ _ _");
                case 5:
                    return (minus + inputStr[1] + " " + inputStr[2] + " " + inputStr[3] + " " + inputStr[4] + " _ _");
                case 6:
                    return (minus + inputStr[1] + " " + inputStr[2] + " " + inputStr[3] +
                            " " + inputStr[4] + " " + inputStr[5] + " _");
                case 7:
                    return (minus + inputStr[1] + " " + inputStr[2] + " " + inputStr[3] + " " +
                            inputStr[4] + " " + inputStr[5] + " " + inputStr[6]);
            }
            return "";
        }

        #endregion

        #region Список значений

        private void Values_Click(object sender, EventArgs e)
        {
            richTextBoxValues.Visible = !richTextBoxValues.Visible;
        }

        private void FillValues()
        {
            richTextBoxValues.Text = Resources.A403_1Form_FillValues_;
        }

        #endregion

        private void A403_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            var blockParams = A403_1Parameters.getInstance();
            bool def;
            switch (TestMain.getIntent())
            {
                case ShareTypes.ModulesEnum.Check_A403:
                    def = blockParams.ТумблерСеть &&
                        !blockParams.ТумблерГотов &&
                        !blockParams.ТумблерАвтКоррекция &&
                        blockParams.ПереключательПроверка == 2;
                    //Комплект произвольный
                    //Неисправность АПН - не работает???

                    TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_A403, Value = Convert.ToInt32(def) });
                    break;
                case ShareTypes.ModulesEnum.A403:
                    def = blockParams.A403Checked;
                    TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.A403, Value = Convert.ToInt32(def) });

                    break;
            }
            A403_1Parameters.getInstance().ParameterChanged -= RefreshFormElements;
            A403_1Parameters.getInstance().DisplayChanged -= RefreshDisplay;
        }
    }
}