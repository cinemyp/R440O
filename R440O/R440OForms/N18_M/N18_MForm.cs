using System.Drawing;
using System.Collections.Generic;
namespace R440O.R440OForms.N18_M
{
    using System.Windows.Forms;
    using BaseClasses;
    using ThirdParty;
    using СостоянияЭлементов;

    /// <summary>
    /// Форма блока Н-18-М
    /// </summary>
    public partial class N18_MForm : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="N18_MForm"/>
        /// </summary>
        public N18_MForm()
        {
            this.InitializeComponent();
            N18_MParameters.ParameterChanged += RefreshFormElements;
            RefreshFormElements();
        }

        #region Тумблеры
        private void ТумблерДАБ5_Click(object sender, System.EventArgs e)
        {
            N18_MParameters.ТумблерДАБ5 = !N18_MParameters.ТумблерДАБ5;
        }

        private void ТумблерКАУ_ПРМ_Click(object sender, System.EventArgs e)
        {
            N18_MParameters.ТумблерКАУ_ПРМ = !N18_MParameters.ТумблерКАУ_ПРМ;
        }

        private void ТумблерПРД_СС_Click(object sender, System.EventArgs e)
        {
            N18_MParameters.ТумблерПРД_СС = !N18_MParameters.ТумблерПРД_СС;
        }

        private void ТумблерТЛФ_ПРМ_Click(object sender, System.EventArgs e)
        {
            N18_MParameters.ТумблерТЛФ_ПРМ = !N18_MParameters.ТумблерТЛФ_ПРМ;
        }

        #endregion

