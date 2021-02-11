namespace R440O.R440OForms.A304
{
    using System.Windows.Forms;
    using BaseClasses;
    using ThirdParty;

    /// <summary>
    /// Форма блока A304
    /// </summary>
    public partial class  A304Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="A304Form"/>.
        /// </summary>
        public A304Form()
        {
            this.InitializeComponent();
            A304Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Инициализация состояний элементов управления

        public void RefreshFormElements()
        {
            //Инициализация тумблеров
            this.ТумблерУправление1.BackgroundImage = A304Parameters.ТумблерУправление1
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;
            this.ТумблерУправление2.BackgroundImage = A304Parameters.ТумблерУправление2
                ? ControlElementImages.tumblerType6Up
                : ControlElementImages.tumblerType6Down;
            this.ТумблерКомплект.BackgroundImage = A304Parameters.ТумблерКомплект
                ? ControlElementImages.tumblerType1Left
                : ControlElementImages.tumblerType1Right;

            // Инициализация лампочек
            Лампочка1К.BackgroundImage = A304Parameters.Лампочка1К
                ? ControlElementImages.lampType10OnGreen
                : null;

            Лампочка2К.BackgroundImage = A304Parameters.Лампочка2К
                ? ControlElementImages.lampType10OnGreen
                : null;

            var angle = A304Parameters.ПереключательВыборСтвола * 26 - 146;
            ПереключательВыборСтвола.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);

            angle = A304Parameters.ПереключательКонтроль * 30 - 120;
            ПереключательКонтроль.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType3, angle);

            angle = A304Parameters.ИндикаторНапряжение;
            ИндикаторНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
        }

        #endregion

        #region Тумблеры управления типом подачи питания

        /// <summary>
        /// Перключение типа подачи питания для первого комплекта оборудования
        /// </summary>
        private void ТумблерУправление1_Click(object sender, System.EventArgs e)
        {
            A304Parameters.ТумблерУправление1 = !A304Parameters.ТумблерУправление1;
        }

        /// <summary>
        /// Перключение типа подачи питания для второго комплекта оборудования
        /// </summary>
        private void ТумблерУправление2_Click(object sender, System.EventArgs e)
        {
            A304Parameters.ТумблерУправление2 = !A304Parameters.ТумблерУправление2;
        }

        /// <summary>
        /// Перключение между комплектами оборудования
        /// </summary>
        private void ТумблерКомплект_Click(object sender, System.EventArgs e)
        {
            A304Parameters.ТумблерКомплект = !A304Parameters.ТумблерКомплект;
        }

        #endregion

        #region Кнопки включения питания
        //// Включение местного питания 1 комплекта
        private void Кнопка1КВкл_MouseDown(object sender, MouseEventArgs e)
        {
            this.Кнопка1КВкл.BackgroundImage = null;
            this.Кнопка1КВкл.Text = string.Empty;
            A304Parameters.Кнопка1К = true;
        }

        private void Кнопка1КВкл_MouseUp(object sender, MouseEventArgs e)
        {
            this.Кнопка1КВкл.BackgroundImage = ControlElementImages.buttonSquareGrey;
            this.Кнопка1КВкл.Text = "ВКЛ";
        }

        //// Включение местного питания 2 комплекта
        private void Кнопка2КВкл_MouseDown(object sender, MouseEventArgs e)
        {
            this.Кнопка2КВкл.BackgroundImage = null;
            this.Кнопка2КВкл.Text = string.Empty;
            A304Parameters.Кнопка2К = true;
        }

        private void Кнопка2КВкл_MouseUp(object sender, MouseEventArgs e)
        {
            this.Кнопка2КВкл.BackgroundImage = ControlElementImages.buttonSquareGrey;
            this.Кнопка2КВкл.Text = "ВКЛ";
        }

        //// Выключение местного питания 1 комплекта
        private void Кнопка1КОткл_MouseDown(object sender, MouseEventArgs e)
        {
            this.Кнопка1КОткл.BackgroundImage = null;
            this.Кнопка1КОткл.Text = string.Empty;
            A304Parameters.Кнопка1К = false;
        }

        private void Кнопка1КОткл_MouseUp(object sender, MouseEventArgs e)
        {
            this.Кнопка1КОткл.BackgroundImage = ControlElementImages.buttonSquareGrey;
            this.Кнопка1КОткл.Text = "ОТКЛ";
        }

        //// Выключение местного питания 2 комплекта
        private void Кнопка2КОткл_MouseDown(object sender, MouseEventArgs e)
        {
            this.Кнопка2КОткл.BackgroundImage = null;
            this.Кнопка2КОткл.Text = string.Empty;
            A304Parameters.Кнопка2К = false;
        }

        private void Кнопка2КОткл_MouseUp(object sender, MouseEventArgs e)
        {
            this.Кнопка2КОткл.BackgroundImage = ControlElementImages.buttonSquareGrey;
            this.Кнопка2КОткл.Text = "ОТКЛ";
        }
        #endregion

        #region Изменение положения переключателей выбора ствола и контроля

        /// <summary>
        /// Выбор ствола
        /// </summary>
        private void ПереключательВыборСтвола_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A304Parameters.ПереключательВыборСтвола += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A304Parameters.ПереключательВыборСтвола -= 1;
            }
        }

        /// <summary>
        /// Выбор питающего напряжения для контроля
        /// </summary>
        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                A304Parameters.ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                A304Parameters.ПереключательКонтроль -= 1;
            }
        }
        #endregion

        private void A304Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            A304Parameters.ParameterChanged -= RefreshFormElements;
        }


    }
}