namespace R440O.R440OForms.N15Inside
{
    using System.Windows.Forms;
    using BaseClasses;
    using ThirdParty;
    using ShareTypes.SignalTypes;
    using global::R440O.LearnModule;

    /// <summary>
    /// Форма внутренней части блока Н15
    /// </summary>
    public partial class N15InsideForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N15InsideForm"/>
        /// </summary>
        public N15InsideForm()
        {
            this.InitializeComponent();
            N15InsideParameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();

            LearnMain.form = this;
            switch (LearnMain.getIntent())
            {
                case ModulesEnum.H15Inside_open_from_H15:
                    if (LearnMain.globalIntent == GlobalIntentEnum.OneChannel)
                    {
                        LearnMain.setIntent(ModulesEnum.H15Inside_power);
                    }
                    break;
            }
        }

        /// <summary>
        /// Закрытие формы внутренней части блока
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void N15InsideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            N15InsideParameters.ParameterChanged -= RefreshFormElements;
            Owner.Show();
        }

        #region Переключатели
        private void ПереключательПУЛ480_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15InsideParameters.ПереключательПУЛ480ПРМ_1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N15InsideParameters.ПереключательПУЛ480ПРМ_1 -= 1;
            }
        }

        private void ПереключательПУЛ480_2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15InsideParameters.ПереключательПУЛ480ПРМ_2 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N15InsideParameters.ПереключательПУЛ480ПРМ_2 -= 1;
            }
        }

        private void ПереключательПУЛ48ПРД_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15InsideParameters.ПереключательПУЛ48ПРД_1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N15InsideParameters.ПереключательПУЛ48ПРД_1 -= 1;
            }
        }

        private void ПереключательПУЛ48ПРД_2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N15InsideParameters.ПереключательПУЛ48ПРД_2 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N15InsideParameters.ПереключательПУЛ48ПРД_2 -= 1;
            }
        }
        #endregion

        #region Тумблеры
        private void ТумблерПУЛ480ПРМ_1_Click(object sender, System.EventArgs e)
        {
            N15InsideParameters.ТумблерПУЛ480ПРМ_1 = N15InsideParameters.ТумблерПУЛ480ПРМ_1 == Модуляция.ЧТ ? Модуляция.ОФТ : Модуляция.ЧТ;
        }

        private void ТумблерПУЛ48ПРД_1_Click(object sender, System.EventArgs e)
        {
            N15InsideParameters.ТумблерПУЛ48ПРД_1 = N15InsideParameters.ТумблерПУЛ48ПРД_1 == Модуляция.ЧТ ? Модуляция.ОФТ : Модуляция.ЧТ;
        }

        private void ТумблерПУЛ480ПРМ_2_Click(object sender, System.EventArgs e)
        {
            N15InsideParameters.ТумблерПУЛ480ПРМ_2 = N15InsideParameters.ТумблерПУЛ480ПРМ_2 == Модуляция.ЧТ ? Модуляция.ОФТ : Модуляция.ЧТ;
        }

        private void ТумблерПУЛ48ПРД_2_Click(object sender, System.EventArgs e)
        {
            N15InsideParameters.ТумблерПУЛ48ПРД_2 = N15InsideParameters.ТумблерПУЛ48ПРД_2 == Модуляция.ЧТ ? Модуляция.ОФТ : Модуляция.ЧТ;
        }

        #endregion

        public void RefreshFormElements()
        {
            this.ТумблерПУЛ480ПРМ_1.BackgroundImage = N15InsideParameters.ТумблерПУЛ480ПРМ_1 == Модуляция.ЧТ
               ? ControlElementImages.tumblerType4Left
               : ControlElementImages.tumblerType4Right;

            this.ТумблерПУЛ480ПРМ_2.BackgroundImage = N15InsideParameters.ТумблерПУЛ480ПРМ_2 == Модуляция.ЧТ
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;

            this.ТумблерПУЛ48ПРД_1.BackgroundImage = N15InsideParameters.ТумблерПУЛ48ПРД_1 == Модуляция.ОФТ
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;

            this.ТумблерПУЛ48ПРД_2.BackgroundImage = N15InsideParameters.ТумблерПУЛ48ПРД_2 == Модуляция.ОФТ
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;

            var angle = N15InsideParameters.ПереключательПУЛ480ПРМ_1 * 36 + 72;
            ПереключательПУЛ480ПРМ_1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType8, angle);

            angle = N15InsideParameters.ПереключательПУЛ480ПРМ_2 * 36 + 72;
            ПереключательПУЛ480ПРМ_2.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType8, angle);

            angle = N15InsideParameters.ПереключательПУЛ48ПРД_1 * 30 + 160;
            ПереключательПУЛ48ПРД_1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType8, angle);

            angle = N15InsideParameters.ПереключательПУЛ48ПРД_2 * 30 + 160;
            ПереключательПУЛ48ПРД_2.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType8, angle);
        }
    }
}