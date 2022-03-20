//-----------------------------------------------------------------------
// <copyright file="BMA_M_1Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;

namespace R440O.R440OForms.BMA_M_1
{
    using System.Windows.Forms;
    using System.Reflection;
    using Parameters;
    using ThirdParty;
    using System;
    using System.Drawing;
    using BaseClasses;
    using global::R440O.TestModule;


    /// <summary>
    /// Форма блока БМА-М-1
    /// </summary>
    public partial class BMA_M_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BMA_M_1Form"/>.
        /// </summary>
        public BMA_M_1Form()
        {
            InitializeComponent();
            BMA_M_1Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();

        }

        #region Переключатели
        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательКонтроль -= 1;
            }
        }

        private void ПереключательРекурента_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательРекуррента += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательРекуррента -= 1;
            }
        }

        private void ПереключательРежимРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательРежимРаботы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательРежимРаботы -= 1;
            }
        }

        private void ПереключательКоррАЧХ_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательКоррАЧХ += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательКоррАЧХ -= 1;
            }
        }

        private void ПереключательЧастотаВызова_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательЧастотаВызова += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательЧастотаВызова -= 1;
            }
        }

        private void ПереключательУровниСигналаПрдПрм_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательУровниСигналаПрдПрм += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательУровниСигналаПрдПрм -= 1;
            }
        }

        private void ПереключательРежимы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательРежимы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательРежимы -= 1;
            }
        }

        private void ПереключательЗапретЗапроса_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательЗапретЗапроса += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательЗапретЗапроса -= 1;
            }
        }

        private void ПереключательКоррКанала_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMA_M_1Parameters.getInstance().ПереключательКоррКанала += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMA_M_1Parameters.getInstance().ПереключательКоррКанала -= 1;
            }
        }
        #endregion

        #region Кнопки

        private void КнопкаШлейфТЧ_Click(object sender, System.EventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаШлейфТЧ++;
        }

        private void КнопкаШлейфДК_Click(object sender, System.EventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаШлейфДК++;
        }

        private void КнопкаПроверка_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПроверка--;
        }

        private void КнопкаПроверка_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПроверка++;
        }


        private void КнопкаПитаниеВЫКЛ_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПитаниеВыкл++;
        }

        private void КнопкаПитаниеВЫКЛ_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПитаниеВыкл--;
        }

        private void КнопкаПитаниеВКЛ_MouseDown(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПитаниеВкл++;
        }

        private void КнопкаПитаниеВКЛ_MouseUp(object sender, MouseEventArgs e)
        {
            BMA_M_1Parameters.getInstance().КнопкаПитаниеВкл--;
        }

        #endregion


        public void RefreshFormElements()
        {
            #region Переключатели
            var angle = (int)BMA_M_1Parameters.getInstance().ПереключательКонтроль * 30 - 100;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРекуррента * 30 - 70;
            ПереключательРекурента.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРежимРаботы * 30 - 70;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательКоррАЧХ * 30 - 100;
            ПереключательКоррАЧХ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательЧастотаВызова * 30 - 70;
            ПереключательЧастотаВызова.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательУровниСигналаПрдПрм * 30 - 70;
            ПереключательУровниСигналаПрдПрм.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРежимы * 30 - 70;
            ПереключательРежимы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательЗапретЗапроса * 30 - 45;
            ПереключательЗапретЗапроса.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательКоррКанала * 30 - 45;
            ПереключательКоррКанала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательКонтроль * 30 - 100;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательЧастотаВызова * 30 - 70;
            ПереключательЧастотаВызова.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательКоррКанала * 30 - 45;
            ПереключательКоррКанала.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательЗапретЗапроса * 30 - 45;
            ПереключательЗапретЗапроса.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРежимы * 30 - 70;
            ПереключательРежимы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательУровниСигналаПрдПрм * 30 - 70;
            ПереключательУровниСигналаПрдПрм.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательКоррАЧХ * 30 - 100;
            ПереключательКоррАЧХ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРежимРаботы * 30 - 70;
            ПереключательРежимРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = (int)BMA_M_1Parameters.getInstance().ПереключательРекуррента * 30 - 70;
            ПереключательРекурента.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
            #endregion

            #region Кнопки

            switch (BMA_M_1Parameters.getInstance().КнопкаШлейфТЧ)
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

            switch (BMA_M_1Parameters.getInstance().КнопкаШлейфДК)
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

            switch (BMA_M_1Parameters.getInstance().КнопкаПитаниеВкл)
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

            switch (BMA_M_1Parameters.getInstance().КнопкаПитаниеВыкл)
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

            switch (BMA_M_1Parameters.getInstance().КнопкаПроверка)
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

            PropertyInfo[] fieldList = typeof(BMA_M_1Parameters).GetProperties();
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Лампочка"))
                {
                    if (item.Name.Contains("ЛампочкаИсправно"))
                    {
                        ЛампочкаИсправно.BackColor = BMA_M_1Parameters.getInstance().ЛампочкаИсправно ? Color.FromArgb(100, 50, 250, 50) : Color.Transparent;
                        continue;
                    }
                    foreach (PropertyInfo property in fieldList)
                    {
                        if (item.Name == property.Name)
                        {
                            item.BackgroundImage = Convert.ToBoolean(property.GetValue(BMA_M_1Parameters.getInstance()))
                            ? ControlElementImages.lampType7OnRed
                            : null;
                        }
                    }
                }
            }

            #endregion

        }

        private void BMA_M_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = BMA_M_1Parameters.getInstance();
                bool def = (blockParams.ПереключательКонтроль == 1 || 
                    blockParams.ПереключательКонтроль == 6) &&
                    (blockParams.ПереключательРежимРаботы == 1 || 
                    blockParams.ПереключательРежимРаботы == 2) &&
                    blockParams.КнопкаШлейфТЧ == 0 && 
                    blockParams.КнопкаШлейфДК == 0;

                TestMain.Action(new JsonAdapter.ActionStation() { Name = "БМА", Value = Convert.ToInt32(def) });
            }
        }
    }
}