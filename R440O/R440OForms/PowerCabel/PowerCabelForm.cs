namespace R440O.R440OForms.PowerCabel
{
    using BaseClasses;
    using global::R440O.LearnModule;
    using global::R440O.TestModule;
    using ShareTypes;
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

            if (LearnMain.getIntent() == ModulesEnum.openPowerCabeltoPower)
            {
                LearnMain.setIntent(ModulesEnum.PowerCabelConnect);
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
                LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);
            }
            else
            {
                LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            }

            PowerCabelParameters.getInstance().ParameterChanged -= RefreshFormElements;
            PowerCabelParameters.getInstance().СтанцияСгорела -= ВыводСообщенияСтанцияСгорела;
            
            switch (TestMain.getIntent())
            {
                case ShareTypes.ModulesEnum.PowerCabelConnect:
                    var blockParams = PowerCabelParameters.getInstance();

                    TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.PowerCabelConnect, Value = blockParams.Напряжение > 0 ? 1 : 0 });
                    break;
            }
        }
    }
}