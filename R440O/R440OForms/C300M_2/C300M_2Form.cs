//-----------------------------------------------------------------------
// <copyright file="C300M_2Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System.IO;
using System.Text;
using System.Windows.Forms.VisualStyles;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.C300M_2
{
    using System.Windows.Forms;
    using ThirdParty;
    using System.Reflection;
    using System;
    using BaseClasses;

    /// <summary>
    /// Форма блока С300М_2
    /// </summary>
    public partial class C300M_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="C300M_2Form"/>
        /// </summary>
        public C300M_2Form()
        {

            InitializeComponent();
            C300M_2Parameters.ParameterChanged += RefreshFormElements;
            C300M_2Parameters.IndicatorChanged += RefreshIndicator;
            RefreshIndicator();
            RefreshFormElements();
        }
        
        #region Кнопки ВИД РАБОТЫ
        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки вида работы
        /// </summary>
        private void КнопкаВидРаботы_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            C300M_2Parameters.КнопкиВидРаботы[(int)Char.GetNumericValue(button.Name[15])] = true;
        }

        private void КнопкаВидРаботыСброс_MouseDown(object sender, MouseEventArgs e)
        {
            this.КнопкаВидРаботыСброс.BackgroundImage = null;
            this.КнопкаВидРаботыСброс.Text = "";

            C300M_2Parameters.КнопкиВидРаботы[10] = true;

        }

        private void КнопкаВидРаботыСброс_MouseUp(object sender, MouseEventArgs e)
        {
            this.КнопкаВидРаботыСброс.BackgroundImage = ControlElementImages.buttonSquareWhite;
            this.КнопкаВидРаботыСброс.Text = "СБРОС";
            C300M_2Parameters.КнопкиВидРаботы[10] = false;
        }
        #endregion

        #region Кнопки КОНТРОЛЬ РЕЖИМА

        private void КнопкаКонтрольРежима_Click(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            C300M_2Parameters.КнопкиКонтрольРежима[(int)Char.GetNumericValue(button.Name[20])] = true;
        }

        private void КнопкаКонтрольРежимаМинус27_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаКонтрольРежимаМинус27.BackgroundImage = null;
            КнопкаКонтрольРежимаМинус27.Text = "";

            C300M_2Parameters.КнопкиКонтрольРежима[10] = true;
        }

        private void КнопкаКонтрольРежимаМинус27_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаКонтрольРежимаМинус27.BackgroundImage = ControlElementImages.buttonSquareWhite;
            КнопкаКонтрольРежимаМинус27.Text = "-27";

            C300M_2Parameters.КнопкиКонтрольРежима[10] = false;
        }
        #endregion

        #region Кнопка Индикация волны
        private void КнопкаИндикацияВолны_MouseDown(object sender, MouseEventArgs e)
        {
            C300M_2Parameters.КнопкаИндикацияВолны = true;
            this.КнопкаИндикацияВолны.BackgroundImage = null;

            if (C300M_2Parameters.КнопкаИндикацияВолны)
            {
                ИндикаторВолна1000.Text = (C300M_2Parameters.ПереключательВолна1000 <= 4)
                ? System.Convert.ToString(C300M_2Parameters.ПереключательВолна1000)
                : "4";
                ИндикаторВолна1000.Visible = true;
                ИндикаторВолна100.Text = System.Convert.ToString(C300M_2Parameters.ПереключательВолна100);
                ИндикаторВолна100.Visible = true;
                ИндикаторВолна10.Text = System.Convert.ToString(C300M_2Parameters.ПереключательВолна10);
                ИндикаторВолна10.Visible = true;
                ИндикаторВолна1.Text = System.Convert.ToString(C300M_2Parameters.ПереключательВолна1);
                ИндикаторВолна1.Visible = true;
            }

        }

        private void КнопкаИндикацияВолны_MouseUp(object sender, MouseEventArgs e)
        {
            C300M_2Parameters.КнопкаИндикацияВолны = false;
            this.КнопкаИндикацияВолны.BackgroundImage = ControlElementImages.buttonSquareWhite;

            ИндикаторВолна1000.Visible = false;
            ИндикаторВолна100.Visible = false;
            ИндикаторВолна10.Visible = false;
            ИндикаторВолна1.Visible = false;
        }
        #endregion

        #region Переключатели Волна
        private void ПереключательВолна1000_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C300M_2Parameters.ПереключательВолна1000 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C300M_2Parameters.ПереключательВолна1000 -= 1;
            }
        }

        private void ПереключательВолна100_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C300M_2Parameters.ПереключательВолна100 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C300M_2Parameters.ПереключательВолна100 -= 1;
            }
        }

        private void ПереключательВолна10_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C300M_2Parameters.ПереключательВолна10 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C300M_2Parameters.ПереключательВолна10 -= 1;
            }
        }

        private void ПереключательВолна1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C300M_2Parameters.ПереключательВолна1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C300M_2Parameters.ПереключательВолна1 -= 1;
            }
        }
        #endregion

        #region Инициализация

        public void RefreshIndicator()
        {
            var angle = C300M_2Parameters.ИндикаторСигнал * 1.15F;
            ИндикаторСигнала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        public void RefreshFormElements()
        {
            var angle1 = C300M_2Parameters.ИндикаторСигнал * 1.15F;
            ИндикаторСигнала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle1);

            // Установка переключателей в положение последней их установки
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Переключатель"))
                {
                    PropertyInfo[] fieldList = typeof(C300M_2Parameters).GetProperties();
                    foreach (PropertyInfo property in fieldList)
                    {
                        if (item.Name == property.Name)
                        {
                            var angle = System.Convert.ToInt32(property.GetValue(null)) * 30 - 135;
                            item.BackgroundImage = TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);
                            break;
                        }
                    }
                }
            }

            // Установка кнопок в положение последней их установки
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("КнопкаВидРаботы") && !item.Name.Contains("Сброс"))
                    item.Visible = !(C300M_2Parameters.КнопкиВидРаботы[(int)Char.GetNumericValue(item.Name[15])]);
            }

            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("КнопкаКонтрольРежима") && !item.Name.Contains("Минус27"))
                    item.Visible = !(C300M_2Parameters.КнопкиКонтрольРежима[(int)Char.GetNumericValue(item.Name[20])]);
            }

            // Установка тумблеров в положение последней их установки
            ТумблерУправление.BackgroundImage = C300M_2Parameters.ТумблерУправление
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерВведение.BackgroundImage = C300M_2Parameters.ТумблерВведение
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерБлокировка.BackgroundImage = C300M_2Parameters.ТумблерБлокировка
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерВидВключения.BackgroundImage = C300M_2Parameters.ТумблерВидВключения
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерАнализСимметрии.BackgroundImage = C300M_2Parameters.ТумблерАнализСимметрии
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерАСЧ.BackgroundImage = C300M_2Parameters.ТумблерАСЧ
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерРегулировкаУровня.BackgroundImage = C300M_2Parameters.ТумблерРегулировкаУровня
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерВидМодуляции.BackgroundImage = C300M_2Parameters.ТумблерВидМодуляции
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерПределы.BackgroundImage = C300M_2Parameters.ТумблерПределы
                ? ControlElementImages.tumblerType3Right
                : ControlElementImages.tumblerType3Left;

            // Установка лампочек
            ЛампочкаСигнал.BackgroundImage = C300M_2Parameters.ЛампочкаСигнал
                ? ControlElementImages.lampType13OnGreen
                : null;

            ЛампочкаПитание.BackgroundImage = C300M_2Parameters.ЛампочкаПитание
                ? ControlElementImages.lampType13OnGreen
                : null;

            ЛампочкаПоиск.BackgroundImage = C300M_2Parameters.ЛампочкаПоиск
                ? ControlElementImages.lampType13OnGreen
                : null;
        }
        #endregion

        #region Тумблеры
        private void ТумблерВведение_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерВведение = !C300M_2Parameters.ТумблерВведение;
        }

        private void ТумблерБлокировка_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерБлокировка = !C300M_2Parameters.ТумблерБлокировка;
        }

        private void ТумблерВидВключения_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерВидВключения = !C300M_2Parameters.ТумблерВидВключения;
        }

        private void ТумблерАнализСимметрии_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерАнализСимметрии = !C300M_2Parameters.ТумблерАнализСимметрии;
        }

        private void ТумблерАСЧ_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерАСЧ = !C300M_2Parameters.ТумблерАСЧ;
        }

        private void ТумблерРегулировкаУровня_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерРегулировкаУровня = !C300M_2Parameters.ТумблерРегулировкаУровня;
        }

        private void ТумблерВидМодуляции_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерВидМодуляции = !C300M_2Parameters.ТумблерВидМодуляции;
        }

        private void ТумблерПределы_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерПределы = !C300M_2Parameters.ТумблерПределы;
        }

        private void ТумблерУправление_Click(object sender, System.EventArgs e)
        {
            C300M_2Parameters.ТумблерУправление = !C300M_2Parameters.ТумблерУправление;
        }
        #endregion

        #region Кнопки ПИТАНИЕ
        private void КнопкаПитаниеВкл_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаПитаниеВкл.BackgroundImage = null;
            КнопкаПитаниеВкл.Text = "";
            C300M_2Parameters.КнопкиПитание = true;
        }

        private void КнопкаПитаниеВкл_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаПитаниеВкл.BackgroundImage = ControlElementImages.buttonSquareWhite;
            КнопкаПитаниеВкл.Text = "ВКЛ";
        }

        private void КнопкаПитаниеВыкл_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаПитаниеВыкл.BackgroundImage = null;
            КнопкаПитаниеВыкл.Text = "";
            C300M_2Parameters.КнопкиПитание = false;
        }

        private void КнопкаПитаниеВыкл_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаПитаниеВыкл.BackgroundImage = ControlElementImages.buttonSquareWhite;
            КнопкаПитаниеВыкл.Text = "ОТКЛ";
        }
        #endregion

        #region Кнопка ПОИСК
        private void КнопкаПоиск_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаПоиск.BackgroundImage = null;
            КнопкаПоиск.Text = "";
            C300M_2Parameters.КнопкаПоиск = true;
        }

        private void КнопкаПоиск_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаПоиск.BackgroundImage = ControlElementImages.buttonSquareWhite;
            КнопкаПоиск.Text = "ВКЛ";
            C300M_2Parameters.КнопкаПоиск = false;
        }

        #endregion

        private void C300M_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            C300M_2Parameters.ParameterChanged -= RefreshFormElements;
            C300M_2Parameters.IndicatorChanged -= RefreshIndicator;
        }
    }
}