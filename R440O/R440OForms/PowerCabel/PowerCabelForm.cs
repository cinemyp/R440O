using System.Runtime.CompilerServices;

namespace R440O.R440OForms.PowerCabel
{
    using BaseClasses;
    using global::R440O.LearnModule;
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока кабель питания
    /// </summary>
    public partial class PowerCabelForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="PowerCabelForm"/>
        /// </summary>
        public PowerCabelForm()
        {
            InitializeComponent();
            PowerCabelParameters.ParameterChanged += RefreshFormElements;
            PowerCabelParameters.СтанцияСгорела += ВыводСообщенияСтанцияСгорела;
            this.RefreshFormElements();

            if (LearnMain.getIntent() == ModulesEnum.PowerCabelConnect)
            { 
                LearnMain.form = this;
                LearnMain.Action();
            }
        }
        private void ВыводСообщенияСтанцияСгорела()
        {
            MessageBox.Show("Станция сгорела!", "ОШИБКА");
        }

        #region Кабель СЕТЬ
        private void КабельСеть_Click(object sender, EventArgs e)
        {
            PowerCabelParameters.КабельСеть = !PowerCabelParameters.КабельСеть;
        }
        #endregion

        #region Тумблер ОСВЕЩЕНИЕ
        private void ТумблерОсвещение_Click(object sender, EventArgs e)
        {
            PowerCabelParameters.ТумблерОсвещение = !PowerCabelParameters.ТумблерОсвещение;
        }
        #endregion

        #region Инициализация

        public void RefreshFormElements()
        {
            ТумблерОсвещение.BackgroundImage = (PowerCabelParameters.ТумблерОсвещение)
                ? ControlElementImages.tumblerType4Right
                : ControlElementImages.tumblerType4Left;

            КабельСеть.BackgroundImage = (PowerCabelParameters.КабельСеть)
                ? ControlElementImages.powerCabelEnter
                : null;
        }
        #endregion

        private void PowerCabelForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            if (!PowerCabelParameters.КабельСеть)
            {
                LearnMain.setIntent(ModulesEnum.openPowerCabeltoPower);
            }      
            else   LearnMain.setIntent(ModulesEnum.openN502BtoCheck);
            
            PowerCabelParameters.ParameterChanged -= RefreshFormElements;
            PowerCabelParameters.СтанцияСгорела -= ВыводСообщенияСтанцияСгорела;
        }
    }
}