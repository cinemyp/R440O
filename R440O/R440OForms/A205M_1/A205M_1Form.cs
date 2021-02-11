using ShareTypes.SignalTypes;
using R440O.R440OForms.NKN_1;

namespace R440O.R440OForms.A205M_1
{
    using System.Windows.Forms;
    using ThirdParty;
    using BaseClasses;
    using global::R440O.LearnModule;

    /// <summary>
    /// Форма блока А205М-1
    /// </summary>
    public partial class A205M_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="A205M_1Form"/>.
        /// </summary>
        public A205M_1Form()
        {
            this.InitializeComponent();
            A205M_1Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
            if (LearnMain.getIntent() == ModulesEnum.A205_m1_Open)
            {
                LearnMain.form = this;
                LearnMain.setIntent(ModulesEnum.A205_m1_Power);
            }
        }

        #region Инициализация элементов управления формы

        public void RefreshFormElements()
        {
            var angle = A205M_1Parameters.ИндикаторКонтроль * 2.2F - 55;
            ИндикаторКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);


            ТумблерКЭД.BackgroundImage = A205M_1Parameters.ТумблерКЭД
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;

            angle = A205M_1Parameters.ПереключательВолнаX10000 * 35 - 90;
            ПереключательВолнаX10000.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВолнаX1000 * 35 - 160;
            ПереключательВолнаX1000.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВолнаX100 * 35 - 160;
            ПереключательВолнаX100.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВолнаX10 * 35 - 160;
            ПереключательВолнаX10.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВолнаX1 * 35 - 160;
            ПереключательВолнаX1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательКонтроль * 30 - 180;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВидРаботы * 30 - 75;
            ПереключательВидРаботы.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            angle = A205M_1Parameters.ПереключательВходЧТ * 30 - 60;
            ПереключательВходЧТ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            ЛампочкаНормРаб.BackgroundImage = A205M_1Parameters.ЛампочкаНормРаб
                ? ControlElementImages.lampType13OnGreen
                : null;
        }

        #endregion

        private void ПереключательКЭД_Click(object sender, System.EventArgs e)
        {
            A205M_1Parameters.ТумблерКЭД = !A205M_1Parameters.ТумблерКЭД;
        }

        #region Отображение на дисплее текущей выбранной волны

        private void КнопкаОтсчет_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОтсчет.BackgroundImage = null;
            if (NKN_1Parameters.ЛампочкаФаза1)
                Дисплей.Text = A205M_1Parameters.ПереключательВолнаX10000 + "  " +
                               A205M_1Parameters.ПереключательВолнаX1000 + "  " +
                               A205M_1Parameters.ПереключательВолнаX100 + "  " +
                               A205M_1Parameters.ПереключательВолнаX10 + "  " +
                               A205M_1Parameters.ПереключательВолнаX1;

        }

        private void КнопкаОтсчет_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОтсчет.BackgroundImage = ControlElementImages.buttonRoundType6;
            Дисплей.Text = string.Empty;
        }

        #endregion

        #region Установка переключателей волны

        private void ПереключательВолнаX10000_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВолнаX10000 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВолнаX10000 -= 1;
            }
        }

        private void ПереключательВолнаX1000_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВолнаX1000 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВолнаX1000 -= 1;
            }
        }

        private void ПереключательВолнаX100_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВолнаX100 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВолнаX100 -= 1;
            }
        }

        private void ПереключательВолнаX10_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВолнаX10 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВолнаX10 -= 1;
            }
        }

        private void ПереключательВолнаX1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВолнаX1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВолнаX1 -= 1;
            }
        }

        #endregion

        #region Переключатели контроля, вида работы, входы чт

        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательКонтроль -= 1;
            }
        }

        private void ПереключательВидРаботы_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВидРаботы += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВидРаботы -= 1;
            }
        }

        private void ПереключательВходЧТ_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A205M_1Parameters.ПереключательВходЧТ += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A205M_1Parameters.ПереключательВходЧТ -= 1;
            }
        }

        #endregion

        private void A205M_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            A205M_1Parameters.ParameterChanged -= RefreshFormElements;
            if(LearnMain.getIntent() == ModulesEnum.A205_m1_Power)
            {
                if(LearnMain.globalIntent == GlobalIntentEnum.OneChannel)
                {
                    if (A205M_1Parameters.ПереключательВидРаботы == 3 && A205M_1Parameters.ПереключательВходЧТ == 1)
                    {
                        LearnMain.setIntent(ModulesEnum.H15Inside_open);
                    }
                    else LearnMain.setIntent(ModulesEnum.A205_m1_Open);
                }
            }
        }
    }
}