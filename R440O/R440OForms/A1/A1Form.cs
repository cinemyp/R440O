namespace R440O.R440OForms.A1
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using BaseClasses;
    using global::R440O.TestModule;
    using ShareTypes;
    using ShareTypes.JsonAdapter;

    public partial class A1Form : Form, IRefreshableForm
    {
        public A1Form()
        {
            this.InitializeComponent();
            A1Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Обработка действий пользователя

        /// <summary>
        /// Переключение кнопки скорость В АБ 1ТЛФК
        /// </summary>
        private void КнопкаСкоростьАБ_1ТЛФ_К_Click(object sender, System.EventArgs e)
        {
            A1Parameters.getInstance().КнопкаСкоростьАб_1ТЛФК = !A1Parameters.getInstance().КнопкаСкоростьАб_1ТЛФК;
        }

        /// <summary>
        /// Переключение кнопки скорость В ГР
        /// </summary>
        private void КнопкаСкоростьГР_Click(object sender, System.EventArgs e)
        {
            A1Parameters.getInstance().КнопкаСкоростьГр = !A1Parameters.getInstance().КнопкаСкоростьГр;
        }

        /// <summary>
        /// Переключение тумблера управления питанием блока
        /// </summary>
        private void ТумблерМуДу_Click(object sender, System.EventArgs e)
        {
            A1Parameters.getInstance().ТумблерМуДу = !A1Parameters.getInstance().ТумблерМуДу;
        }

        #endregion

        #region Инициализация

        public void RefreshFormElements()
        {
            this.ТумблерМуДу.BackgroundImage = A1Parameters.getInstance().ТумблерМуДу
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            this.КнопкаСкоростьГР.BackgroundImage = A1Parameters.getInstance().КнопкаСкоростьГр
                ? null
                : ControlElementImages.buttonRectType1;

            this.КнопкаСкоростьАБ_1ТЛФ_К.BackgroundImage = A1Parameters.getInstance().КнопкаСкоростьАб_1ТЛФК
                ? null
                : ControlElementImages.buttonRectType1;

            foreach (Control itemIn in Panel.Controls)
            {
                var item = itemIn;
                if (!item.Name.Contains("Лампочка")) continue;
                var propertiesList = typeof(A1Parameters).GetProperties();
                foreach (var prop in propertiesList.Where(field => item.Name == field.Name))
                {
                    if (item.Name.Contains("ЛампочкаФСПК") ||
                        item.Name.Contains("ЛампочкаПУЛ1_2") ||
                        item.Name.Contains("ЛампочкаПУЛ2_2") ||
                        item.Name.Contains("ЛампочкаПУЛ3_2") ||
                        item.Name.Contains("ЛампочкаПитание"))
                        item.BackgroundImage = (bool)prop.GetValue(A1Parameters.getInstance())
                            ? ControlElementImages.lampType3OnRed
                            : null;
                    else
                        item.BackgroundImage = (bool)prop.GetValue(A1Parameters.getInstance())
                            ? ControlElementImages.lampType2OnRed
                            : null;
                    break;
                }
            }
        }

        #endregion

        private void A1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = A1Parameters.getInstance();
                bool def = !blockParams.ТумблерМуДу;

                TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_A1, Value = Convert.ToInt32(def) });
            }
        }
    }
}