//-----------------------------------------------------------------------
// <copyright file="N15Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using R440O.InternalBlocks;
using R440O.Parameters;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.N16;
using R440O.ThirdParty;

namespace R440O.R440OForms.N15
{
    using BaseClasses;
    using global::R440O.LearnModule;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока Н-15
    /// </summary>
    public partial class N15Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N15Form"/>
        /// </summary>
        public N15Form()
        {
            this.InitializeComponent();
            N15Parameters.ParameterChanged += RefreshFormElements;
            N15Parameters.IndicatorChanged += RefreshIndicator;
            RefreshFormElements();


            LearnMain.form = this;
            switch (LearnMain.getIntent())
            {
                case ModulesEnum.openN15:
                    LearnMain.setIntent(ModulesEnum.N15Power);
                    break;
                case ModulesEnum.H15Inside_open:
                    LearnMain.setIntent(ModulesEnum.H15Inside_open_from_H15);
                    break;
            }
            
            
        }

        #region Инициализация элементов управления

        public void RefreshIndicator()
        {
            var angle = N15Parameters.ИндикаторМощностьВыхода * 1.05F;
            ИндикаторМощностьВыхода.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        public void RefreshFormElements()
        {
            RefreshIndicator();
            InitializeButtons();
            InitializeTumblers();
            InitializeLamps();

            РегуляторУровень.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                    ControlElementImages.revolverRoundSmall,
                    (float)N15Parameters.РегуляторУровень);
        }

        /// <summary>
        /// Установка кнопок в положение последней их установки
        /// </summary>
        private void InitializeButtons()
        {
            КнопкаПРМНаведениеЦ300М1.Visible = !N15Parameters.КнопкаПРМНаведениеЦ300М1;
            КнопкаПРМНаведениеЦ300М2.Visible = !N15Parameters.КнопкаПРМНаведениеЦ300М2;
            КнопкаПРМНаведениеЦ300М3.Visible = !N15Parameters.КнопкаПРМНаведениеЦ300М3;
            КнопкаПРМНаведениеЦ300М4.Visible = !N15Parameters.КнопкаПРМНаведениеЦ300М4;
            КнопкаМощностьАнт.Visible = !N15Parameters.КнопкаМощностьАнт;
            КнопкаМощностьН16.Visible = !N15Parameters.КнопкаМощностьН16;

            КнопкаН13_1.Visible = !N15LocalParameters.локКнопкаН13_1;
            КнопкаН13_2.Visible = !N15LocalParameters.локКнопкаН13_2;
            КнопкаН13_12.Visible = !N15LocalParameters.локКнопкаН13_12;
        }

        /// <summary>
        /// Установка тумблеров в положение последней их установки
        /// </summary>
        private void InitializeTumblers()
        {

            //Тумблеры левой части для которых требуется нажатие на кнопку ВКЛ
            foreach (Control item in Panel.Controls)
            {
                if (!item.Name.Contains("Тумблер")) continue;
                var propertyList = typeof(N15LocalParameters).GetProperties();
                foreach (var property in propertyList.Where(property => ("лок" + item.Name) == property.Name
                                                                        && !property.Name.Contains("5Мгц") &&
                                                                        !property.Name.Contains("АнтЭкв") &&
                                                                        !property.Name.Contains("А20512")))
                {
                    item.BackgroundImage = (bool)property.GetValue(null)
                        ? ControlElementImages.tumblerType3Up
                        : ControlElementImages.tumblerType3Down;
                }
            }

            ТумблерА20512.BackgroundImage = N15LocalParameters.локТумблерА20512
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;


            //Тумблеры левой и правой части для которых не требуется нажатие на кнопку ВКЛ
            ТумблерА30412.BackgroundImage = N15Parameters.ТумблерА30412
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерА503Б.BackgroundImage = N15Parameters.ТумблерА503Б
                ? ControlElementImages.tumblerType3Up
                : ControlElementImages.tumblerType3Down;

            ТумблерАнтЭкв.BackgroundImage = N15LocalParameters.локТумблерАнтЭкв
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерТлфТлгПрд.BackgroundImage = N15Parameters.ТумблерТлфТлгПрд
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерТлфТлгПрм.BackgroundImage = N15Parameters.ТумблерТлфТлгПрм
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

        }

