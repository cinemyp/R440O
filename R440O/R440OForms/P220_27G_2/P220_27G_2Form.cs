namespace R440O.R440OForms.P220_27G_2
{
    using System;
    using System.Windows.Forms;
    using BaseClasses;
    using global::R440O.TestModule;

    /// <summary>
    /// Форма блока П220-27Г-2
    /// </summary>
    public partial class P220_27G_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="P220_27G_2Form"/>
        /// </summary>
        public P220_27G_2Form()
        {
            InitializeComponent();
            P220_27G_2Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            P220_27G_2Parameters.getInstance().ТумблерСеть = !P220_27G_2Parameters.getInstance().ТумблерСеть;
        }

        private void ТумблерУправление_Click(object sender, System.EventArgs e)
        {
            P220_27G_2Parameters.getInstance().ТумблерУправление = !P220_27G_2Parameters.getInstance().ТумблерУправление;
        }

        public void RefreshFormElements()
        {
            ЛампочкаСеть.BackgroundImage = P220_27G_2Parameters.getInstance().ЛампочкаСеть
                ? ControlElementImages.lampType9OnGreen
                : null;

            Лампочка27В.BackgroundImage = P220_27G_2Parameters.getInstance().Лампочка27В
                ? ControlElementImages.lampType3OnRed
                : null;

            ТумблерУправление.BackgroundImage = P220_27G_2Parameters.getInstance().ТумблерУправление
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            ТумблерСеть.BackgroundImage = P220_27G_2Parameters.getInstance().ТумблерСеть
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;
        }

        private void P220_27G_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = P220_27G_2Parameters.getInstance();
                bool def = blockParams.ТумблерСеть &&
                    blockParams.ТумблерУправление;

                TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_P220, Value = Convert.ToInt32(def) });
            }
            P220_27G_2Parameters.getInstance().ParameterChanged -= RefreshFormElements;
        }


    }
}