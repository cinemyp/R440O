namespace R440O.R440OForms.B2_1
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using BaseClasses;

    /// <summary>
    /// Форма блока Б2-1
    /// </summary>
    public partial class B2_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="B2_1Form"/>.
        /// </summary>
        public B2_1Form()
        {
            this.InitializeComponent();
            B2_1Parameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Кнопки

        private void ТумблерМуДу_Click(object sender, EventArgs e)
        {
            B2_1Parameters.ТумблерМуДу = !B2_1Parameters.ТумблерМуДу;
        }

        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки данного блока
        /// </summary>
        private void КнопкаБК_Click(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var numberOfComplect = Convert.ToInt32(button.Name[8].ToString());
            var numberOfButton = Convert.ToInt32(button.Name[9].ToString());

            if (numberOfComplect == 1) B2_1Parameters.КнопкаБК1 = numberOfButton;
            else B2_1Parameters.КнопкаБК2 = numberOfButton;

        }
        #endregion Кнопки

        #region Колодки
        private void КолодкаТЛГпр_1_Click(object sender,  EventArgs e)
        {
            B2_1Parameters.КолодкаТЛГпр1 = !B2_1Parameters.КолодкаТЛГпр1;                                     
        }                                                     
                                                              
        private void КолодкаТЛГпр_2_Click(object sender,  EventArgs e)
        {
            B2_1Parameters.КолодкаТЛГпр2 = !B2_1Parameters.КолодкаТЛГпр2;                                                 
        }                                                     
                                                              
                                                              
        private void КолодкаТКСпр2_1_Click(object sender, EventArgs e)
        {
            B2_1Parameters.КолодкаТКСпр21 = !B2_1Parameters.КолодкаТКСпр21;
        }                                                     
                                                              
        private void КолодкаТКСпр2_2_Click(object sender, EventArgs e)
        {
            B2_1Parameters.КолодкаТКСпр22 = !B2_1Parameters.КолодкаТКСпр22;
        }
        #endregion

        #region Инициализация
        public void RefreshFormElements()
        {

            this.ТумблерМуДу.BackgroundImage = B2_1Parameters.ТумблерМуДу
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Кнопка"))
                {
                    item.BackgroundImage = ControlElementImages.buttonRectType1;
                    var button = item as Button;
                    var numberOfComplect = Convert.ToInt32(button.Name[8].ToString());
                    var numberOfButton = Convert.ToInt32(button.Name[9].ToString());
                    if (numberOfComplect == 1 && B2_1Parameters.КнопкаБК1 == numberOfButton ||
                        numberOfComplect == 2 && B2_1Parameters.КнопкаБК2 == numberOfButton)
                    {
                        item.BackgroundImage = null;
                    }
                }

                if (!item.Name.Contains("Лампочка")) continue;
                var propertiesList = typeof(B2_1Parameters).GetProperties();
                foreach (var prop in propertiesList.Where(field => item.Name == field.Name))
                {
                    if (item.Name.Contains("ЛампочкаПУЛГ_2") ||
                        item.Name.Contains("ЛампочкаПрРПрС_2") ||
                        item.Name.Contains("ЛампочкаПрТС1_2") ||
                        item.Name.Contains("ЛампочкаПрТС2_2") ||
                        item.Name.Contains("ЛампочкаВУП_1"))
                        item.BackgroundImage = (bool) prop.GetValue(null)
                            ? ControlElementImages.lampType3OnRed
                            : null;
                    else if (item.Name.Contains("ЛампочкаТЛГпр") ||
                             item.Name.Contains("ЛампочкаТКСпр2"))
                        item.BackgroundImage = (bool) prop.GetValue(null)
                            ? ControlElementImages.lampType4OnRed
                            : null;
                    else
                        item.BackgroundImage = (bool) prop.GetValue(null)
                            ? ControlElementImages.lampType2OnRed
                            : null;
                    break;
                }
            }

            КолодкаТЛГпр_1.BackgroundImage = B2_1Parameters.КолодкаТЛГпр1 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр_2.BackgroundImage = B2_1Parameters.КолодкаТЛГпр2 ? ControlElementImages.jumperType1 : null;
            КолодкаТКСпр2_1.BackgroundImage = B2_1Parameters.КолодкаТКСпр21 ? ControlElementImages.jumperType1 : null;
            КолодкаТКСпр2_2.BackgroundImage = B2_1Parameters.КолодкаТКСпр22 ? ControlElementImages.jumperType1 : null;
            
            КолодкаТЛГпр_1.Visible = !B2_1Parameters.КолодкаТЛГпр2;
            КолодкаТЛГпр_2.Visible = !B2_1Parameters.КолодкаТЛГпр1;
            КолодкаТКСпр2_1.Visible = !B2_1Parameters.КолодкаТКСпр22;
            КолодкаТКСпр2_2.Visible = !B2_1Parameters.КолодкаТКСпр21;
        }
        #endregion
    }
}