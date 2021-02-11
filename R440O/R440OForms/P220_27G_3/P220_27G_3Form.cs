namespace R440O.R440OForms.P220_27G_3
{
    using System.Windows.Forms;
    using BaseClasses;

    /// <summary>
    /// Форма блока П220-27Г-2
    /// </summary>
    public partial class P220_27G_3Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="P220_27G_3Form"/>
        /// </summary>
        public P220_27G_3Form()
        {
            InitializeComponent();
            P220_27G_3Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            P220_27G_3Parameters.ТумблерСеть = !P220_27G_3Parameters.ТумблерСеть;
        }

        private void ТумблерУправление_Click(object sender, System.EventArgs e)
        {
            P220_27G_3Parameters.ТумблерУправление = !P220_27G_3Parameters.ТумблерУправление;
        }

        public void RefreshFormElements()
        {
            ЛампочкаСеть.BackgroundImage = P220_27G_3Parameters.ЛампочкаСеть
                ? ControlElementImages.lampType9OnGreen
                : null;

            Лампочка27В.BackgroundImage = P220_27G_3Parameters.Лампочка27В
                ? ControlElementImages.lampType3OnRed
                : null;

            ТумблерУправление.BackgroundImage = P220_27G_3Parameters.ТумблерУправление
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            ТумблерСеть.BackgroundImage = P220_27G_3Parameters.ТумблерСеть
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;
        }

        private void P220_27G_3Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            P220_27G_3Parameters.ParameterChanged -= RefreshFormElements;
        }


    }
}