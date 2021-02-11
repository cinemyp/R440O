//-----------------------------------------------------------------------
// <copyright file="K03M_02Inside.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Runtime.CompilerServices;
using R440O.Parameters;
using R440O.R440OForms.K05M_01;
using R440O.ThirdParty;

namespace R440O.R440OForms.K03M_02Inside
{
    using System.Windows.Forms;

    /// <summary>
    /// Форма внутренней части блока К03-М-1
    /// </summary>
    public partial class K03M_02InsideForm : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K03M_02InsideForm"/>
        /// </summary>
        public K03M_02InsideForm()
        {
            this.InitializeComponent();
            this.InitializeTumblers();
        }

        /// <summary>
        /// Закрытие формы
        /// </summary>
        /// <param name="sender">Объет вызвавший событие</param>
        /// <param name="e">Событие закрытия формы</param>
        private void K03M_02InsideForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Show();
        }

        private void InitializeTumblers()
        {
            foreach (Control item in K03M_02InsidePanel.Controls)
            {
                if (item.Name.Contains("K03M_02InsideПереключатель"))
                {
                    var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("K03M_02InsideПереключатель") +
                                                                    "K03M_02InsideПереключатель".Length));
                    var angle = K03M_02InsideParameters.K03M_02InsideПереключатель[index] * 30 - 10;
                    item.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                        ControlElementImages.toggleType2, angle);
                }
                if (item.Name.Contains("K03M_02InsideТумблер"))
                {
                    try
                    {
                        var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("K03M_02InsideТумблер") +
                                                                        "K03M_02InsideТумблер".Length));
                        item.BackgroundImage = (K03M_02InsideParameters.K03M_02InsideПереключатель[index] == 0)
                        ? ControlElementImages.tumblerType3Left
                        : ControlElementImages.tumblerType3Right;
                    }
                    catch (System.FormatException)
                    {
                    }
                }
            }
            K03M_02InsideТумблерИП.BackgroundImage = K03M_02InsideParameters.K03M_02InsideТумблерИП
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
            K03M_02InsideТумблерВклОткл.BackgroundImage = K03M_02InsideParameters.K03M_02InsideТумблерВклОткл
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        }

        private void K03M_02InsideПереключатель_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("K03M_02InsideПереключатель") +
                                                            "K03M_02InsideПереключатель".Length));
            var property = typeof(K05M_01Parameters).GetProperty(item.Name);
            if (e.Button == MouseButtons.Left)
            {
                K03M_02InsideParameters.K03M_02InsideПереключатель[index] += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                K03M_02InsideParameters.K03M_02InsideПереключатель[index] -= 1;
            }

            var angle = K03M_02InsideParameters.K03M_02InsideПереключатель[index] * 30 - 10;
            item.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                ControlElementImages.toggleType2, angle);
        }

        private void K03M_02InsideТумблер_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            var index = Convert.ToInt32(item.Name.Substring(item.Name.IndexOf("K03M_02InsideТумблер") +
                                                            "K03M_02InsideТумблер".Length));
            if (e.Button == MouseButtons.Left)
            {
                if (K03M_02InsideParameters.K03M_02InsideПереключатель[index] == 0)
                    K03M_02InsideParameters.K03M_02InsideПереключатель[index] = 1;
                else K03M_02InsideParameters.K03M_02InsideПереключатель[index] = 0;
            }
            if (item.Name.Contains("K03M_02InsideТумблер"))
            {
                item.BackgroundImage = (K03M_02InsideParameters.K03M_02InsideПереключатель[index] == 0)
                    ? ControlElementImages.tumblerType3Left
                    : ControlElementImages.tumblerType3Right;
            }
        }

        private void K03M_02InsideТумблерИП_Click(object sender, EventArgs e)
        {
            K03M_02InsideParameters.K03M_02InsideТумблерИП = !K03M_02InsideParameters.K03M_02InsideТумблерИП;
            K03M_02InsideТумблерИП.BackgroundImage = K03M_02InsideParameters.K03M_02InsideТумблерИП
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        }

        private void K03M_02InsideТумблерВклОткл_Click(object sender, EventArgs e)
        {
            K03M_02InsideParameters.K03M_02InsideТумблерВклОткл = !K03M_02InsideParameters.K03M_02InsideТумблерВклОткл;
            K03M_02InsideТумблерВклОткл.BackgroundImage = K03M_02InsideParameters.K03M_02InsideТумблерВклОткл
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        }
    }
}