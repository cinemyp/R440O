namespace R440O.R440OForms.BMB
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Media;
    using System.Windows.Forms;
    using BaseClasses;
    using ThirdParty;
    using СостоянияЭлементов.БМБ;
    using global::R440O.LearnModule;

    /// <summary>
    /// Форма блока БМБ
    /// </summary>
    public partial class BMBForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="BMBForm"/>
        /// </summary>
        public BMBForm()
        {
            InitializeComponent();
            BMBParameters.RefreshForm += RefreshFormElements;
            N18_M.N18_MParameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
           
        }

        #region Переключатели

        private void BMBПереключательПодключениеРезерва_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.ПереключательПодключениеРезерва += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.ПереключательПодключениеРезерва -= 1;
            }
        }

        private void BMBПереключательНаправление_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.ПереключательНаправление += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.ПереключательНаправление -= 1;
            }
        }

        #endregion

        #region Инициализация

        private SoundPlayer _player = new SoundPlayer(Properties.Resources.bmb);

        public void RefreshFormElements()
        {
            InitializeButtons();
            InitializeToggles();
            InitializeLamps();

            // Звук для БМБ
            if (BMBParameters.ЛампочкаПриемВызова && BMBParameters.КнопкаЗвСигнал == Кнопка.Горит)
            {
                _player = new SoundPlayer(Properties.Resources.bmb);
                _player.PlayLooping();
            }
            else
            {
                _player.Stop();
                _player.Dispose();
            }

        }

        private void InitializeButtons()
        {
            this.КнопкаПередачаВызоваДк.BackgroundImage = BMBParameters.КнопкаПередачаВызоваДк == Кнопка.Горит
                ? null
                : BMBParameters.КнопкаПередачаВызоваДк == Кнопка.Отжата
                    ? ControlElementImages.buttonSquareYellow1
                    : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаПередачаВызоваТч.BackgroundImage = BMBParameters.КнопкаПередачаВызоваТч == Кнопка.Горит
                ? null
                : BMBParameters.КнопкаПередачаВызоваТч == Кнопка.Отжата
                    ? ControlElementImages.buttonSquareYellow1
                    : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаСлСвязь.BackgroundImage = BMBParameters.КнопкаСлСвязь == Кнопка.Горит
                 ? null
                 : BMBParameters.КнопкаСлСвязь == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareYellow1
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаПитание.BackgroundImage = BMBParameters.КнопкаПитание == Кнопка.Горит
                 ? null
                 : BMBParameters.КнопкаПитание == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareGreen
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareGreen, 65);

            this.КнопкаЗвСигнал.BackgroundImage = BMBParameters.КнопкаЗвСигнал == Кнопка.Горит
                 ? null
                 : BMBParameters.КнопкаЗвСигнал == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareGreen
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareGreen, 65);

            this.КнопкаПередачаКоманды.BackgroundImage = BMBParameters.КнопкаПередачаКоманды == Кнопка.Горит
                 ? ControlElementImages.buttonSquareBlueOn
                 : BMBParameters.КнопкаПередачаКоманды == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareBlueOff
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareBlueOff, 85);

            this.КнопкаПередачаВызоваДк.Text = BMBParameters.КнопкаПередачаВызоваДк == Кнопка.Горит ? null : "ДК";
            this.КнопкаПередачаВызоваТч.Text = BMBParameters.КнопкаПередачаВызоваТч == Кнопка.Горит ? null : "ТЧ";
            this.КнопкаСлСвязь.Text = BMBParameters.КнопкаСлСвязь == Кнопка.Горит ? null : "ВКЛ";
            this.КнопкаПитание.Text = BMBParameters.КнопкаПитание == Кнопка.Горит ? null : "ВКЛ";
            this.КнопкаЗвСигнал.Text = BMBParameters.КнопкаЗвСигнал == Кнопка.Горит ? null : "ЗВ.\nСИГН.";
        }

        private void InitializeToggles()
        {
            var angle = BMBParameters.ПереключательРаботаКонтроль * 30 - 45;
            ПереключательРаботаКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = BMBParameters.ПереключательПодключениеРезерва * 40 - 80;
            BMBПереключательПодключениеРезерва.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = BMBParameters.ПереключательНаправление * 30 - 75;
            BMBПереключательНаправление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeLamps()
        {
            ЛампочкаТч.BackgroundImage = BMBParameters.ЛампочкаТч
                ? ControlElementImages.lampType7OnRed
                : null;
            ЛампочкаДк.BackgroundImage = BMBParameters.ЛампочкаДк
                ? ControlElementImages.lampType7OnRed
                : null;

            ЛампочкаПриемВызова.BackColor = BMBParameters.ЛампочкаПриемВызова ? Color.FromArgb(100, 50, 250, 50) : Color.Transparent;

            BMBЛампочкаНаправление1.BackgroundImage = BMBParameters.ЛампочкаНаправление1 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление2.BackgroundImage = BMBParameters.ЛампочкаНаправление2 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление3.BackgroundImage = BMBParameters.ЛампочкаНаправление3 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление4.BackgroundImage = BMBParameters.ЛампочкаНаправление4 ? ControlElementImages.lampType7OnRed
                : null;

            ИндикаторНаборКоманды.Text = BMBParameters.НаборКоманды;
            ИндикаторПриемКоманды.Text = BMBParameters.ПриемКоманды;

        }
        #endregion

        #region Кнопки

        private void КнопкаПитание_Click(object sender, System.EventArgs e)
        {
            BMBParameters.КнопкаПитание = BMBParameters.КнопкаПитание == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаЗвСигнал_Click(object sender, System.EventArgs e)
        {
            BMBParameters.КнопкаЗвСигнал = BMBParameters.КнопкаЗвСигнал == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаСлСвязь_Click(object sender, System.EventArgs e)
        {
            BMBParameters.КнопкаСлСвязь = BMBParameters.КнопкаСлСвязь == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаПередачаВызоваТч_Click(object sender, System.EventArgs e)
        {
            BMBParameters.КнопкаПередачаВызоваТч = BMBParameters.КнопкаПередачаВызоваТч == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаПередачаВызоваДк_Click(object sender, System.EventArgs e)
        {
            BMBParameters.КнопкаПередачаВызоваДк = BMBParameters.КнопкаПередачаВызоваДк == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void ПереключательРаботаКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.ПереключательРаботаКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.ПереключательРаботаКонтроль -= 1;
            }
        }
        #endregion

        #region КнопкаПередачаКоманды

        private void КнопкаНаборКоманды_MouseUp(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null) button.BackgroundImage = ControlElementImages.buttonSquareBlue;
        }

        private void КнопкаНаборКоманды_MouseDown(object sender, MouseEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                var buttonNumber = Convert.ToInt32(button.Name[18].ToString());
                button.BackgroundImage = null;
                button.Text = string.Empty + buttonNumber;
                BMBParameters.ДобавитьЧисло(buttonNumber);
            }
        }

        private void КнопкаПередачаКоманды_MouseDown(object sender, MouseEventArgs e)
        {
            BMBParameters.КнопкаПередачаКоманды = Кнопка.Нажата;
            this.КнопкаПередачаКоманды.BackgroundImage = TransformImageHelper.Scale(ControlElementImages.buttonSquareBlueOff, 85);
            BMBParameters.ПередатьКоманду();
        }

        private void КнопкаПередачаКоманды_MouseUp(object sender, MouseEventArgs e)
        {
            BMBParameters.КнопкаПередачаКоманды = Кнопка.Отжата;
            this.КнопкаПередачаКоманды.BackgroundImage = ControlElementImages.buttonSquareBlueOff;
            RefreshFormElements();
        }
        #endregion

        private void BMBForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}