        /// <summary>
        /// Установка лампочек в положение последней их установки
        /// </summary>
        private void InitializeLamps()
        {

            foreach (Control item in Panel.Controls)
            {
                if (!item.Name.Contains("Лампочка")) continue;
                var propertyList = typeof(N15Parameters).GetProperties();
                foreach (var property in propertyList.Where(property => item.Name == property.Name))
                {
                    if (item.Name.Contains("Ц300М") || item.Name.Contains("ППВ") || item.Name.Contains("А205") ||
                        item.Name.Contains("УМ1"))
                    {
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.lampType8OnRed
                            : null;
                    }
                    else
                    {
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.lampType5OnRed
                            : null;
                    }
                    break;
                }
            }
        }
        #endregion

        #region Обновление элементов управления
        /// <summary>
        /// Перерисовка одиночных тумблеров, которые включаются через кнопку СТАНЦИЯ.ВКЛ.
        /// </summary>
        /// <param name="parameterName"></param>
        private void RefreshFormElement(string parameterName)
        {
            var item = Panel.Controls.Find(parameterName, false)[0];
            if (item == null) return;
            if (!item.Name.Contains("Тумблер")) return;

            var propertyList = typeof(N15LocalParameters).GetProperties();
            foreach (var property in propertyList.Where(property => ("лок" + item.Name) == property.Name && !item.Name.Contains("А20512")))
            {
                item.BackgroundImage = (bool)property.GetValue(null)
                        ? ControlElementImages.tumblerType3Up
                        : ControlElementImages.tumblerType3Down;
            }

            ТумблерА20512.BackgroundImage = N15LocalParameters.локТумблерА20512
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;
        }
        #endregion

        #region Включение и выключение блоков станции, открытие блока

        private void КнопкаСтанцияВкл_MouseDown(object sender, MouseEventArgs e)
        {
            this.КнопкаСтанцияВкл.BackgroundImage = null;
            N15Parameters.SetCurrentParameters();
            N15Parameters.ResetParameters();
        }

        private void КнопкаСтанцияВкл_MouseUp(object sender, MouseEventArgs e)
        {
            this.КнопкаСтанцияВкл.BackgroundImage = ControlElementImages.buttonN15On;
        }

        private void КнопкаСтанцияВыкл_MouseDown(object sender, MouseEventArgs e)
        {
            this.КнопкаСтанцияВыкл.BackgroundImage = null;
            N15Parameters.ResetCurrentParameters();
            N15Parameters.ResetParameters();
        }

        private void КнопкаСтанцияВыкл_MouseUp(object sender, MouseEventArgs e)
        {
            this.КнопкаСтанцияВыкл.BackgroundImage = ControlElementImages.buttonN15Off;
        }

