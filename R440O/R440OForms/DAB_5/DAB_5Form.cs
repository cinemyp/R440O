using System;
using System.Reflection;
using ShareTypes.SignalTypes;
using R440O.BaseClasses;

namespace R440O.R440OForms.DAB_5
{
    using System.Windows.Forms;
    using global::R440O.TestModule;
    using Parameters;
    using СостоянияЭлементов.ДАБ5;
    /// <summary>
    /// Форма блока ДАБ-5
    /// </summary>
    public partial class DAB_5Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DAB_5Form"/>
        /// </summary>
        public DAB_5Form()
        {
            InitializeComponent();
            DAB_5Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        public void RefreshFormElements()
        {
            foreach (Control controlElement in Panel.Controls)
            {
                if (controlElement.Name.Contains("Лампочка"))
                {
                    PropertyInfo[] propertyList = typeof(DAB_5Parameters).GetProperties();
                    foreach (PropertyInfo property in propertyList)
                    {
                        if (controlElement.Name == property.Name)
                        {
                            controlElement.BackgroundImage = Convert.ToBoolean(property.GetValue(DAB_5Parameters.getInstance()))
                            ? ControlElementImages.lampType5OnRed
                            : null;
                        }
                    }
                }
            }
            ЛампочкаПитание.BackgroundImage = DAB_5Parameters.getInstance().ЛампочкаПитание
                ? ControlElementImages.lampType10OnGreen
                : null;
            ТумблерПитание.BackgroundImage = DAB_5Parameters.getInstance().ТумблерПитание
               ? ControlElementImages.tumblerType4Up
               : ControlElementImages.tumblerType4Down;

            ТумблерПитание.BackgroundImage = DAB_5Parameters.getInstance().ТумблерПитание
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            КнопкаОбходВкл.BackgroundImage = DAB_5Parameters.getInstance().КнопкаОбходВкл ? ControlElementImages.buttonRoundType3 : null;
            КнопкаОбходВыкл.BackgroundImage = DAB_5Parameters.getInstance().КнопкаОбходВыкл ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимРучн.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимРучн ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимАвтом.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимАвтом ? ControlElementImages.buttonRoundType3 : null;
            КнопкаВыборПрмПрд1.BackgroundImage = DAB_5Parameters.getInstance().КнопкаВыборПрмПрд1 ? ControlElementImages.buttonRoundType3 : null;
            КнопкаВыборПрмПрд2.BackgroundImage = DAB_5Parameters.getInstance().КнопкаВыборПрмПрд2 ? ControlElementImages.buttonRoundType3 : null;
            КнопкаВыборБП1.BackgroundImage = DAB_5Parameters.getInstance().КнопкаВыборБП1 ? ControlElementImages.buttonRoundType3 : null;
            КнопкаВыборБП2.BackgroundImage = DAB_5Parameters.getInstance().КнопкаВыборБП2 ? ControlElementImages.buttonRoundType3 : null;

            КнопкаРежимВыкл1К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимВыкл1К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимРабота1К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимРабота1К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимШлейф1К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимШлейф1К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимПрмПрд1К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд1К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимПрм1К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм1К ? ControlElementImages.buttonRoundType3 : null;

            КнопкаРежимВыкл2К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимВыкл2К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимРабота2К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимРабота2К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимШлейф2К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимШлейф2К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимПрмПрд2К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд2К ? ControlElementImages.buttonRoundType3 : null;
            КнопкаРежимПрм2К.BackgroundImage = DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм2К ? ControlElementImages.buttonRoundType3 : null;

            ЛампочкаОбход.BackgroundImage = DAB_5Parameters.getInstance().ЛампочкаОбход ? ControlElementImages.lampType10OnGreen : null;
        }


        private void ТумблерПитание_MouseClick(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().ТумблерПитание = !DAB_5Parameters.getInstance().ТумблерПитание;
        }

        #region Кнопки РЕЖИМЫ
        private void КнопкаРежимРучн_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРучн = true;
        }

        private void КнопкаРежимРучн_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРучн = false;
        }

        private void КнопкаРежимАвтом_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимАвтом = true;
        }

        private void КнопкаРежимАвтом_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимАвтом = false;
        }
        #endregion

        #region Кнопки ВЫБОР КОМПЛЕКТА
        private void КнопкаВыборПрмПрд1_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборПрмПрд1 = true;
        }

        private void КнопкаВыборПрмПрд1_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборПрмПрд1 = false;
        }

        private void КнопкаВыборПрмПрд2_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборПрмПрд2 = true;
        }

        private void КнопкаВыборПрмПрд2_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборПрмПрд2 = false;
        }

        private void КнопкаВыборБП1_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборБП1 = true;
        }

        private void КнопкаВыборБП1_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборБП1 = false;
        }

        private void КнопкаВыборБП2_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборБП2 = true;
        }

        private void КнопкаВыборБП2_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаВыборБП2 = false;
        }
        #endregion

        #region Кнопки РЕЖИМ РАБОТЫ 1K
        private void КнопкаРежимВыкл1К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимВыкл1К = true;
        }

        private void КнопкаРежимВыкл1К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимВыкл1К = false;
        }

        private void КнопкаРежимРабота1К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРабота1К = true;
        }

        private void КнопкаРежимРабота1К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРабота1К = false;
        }

        private void КнопкаРежимШлейф1К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимШлейф1К = true;
        }

        private void КнопкаРежимШлейф1К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимШлейф1К = false;
        }

        private void КнопкаРежимПрмПрд1К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд1К = true;
        }

        private void КнопкаРежимПрмПрд1К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд1К = false;
        }

        private void КнопкаРежимПрм1К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм1К = true;
        }

        private void КнопкаРежимПрм1К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм1К = false;
        }
        #endregion

        #region Кнопки РЕЖИМ РАБОТЫ 2К
        private void КнопкаРежимВыкл2К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимВыкл2К = true;
        }

        private void КнопкаРежимВыкл2К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимВыкл2К = false;
        }

        private void КнопкаРежимРабота2К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРабота2К = true;
        }

        private void КнопкаРежимРабота2К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимРабота2К = false;
        }

        private void КнопкаРежимШлейф2К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимШлейф2К = true;
        }

        private void КнопкаРежимШлейф2К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимШлейф2К = false;
        }

        private void КнопкаРежимПрмПрд2К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд2К = true;
        }

        private void КнопкаРежимПрмПрд2К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрмПрд2К = false;
        }

        private void КнопкаРежимПрм2К_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм2К = true;
        }

        private void КнопкаРежимПрм2К_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаРежимПроверкаПрм2К = false;
        }

        #endregion

        private void КнопкаОбходВкл_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаОбходВкл = true;
        }

        private void КнопкаОбходВкл_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаОбходВкл = false;
        }

        private void КнопкаОбходВыкл_MouseDown(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаОбходВыкл = true;
        }

        private void КнопкаОбходВыкл_MouseUp(object sender, MouseEventArgs e)
        {
            DAB_5Parameters.getInstance().КнопкаОбходВыкл = false;
        }

        private void DAB_5Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = DAB_5Parameters.getInstance();
                bool def = blockParams.ТумблерПитание;

                TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_DAB5, Value = Convert.ToInt32(def) });
            }
        }
    }
}