        #region Переключатели
        private void ПереключательПРМ1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПРМ1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПРМ1 -= 1;
            }
        }

        private void ПереключательПРМ2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПРМ2 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПРМ2 -= 1;
            }
        }

        private void ПереключательВходК1_2_1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательВходК121 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательВходК121 -= 1;
            }
        }

        private void ПереключательПРД_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПРД += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПРД -= 1;
            }
        }

        private void ПереключательПРДБМА12_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПрдБма12 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПрдБма12 -= 1;
            }
        }

        private void ПереключательПРМСС1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПрмСс1 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПрмСс1 -= 1;
            }
        }

        private void ПереключательПРМСС2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательПрмСс2 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательПрмСс2 -= 1;
            }
        }

        private void Переключатель48ПРМЩВ_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.Переключатель48ПрмЩв += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.Переключатель48ПрмЩв -= 1;
            }
        }

        private void ПереключательВыход2РН_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательВыход2РН += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательВыход2РН -= 1;
            }
        }

        private void ПереключательВыход1РН_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательВыход1РН += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательВыход1РН -= 1;
            }
        }

        private void ПереключательВходБ22_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                N18_MParameters.ПереключательВходБ22 += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                N18_MParameters.ПереключательВходБ22 -= 1;
            }
        }
        #endregion

        public void RefreshFormElements()
        {

            // Panel.Refresh();
            ЛампочкаКЗТЛГ1.BackgroundImage = N18_MParameters.ЛампочкаК3ТЛГ1
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаКЗТЛГ2.BackgroundImage = N18_MParameters.ЛампочкаК3ТЛГ2
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаКЗТЛГ3.BackgroundImage = N18_MParameters.ЛампочкаК3ТЛГ3
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаКЗТЛГ4.BackgroundImage = N18_MParameters.ЛампочкаК3ТЛГ4
                ? ControlElementImages.lampType6OnRed
                : null;

            ЛампочкаСПСТест.BackgroundImage = N18_MParameters.ЛампочкаСПСТест
                ? ControlElementImages.lampType8OnRed
                : null;

            ЛампочкаСПСИнформ.BackgroundImage = N18_MParameters.ЛампочкаСПСИнформ
                ? ControlElementImages.lampType8OnRed
                : null;

            ЛампочкаПилотК1_1.BackgroundImage = N18_MParameters.ЛампочкаПилотК1_1
                ? ControlElementImages.lampType8OnRed
                : null;

            ЛампочкаПилотК1_2.BackgroundImage = N18_MParameters.ЛампочкаПилотК1_2
                ? ControlElementImages.lampType8OnRed
                : null;

            ЛампочкаИнформК1_1.BackgroundImage = N18_MParameters.ЛампочкаИнформК1_1
                ? ControlElementImages.lampType8OnRed
                : null;

            ЛампочкаИнформК1_2.BackgroundImage = N18_MParameters.ЛампочкаИнформК1_2
                ? ControlElementImages.lampType8OnRed
                : null;

            ТумблерДАБ5.BackgroundImage = N18_MParameters.ТумблерДАБ5
                ? ControlElementImages.tumblerType5Right
                : ControlElementImages.tumblerType5Left;

            ТумблерКАУ_ПРМ.BackgroundImage = N18_MParameters.ТумблерКАУ_ПРМ
                ? ControlElementImages.tumblerType5Right
                : ControlElementImages.tumblerType5Left;

            ТумблерПРД_СС.BackgroundImage = N18_MParameters.ТумблерПРД_СС
                ? ControlElementImages.tumblerType5Right
                : ControlElementImages.tumblerType5Left;

            ТумблерТЛФ_ПРМ.BackgroundImage = N18_MParameters.ТумблерТЛФ_ПРМ
                ? ControlElementImages.tumblerType5Right
                : ControlElementImages.tumblerType5Left;

            var angle = N18_MParameters.ПереключательПРМ1 * 40 - 120;
            ПереключательПРМ1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательПРМ2 * 40 - 120;
            ПереключательПРМ2.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательВходК121 * 40 - 120;
            ПереключательВходК1_2_1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательПРД * 40 - 120;
            ПереключательПРД.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательПрдБма12 * 28 - 180;
            if (N18_MParameters.ПереключательПрдБма12 == 6) angle += 12;
            else if (N18_MParameters.ПереключательПрдБма12 > 6) angle += 28;   ////Смещение
            ПереключательПРДБМА12.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательПрмСс1 * 40 - 120;
            ПереключательПРМСС1.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательПрмСс2 * 40 - 120;
            ПереключательПРМСС2.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.Переключатель48ПрмЩв * 50 - 75;
            Переключатель48ПРМЩВ.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательВыход2РН * 50 - 75;
            ПереключательВыход2РН.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательВыход1РН * 50 - 75;
            ПереключательВыход1РН.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            angle = N18_MParameters.ПереключательВходБ22 * 50 - 75;
            ПереключательВходБ22.BackgroundImage =
                TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType2, angle);

            //  Panel.Invalidate();
            Panel.Paint += Panel_Paint;
            Panel.Refresh();
        }

        private void N18_MForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            N18_MParameters.ParameterChanged -= RefreshFormElements;
        }

        #region Отрисовка соединенй
        private void DrawLine(Point onePoint, Point twoPoint, PaintEventArgs e, Color color)
        {
            var myPen = new Pen(color, 5);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Point p1, p2, p_control1, p_control2;
            int d = (onePoint.Y < twoPoint.Y ? twoPoint.Y - onePoint.Y : onePoint.Y - twoPoint.Y) / 2;
            int Y1, Y2;
            if (d < 30)
            {
                if (d != 0)
                {
                    Y1 = onePoint.Y < twoPoint.Y ? onePoint.Y + d : onePoint.Y - d;
                    Y2 = onePoint.Y < twoPoint.Y ? twoPoint.Y - d : twoPoint.Y + d;
                }
                else
                {
                    Y1 = onePoint.Y + 22;
                    Y2 = twoPoint.Y + 22;
                }
                p1 = new Point(onePoint.X, Y1);
                p2 = new Point(twoPoint.X, Y2);

                e.Graphics.DrawLine(myPen, onePoint, p1);
                e.Graphics.DrawLine(myPen, twoPoint, p2);
                e.Graphics.DrawLine(myPen, p1, p2);
            }
            else
            {
                if (onePoint.X < 300 || twoPoint.X < 300)
                {
                    p_control1 = new Point(220, 182);
                    p_control2 = new Point(220, 140);
                }
                else
                {
                    p_control1 = new Point(305, 182);
                    p_control2 = new Point(305, 142);
                }

                Y1 = onePoint.Y < twoPoint.Y ? onePoint.Y + 22 : onePoint.Y - 22;
                Y2 = onePoint.Y < twoPoint.Y ? twoPoint.Y - 22 : twoPoint.Y + 22;

                p1 = new Point(onePoint.X, Y1);
                p2 = new Point(twoPoint.X, Y2);

                e.Graphics.DrawLine(myPen, onePoint, p1);
                if (onePoint.Y > twoPoint.Y)
                {
                    e.Graphics.DrawLine(myPen, p1, p_control1);
                    e.Graphics.DrawLine(myPen, p_control2, p2);
                }
                else
                {
                    e.Graphics.DrawLine(myPen, p2, p_control1);
                    e.Graphics.DrawLine(myPen, p_control2, p1);
                }

                e.Graphics.DrawLine(myPen, p_control1, p_control2);
                e.Graphics.DrawLine(myPen, twoPoint, p2);
            }
            myPen.Dispose();
        }

        private void РисованиеСоеденений(PaintEventArgs e)
        {
            bool[] Дублирующие = new bool[77];
            int номер_гнезда1, номер_гнезда2;
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 0);
            List<Control> соединенные_гнезда = new List<Control>();
            foreach (Control item in Panel.Controls)
                if (item.Name.Contains("Гнездо") && item.BackgroundImage != null)
                    item.BackgroundImage = null;

            for (int i = 1; i < 76; i++)
            {
                номер_гнезда1 = i;
                номер_гнезда2 = N18_MParameters.Соединения[i];

                if (!Дублирующие[i] && номер_гнезда2 != 0)
                {
                    foreach (Control item in Panel.Controls)
                    {
                        if (item.Name == "Гнездо" + номер_гнезда1)
                        {
                            point1 = new Point(item.Location.X + item.Size.Width / 2,
                                 item.Location.Y + item.Size.Height / 2);
                            соединенные_гнезда.Add(item);
                        }
                        if (item.Name == "Гнездо" + номер_гнезда2)
                        {
                            point2 = new Point(item.Location.X + item.Size.Width / 2,
                                 item.Location.Y + item.Size.Height / 2);
                            соединенные_гнезда.Add(item);
                        }
                    }
                    DrawLine(point1, point2, e, N18_MParameters.Цвет_соеденения[номер_гнезда1]);
                    Дублирующие[номер_гнезда1] = true;
                    Дублирующие[номер_гнезда2] = true;
                }
            }

            var первый_выбраный_контрол = Panel.Controls.Find("Гнездо" + N18_MParameters.номер_первого_гнезда, false);
            if (первый_выбраный_контрол.Length != 0)
            {
                первый_выбраный_контрол[0].BackgroundImage = ControlElementImages.N18_M_Gnezdo;
            }

            foreach (var item in соединенные_гнезда)
                item.BackgroundImage = ControlElementImages.N18_M_Gnezdo;
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel.Paint -= Panel_Paint;
            РисованиеСоеденений(e);
        }
        #endregion

        private void Гнездо_Click(object sender, System.EventArgs e)
        {
            var СвязанноеГнездо = sender as Button;
            var text = СвязанноеГнездо.Name;
            int НомерГнезда = text.Length == 7 ?
                (int)char.GetNumericValue(text[6]) :
                10 * (int)char.GetNumericValue(text[6]) + (int)char.GetNumericValue(text[7]);
            N18_MParameters.Соеденить(НомерГнезда);
        }

    }
}