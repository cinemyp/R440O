namespace R440O.R440OForms.VoltageStabilizer
{
    using System.Windows.Forms;
    using BaseClasses;
    using global::R440O.LearnModule;
    using ThirdParty;

    /// <summary>
    /// Форма блока стабилизатор напряжения
    /// </summary>
    public partial class VoltageStabilizerForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="VoltageStabilizerForm"/>
        /// </summary>
        public VoltageStabilizerForm()
        {
            InitializeComponent();
            VoltageStabilizerParameters.ParameterChanged += RefreshFormElements;
            VoltageStabilizerParameters.ОператорСтанцииПораженТоком += ВыводСообщенияОператорСтанцииПоражёнТоком;
            RefreshFormElements();

            if(LearnMain.getIntent()==ModulesEnum.openVoltageStabilizer)
            {
                LearnMain.form = this;
                LearnMain.setIntent(ModulesEnum.VoltageStabilizerSetUp);
            }
        }

        private void ВыводСообщенияОператорСтанцииПоражёнТоком()
        {
            MessageBox.Show("Оператор станции поражён током!", "ОШИБКА");
        }

        #region Обработка действий пользователя

        /// <summary>
        /// Обработка клика на кабельный вход 220В.
        /// Если питание отключено, оно будет установлено на 220В.
        /// Если питание установлено на 220В, то оно будет отключено.
        /// Если питание установлено на 380В, то оно будет переключено на 220В.
        /// </summary>
        private void КабельВход1_Click(object sender, System.EventArgs e)
        {
            switch (VoltageStabilizerParameters.КабельВход)
            {
                case 0:
                case 380:
                    VoltageStabilizerParameters.КабельВход = 220;
                    break;
                case 220:
                    VoltageStabilizerParameters.КабельВход = 0;
                    break;
            }
        }

        /// <summary>
        /// Обработка клика на кабельный вход 380В.
        /// Если питание отключено, оно будет установлено на 380В.
        /// Если питание установлено на 380В, то оно будет отключено.
        /// Если питание установлено на 220В, то оно будет переключено на 380В.
        /// </summary>
        private void КабельВход2_Click(object sender, System.EventArgs e)
        {
            switch (VoltageStabilizerParameters.КабельВход)
            {
                case 0:
                case 220: VoltageStabilizerParameters.КабельВход = 380;
                    break;
                case 380: VoltageStabilizerParameters.КабельВход = 0;
                    break;
            }
        }

        /// <summary>
        /// Переключатель КонтрольНапряжения
        /// </summary>
        private void ПереключательКонтрольНапр_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) VoltageStabilizerParameters.ПереключательКонтрольНапр += 1;
            if (e.Button == MouseButtons.Right) VoltageStabilizerParameters.ПереключательКонтрольНапр -= 1;
        }

        #endregion

        public void RefreshFormElements()
        {
            switch (VoltageStabilizerParameters.КабельВход)
            {
                case 0:
                    КабельВход1.BackgroundImage = null;
                    КабельВход2.BackgroundImage = null;
                    break;
                case 220:
                    КабельВход1.BackgroundImage = ControlElementImages.voltageStabilizerInput;
                    КабельВход2.BackgroundImage = null;
                    break;
                case 380:
                    КабельВход1.BackgroundImage = null;
                    КабельВход2.BackgroundImage = ControlElementImages.voltageStabilizerInput;
                    break;
            }
            var angle = VoltageStabilizerParameters.ПереключательКонтрольНапр * 30 - 195;
            ПереключательКонтрольНапр.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);
            ИндикаторНапряжения.Invalidate();

            ЛампочкаСетьВкл.BackgroundImage = VoltageStabilizerParameters.ЛампочкаСеть
                ? ControlElementImages.lampType13OnGreen
                : null;

            ЛампочкаАвария.BackgroundImage = VoltageStabilizerParameters.ЛампочкаАвария
                ? ControlElementImages.lampType6OnRed
                : null;

            angle = (int) (VoltageStabilizerParameters.ИндикаторНапряжение * 0.3 - 75);
            ИндикаторНапряжения.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        private void VoltageStabilizerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            VoltageStabilizerParameters.ParameterChanged -= RefreshFormElements;
            VoltageStabilizerParameters.ОператорСтанцииПораженТоком -= ВыводСообщенияОператорСтанцииПоражёнТоком;

            if((LearnMain.getIntent() == ModulesEnum.VoltageStabilizerSetUp)
                && (VoltageStabilizerParameters.КабельВход>0))
            { 
                LearnMain.setIntent(ModulesEnum.openN502BtoPower);
            } else LearnMain.setIntent(ModulesEnum.openVoltageStabilizer);
        }
       
    }
}