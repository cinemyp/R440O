//-----------------------------------------------------------------------
// <copyright file="AstraForm.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using ShareTypes.SignalTypes;

namespace R440O.R440OForms.Astra
{
    using System.Windows.Forms;
    using Parameters;
    using ThirdParty;
    using BaseClasses;

    /// <summary>
    /// Форма блока Астра
    /// </summary>
    public partial class AstraForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AstraForm"/>.
        /// </summary>
        public AstraForm()
        {
            InitializeComponent();
            AstraParameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Инициализация
        public void RefreshFormElements()
        {
            //переключатели

            var angle = AstraParameters.getInstance().ПереключательТлгТлф * 30 - 150;
            ПереключательТлгТлф.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = AstraParameters.getInstance().ПереключательВнешнегоПитания * 30;
            ПереключательВнешнегоПитания.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = AstraParameters.getInstance().ПереключательКонтроль * 35 - 160;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = AstraParameters.getInstance().ПереключательДиапазоны * 30 - 148;
            ПереключательДиапазоны.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = AstraParameters.getInstance().ПереключательВыходаРеле * 30 - 60;
            ПереключательВыходаРеле.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            ТумблерШпУп.BackgroundImage = AstraParameters.getInstance().ТумблерШпУп
                ? ControlElementImages.tumblerType5Left
                : ControlElementImages.tumblerType5Right;

            //регуляторы

            РегуляторЧастота.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторЧастота);
            РегуляторУсиление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторУсиление);
            РегуляторУсилениеПЧ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторУсилениеПЧ);

            // кнопки
            Кнопка150_270.Visible = !AstraParameters.getInstance().Кнопка150_270;
            Кнопка270_480.Visible = !AstraParameters.getInstance().Кнопка270_480;
            Кнопка480_860.Visible = !AstraParameters.getInstance().Кнопка480_860;
            Кнопка860_1500.Visible = !AstraParameters.getInstance().Кнопка860_1500;
        }

        #endregion

        #region Кнопки

        private void Кнопка150_270_Click(object sender, System.EventArgs e)
        {
            SwitchToButton(1);
        }

        private void Кнопка270_480_Click(object sender, System.EventArgs e)
        {
            SwitchToButton(2);
        }

        private void Кнопка480_860_Click(object sender, System.EventArgs e)
        {
            SwitchToButton(3);
        }

        private void Кнопка860_1500_Click(object sender, System.EventArgs e)
        {
            SwitchToButton(4);
        }

        /// <summary>
        /// Переключает на нажатую пользователем кнопку, определяющую некоторый заданный диапазон.
        /// </summary>
        /// <param name="numberOfButton">Номер нажатой кнопки по порядку слева направо.</param>
        private void SwitchToButton(int numberOfButton)
        {
            AstraParameters.getInstance().Кнопка150_270 = numberOfButton == 1;
            AstraParameters.getInstance().Кнопка270_480 = numberOfButton == 2;
            AstraParameters.getInstance().Кнопка480_860 = numberOfButton == 3;
            AstraParameters.getInstance().Кнопка860_1500 = numberOfButton == 4;
            Кнопка150_270.Visible = !AstraParameters.getInstance().Кнопка150_270;
            Кнопка270_480.Visible = !AstraParameters.getInstance().Кнопка270_480;
            Кнопка480_860.Visible = !AstraParameters.getInstance().Кнопка480_860;
            Кнопка860_1500.Visible = !AstraParameters.getInstance().Кнопка860_1500;
        }

        #endregion

        #region Переключатели

        private void ПереключательТлгТлф_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AstraParameters.getInstance().ПереключательТлгТлф += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                AstraParameters.getInstance().ПереключательТлгТлф -= 1;
            }
        }

        private void ПереключательВнешнегоПитания_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AstraParameters.getInstance().ПереключательВнешнегоПитания += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                AstraParameters.getInstance().ПереключательВнешнегоПитания -= 1;
            }
        }

        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AstraParameters.getInstance().ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                AstraParameters.getInstance().ПереключательКонтроль -= 1;
            }
        }

        private void ПереключательДиапазоны_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AstraParameters.getInstance().ПереключательДиапазоны += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                AstraParameters.getInstance().ПереключательДиапазоны -= 1;
            }
        }

        private void ПереключательВыходаРеле_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                AstraParameters.getInstance().ПереключательВыходаРеле += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                AstraParameters.getInstance().ПереключательВыходаРеле -= 1;
            }

        }
        #endregion

        #region Переключатель комплекта и тумблер
        private void ТумблерШпУп_Click(object sender, System.EventArgs e)
        {
            AstraParameters.getInstance().ТумблерШпУп = !AstraParameters.getInstance().ТумблерШпУп;
        }

        private void КнопкаЧастота_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаЧастота.BackgroundImage = ControlElementImages.buttonRoundType2;
        }

        private void КнопкаЧастота_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаЧастота.BackgroundImage = null;
        }
        #endregion

        #region Регуляторы

        private bool isManipulation;
        private void Регулятор_MouseDown(object sender, MouseEventArgs e)
        {
            isManipulation = true;
        }

        private void Регулятор_MouseUp(object sender, MouseEventArgs e)
        {
            isManipulation = false;
        }

        private void РегуляторЧастота_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            AstraParameters.getInstance().РегуляторЧастота = angle;
            РегуляторЧастота.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторЧастота);
        }

        private void РегуляторУсиление_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            AstraParameters.getInstance().РегуляторУсиление = angle;
            РегуляторУсиление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторУсиление);
        }

        private void РегуляторУсилениеПЧ_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            AstraParameters.getInstance().РегуляторУсилениеПЧ = angle;
            РегуляторУсилениеПЧ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.revolverRoundBlack, AstraParameters.getInstance().РегуляторУсилениеПЧ);
        }
        #endregion

        private void AstraForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AstraParameters.getInstance().ParameterChanged -= RefreshFormElements;
        }
    }
}