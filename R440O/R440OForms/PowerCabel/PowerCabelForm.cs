namespace R440O.R440OForms.PowerCabel
{
    using BaseClasses;
    using global::R440O.LearnModule;
    using global::R440O.TestModule;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока кабель питания
    /// </summary>
    public partial class PowerCabelForm : Form, IRefreshableForm, ITestModule
    {
        public bool IsExactModule { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PowerCabelForm"/>
        /// </summary>
        public PowerCabelForm()
        {
            InitializeComponent();
            PowerCabelParameters.getInstance().ParameterChanged += RefreshFormElements;
            PowerCabelParameters.getInstance().СтанцияСгорела += ВыводСообщенияСтанцияСгорела;

            this.RefreshFormElements();

            if (LearnMain.getIntent() == LearnModule.ModulesEnum.openPowerCabeltoPower)
            {
                LearnMain.setIntent(LearnModule.ModulesEnum.PowerCabelConnect);
                LearnMain.form = this;
                LearnMain.Action();
            }
        }
        private void ВыводСообщенияСтанцияСгорела()
        {
            MessageBox.Show("Станция сгорела!", "ОШИБКА");
            TestMain.MakeBlunderMistake();
        }

        #region Кабель СЕТЬ
        private void КабельСеть_Click(object sender, EventArgs e)
        {
            PowerCabelParameters.getInstance().КабельСеть = !PowerCabelParameters.getInstance().КабельСеть;
        }
        #endregion

        #region Тумблер ОСВЕЩЕНИЕ
        private void ТумблерОсвещение_Click(object sender, EventArgs e)
        {
            PowerCabelParameters.getInstance().ТумблерОсвещение = !PowerCabelParameters.getInstance().ТумблерОсвещение;
        }
        #endregion

        #region Инициализация

        public void RefreshFormElements()
        {
            ТумблерОсвещение.BackgroundImage = (PowerCabelParameters.getInstance().ТумблерОсвещение)
                ? ControlElementImages.tumblerType4Right
                : ControlElementImages.tumblerType4Left;

            КабельСеть.BackgroundImage = (PowerCabelParameters.getInstance().КабельСеть)
                ? ControlElementImages.powerCabelEnter
                : null;
        }
        #endregion
        
        private void PowerCabelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!PowerCabelParameters.getInstance().КабельСеть)
            {
                LearnMain.setIntent(LearnModule.ModulesEnum.openPowerCabeltoPower);
            }
            else
            {
                LearnMain.setIntent(LearnModule.ModulesEnum.openN502BtoCheck);
            }

            PowerCabelParameters.getInstance().ParameterChanged -= RefreshFormElements;
            PowerCabelParameters.getInstance().СтанцияСгорела -= ВыводСообщенияСтанцияСгорела;
            
            switch (TestMain.getIntent())
            {
                case ModulesEnum.PowerCabelConnect:
                    var blockParams = PowerCabelParameters.getInstance();

                    TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.PowerCabelConnect, Value = blockParams.Напряжение });
                    break;
            }
        }
    }
}