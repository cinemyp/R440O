﻿namespace R440O.R440OForms.B3_1
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using BaseClasses;
    using global::R440O.TestModule;

    /// <summary>
    /// Форма блока Б3-1
    /// </summary>
    public partial class B3_1Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="B3_1Form"/>
        /// </summary>
        public B3_1Form()
        {
            InitializeComponent();
            B3_1Parameters.getInstance().ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Колодки УКК
        private void КолодкаУКК_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var numberOfButton = (int)Char.GetNumericValue(button.Name[12]);
            var numberOfComplect = button.Name[10];

            var property = typeof(B3_1Parameters).GetProperty("КолодкаУКК" + numberOfComplect);
            var value = (int)property.GetValue(B3_1Parameters.getInstance());
            property.SetValue(B3_1Parameters.getInstance(), numberOfButton == value ? 0 : numberOfButton);
        }
        #endregion 

        #region Колодки КРПР
        private void КолодкаКРПР_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            var numberOfButton = (int)Char.GetNumericValue(button.Name[11]);

            var property = typeof(B3_1Parameters).GetProperty("КолодкаКРПР");
            var value = (int)property.GetValue(B3_1Parameters.getInstance());
            property.SetValue(B3_1Parameters.getInstance(), numberOfButton == value ? 0 : numberOfButton);
        }
        #endregion

        #region ОКпр Колодки
        private void КолодкаОКпр1_син_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаОКпр1Син = !B3_1Parameters.getInstance().КолодкаОКпр1Син;
        }

        private void КолодкаОКпр1_ас_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаОКпр1Ас = !B3_1Parameters.getInstance().КолодкаОКпр1Ас;
        }

        private void КолодкаОКпр2_син_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаОКпр2Син = !B3_1Parameters.getInstance().КолодкаОКпр2Син;
        }

        private void КолодкаОКпр2_ас_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаОКпр2Ас = !B3_1Parameters.getInstance().КолодкаОКпр2Ас;
        }
        #endregion

        #region ТЛГпр Колодки
        private void КолодкаТЛГпр1_1_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр11 = !B3_1Parameters.getInstance().КолодкаТлГпр11;
        }

        private void КолодкаТЛГпр1_2_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр12 = !B3_1Parameters.getInstance().КолодкаТлГпр12;
        }
        
        private void КолодкаТЛГпр2_1_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр21 = !B3_1Parameters.getInstance().КолодкаТлГпр21;
        }
        private void КолодкаТЛГпр2_2_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр22 = !B3_1Parameters.getInstance().КолодкаТлГпр22;
        }

        private void КолодкаТЛГпр3_1_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр31 = !B3_1Parameters.getInstance().КолодкаТлГпр31;
        }

        private void КолодкаТЛГпр3_2_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().КолодкаТлГпр32 = !B3_1Parameters.getInstance().КолодкаТлГпр32;
        }
        #endregion

        private void ТумблерМуДу_Click(object sender, System.EventArgs e)
        {
            B3_1Parameters.getInstance().ТумблерМуДу = !B3_1Parameters.getInstance().ТумблерМуДу;
        }

        public void RefreshFormElements()
        {
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("КолодкаУКК1"))
                    item.BackgroundImage = (item.Name.Contains("КолодкаУКК1_" + B3_1Parameters.getInstance().КолодкаУКК1))
                    ? ControlElementImages.jumperType2
                    : null;

                if (item.Name.Contains("КолодкаУКК2"))
                    item.BackgroundImage = (item.Name.Contains("КолодкаУКК2_" + B3_1Parameters.getInstance().КолодкаУКК2))
                    ? ControlElementImages.jumperType2
                    : null;

                if (item.Name.Contains("КолодкаКРПР"))
                    item.BackgroundImage = (item.Name.Contains("КолодкаКРПР_" + B3_1Parameters.getInstance().КолодкаКРПР))
                    ? ControlElementImages.jumperType2
                    : null;

                if (!item.Name.Contains("Лампочка")) continue;
                var propertiesList = typeof(B3_1Parameters).GetProperties();
                foreach (var prop in propertiesList.Where(field => item.Name == field.Name))
                {
                    if (item.Name.Contains("ЛампочкаПУЛГ_2") ||
                        item.Name.Contains("ЛампочкаРС_синхр") ||
                        item.Name.Contains("ЛампочкаПФТК1_2") ||
                        item.Name.Contains("ЛампочкаПФТК2_2") ||
                        item.Name.Contains("ЛампочкаВУП1"))
                        item.BackgroundImage = (bool)prop.GetValue(B3_1Parameters.getInstance())
                            ? ControlElementImages.lampType3OnRed
                            : null;
                    else if (item.Name.Contains("ЛампочкаТЛГпр"))
                        item.BackgroundImage = (bool)prop.GetValue(B3_1Parameters.getInstance())
                            ? ControlElementImages.lampType4OnRed
                            : null;
                    else
                        item.BackgroundImage = (bool)prop.GetValue(B3_1Parameters.getInstance())
                            ? ControlElementImages.lampType2OnRed
                            : null;
                    break;
                }
            }

            КолодкаОКпр1Син.BackgroundImage = B3_1Parameters.getInstance().КолодкаОКпр1Син ? ControlElementImages.jumperType2 : null;
            КолодкаОКпр2Син.BackgroundImage = B3_1Parameters.getInstance().КолодкаОКпр2Син ? ControlElementImages.jumperType2 : null;
            КолодкаОКпр1Ас.BackgroundImage = B3_1Parameters.getInstance().КолодкаОКпр1Ас ? ControlElementImages.jumperType2 : null;
            КолодкаОКпр2Ас.BackgroundImage = B3_1Parameters.getInstance().КолодкаОКпр2Ас ? ControlElementImages.jumperType2 : null;

            КолодкаТЛГпр11.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр11 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр12.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр12 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр21.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр21 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр22.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр22 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр31.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр31 ? ControlElementImages.jumperType1 : null;
            КолодкаТЛГпр32.BackgroundImage = B3_1Parameters.getInstance().КолодкаТлГпр32 ? ControlElementImages.jumperType1 : null;

            КолодкаТЛГпр11.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр12;
            КолодкаТЛГпр12.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр11;
            КолодкаТЛГпр21.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр22;
            КолодкаТЛГпр22.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр21;
            КолодкаТЛГпр31.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр32;
            КолодкаТЛГпр32.Visible = !B3_1Parameters.getInstance().КолодкаТлГпр31;

            this.ТумблерМуДу.BackgroundImage = B3_1Parameters.getInstance().ТумблерМуДу
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;
        }

        private void B3_1Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = B3_1Parameters.getInstance();
                bool def = !blockParams.ТумблерМуДу;

                TestMain.Action(new JsonAdapter.ActionStation() { Name = "Б3_1", Value = Convert.ToInt32(def) });
            }
        }
    }
}