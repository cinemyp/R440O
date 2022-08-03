namespace R440O.R440OForms.B2_1
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using BaseClasses;
    using global::R440O.TestModule;

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
            B2_1Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Кнопки

        private void ТумблерМуДу_Click(object sender, EventArgs e)
        {
            B2_1Parameters.getInstance().ТумблерМуДу = !B2_1Parameters.getInstance().ТумблерМуДу;
        }

        /// <summary>
        /// Универсальный метод обработки нажатий на кнопки данного блока
        /// </summary>
        private void КнопкаБК_Click(object sender, System.EventArgs e)
        {
            var button = sender as Button;
            var numberOfComplect = Convert.ToInt32(button.Name[8].ToString());
            var numberOfButton = Convert.ToInt32(button.Name[9].ToString());

            if (numberOfComplect == 1) B2_1Parameters.getInstance().КнопкаБК1 = numberOfButton;
            else B2_1Parameters.getInstance().КнопкаБК2 = numberOfButton;

        }
        #endregion Кнопки

        #region Колодки
        private void КолодкаТЛГпр_1_Click(object sender,  EventArgs e)
        {
            B2_1Parameters.getInstance().КолодкаТЛГпр1 = !B2_1Parameters.getInstance().КолодкаТЛГпр1;                                     
        }                                                     
                                                              
        private void КолодкаТЛГпр_2_Click(object sender,  EventArgs e)
        {
            B2_1Parameters.getInstance().КолодкаТЛГпр2 = !B2_1Parameters.getInstance().КолодкаТЛГпр2;                                                 
        }                                                     
                                                              
                                                              
        private void КолодкаТКСпр2_1_Click(object sender, EventArgs e)
        {
            B2_1Parameters.getInstance().КолодкаТКСпр21 = !B2_1Parameters.getInstance().КолодкаТКСпр21;
        }                                                     
                                                              
        private void КолодкаТКСпр2_2_Click(object sender, EventArgs e)
        {
            B2_1Parameters.getInstance().КолодкаТКСпр22 = !B2_1Parameters.getInstance().КолодкаТКСпр22;
        }
        #endregion

        #region Инициализация
        public void RefreshFormElements()
        {

            this.ТумблерМуДу.BackgroundImage = B2_1Parameters.getInstance().ТумблерМуДу
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
                    if (numberOfComplect == 1 && B2_1Parameters.getInstance().КнопкаБК1 == numberOfButton ||
                        numberOfComplect == 2 && B2_1Parameters.getInstance().КнопкаБК2 == numberOfButton)
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
                        item.BackgroundImage = (bool) prop.GetValue(B2_1Parameters.getInstance())
                            ? ControlElementImages.lampType3OnRed
                            : null;
                    else if (item.Name.Contains("ЛампочкаТЛГпр") ||
                             item.Name.Contains("ЛампочкаТКСпр2"))
                        item.BackgroundImage = (bool) prop.GetValue(B2_1Parameters.getInstance())
                            ? ControlElementImages.lampType4OnRed
                            : null;
                    else
                        item.BackgroundImage = (bool) prop.GetValue(B2_1Parameters.getInstance())
                            ? ControlElementImages.lampType2OnRed
                            : null;
                    break;
                }
            }

            КолодкаТЛГпр_1.BackgroundImage = B2_1Parameters.getInstance().КолодкаТЛГпр1 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр_2.BackgroundImage = B2_1Parameters.getInstance().КолодкаТЛГпр2 ? ControlElementImages.jumperType1 : null;
            КолодкаТКСпр2_1.BackgroundImage = B2_1Parameters.getInstance().КолодкаТКСпр21 ? ControlElementImages.jumperType1 : null;
            КолодкаТКСпр2_2.BackgroundImage = B2_1Parameters.getInstance().КолодкаТКСпр22 ? ControlElementImages.jumperType1 : null;
            
            КолодкаТЛГпр_1.Visible = !B2_1Parameters.getInstance().КолодкаТЛГпр2;
            КолодкаТЛГпр_2.Visible = !B2_1Parameters.getInstance().КолодкаТЛГпр1;
            КолодкаТКСпр2_1.Visible = !B2_1Parameters.getInstance().КолодкаТКСпр22;
            КолодкаТКСпр2_2.Visible = !B2_1Parameters.getInstance().КолодкаТКСпр21;
        }
        #endregion

        private void B2_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = B2_1Parameters.getInstance();
                bool def = !blockParams.ТумблерМуДу;

                TestMain.Action(new JsonAdapter.ActionStation() { Module = LearnModule.ModulesEnum.Check_B2_1, Value = Convert.ToInt32(def) });
            }
        }
    }
}