//-----------------------------------------------------------------------
// <copyright file="K04M_01.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows.Forms;
using R440O.ThirdParty;

namespace R440O.R440OForms.K04M_01
{
    /// <summary>
    /// Форма блока К04-М-1
    /// </summary>
    public partial class K04M_01Form : Form
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="K04M_01Form"/>
        /// </summary>
        public K04M_01Form()
        {
            this.InitializeComponent();
            this.InitializeToggles();
        }

        private void InitializeToggles()
        {
            foreach (Control item in K04M_01Panel.Controls)
            {
                var fieldList = typeof(K04M_01Parameters).GetProperties();
                var item1 = item;
                foreach (var field in fieldList.Where(property => item1.Name == property.Name))
                {
                    if (item.Name.Contains("Переключатель"))
                    {
                        var angle = (int)field.GetValue(null) * 26 - 120;
                        item.BackgroundImage =
                            TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
                    }
                }
            }
        }

        private void Переключатель_MouseDown(object sender, MouseEventArgs e)
        {
            var item = sender as Button;
            if (item != null)
            {
                var property = typeof(K04M_01Parameters).GetProperty(item.Name);
                if (e.Button == MouseButtons.Left)
                {
                    property.SetValue(null, (int)property.GetValue(null) + 1);
                }

                if (e.Button == MouseButtons.Right)
                {
                    property.SetValue(null, (int)property.GetValue(null) - 1);
                }

                var angle = (int)property.GetValue(null) * 26 - 120;
                item.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);
            }
        }

        private void Крышка_Click(object sender, EventArgs e)
        {
            Крышка.Visible = false;
        }
    }
}