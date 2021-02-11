//-----------------------------------------------------------------------
// <copyright file="BMA_M_2Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;

namespace R440O.R440OForms.BMA_M_2
{
    using System.Windows.Forms;
    using System.Reflection;
    using Parameters;
    using ThirdParty;
    using System;
    using System.Drawing;
    using BaseClasses;


    /// <summary>
    /// Форма блока БМА-М-1
    /// </summary>
    public partial class BMA_M_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BMA_M_2Form"/>.
        /// </summary>
        public BMA_M_2Form()
        {
            InitializeComponent();
            BMA_M_2Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();

        }

        #region Переключатели
        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательКонтроль -= 1;
            }
        }

        private void ПереключательРекурента_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательРекуррента += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательРекуррента -= 1;
            }
        }

        private void ПереключательРежимРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательРежимРаботы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательРежимРаботы -= 1;
            }
        }

        private void ПереключательКоррАЧХ_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательКоррАЧХ += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательКоррАЧХ -= 1;
            }
        }

        private void ПереключательЧастотаВызова_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательЧастотаВызова += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательЧастотаВызова -= 1;
            }
        }

        private void ПереключательУровниСигналаПрдПрм_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательУровниСигналаПрдПрм += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательУровниСигналаПрдПрм -= 1;
            }
        }

        private void ПереключательРежимы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательРежимы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательРежимы -= 1;
            }
        }

        private void ПереключательЗапретЗапроса_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательЗапретЗапроса += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательЗапретЗапроса -= 1;
            }
        }

        private void ПереключательКоррКанала_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_2Parameters.ПереключательКоррКанала += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_2Parameters.ПереключательКоррКанала -= 1;
            }
        }
        #endregion

        #region Кнопки

        private void КнопкаШлейфТЧ_Click(object sender, System.EventArgs e)
        {
            BMA_M_2Parameters.КнопкаШлейфТЧ++;
        }

        private void КнопкаШлейфДК_Click(object sender, System.EventArgs e)
        {
            BMA_M_2Parameters.КнопкаШлейфДК++;
        }

        private void КнопкаПроверка_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПроверка--;
        }

        private void КнопкаПроверка_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПроверка++;
        }


        private void КнопкаПитаниеВЫКЛ_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПитаниеВыкл++;
        }

        private void КнопкаПитаниеВЫКЛ_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПитаниеВыкл--;
        }

        private void КнопкаПитаниеВКЛ_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПитаниеВкл++;
        }

        private void КнопкаПитаниеВКЛ_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_2Parameters.КнопкаПитаниеВкл--;
        }

        #endregion


        public void RefreshFormElements()
        {
            #region Переключатели
            var angle = (int)BMA_M_2Parameters.ПереключательКонтроль * 30 - 100;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРекуррента * 30 - 70;
            ПереключательРекурента.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРежимРаботы * 30 - 70;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательКоррАЧХ * 30 - 100;
            ПереключательКоррАЧХ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательЧастотаВызова * 30 - 70;
            ПереключательЧастотаВызова.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательУровниСигналаПрдПрм * 30 - 70;
            ПереключательУровниСигналаПрдПрм.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРежимы * 30 - 70;
            ПереключательРежимы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательЗапретЗапроса * 30 - 45;
            ПереключательЗапретЗапроса.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательКоррКанала * 30 - 45;
            ПереключательКоррКанала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательКонтроль * 30 - 100;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательЧастотаВызова * 30 - 70;
            ПереключательЧастотаВызова.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательКоррКанала * 30 - 45;
            ПереключательКоррКанала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательЗапретЗапроса * 30 - 45;
            ПереключательЗапретЗапроса.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРежимы * 30 - 70;
            ПереключательРежимы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательУровниСигналаПрдПрм * 30 - 70;
            ПереключательУровниСигналаПрдПрм.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательКоррАЧХ * 30 - 100;
            ПереключательКоррАЧХ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРежимРаботы * 30 - 70;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_2Parameters.ПереключательРекуррента * 30 - 70;
            ПереключательРекурента.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
            #endregion

            #region Кнопки

            switch (BMA_M_2Parameters.КнопкаШлейфТЧ)
            {
                case 0:
                    КнопкаШлейфТЧ.BackgroundImage = ControlElementImages.buttonSquareYellow;
                    КнопкаШлейфТЧ.Text = "ТЧ";
                    КнопкаШлейфТЧ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 1:
                    КнопкаШлейфТЧ.BackgroundImage = ControlElementImages.buttonSquareYellow1;
                    КнопкаШлейфТЧ.Text = "ТЧ";
                    КнопкаШлейфТЧ.Font = new Font(FontFamily.GenericSansSerif, 8);
                    break;
                case 2:
                    КнопкаШлейфТЧ.BackgroundImage = ControlElementImages.buttonSquareYellowOn;
                    КнопкаШлейфТЧ.Text = "ТЧ";
                    КнопкаШлейфТЧ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 3:
                    КнопкаШлейфТЧ.BackgroundImage = null;
                    КнопкаШлейфТЧ.Text = string.Empty;
                    break;
            }

            switch (BMA_M_2Parameters.КнопкаШлейфДК)
            {
                case 0:
                    КнопкаШлейфДК.BackgroundImage = ControlElementImages.buttonSquareYellow;
                    КнопкаШлейфДК.Text = "ДК";
                    КнопкаШлейфДК.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 1:
                    КнопкаШлейфДК.BackgroundImage = ControlElementImages.buttonSquareYellow1;
                    КнопкаШлейфДК.Text = "ДК";
                    КнопкаШлейфДК.Font = new Font(FontFamily.GenericSansSerif, 8);
                    break;
                case 2:
                    КнопкаШлейфДК.BackgroundImage = ControlElementImages.buttonSquareYellowOn;
                    КнопкаШлейфДК.Text = "ДК";
                    КнопкаШлейфДК.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 3:
                    КнопкаШлейфДК.BackgroundImage = null;
                    КнопкаШлейфДК.Text = string.Empty;
                    break;
            }

            switch (BMA_M_2Parameters.КнопкаПитаниеВкл)
            {
                case 0:
                    КнопкаПитаниеВКЛ.BackgroundImage = ControlElementImages.buttonSquareBlueOff;
                    КнопкаПитаниеВКЛ.Text = "ВКЛ";
                    КнопкаПитаниеВКЛ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 1:
                    КнопкаПитаниеВКЛ.BackgroundImage = ControlElementImages.buttonSquareBlue;
                    КнопкаПитаниеВКЛ.Text = "ВКЛ";
                    КнопкаПитаниеВКЛ.Font = new Font(FontFamily.GenericSansSerif, 8);
                    break;
                case 2:
                    КнопкаПитаниеВКЛ.BackgroundImage = ControlElementImages.buttonSquareBlueOn;
                    КнопкаПитаниеВКЛ.Text = "ВКЛ";
                    КнопкаПитаниеВКЛ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 3:
                    КнопкаПитаниеВКЛ.BackgroundImage = null;
                    КнопкаПитаниеВКЛ.Text = string.Empty;
                    break;
            }

            switch (BMA_M_2Parameters.КнопкаПитаниеВыкл)
            {
                case 0:
                    КнопкаПитаниеВЫКЛ.BackgroundImage = ControlElementImages.buttonSquareBlueOff;
                    КнопкаПитаниеВЫКЛ.Text = "ВЫКЛ";
                    КнопкаПитаниеВЫКЛ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 1:
                    КнопкаПитаниеВЫКЛ.BackgroundImage = ControlElementImages.buttonSquareBlue;
                    КнопкаПитаниеВЫКЛ.Text = "ВЫКЛ";
                    КнопкаПитаниеВЫКЛ.Font = new Font(FontFamily.GenericSansSerif, 8);
                    break;
                case 2:
                    КнопкаПитаниеВЫКЛ.BackgroundImage = ControlElementImages.buttonSquareBlueOn;
                    КнопкаПитаниеВЫКЛ.Text = "ВЫКЛ";
                    КнопкаПитаниеВЫКЛ.Font = new Font(FontFamily.GenericSansSerif, 10);
                    break;
                case 3:
                    КнопкаПитаниеВЫКЛ.BackgroundImage = null;
                    КнопкаПитаниеВЫКЛ.Text = string.Empty;
                    break;
            }

            switch (BMA_M_2Parameters.КнопкаПроверка)
            {
                case 0:
                    КнопкаПроверка.BackgroundImage = ControlElementImages.buttonSquareYellow;
                    КнопкаПроверка.Text = "1";
                    break;
                case 1:
                    КнопкаПроверка.BackgroundImage = null;
                    КнопкаПроверка.Text = string.Empty;
                    break;
            }

            #endregion

            #region Лампочки

            PropertyInfo[] fieldList = typeof(BMA_M_2Parameters).GetProperties();
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Лампочка"))
                {
                    if (item.Name.Contains("ЛампочкаИсправно"))
                    {
                        ЛампочкаИсправно.BackColor = BMA_M_2Parameters.ЛампочкаИсправно ? Color.FromArgb(100, 50, 250, 50) : Color.Transparent;
                        continue;
                    }
                    foreach (PropertyInfo property in fieldList)
                    {
                        if (item.Name == property.Name)
                        {
                            item.BackgroundImage = Convert.ToBoolean(property.GetValue(null))
                            ? ControlElementImages.lampType7OnRed
                            : null;
                        }
                    }
                }
            }

            #endregion

        }
    }
}