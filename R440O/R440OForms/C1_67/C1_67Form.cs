//-----------------------------------------------------------------------
// <copyright file="C1_67Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Linq;
using R440O.Parameters;
using R440O.ThirdParty;

namespace R440O.R440OForms.C1_67
{
    using global::R440O.LearnModule;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока С1-67
    /// </summary>
    public partial class C1_67Form : Form
    {
        #region Инициализация формы
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="C1_67Form"/>
        /// </summary>
        public C1_67Form()
        {
            this.InitializeComponent();
            InitializeTogglesPosition();
            InitializeTumblersPosition();

           
        }



        private void InitializeTogglesPosition()
        {
            var angle = C1_67Parameters.C1_67ПереключательДлительность * 15 - 148;
            if (C1_67Parameters.C1_67ПереключательДлительность > 3) angle += 4;
            if (C1_67Parameters.C1_67ПереключательДлительность > 9) angle += 6;
            if (C1_67Parameters.C1_67ПереключательДлительность > 15) angle += 4;
            C1_67ПереключательДлительность.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType7, angle);

            angle = C1_67Parameters.C1_67ПереключательУсиление * 30 + 15;
            if (C1_67Parameters.C1_67ПереключательУсиление > 2) angle += 5;
            if (C1_67Parameters.C1_67ПереключательУсиление > 5) angle -= 10;
            if (C1_67Parameters.C1_67ПереключательУсиление > 8) angle += 5;
            C1_67ПереключательУсиление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType7, angle);

