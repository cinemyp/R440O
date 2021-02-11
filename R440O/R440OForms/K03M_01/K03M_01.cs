//-----------------------------------------------------------------------
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
    using System.Windows.Forms;
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
            K03M_01Parameters.ParameterChanged += RefreshFormElements;
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
                        item.BackgroundImage = (bool)property.GetValue(null)
                            ? ControlElementImages.tumblerType3Up
                            : ControlElementImages.tumblerType3Down;
                    }
                }
            }
            var angle = K03M_01Parameters.ПереключательЗонаПоиска * 30 - 75;
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
                        item.BackgroundImage = (bool)property.GetValue(null)
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
                property.SetValue(null, !(bool)property.GetValue(null));            
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
                K03M_01Parameters.ПереключательЗонаПоиска += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K03M_01Parameters.ПереключательЗонаПоиска -= 1;
            }
        }

        private void КнопкаЛТЧ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(-100);
        }

        private void КнопкаПТЧ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(100);
        }

        private void КнопкаЛТВ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(-10);
        }

        private void КнопкаПТВ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(10);
        }

        private void КнопкаЛГ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(-1);
        }

        private void КнопкаПГ_Click(object sender, System.EventArgs e)
        {
            K03M_01Parameters.ИзменитьВременнуюПозициюПоиска(1);
        }
    }
}