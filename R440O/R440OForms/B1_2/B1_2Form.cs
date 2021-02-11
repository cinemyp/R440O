using System.Linq;

namespace R440O.R440OForms.B1_2
{
    using System.Windows.Forms;
    using BaseClasses;

    /// <summary>
    /// Форма блока Б1-2
    /// </summary>
    public partial class B1_2Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="B1_2Form"/>.
        /// </summary>
        public B1_2Form()
        {
            this.InitializeComponent();
            B1_2Parameters.ParameterChanged += RefreshFormElements;
            this.RefreshFormElements();
        }

        #region Кнопки

        private void КнопкаСкоростьГР_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КнопкаСкоростьГР = !B1_2Parameters.КнопкаСкоростьГР;
        }

        private void КнопкаСкоростьАБ_1ТЛФ_К_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КнопкаСкоростьАб1ТлфК = !B1_2Parameters.КнопкаСкоростьАб1ТлфК;
        }

        #endregion

        #region ТЛГпр
        private void КолодкаТЛГпр1_1_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр11 = !B1_2Parameters.КолодкаТлГпр11;
        }

        private void КолодкаТЛГпр1_2_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр12 = !B1_2Parameters.КолодкаТлГпр11;
        }

        private void КолодкаТЛГпр2_1_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр21 = !B1_2Parameters.КолодкаТлГпр21;
        }
        private void КолодкаТЛГпр2_2_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр22 = !B1_2Parameters.КолодкаТлГпр21;
        }
        private void КолодкаТЛГпр3_1_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр31 = !B1_2Parameters.КолодкаТлГпр31;
        }

        private void КолодкаТЛГпр3_2_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.КолодкаТлГпр32 = !B1_2Parameters.КолодкаТлГпр32;
        }
        #endregion

        /// <summary>
        /// Переключение тумблера управления питанием блока
        /// </summary>
        private void ТумблерМуДу_Click(object sender, System.EventArgs e)
        {
            B1_2Parameters.ТумблерМуДу = !B1_2Parameters.ТумблерМуДу;
        }

        public void RefreshFormElements()
        {
            foreach (Control itemIn in Panel.Controls)
            {
                var item = itemIn;
                if (!item.Name.Contains("Лампочка")) continue;
                var propertiesList = typeof(B1_2Parameters).GetProperties();
                foreach (var prop in propertiesList.Where(field => item.Name == field.Name))
                {
                    if (item.Name.Contains("ЛампочкаПУЛ_2") ||
                        item.Name.Contains("ЛампочкаТКБтк1_2") ||
                        item.Name.Contains("ЛампочкаТКБтк2_2") ||
                        item.Name.Contains("ЛампочкаТКБтк3_2") ||
                        item.Name.Contains("ЛампочкаВУП_1"))
                        item.BackgroundImage = (bool)prop.GetValue(null)
                            ? ControlElementImages.lampType3OnRed
                            : null;
                    else if (item.Name.Contains("ЛампочкаТЛГпр"))
                        item.BackgroundImage = (bool)prop.GetValue(null)
                            ? ControlElementImages.lampType4OnRed
                            : null;
                    else
                        item.BackgroundImage = (bool)prop.GetValue(null)
                            ? ControlElementImages.lampType2OnRed
                            : null;
                    break;
                }
            }

            this.ТумблерМуДу.BackgroundImage = B1_2Parameters.ТумблерМуДу
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            this.КнопкаСкоростьГР.BackgroundImage = B1_2Parameters.КнопкаСкоростьГР
                ? null
                : ControlElementImages.buttonRectType1;

            this.КнопкаСкоростьАБ_1ТЛФ_К.BackgroundImage = B1_2Parameters.КнопкаСкоростьАб1ТлфК
                ? null
                : ControlElementImages.buttonRectType1;

            КолодкаТЛГпр1_1.BackgroundImage = B1_2Parameters.КолодкаТлГпр11 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр1_2.BackgroundImage = B1_2Parameters.КолодкаТлГпр12 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр2_1.BackgroundImage = B1_2Parameters.КолодкаТлГпр21 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр2_2.BackgroundImage = B1_2Parameters.КолодкаТлГпр22 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр3_1.BackgroundImage = B1_2Parameters.КолодкаТлГпр31 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр3_2.BackgroundImage = B1_2Parameters.КолодкаТлГпр32 ? ControlElementImages.jumperType1 : null;

            КолодкаТЛГпр1_1.Visible = !B1_2Parameters.КолодкаТлГпр11;
            КолодкаТЛГпр1_2.Visible = !B1_2Parameters.КолодкаТлГпр12;
            КолодкаТЛГпр2_1.Visible = !B1_2Parameters.КолодкаТлГпр21;
            КолодкаТЛГпр2_2.Visible = !B1_2Parameters.КолодкаТлГпр22;
            КолодкаТЛГпр3_1.Visible = !B1_2Parameters.КолодкаТлГпр31;
            КолодкаТЛГпр3_2.Visible = !B1_2Parameters.КолодкаТлГпр32;
        }
    }
}