        private void N15ButtonInside1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form thisForm = new N15InsideForm();
            thisForm.Show(this);
        }

        private void N15ButtonInside2_Click(object sender, EventArgs e)
        {
            N15ButtonInside1_Click(sender, e);
        }

        #endregion

        #region Кнопки ПРМ НАВЕДЕНИЕ/Ц300М 1 2 3 4 и МОЩНОСТЬ Н16 АНТ Сброс

        private void КнопкаПРМНаведениеЦ300М1_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = true;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаПРМНаведениеЦ300М2_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = true;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаПРМНаведениеЦ300М3_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = true;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаПРМНаведениеЦ300М4_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = true;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаМощностьН16_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = true;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаМощностьАнт_Click(object sender, EventArgs e)
        {
            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = true;
        }

        private void КнопкаМощностьСброс_MouseDown(object sender, MouseEventArgs e)
        {
            this.КнопкаМощностьСброс.BackgroundImage = null;
            this.КнопкаМощностьСброс.Text = string.Empty;

            N15Parameters.КнопкаПРМНаведениеЦ300М1 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М2 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М3 = false;
            N15Parameters.КнопкаПРМНаведениеЦ300М4 = false;
            N15Parameters.КнопкаМощностьН16 = false;
            N15Parameters.КнопкаМощностьАнт = false;
        }

        private void КнопкаМощностьСброс_MouseUp(object sender, MouseEventArgs e)
        {
            this.КнопкаМощностьСброс.BackgroundImage = ControlElementImages.buttonSquareWhite;
            this.КнопкаМощностьСброс.Text = "СБРОС";
        }

        #endregion

        #region Кнопки Н13-1 Н13-2 Н13-1,2 СБРОС
        private void КнопкаН13_1_Click(object sender, EventArgs e)
        {
            this.КнопкаН13_1.Visible = false;
            this.КнопкаН13_2.Visible = true;
            this.КнопкаН13_12.Visible = true;

            N15LocalParameters.локКнопкаН13_1 = true;
            N15LocalParameters.локКнопкаН13_2 = false;
            N15LocalParameters.локКнопкаН13_12 = false;
            N16Parameters.ЩелевойМостН13 = 1;
        }

        private void КнопкаН13_2_Click(object sender, EventArgs e)
        {
            this.КнопкаН13_2.Visible = false;
            this.КнопкаН13_1.Visible = true;
            this.КнопкаН13_12.Visible = true;

            N15LocalParameters.локКнопкаН13_1 = false;
            N15LocalParameters.локКнопкаН13_2 = true;
            N15LocalParameters.локКнопкаН13_12 = false;
            N16Parameters.ЩелевойМостН13 = 2;
        }

        private void КнопкаН13_12_Click(object sender, EventArgs e)
        {
            this.КнопкаН13_12.Visible = false;
            this.КнопкаН13_1.Visible = true;
            this.КнопкаН13_2.Visible = true;

            N15LocalParameters.локКнопкаН13_1 = false;
            N15LocalParameters.локКнопкаН13_2 = false;
            N15LocalParameters.локКнопкаН13_12 = true;
            N16Parameters.ЩелевойМостН13 = 3;
        }

        private void КнопкаСброс_MouseUp(object sender, MouseEventArgs e)
        {
            N15Parameters.КнопкаН13 = 0;
            this.КнопкаСброс.BackgroundImage = ControlElementImages.buttonSquareWhite;
            this.КнопкаСброс.Text = "СБРОС";
        }

        private void КнопкаСброс_MouseDown(object sender, MouseEventArgs e)
        {
            this.КнопкаСброс.BackgroundImage = null;
            this.КнопкаСброс.Text = string.Empty;

            N15LocalParameters.локКнопкаН13_1 = false;
            N15LocalParameters.локКнопкаН13_2 = false;
            N15LocalParameters.локКнопкаН13_12 = false;
            N16Parameters.ЩелевойМостН13 = 0;
        }
        #endregion

        #region Регуляторы

        private static bool isManipulation;

        private void Регулятор_MouseDown(object sender, MouseEventArgs e)
        {
            isManipulation = true;
        }

        private void Регулятор_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            N15Parameters.РегуляторУровень = angle;
            button.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                    ControlElementImages.revolverRoundSmall,
                    (float)N15Parameters.РегуляторУровень);
        }

        private void Регулятор_MouseUp(object sender, MouseEventArgs e)
        {
            isManipulation = false;
        }
        #endregion

        #region Нажатия на тумблеры
        private void Тумблер_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var localParameter = typeof(N15LocalParameters).GetProperty("лок" + button.Name);
            var newValue = !(bool)localParameter.GetValue(null);
            localParameter.SetValue(null, newValue);
            RefreshFormElement(button.Name);
        }
        private void ТумблерА30412_Click(object sender, EventArgs e)
        {
            N15Parameters.ТумблерА30412 = !N15Parameters.ТумблерА30412;
        }

        private void ТумблерА503Б_Click(object sender, EventArgs e)
        {
            N15Parameters.ТумблерА503Б = !N15Parameters.ТумблерА503Б;
        }

        private void ТумблерАнтЭкв_Click(object sender, EventArgs e)
        {
            N15LocalParameters.локТумблерАнтЭкв = !N15LocalParameters.локТумблерАнтЭкв;
            N16Parameters.КоаксиальныйПереключатель = N15LocalParameters.локТумблерАнтЭкв;
        }

        private void ТумблерТлфТлгПрм_Click(object sender, EventArgs e)
        {
            N15Parameters.ТумблерТлфТлгПрм = !N15Parameters.ТумблерТлфТлгПрм;
        }

        private void ТумблерТлфТлгПрд_Click(object sender, EventArgs e)
        {
            N15Parameters.ТумблерТлфТлгПрд = !N15Parameters.ТумблерТлфТлгПрд;
        }

        #region Тумблеры с 3 положениями
        private void Тумблер5Мгц_MouseUp(object sender, MouseEventArgs e)
        {
            N15Parameters.Тумблер5Мгц = 0;
            Тумблер5Мгц.BackgroundImage = null;
        }

        private void Тумблер5Мгц_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15Parameters.Тумблер5Мгц = 1;
                Тумблер5Мгц.BackgroundImage = ControlElementImages.tumblerType2Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N15Parameters.Тумблер5Мгц = -1;
                Тумблер5Мгц.BackgroundImage = ControlElementImages.tumblerType2Up;
            }
        }

        private void ТумблерФаза_MouseUp(object sender, MouseEventArgs e)
        {
            N15Parameters.ТумблерФаза = 0;
            ТумблерФаза.BackgroundImage = null;
        }

        private void ТумблерФаза_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15Parameters.ТумблерФаза = 1;
                ТумблерФаза.BackgroundImage = ControlElementImages.tumblerType2Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N15Parameters.ТумблерФаза = -1;
                ТумблерФаза.BackgroundImage = ControlElementImages.tumblerType2Up;
            }
        }

        private void ТумблерУров1_MouseUp(object sender, MouseEventArgs e)
        {
            N15Parameters.ТумблерУров1 = 0;
            ТумблерУров1.BackgroundImage = null;
        }

        private void ТумблерУров1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15Parameters.ТумблерУров1 = 1;
                ТумблерУров1.BackgroundImage = ControlElementImages.tumblerType2Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N15Parameters.ТумблерУров1 = -1;
                ТумблерУров1.BackgroundImage = ControlElementImages.tumblerType2Up;
            }
        }

        private void ТумблерУров2_MouseUp(object sender, MouseEventArgs e)
        {
            N15Parameters.ТумблерУров2 = 0;
            ТумблерУров2.BackgroundImage = null;
        }

        private void ТумблерУров2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15Parameters.ТумблерУров2 = 1;
                ТумблерУров2.BackgroundImage = ControlElementImages.tumblerType2Down;
            }
            if (e.Button == MouseButtons.Right)
            {
                N15Parameters.ТумблерУров2 = -1;
                ТумблерУров2.BackgroundImage = ControlElementImages.tumblerType2Up;
            }
        }
        #endregion
        #endregion

        private void N15Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            N15Parameters.ParameterChanged -= RefreshFormElements;
            
            if(LearnMain.getIntent() == ModulesEnum.N15Power)
            {
                if(LearnMain.globalIntent == GlobalIntentEnum.OneChannel)
                {
                    if(N15Parameters.ТумблерЦ300М1 && N15Parameters.ТумблерЦ300М2 && N15Parameters.ТумблерЦ300М3 && N15Parameters.ТумблерЦ300М4 &&
                        N15Parameters.ТумблерАФСС && !N15Parameters.ТумблерАнтЭкв && N15Parameters.ТумблерА403 && N15Parameters.ЛампочкаБМА_1 && 
                        N15Parameters.ЛампочкаБМА_2 && N15Parameters.ЛампочкаМШУ && N15Parameters.ТумблерТлфТлгПрд && N15.N15Parameters.ТумблерТлфТлгПрм )
                    {
                        LearnMain.setIntent(ModulesEnum.A205_m1_Open);
                    } else
                    {
                        LearnMain.setIntent(ModulesEnum.openN15);
                    }
                }
            }
        }

        
    }
}