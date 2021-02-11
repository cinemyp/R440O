//-----------------------------------------------------------------------
// <copyright file="K02M_02.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System.Linq;
using R440O.ThirdParty;

namespace R440O.R440OForms.K02M_02
{
    using System;
    using System.Reflection;
    using System.Windows.Forms;
    using K02M_02Inside;
    using Parameters;

    /// <summary>
    /// Форма блока К02-М-1
    /// </summary>
    public partial class K02M_02Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K02M_02Form"/>
        /// </summary>
        public K02M_02Form()
        {
            this.InitializeComponent();
            this.InitializeLamps();
            this.InitializeToggles();
        }

        #region Инициализация
        private void InitializeToggles()
        {
            var angle = K02M_02Parameters.K02M_02ПереключательСкорость * 45 - 90;
            K02M_02ПереключательСкорость.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_02Parameters.K02M_02ПереключательВклОткл * 60 - 90;
            K02M_02ПереключательВклОткл.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_02Parameters.K02M_02ПереключательНапряжение1К * 30 - 75;
            K02M_02ПереключательНапряжение1К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = K02M_02Parameters.K02M_02ПереключательНапряжение2К * 30 - 75;
            K02M_02ПереключательНапряжение2К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeLamps()
        {
            foreach (Control item in K02M_02Panel.Controls)
            {
                var fieldList = typeof(K02M_02Parameters).GetFields();
                foreach (var property in fieldList.Where(property => item.Name == property.Name))
                {
                    if (item.Name == "K02M_02ЛампочкаПоискСигналов")
                    {
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.lampType1OnRed
                            : null;
                    }
                    else if (item.Name.Contains("K02M_02Лампочка"))
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
        private void K02M_02ButtonInside_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form thisForm = new K02M_02InsideForm();
            thisForm.Show(this);
        }


        private void K02M_02КнопкаПоиск_MouseDown(object sender, MouseEventArgs e)
        {
            K02M_02КнопкаПоиск.BackgroundImage = null;
        }

        private void K02M_02КнопкаПоиск_MouseUp(object sender, MouseEventArgs e)
        {
            K02M_02КнопкаПоиск.BackgroundImage = ControlElementImages.buttonRoundType5;
        }
        #endregion

        private void K02M_02ПереключательСкорость_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_02Parameters.K02M_02ПереключательСкорость += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_02Parameters.K02M_02ПереключательСкорость -= 1;
            }

            var angle = K02M_02Parameters.K02M_02ПереключательСкорость * 45 - 90;
            K02M_02ПереключательСкорость.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void K02M_02ПереключательВклОткл_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_02Parameters.K02M_02ПереключательВклОткл += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_02Parameters.K02M_02ПереключательВклОткл -= 1;
            }

            var angle = K02M_02Parameters.K02M_02ПереключательВклОткл * 60 - 90;
            K02M_02ПереключательВклОткл.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void K02M_02ПереключательНапряжение1К_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_02Parameters.K02M_02ПереключательНапряжение1К += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_02Parameters.K02M_02ПереключательНапряжение1К -= 1;
            }

            var angle = K02M_02Parameters.K02M_02ПереключательНапряжение1К * 30 - 75;
            K02M_02ПереключательНапряжение1К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void K02M_02ПереключательНапряжение2К_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K02M_02Parameters.K02M_02ПереключательНапряжение2К += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K02M_02Parameters.K02M_02ПереключательНапряжение2К -= 1;
            }

            var angle = K02M_02Parameters.K02M_02ПереключательНапряжение2К * 30 - 75;
            K02M_02ПереключательНапряжение2К.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }
    }
}