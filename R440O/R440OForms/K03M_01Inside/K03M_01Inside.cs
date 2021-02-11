//-----------------------------------------------------------------------
// <copyright file="K03M_01Inside.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Windows.Forms;
using R440O.ThirdParty;

namespace R440O.R440OForms.K03M_01Inside
{
    /// <summary>
    /// Форма внутренней части блока К03-М-1
    /// </summary>
    public partial class K03M_01InsideForm : Form
    {

        public void RefreshFormElements()
        {
            this.InitializeTumblers();
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K03M_01InsideForm"/>
        /// </summary>
        public K03M_01InsideForm()
        {
            K03M_01InsideParameters.ParameterChanged += RefreshFormElements;
            this.InitializeComponent();
            this.InitializeTumblers();
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void InitializeTumblers()
        {
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Переключатель"))
                {
                    var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Переключатель", StringComparison.Ordinal) +
                                                                    "Переключатель".Length));
                    var angle = K03M_01InsideParameters.Переключатели[index]*30 - 10;
                        item.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                            ControlElementImages.toggleType2, angle);
                }
                if (item.Name.Contains("Тумблер"))
                {
                    try
                    {
                        var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Тумблер", StringComparison.Ordinal) +
                                                                        "Тумблер".Length));
                        item.BackgroundImage = (K03M_01InsideParameters.Переключатели[index] == 0)
                        ? ControlElementImages.tumblerType3Left
                        : ControlElementImages.tumblerType3Right;
                    }
                    catch (FormatException)
                    {
                    }
                }
            }
            ТумблерИП.BackgroundImage = K03M_01InsideParameters.ТумблерИП
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
            ТумблерВклОткл.BackgroundImage = K03M_01InsideParameters.ТумблерВклОткл
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        }

        private void Переключатель_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            if (item != null)
            {
                var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Переключатель", StringComparison.Ordinal) +
                                                                "Переключатель".Length));
                if (e.Button == MouseButtons.Left)
                {
                    K03M_01InsideParameters.Переключатели[index] += 1;
                }

                if (e.Button == MouseButtons.Right)
                {
                    K03M_01InsideParameters.Переключатели[index] -= 1;
                }
            }
        }

        private void Тумблер_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            if (item != null)
            {
                var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Тумблер", StringComparison.Ordinal) +
                                                                "Тумблер".Length));
                if (e.Button == MouseButtons.Left)
                {
                    if (K03M_01InsideParameters.Переключатели[index] == 0)
                        K03M_01InsideParameters.Переключатели[index] = 1;
                    else K03M_01InsideParameters.Переключатели[index] = 0;
                }
            }
        }

        private void ТумблерИП_Click(object sender, EventArgs e)
        {
            K03M_01InsideParameters.ТумблерИП = !K03M_01InsideParameters.ТумблерИП;
        }

        private void ТумблерВклОткл_Click(object sender, EventArgs e)
        {
            K03M_01InsideParameters.ТумблерВклОткл = !K03M_01InsideParameters.ТумблерВклОткл;
        }
    }
}