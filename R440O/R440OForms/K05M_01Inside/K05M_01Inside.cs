//-----------------------------------------------------------------------
// <copyright file="K05M_01Inside.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using R440O.Parameters;
using R440O.R440OForms.K05M_01;
using R440O.ThirdParty;

namespace R440O.R440OForms.K05M_01Inside
{
    using System.Windows.Forms;

    /// <summary>
    /// Внутренняя часть блока К05-М-1
    /// </summary>
    public partial class K05M_01InsideForm : Form
    {
        public void RefreshFormElements()
        {
            this.InitializeTumblers();
        }
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K05M_01InsideForm"/>
        /// </summary>
        public K05M_01InsideForm()
        {
            K05M_01InsideParameters.ParameterChanged += RefreshFormElements;
            this.InitializeComponent();
            this.InitializeTumblers();
        }

        /// <summary>
        /// Закрытие формы внутренней части блока
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void K05M_01InsideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void InitializeTumblers()
        {
            foreach (Control item in   Panel.Controls)
            {
                if (item.Name.Contains("Переключатель"))
                {
                    var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Переключатель") +
                                                                    "Переключатель".Length));
                    var angle = K05M_01InsideParameters.Переключатель[index] * 30 - 10;
                    item.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                        ControlElementImages.toggleType2, angle);
                }
                if (item.Name.Contains("Тумблер"))
                {
                    try
                    {
                        var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Тумблер") +
                                                                        "Тумблер".Length));
                        item.BackgroundImage = (K05M_01InsideParameters.Переключатель[index] == 0)
                            ? ControlElementImages.tumblerType3Left
                            : ControlElementImages.tumblerType3Right;
                    }
                    catch (System.FormatException)
                    {
                    }
                }
            }
            ТумблерВ4.BackgroundImage = K05M_01InsideParameters.ТумблерВ4
                            ? ControlElementImages.tumblerType7Right
                            : ControlElementImages.tumblerType7Left;
            ТумблерВ7.BackgroundImage = K05M_01InsideParameters.ТумблерВ7
                            ? ControlElementImages.tumblerType7Down
                            : ControlElementImages.tumblerType7Up;
        }

        private void Переключатель_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Переключатель") +
                                                            "Переключатель".Length));
            var property = typeof(K05M_01Parameters).GetProperty(item.Name);
            if (e.Button == MouseButtons.Left)
            {
                K05M_01InsideParameters.Переключатель[index] += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K05M_01InsideParameters.Переключатель[index] -= 1;
            }
        }

        private void Тумблер_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("Тумблер") +
                                                            "Тумблер".Length));
            if (e.Button == MouseButtons.Left)
            {
                if (K05M_01InsideParameters.Переключатель[index] == 0)
                    K05M_01InsideParameters.Переключатель[index] = 1;
                else K05M_01InsideParameters.Переключатель[index] = 0;
            }
        }

        private void ТумблерВ4_Click(object sender, EventArgs e)
        {
            K05M_01InsideParameters.ТумблерВ4 = !K05M_01InsideParameters.ТумблерВ4;
        }

        private void ТумблерВ7_Click(object sender, EventArgs e)
        {
            K05M_01InsideParameters.ТумблерВ7 = !K05M_01InsideParameters.ТумблерВ7;
        }
    }
}