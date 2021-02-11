//-----------------------------------------------------------------------
// <copyright file="K02M_01.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows.Forms;
using ShareTypes.SignalTypes;
using R440O.R440OForms.K02M_01Inside;
using R440O.R440OForms.K03M_01;
using R440O.ThirdParty;
using R440O.BaseClasses;

namespace R440O.R440OForms.K02M_01
{
    /// <summary>
    /// Форма блока К02-М-1
    /// </summary>
    public partial class K02M_01Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K02M_01Form"/>
        /// </summary>
        public K02M_01Form()
        {
            InitializeComponent();
            K02M_01Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        public void RefreshFormElements()
        {
            InitializeLamps();
            InitializeToggles();
        }

        #region Инициализация
        private void InitializeToggles()
        {
            var angle = K02M_01Parameters.ПереключательСкорость * 45 - 90;
            ПереключательСкорость.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_01Parameters.ПереключательВклОткл * 60 - 90;
            ПереключательВклОткл.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_01Parameters.ПереключательНапряжение1К * 30 - 75;
            ПереключательНапряжение1К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_01Parameters.ПереключательНапряжение2К * 30 - 75;
            ПереключательНапряжение2К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeLamps()
        {
            foreach (Control item in Panel.Controls)
            {
                var fieldList = typeof(K02M_01Parameters).GetProperties();
                var item1 = item;
                foreach (var property in fieldList.Where(property => item1.Name == property.Name))
                {
                    if (item.Name == "ЛампочкаПоискСигналов")
                    {
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.lampType1OnRed
                            : null;
                    }
                    else if (item.Name.Contains("Лампочка"))
                    {
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.lampType9OnGreen
                            : null;
                    }
                }
            }
        }
        #endregion

        #region Кнопки
        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void ButtonInside_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form thisForm = new K02M_01InsideForm();
            thisForm.Show(this);
        }


        private void КнопкаПоиск_MouseDown(object sender, MouseEventArgs e)
        {
            K02M_01Parameters.КнопкаНачатьПоиск_MouseDown();
            КнопкаПоиск.BackgroundImage = null;
        }

        private void K02M_01КнопкаПоиск_MouseUp(object sender, MouseEventArgs e)
        {
            K02M_01Parameters.КнопкаНачатьПоиск_MouseUp();
            КнопкаПоиск.BackgroundImage = ControlElementImages.buttonRoundType5;
        }
        #endregion

        #region Переключатели
        private void ПереключательСкорость_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_01Parameters.ПереключательСкорость += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_01Parameters.ПереключательСкорость -= 1;
            }
        }

        private void ПереключательВклОткл_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_01Parameters.ПереключательВклОткл += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_01Parameters.ПереключательВклОткл -= 1;
            }
        }

        private void ПереключательНапряжение1К_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_01Parameters.ПереключательНапряжение1К += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_01Parameters.ПереключательНапряжение1К -= 1;
            }
        }

        private void ПереключательНапряжение2К_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_01Parameters.ПереключательНапряжение2К += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_01Parameters.ПереключательНапряжение2К -= 1;
            }
        }
        #endregion

        private void K02M_01Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            K02M_01Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}