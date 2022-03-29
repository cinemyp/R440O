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
    using global::R440O.TestModule;

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
            BMBParameters.getInstance().RefreshForm += RefreshFormElements;
            N18_M.N18_MParameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
            if (ParametersConfig.IsTesting)
            {
                BMBParameters.getInstance().Action += TestMain.Action;
            }
        }

        #region Переключатели

        private void BMBПереключательПодключениеРезерва_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.getInstance().ПереключательПодключениеРезерва += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.getInstance().ПереключательПодключениеРезерва -= 1;
            }
        }

        private void BMBПереключательНаправление_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.getInstance().ПереключательНаправление += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.getInstance().ПереключательНаправление -= 1;
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
            if (BMBParameters.getInstance().ЛампочкаПриемВызова && BMBParameters.getInstance().КнопкаЗвСигнал == Кнопка.Горит)
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
            this.КнопкаПередачаВызоваДк.BackgroundImage = BMBParameters.getInstance().КнопкаПередачаВызоваДк == Кнопка.Горит
                ? null
                : BMBParameters.getInstance().КнопкаПередачаВызоваДк == Кнопка.Отжата
                    ? ControlElementImages.buttonSquareYellow1
                    : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаПередачаВызоваТч.BackgroundImage = BMBParameters.getInstance().КнопкаПередачаВызоваТч == Кнопка.Горит
                ? null
                : BMBParameters.getInstance().КнопкаПередачаВызоваТч == Кнопка.Отжата
                    ? ControlElementImages.buttonSquareYellow1
                    : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаСлСвязь.BackgroundImage = BMBParameters.getInstance().КнопкаСлСвязь == Кнопка.Горит
                 ? null
                 : BMBParameters.getInstance().КнопкаСлСвязь == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareYellow1
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareYellow1, 65);

            this.КнопкаПитание.BackgroundImage = BMBParameters.getInstance().КнопкаПитание == Кнопка.Горит
                 ? null
                 : BMBParameters.getInstance().КнопкаПитание == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareGreen
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareGreen, 65);

            this.КнопкаЗвСигнал.BackgroundImage = BMBParameters.getInstance().КнопкаЗвСигнал == Кнопка.Горит
                 ? null
                 : BMBParameters.getInstance().КнопкаЗвСигнал == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareGreen
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareGreen, 65);

            this.КнопкаПередачаКоманды.BackgroundImage = BMBParameters.getInstance().КнопкаПередачаКоманды == Кнопка.Горит
                 ? ControlElementImages.buttonSquareBlueOn
                 : BMBParameters.getInstance().КнопкаПередачаКоманды == Кнопка.Отжата
                     ? ControlElementImages.buttonSquareBlueOff
                     : TransformImageHelper.Scale(ControlElementImages.buttonSquareBlueOff, 85);

            this.КнопкаПередачаВызоваДк.Text = BMBParameters.getInstance().КнопкаПередачаВызоваДк == Кнопка.Горит ? null : "ДК";
            this.КнопкаПередачаВызоваТч.Text = BMBParameters.getInstance().КнопкаПередачаВызоваТч == Кнопка.Горит ? null : "ТЧ";
            this.КнопкаСлСвязь.Text = BMBParameters.getInstance().КнопкаСлСвязь == Кнопка.Горит ? null : "ВКЛ";
            this.КнопкаПитание.Text = BMBParameters.getInstance().КнопкаПитание == Кнопка.Горит ? null : "ВКЛ";
            this.КнопкаЗвСигнал.Text = BMBParameters.getInstance().КнопкаЗвСигнал == Кнопка.Горит ? null : "ЗВ.\nСИГН.";
        }

        private void InitializeToggles()
        {
            var angle = BMBParameters.getInstance().ПереключательРаботаКонтроль * 30 - 45;
            ПереключательРаботаКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = BMBParameters.getInstance().ПереключательПодключениеРезерва * 40 - 80;
            BMBПереключательПодключениеРезерва.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = BMBParameters.getInstance().ПереключательНаправление * 30 - 75;
            BMBПереключательНаправление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeLamps()
        {
            ЛампочкаТч.BackgroundImage = BMBParameters.getInstance().ЛампочкаТч
                ? ControlElementImages.lampType7OnRed
                : null;
            ЛампочкаДк.BackgroundImage = BMBParameters.getInstance().ЛампочкаДк
                ? ControlElementImages.lampType7OnRed
                : null;

            ЛампочкаПриемВызова.BackColor = BMBParameters.getInstance().ЛампочкаПриемВызова ? Color.FromArgb(100, 50, 250, 50) : Color.Transparent;

            BMBЛампочкаНаправление1.BackgroundImage = BMBParameters.getInstance().ЛампочкаНаправление1 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление2.BackgroundImage = BMBParameters.getInstance().ЛампочкаНаправление2 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление3.BackgroundImage = BMBParameters.getInstance().ЛампочкаНаправление3 ? ControlElementImages.lampType7OnRed
                : null;
            BMBЛампочкаНаправление4.BackgroundImage = BMBParameters.getInstance().ЛампочкаНаправление4 ? ControlElementImages.lampType7OnRed
                : null;

            ИндикаторНаборКоманды.Text = BMBParameters.getInstance().НаборКоманды;
            ИндикаторПриемКоманды.Text = BMBParameters.getInstance().ПриемКоманды;

        }
        #endregion

        #region Кнопки

        private void КнопкаПитание_Click(object sender, System.EventArgs e)
        {
            BMBParameters.getInstance().КнопкаПитание = BMBParameters.getInstance().КнопкаПитание == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаЗвСигнал_Click(object sender, System.EventArgs e)
        {
            BMBParameters.getInstance().КнопкаЗвСигнал = BMBParameters.getInstance().КнопкаЗвСигнал == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаСлСвязь_Click(object sender, System.EventArgs e)
        {
            BMBParameters.getInstance().КнопкаСлСвязь = BMBParameters.getInstance().КнопкаСлСвязь == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаПередачаВызоваТч_Click(object sender, System.EventArgs e)
        {
            BMBParameters.getInstance().КнопкаПередачаВызоваТч = BMBParameters.getInstance().КнопкаПередачаВызоваТч == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void КнопкаПередачаВызоваДк_Click(object sender, System.EventArgs e)
        {
            BMBParameters.getInstance().КнопкаПередачаВызоваДк = BMBParameters.getInstance().КнопкаПередачаВызоваДк == Кнопка.Отжата ? Кнопка.Нажата : Кнопка.Отжата;
        }

        private void ПереключательРаботаКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                BMBParameters.getInstance().ПереключательРаботаКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                BMBParameters.getInstance().ПереключательРаботаКонтроль -= 1;
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
                BMBParameters.getInstance().ДобавитьЧисло(buttonNumber);
            }
        }

        private void КнопкаПередачаКоманды_MouseDown(object sender, MouseEventArgs e)
        {
            BMBParameters.getInstance().КнопкаПередачаКоманды = Кнопка.Нажата;
            this.КнопкаПередачаКоманды.BackgroundImage = TransformImageHelper.Scale(ControlElementImages.buttonSquareBlueOff, 85);
            BMBParameters.getInstance().ПередатьКоманду();
        }

        private void КнопкаПередачаКоманды_MouseUp(object sender, MouseEventArgs e)
        {
            BMBParameters.getInstance().КнопкаПередачаКоманды = Кнопка.Отжата;
            this.КнопкаПередачаКоманды.BackgroundImage = ControlElementImages.buttonSquareBlueOff;
            RefreshFormElements();
        }
        #endregion

        private void BMBForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = BMBParameters.getInstance();

                if(TestMain.IsCheck)
                {
                    bool def = blockParams.КнопкаПитание == Кнопка.Отжата &&
                    blockParams.КнопкаСлСвязь == Кнопка.Отжата &&
                    blockParams.КнопкаЗвСигнал == Кнопка.Отжата;

                    TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.Check_BMB, Value = Convert.ToInt32(def) });
                } else
                {
                    bool def = blockParams.КнопкаПитание == Кнопка.Горит;

                    TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.BMB_Power, Value = Convert.ToInt32(def) });
                }
            }
        }
    }
}