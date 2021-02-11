namespace R440O.R440OForms.P220_27G_2
{
    using System.Windows.Forms;
    using BaseClasses;

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
            P220_27G_2Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            P220_27G_2Parameters.ТумблерСеть = !P220_27G_2Parameters.ТумблерСеть;
        }

        private void ТумблерУправление_Click(object sender, System.EventArgs e)
        {
            P220_27G_2Parameters.ТумблерУправление = !P220_27G_2Parameters.ТумблерУправление;
        }

        public void RefreshFormElements()
        {
            ЛампочкаСеть.BackgroundImage = P220_27G_2Parameters.ЛампочкаСеть
                ? ControlElementImages.lampType9OnGreen
                : null;

            Лампочка27В.BackgroundImage = P220_27G_2Parameters.Лампочка27В
                ? ControlElementImages.lampType3OnRed
                : null;

            ТумблерУправление.BackgroundImage = P220_27G_2Parameters.ТумблерУправление
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            ТумблерСеть.BackgroundImage = P220_27G_2Parameters.ТумблерСеть
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;
        }

        private void P220_27G_2Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            P220_27G_2Parameters.ParameterChanged -= RefreshFormElements;
        }


    }
}