            angle = C1_67Parameters.C1_67_N19ПереключательВыборПриемника * 30 - 180;
            if (C1_67Parameters.C1_67_N19ПереключательВыборПриемника > 4) angle += 10;
            C1_67_N19ПереключательВыборПриемника.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);

            this.С1_67ПереключательУсилительУ1.BackgroundImage = C1_67Parameters.C1_67ПереключательУсилительУ != 1
                ? null
                : ControlElementImages.toggleС1_67;

            this.С1_67ПереключательУсилительУ2.BackgroundImage = C1_67Parameters.C1_67ПереключательУсилительУ != 2
                ? null
                : ControlElementImages.toggleС1_67;

            this.С1_67ПереключательУсилительУ3.BackgroundImage = C1_67Parameters.C1_67ПереключательУсилительУ != 3
                ? null
                : ControlElementImages.toggleС1_67;



            this.C1_67ПереключательСинхронизация1_1.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация1 != 1
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация1_2.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация1 != 2
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация1_3.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация1 != 3
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация1_4.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация1 != 4
                ? null
                : ControlElementImages.toggleС1_67;



            this.C1_67ПереключательСинхронизация2_1.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация2 != 1
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация2_2.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация2 != 2
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация2_3.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация2 != 3
                ? null
                : ControlElementImages.toggleС1_67;

            this.C1_67ПереключательСинхронизация2_4.BackgroundImage = C1_67Parameters.C1_67ПереключательСинхронизация2 != 4
                ? null
                : ControlElementImages.toggleС1_67;

        }

        private void InitializeTumblersPosition()
        {
            this.C1_67_N19ТумблерВклВыкл.BackgroundImage = C1_67Parameters.C1_67_N19ТумблерВклВыкл == false
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            this.C1_67_N19Тумблер200_20.BackgroundImage = C1_67Parameters.C1_67_N19Тумблер200_20 == "20"
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            this.C1_67ТумблерСеть.BackgroundImage = C1_67Parameters.C1_67ТумблерСеть == false
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            this.C1_67ТумблерX1X02.BackgroundImage = C1_67Parameters.C1_67ТумблерX1X02 == "X02"
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;

            this.C1_67Тумблер2kHz.BackgroundImage = C1_67Parameters.C1_67Тумблер2kHz == false
                ? ControlElementImages.tumblerType4Left
                : ControlElementImages.tumblerType4Right;
        } 
        #endregion

        #region Тумблеры
        private void C1_67_N19ТумблерВклВыкл_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67_N19ТумблерВклВыкл == true)
            {
                this.C1_67_N19ТумблерВклВыкл.BackgroundImage = ControlElementImages.tumblerType4Down;
                C1_67Parameters.C1_67_N19ТумблерВклВыкл = false;
            }
            else
            {
                this.C1_67_N19ТумблерВклВыкл.BackgroundImage = ControlElementImages.tumblerType4Up;
                C1_67Parameters.C1_67_N19ТумблерВклВыкл = true;
            }
        }

        private void C1_67_N19Тумблер200_20_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67_N19Тумблер200_20 == "200")
            {
                this.C1_67_N19Тумблер200_20.BackgroundImage = ControlElementImages.tumblerType4Down;
                C1_67Parameters.C1_67_N19Тумблер200_20 = "20";
            }
            else
            {
                this.C1_67_N19Тумблер200_20.BackgroundImage = ControlElementImages.tumblerType4Up;
                C1_67Parameters.C1_67_N19Тумблер200_20 = "200";
            }
        }

        private void C1_67ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67ТумблерСеть == true)
            {
                this.C1_67ТумблерСеть.BackgroundImage = ControlElementImages.tumblerType4Down;
                C1_67Parameters.C1_67ТумблерСеть = false;
            }
            else
            {
                this.C1_67ТумблерСеть.BackgroundImage = ControlElementImages.tumblerType4Up;
                C1_67Parameters.C1_67ТумблерСеть = true;
            }
        }

        private void C1_67ТумблерX1X02_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67ТумблерX1X02 == "X1")
            {
                this.C1_67ТумблерX1X02.BackgroundImage = ControlElementImages.tumblerType4Down;
                C1_67Parameters.C1_67ТумблерX1X02 = "X02";
            }
            else
            {
                this.C1_67ТумблерX1X02.BackgroundImage = ControlElementImages.tumblerType4Up;
                C1_67Parameters.C1_67ТумблерX1X02 = "X1";
            }
        }

        private void C1_67Тумблер2kHz_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67Тумблер2kHz == true)
            {
                this.C1_67Тумблер2kHz.BackgroundImage = ControlElementImages.tumblerType4Left;
                C1_67Parameters.C1_67Тумблер2kHz = false;
            }
            else
            {
                this.C1_67Тумблер2kHz.BackgroundImage = ControlElementImages.tumblerType4Right;
                C1_67Parameters.C1_67Тумблер2kHz = true;
            }
        }
        #endregion

        #region Переключатели
        private void C1_67_N19ПереключательВыборПриемника_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C1_67Parameters.C1_67_N19ПереключательВыборПриемника += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C1_67Parameters.C1_67_N19ПереключательВыборПриемника -= 1;
            }

            var angle = C1_67Parameters.C1_67_N19ПереключательВыборПриемника * 30 - 180;
            if (C1_67Parameters.C1_67_N19ПереключательВыборПриемника > 4) angle += 10;
            C1_67_N19ПереключательВыборПриемника.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);
        }
        private void C1_67ПереключательУсиление_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C1_67Parameters.C1_67ПереключательУсиление += 1;
                if (C1_67Parameters.C1_67ПереключательУсиление == 13) C1_67Parameters.C1_67ПереключательУсиление = 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C1_67Parameters.C1_67ПереключательУсиление -= 1;
                if (C1_67Parameters.C1_67ПереключательУсиление == 0) C1_67Parameters.C1_67ПереключательУсиление = 12;
            }

            var angle = C1_67Parameters.C1_67ПереключательУсиление * 30 + 15;
            if (C1_67Parameters.C1_67ПереключательУсиление > 2) angle += 5;
            if (C1_67Parameters.C1_67ПереключательУсиление > 5) angle -= 10;
            if (C1_67Parameters.C1_67ПереключательУсиление > 8) angle += 5;
            C1_67ПереключательУсиление.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType7, angle);
        }
        private void C1_67ПереключательДлительность_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                C1_67Parameters.C1_67ПереключательДлительность += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                C1_67Parameters.C1_67ПереключательДлительность -= 1;
            }

            var angle = C1_67Parameters.C1_67ПереключательДлительность * 15 - 148;
            if (C1_67Parameters.C1_67ПереключательДлительность > 3) angle += 4;
            if (C1_67Parameters.C1_67ПереключательДлительность > 9) angle += 6;
            if (C1_67Parameters.C1_67ПереключательДлительность > 15) angle += 4;
            C1_67ПереключательДлительность.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType7, angle);
        }
        private void С1_67ПереключательУсилительУ1_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательУсилительУ != 1)
            {
                this.С1_67ПереключательУсилительУ1.BackgroundImage = ControlElementImages.toggleС1_67;
                this.С1_67ПереключательУсилительУ2.BackgroundImage = null;
                this.С1_67ПереключательУсилительУ3.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательУсилительУ = 1;
            }
        }
        private void С1_67ПереключательУсилительУ2_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательУсилительУ != 2)
            {
                this.С1_67ПереключательУсилительУ1.BackgroundImage = null;
                this.С1_67ПереключательУсилительУ2.BackgroundImage = ControlElementImages.toggleС1_67;
                this.С1_67ПереключательУсилительУ3.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательУсилительУ = 2;
            }
        }
        private void С1_67ПереключательУсилительУ3_Click(object sender, System.EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательУсилительУ != 3)
            {
                this.С1_67ПереключательУсилительУ1.BackgroundImage = null;
                this.С1_67ПереключательУсилительУ2.BackgroundImage = null;
                this.С1_67ПереключательУсилительУ3.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67Parameters.C1_67ПереключательУсилительУ = 3;
            }
        }

        #endregion

        #region Вращатели

        private static bool isManipulation;

        private void C1_67Регулятор_MouseDown(object sender, MouseEventArgs e)
        {
            isManipulation = true;
        }

        private void C1_67Регулятор_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isManipulation) return;
            var button = sender as Button;
            var angle = TransformImageHelper.CalculateAngle(button.Width, button.Height, e);
            var propertyList = typeof(C1_67Parameters).GetProperties();
            foreach (var property in propertyList.Where(property => button.Name == property.Name))
            {
                property.SetValue(null, angle);
                var tempAngle = Convert.ToInt32(property.GetValue(null, null));
                button.BackgroundImage = TransformImageHelper.RotateImageByAngle(
                    ControlElementImages.revolverRoundSmall,
                    tempAngle);
            }
        }

        private void C1_67Регулятор_MouseUp(object sender, MouseEventArgs e)
        {
            isManipulation = false;
        }
        #endregion

        #region Переключатели синхронизации
        private void C1_67ПереключательСинхронизация1_1_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация1 != 1)
            {
                C1_67ПереключательСинхронизация1_1.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация1_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация1 = 1;
            }
        }

        private void C1_67ПереключательСинхронизация1_2_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация1 != 2)
            {
                C1_67ПереключательСинхронизация1_2.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация1_1.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация1 = 2;
            }
        }

        private void C1_67ПереключательСинхронизация1_3_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация1 != 3)
            {
                C1_67ПереключательСинхронизация1_3.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация1_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_1.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация1 = 3;
            }
        }

        private void C1_67ПереключательСинхронизация1_4_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация1 != 1)
            {
                C1_67ПереключательСинхронизация1_4.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация1_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация1_1.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация1 = 4;
            }
        }

        private void C1_67ПереключательСинхронизация2_1_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация2 != 1)
            {
                C1_67ПереключательСинхронизация2_1.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация2_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация2 = 1;
            }
        }

        private void C1_67ПереключательСинхронизация2_2_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация2 != 2)
            {
                C1_67ПереключательСинхронизация2_2.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация2_1.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация2 = 2;
            }
        }

        private void C1_67ПереключательСинхронизация2_3_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация2 != 3)
            {
                C1_67ПереключательСинхронизация2_3.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация2_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_1.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_4.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация2 = 3;
            }
        }

        private void C1_67ПереключательСинхронизация2_4_Click(object sender, EventArgs e)
        {
            if (C1_67Parameters.C1_67ПереключательСинхронизация2 != 4)
            {
                C1_67ПереключательСинхронизация2_4.BackgroundImage = ControlElementImages.toggleС1_67;
                C1_67ПереключательСинхронизация2_2.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_3.BackgroundImage = null;
                C1_67ПереключательСинхронизация2_1.BackgroundImage = null;
                C1_67Parameters.C1_67ПереключательСинхронизация2 = 4;
            }
        }
        #endregion

        private void C1_67Form_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        }
    }
}