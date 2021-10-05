namespace R440O.R440OForms.N502B
{
    using System;
    using System.Globalization;
    using System.Windows.Forms;
    using ThirdParty;
    using BaseClasses;
    using global::R440O.LearnModule;
    using global::R440O.TestModule;

    public partial class N502BForm : Form, IRefreshableForm, ITestModule
    {
        public bool IsExactModule { get; set; }

        public N502BForm()
        {
            InitializeComponent();
            N502BParameters.ParameterChanged += RefreshFormElements;

            if (ParametersConfig.IsTesting)
            {
                N502BParameters.TestModuleRef = this;
                N502BParameters.Action += TestMain.Action;
            }

            N502BParameters.СтанцияСгорела += ВыводСообщенияСтанцияСгорела;
            N502BParameters.НекорректноеДействие += ВыводСообщенияНекорректноеДействие;
            RefreshFormElements();

            LearnMain.isMainWindow = false;

            switch (LearnMain.getIntent())
            {
                case ModulesEnum.openN502BtoCheck:
                    LearnMain.form = this;
                    LearnMain.setIntent(ModulesEnum.N502Check);
                    break;
                case ModulesEnum.openN502BtoPower:
                    if (VoltageStabilizer.VoltageStabilizerParameters.КабельВход > 0)
                    {
                        LearnMain.form = this;
                        LearnMain.setIntent(ModulesEnum.N502Power);
                    }
                    break;
                default:
                    break;
            }
            
            switch (TestMain.getIntent())
            {
                case ModulesEnum.openN502BtoCheck:
                    IsExactModule = true;
                    TestMain.setIntent(ModulesEnum.N502Check);
                    break;
                case ModulesEnum.openN502BtoPower:
                    IsExactModule = true;
                    if (VoltageStabilizer.VoltageStabilizerParameters.КабельВход > 0)
                    {
                        TestMain.setIntent(ModulesEnum.N502Power);
                    }
                    break;
                default:
                    break;
                    
            }
        }

        private void ВыводСообщенияСтанцияСгорела()
        {
            MessageBox.Show("Станция сгорела!", "ОШИБКА");

            if (ParametersConfig.IsTesting)
                TestMain.MakeBlunderMistake();
            
        }

        private void ВыводСообщенияНекорректноеДействие()
        {
            MessageBox.Show("Некорректное действие!", "ОШИБКА");

            if (ParametersConfig.IsTesting)
                TestMain.MakeSoftMistake();
        }

        #region Тумблеры

        private void ТумблерЭлектрооборудование_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерЭлектрооборудование = !N502BParameters.ТумблерЭлектрооборудование;
        }

        private void ТумблерВыпрямитель27В_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерВыпрямитель27В = !N502BParameters.ТумблерВыпрямитель27В;
        }

        private void ТумблерОсвещение_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерОсвещение = !N502BParameters.ТумблерОсвещение;
        }

        private void ТумблерН131_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерН13_1 = !N502BParameters.ТумблерН13_1;
        }

        private void ТумблерН132_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерН13_2 = !N502BParameters.ТумблерН13_2;
        }

        private void ТумблерН15_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ТумблерН15 = !N502BParameters.ТумблерН15;
        }

        private void ТумблерОсвещение1_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (N502BParameters.ТумблерОсвещение1)
                    {
                        case 1:
                            N502BParameters.ТумблерОсвещение1 = 2;
                            break;
                        case 2:
                            N502BParameters.ТумблерОсвещение1 = 3;
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (N502BParameters.ТумблерОсвещение1)
                    {
                        case 3:
                            N502BParameters.ТумблерОсвещение1 = 2;
                            break;
                        case 2:
                            N502BParameters.ТумблерОсвещение1 = 1;
                            break;
                    }
                    break;
            }
        }

        private void ТумблерОсвещение2_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    switch (N502BParameters.ТумблерОсвещение2)
                    {
                        case 1:
                            N502BParameters.ТумблерОсвещение2 = 2;
                            break;
                        case 2:
                            N502BParameters.ТумблерОсвещение2 = 3;
                            break;
                    }
                    break;
                case MouseButtons.Right:
                    switch (N502BParameters.ТумблерОсвещение2)
                    {
                        case 3:
                            N502BParameters.ТумблерОсвещение2 = 2;
                            break;
                        case 2:
                            N502BParameters.ТумблерОсвещение2 = 1;
                            break;
                    }
                    break;
            }
        }

        #endregion

        #region Кнопки
        private void КнопкаРБПСброс_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаРБПСброс.BackgroundImage = ControlElementImages.buttonRoundType3;
        }

        private void КнопкаРБПСброс_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаРБПСброс.BackgroundImage = null;
        }

        private void КнопкаРБППроверка_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаРБППроверка.BackgroundImage = ControlElementImages.buttonRoundType3;
        }

        private void КнопкаРБППроверка_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаРБППроверка.BackgroundImage = null;
        }

        private void КнопкаВклНагрузки_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаВклНагрузки.BackgroundImage = null;
            N502BParameters.КнопкаВклНагрузки = true;
        }

        private void КнопкаВклНагрузки_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаВклНагрузки.BackgroundImage = ControlElementImages.buttonRoundType3;
            N502BParameters.КнопкаВклНагрузки = false;
        }
        #endregion

        #region Переключатели

        private void ПереключательСеть_Click(object sender, System.EventArgs e)
        {
            N502BParameters.ПереключательСеть = !N502BParameters.ПереключательСеть;

            if (N502BParameters.ЛампочкаСеть && N502BParameters.ПереключательСеть) N502BParameters.StationTimer.Start();
                else N502BParameters.StationTimer.Stop();
        }

        private void ПереключательНапряжение_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N502BParameters.ПереключательНапряжение += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N502BParameters.ПереключательНапряжение -= 1;
            }
        }

        private void ПереключательФазировка_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N502BParameters.ПереключательФазировка += 1;
                if (N502BParameters.ПереключательФазировка == 5) N502BParameters.ПереключательФазировка = 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                N502BParameters.ПереключательФазировка -= 1;
                if (N502BParameters.ПереключательФазировка == 0) N502BParameters.ПереключательФазировка = 4;
            }
        }

        private void ПереключательКонтрольНапряжения_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N502BParameters.ПереключательКонтрольНапряжения += 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                N502BParameters.ПереключательКонтрольНапряжения -= 1;
            }
        }

        private void ПереключательТокНагрузкиИЗаряда_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N502BParameters.ПереключательТокНагрузкиИЗаряда += 1;
            }
            if (e.Button == MouseButtons.Right)
            {
                N502BParameters.ПереключательТокНагрузкиИЗаряда -= 1;
            }
        }

        #endregion

        #region Обновление формы

        public void RefreshFormElements()
        {

            ВремяРаботы.Text = Math.Round(N502BParameters.ВремяРаботыСтанции.TotalHours, 1).ToString(CultureInfo.CurrentCulture);

            this.RefreshLamps();
            this.RefreshTogglesPosition();
            this.RefreshTumblersPosition();

            var angle = N502BParameters.ИндикаторНапряжение * 0.25F - 70;
            ИндикаторНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);

            angle = N502BParameters.ИндикаторТокНагрузки * 0.25F - 70;
            ИндикаторТокНагрузки.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);

            angle = N502BParameters.ИндикаторКонтрольНапряжения * 1.5F - 60;
            ИндикаторКонтрольНапряжения.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);

            angle = N502BParameters.ИндикаторТокНагрузкиИЗаряда * 1.75F - 70;
            ИндикаторТокНагрузкиИЗаряда.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        private void RefreshTumblersPosition()
        {
            ТумблерЭлектрооборудование.BackgroundImage = N502BParameters.ТумблерЭлектрооборудование ?
                ControlElementImages.tumblerType2Up : ControlElementImages.tumblerType2Down;

            ТумблерВыпрямитель27В.BackgroundImage = N502BParameters.ТумблерВыпрямитель27В ?
                ControlElementImages.tumblerType2Up : ControlElementImages.tumblerType2Down;

            ТумблерОсвещение.BackgroundImage = !N502BParameters.ТумблерОсвещение ?
                ControlElementImages.tumblerType2Down : ControlElementImages.tumblerType2Up;

            ТумблерН13_1.BackgroundImage = !N502BParameters.ТумблерН13_1 ?
                ControlElementImages.tumblerType2Down : ControlElementImages.tumblerType2Up;

            ТумблерН13_2.BackgroundImage = !N502BParameters.ТумблерН13_2 ?
                ControlElementImages.tumblerType2Down : ControlElementImages.tumblerType2Up;

            ТумблерН15.BackgroundImage = !N502BParameters.ТумблерН15 ?
                ControlElementImages.tumblerType2Down : ControlElementImages.tumblerType2Up;

            switch (N502BParameters.ТумблерОсвещение1)
            {
                case 2:
                    ТумблерОсвещение1.BackgroundImage = ControlElementImages.tumblerType5Middle;
                    break;
                case 1:
                    ТумблерОсвещение1.BackgroundImage = ControlElementImages.tumblerType5Up;
                    break;
                default:
                    ТумблерОсвещение1.BackgroundImage = ControlElementImages.tumblerType5Down;
                    break;
            }

            switch (N502BParameters.ТумблерОсвещение2)
            {
                case 2:
                    ТумблерОсвещение2.BackgroundImage = ControlElementImages.tumblerType5Middle;
                    break;
                case 1:
                    ТумблерОсвещение2.BackgroundImage = ControlElementImages.tumblerType5Up;
                    break;
                default:
                    ТумблерОсвещение2.BackgroundImage = ControlElementImages.tumblerType5Down;
                    break;
            }
        }

        private void RefreshTogglesPosition()
        {
            ПереключательСеть.BackgroundImage = N502BParameters.ПереключательСеть
                ? ControlElementImages.tumblerN502BPowerUp
                : ControlElementImages.tumblerN502BPowerDown;

            var angle = N502BParameters.ПереключательНапряжение * 38 - 150;
            ПереключательНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N502BParameters.ПереключательФазировка * 90 - 180;
            ПереключательФазировка.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType5, angle);

            angle = N502BParameters.ПереключательКонтрольНапряжения * 45 - 90;
            ПереключательКонтрольНапряжения.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType1, angle);

            angle = N502BParameters.ПереключательТокНагрузкиИЗаряда * 40 - 180;
            ПереключательТокНагрузкиИЗаряда.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType4, angle);
        }

        private void RefreshLamps()
        {
            ЛампочкаСеть.BackgroundImage = N502BParameters.ЛампочкаСеть
                ? ControlElementImages.lampType12OnRed
                : null;

            ЛампочкаСфазировано.BackgroundImage = N502BParameters.ЛампочкаСфазировано
                ? ControlElementImages.lampType12OnRed
                : null;
        }

        #endregion

        private void N502BForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            N502BParameters.ParameterChanged -= RefreshFormElements;
            N502BParameters.СтанцияСгорела -= ВыводСообщенияСтанцияСгорела;
            N502BParameters.НекорректноеДействие -= ВыводСообщенияНекорректноеДействие;

            if (ParametersConfig.IsTesting)
            {
                N502BParameters.Action -= TestMain.Action;
            }

            switch (LearnMain.getIntent())
            {
                case ModulesEnum.N502Check:
                    LearnMain.setIntent(ModulesEnum.openVoltageStabilizer);
                    break;
                case ModulesEnum.N502Power:
                    if ((N502BParameters.ЛампочкаСфазировано) &&
                        (N502BParameters.Н15Включен) &&
                        (N502BParameters.ТумблерЭлектрооборудование) &&
                        (N502BParameters.ТумблерН13_1) &&
                        (N502BParameters.ТумблерН13_2) &&
                        (N502BParameters.ТумблерВыпрямитель27В))
                        LearnMain.setIntent(ModulesEnum.openN15);
                    break;
            }
            switch (TestMain.getIntent())
            {
                case ModulesEnum.N502Check:
                    TestMain.setIntent(ModulesEnum.openVoltageStabilizer);
                    break;
                case ModulesEnum.N502Power:
                    if ((N502BParameters.ЛампочкаСфазировано) &&
                        (N502BParameters.Н15Включен) &&
                        (N502BParameters.ТумблерЭлектрооборудование) &&
                        (N502BParameters.ТумблерН13_1) &&
                        (N502BParameters.ТумблерН13_2) &&
                        (N502BParameters.ТумблерВыпрямитель27В))
                    {
                        TestMain.setIntent(ModulesEnum.openN15);
                        IsExactModule = false;
                    }
                    break;
            }
            //if (LearnMain.globalIntent == GlobalIntentEnum.nill)
            //    LearnMain.setIntent(ModulesEnum.chooseLearnType);

        }
        
    }
}