﻿//-----------------------------------------------------------------------
// <copyright file="K03M_01.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Linq;
using R440O.Parameters;
using R440O.ThirdParty;

namespace R440O.R440OForms.K03M_01
{
    using System;
    using System.Windows.Forms;
    using global::R440O.TestModule;
    using K03M_01Inside;

    /// <summary>
    /// Форма блока К03-М-1
    /// </summary>
    public partial class K03M_01Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K03M_01Form"/>
        /// </summary>
        /// 
        public void RefreshFormElements()
        {
            this.InitializeLamps();
            this.InitializeTumblers();
        }

        public K03M_01Form()
        {
            K03M_01Parameters.getInstance().ParameterChanged += RefreshFormElements;
            this.InitializeComponent();
            RefreshFormElements();
        }

        #region Инициализация
        private void InitializeTumblers()
        {            
           foreach (Control item in Panel.Controls)
            {
                var fieldList = typeof(K03M_01Parameters).GetProperties();
                var item1 = item;
                foreach (var property in fieldList.Where(property => item1.Name == property.Name))
                {
                    if (item.Name.Contains("Переключатель") 
                        && !item.Name.Contains("ПереключательНапряжение"))
                    {
                        item.BackgroundImage = (bool)property.GetValue(K03M_01Parameters.getInstance())
                            ? ControlElementImages.tumblerType3Up
                            : ControlElementImages.tumblerType3Down;
                    }
                }
            }
            var angle = K03M_01Parameters.getInstance().ПереключательЗонаПоиска * 30 - 75;
            ПереключательНапряжение.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
        }

        private void InitializeLamps()
        {
            foreach (Control item in Panel.Controls)
            {
                var fieldList = typeof (K03M_01Parameters).GetProperties();
                var item1 = item;
                foreach (var property in fieldList.Where(property => item1.Name == property.Name))
                {
                    if (item.Name.Contains("Лампочка"))
                    {
                        item.BackgroundImage = (bool)property.GetValue(K03M_01Parameters.getInstance())
                            ? ControlElementImages.lampType9OnGreen
                            : null;
                    }
                }
            }
        } 
        #endregion

        #region Крышки
        /// <summary>
        /// Снятие крышки на форме блока
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void Крышка_Click(object sender, System.EventArgs e)
        {
            Крышка.Visible = false;
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void ButtonInside_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Form thisForm = new K03M_01InsideForm();
            thisForm.Show(this);
        } 
        #endregion

        #region Переключатели
        /// <summary>
        /// Для переключателей ввода данных с АПН
        /// </summary>
        private void Переключатель0_Click(object sender, System.EventArgs e)
        {
            var item = sender as Button;
            var fieldList = typeof(K03M_01Parameters).GetProperties();
            foreach (var property in fieldList.Where(property => item != null && item.Name == property.Name))
            {
                property.SetValue(K03M_01Parameters.getInstance(), !(bool)property.GetValue(K03M_01Parameters.getInstance()));            
            }
        } 
        #endregion

        #region Кнопки
        private void Кнопка_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            if (item != null) item.BackgroundImage = null;
        }

        private void Кнопка_MouseUp(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            if (item != null) item.BackgroundImage = ControlElementImages.buttonRoundType5;
        }

        #endregion

        private void ПереключательЗонаПоиска_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                K03M_01Parameters.getInstance().ПереключательЗонаПоиска += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K03M_01Parameters.getInstance().ПереключательЗонаПоиска -= 1;
            }
        }

        private void КнопкаЛТЧ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(-100);
        }

        private void КнопкаПТЧ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(100);
        }

        private void КнопкаЛТВ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(-10);
        }

        private void КнопкаПТВ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(10);
        }

        private void КнопкаЛГ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(-1);
        }

        private void КнопкаПГ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.getInstance().ИзменитьВременнуюПозициюПоиска(1);
        }

        private void K03M_01Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ParametersConfig.IsTesting)
            {
                var blockParams = K03M_01Parameters.getInstance();
                bool def = false;

                switch (TestMain.getIntent())
                {
                    case ShareTypes.ModulesEnum.Check_K03M_01_1:
                        def = blockParams.ПереключательЗонаПоиска == 2;
                        TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_K03M_01_1, Value = Convert.ToInt32(def) });
                        break;
                    case ShareTypes.ModulesEnum.Check_K03M_01_2:
                        def = blockParams.Переключатель0 &&
                        blockParams.Переключатель4 &&
                        !blockParams.Переключатель1 &&
                        !blockParams.Переключатель2 &&
                        !blockParams.Переключатель8 &&
                        !blockParams.Переключатель16 &&
                        !blockParams.Переключатель32 &&
                        blockParams.ПереключательНепрОднокр &&
                        blockParams.ПереключательАвтРучн;
                        TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Check_K03M_01_2, Value = Convert.ToInt32(def) });
                        break;
                    case ShareTypes.ModulesEnum.Kulon_K03M:
                        def =
                        blockParams.ПереключательЗонаПоиска == 2 &&
                        blockParams.Переключатель0 &&
                        blockParams.Переключатель1 &&
                        !blockParams.Переключатель2 &&
                        !blockParams.Переключатель4 &&
                        !blockParams.Переключатель8 &&
                        !blockParams.Переключатель16 &&
                        !blockParams.Переключатель32 &&
                        blockParams.ПереключательНепрОднокр &&
                        blockParams.ПереключательАвтРучн;

                        TestMain.Action(new ShareTypes.JsonAdapter.ActionStation() { Module = ShareTypes.ModulesEnum.Kulon_K03M, Value = Convert.ToInt32(def) });
                        break;
                }
            }
        }
    }
}