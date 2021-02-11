using ShareTypes.SignalTypes;
using R440O.BaseClasses;

namespace R440O.R440OForms.A306
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Форма блока А306
    /// </summary>
    public partial class A306Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="A306Form"/>.
        /// </summary>
        public A306Form()
        {
            InitializeComponent();
            A306Parameters.ParameterChanged += RefreshFormElements;
        }

        #region Тумблеры

        private void ТумблерДистанцМестн_Click(object sender, System.EventArgs e)
        {
            A306Parameters.ТумблерДистанцМестн = !A306Parameters.ТумблерДистанцМестн;
        }

        private void ТумблерПитание_Click(object sender, System.EventArgs e)
        {
            A306Parameters.ТумблерПитание = !A306Parameters.ТумблерПитание;
        }

        #endregion

        #region Коммутация

        private void Выходы_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            int numberOfButton = int.Parse(button.Name[5].ToString() + button.Name[6]);
            A306Parameters.Выходы[numberOfButton] = A306Parameters.АктивныйВход;
        }

        private void ВходыКаналов_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            //названия кнопок отличются на 11й символ
            int numberOfButton = 0;
            if (button.Name.Length >= 11) //входы каналов
                numberOfButton = (int)Char.GetNumericValue(button.Name[10]);
            else //входы NO
                numberOfButton = (int)Char.GetNumericValue(button.Name[7]) + 3;

            if (!button.Font.Bold)
                FontChange(button);

            A306Parameters.АктивныйВход = numberOfButton;
        }

        #endregion

        #region Графика

        private void FontChange(Button button)
        {
            if (!button.Font.Bold)
            {
                foreach (Control item2 in Panel.Controls)
                {
                    if (item2.Name.Contains("ВходNO") || item2.Name.Contains("ВходКанала"))
                    {
                        item2.Font = new Font("Microsoft Sans Serif", 9.75F, (FontStyle.Regular));
                        item2.ForeColor = Color.Black;
                    }
                }
                button.Font = new Font("Microsoft Sans Serif", 10.25F, (FontStyle.Bold));
                button.ForeColor = Color.Blue;
            }
            else
            {
                button.Font = new Font("Microsoft Sans Serif", 9.75F, (FontStyle.Regular));
                button.ForeColor = Color.Black;
            }
        }

        private void DrawLine(Point onePoint, Point twoPoint, PaintEventArgs e)
        {
            var myPen = new Pen(Color.Gray, 10);
            e.Graphics.DrawLine(myPen, onePoint, twoPoint);
            myPen.Dispose();
        }

        private void DrawLine(Point onePoint, Point twoPoint, PaintEventArgs e, int thickness)
        {
            var myPen = new Pen(Color.Gray, thickness);
            e.Graphics.DrawLine(myPen, onePoint, twoPoint);
            myPen.Dispose();
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            Panel.Paint -= Panel_Paint;

            НО1.Visible = false;
            НО1Своб.Visible = true;
            НО1Своб.BackgroundImage = ControlElementImages.A306CabelNO;
            НО2.Visible = false;
            НО2Своб.Visible = true;
            НО2Своб.BackgroundImage = ControlElementImages.A306CabelNO;

            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("ВходКанала"))
                {
                    //если кабели висят на планке
                    if (A306Parameters.КабелиВходы[(int)char.GetNumericValue(item.Name[10])])
                    {
                        var onePoint = new Point(Panel.Left + 55 * (int)char.GetNumericValue(item.Name[10]) + 140,
                            Panel.Bottom - 85);
                        var twoPoint = new Point(item.Left + 8, item.Top + 100);
                        for (int i = 0; i < 10; i++)
                        {
                            onePoint.X++;
                            twoPoint.X++;
                            DrawLine(onePoint, twoPoint, e, 1);
                        }
                        continue;
                    }
                }
                //если воткнуты куда-нибудь
                if (item.Name.Contains("Выход"))
                {
                    int index =
                        int.Parse(Convert.ToString(Convert.ToString(item.Name[5]) + Convert.ToString(item.Name[6])));
                    if (A306Parameters.Выходы[index] != -1 && A306Parameters.Выходы[index] <= 3)
                    {
                        var onePoint = new Point(Panel.Left + 55 * A306Parameters.Выходы[index] + 142, Panel.Bottom - 80);
                        if (index <= 10)
                        {
                            //для нижнего ряда выходов
                            var twoPoint = new Point(item.Left + 12, item.Bottom - 5);
                            DrawLine(onePoint, twoPoint, e);
                        }
                        else
                        {
                            //для верхнего ряда выходов, с изломом
                            var twoPoint = new Point(item.Left + 12, item.Bottom + 50);
                            var threePoint = new Point(item.Left + 12, item.Bottom);

                            DrawLine(onePoint, twoPoint, e);
                            twoPoint.Y += 4;
                            DrawLine(twoPoint, threePoint, e);
                        }
                    }
                    else //для NO
                    {
                        if (A306Parameters.Выходы[index] == 4)
                        {
                            НО1.Visible = true;
                            НО1.BackgroundImage = ControlElementImages.A306Input;
                            НО1Своб.Visible = false;
                            var Point0 = new Point(НО1.Left + 10, НО1.Bottom);
                            var Point1 = new Point(НО1.Left + 10, НО1.Bottom + 50);
                            var Point1_1 = ((index >= 11 && index <= 14) || index < 5)
                                ? new Point(НО1.Left + 20, НО1.Bottom + 50)
                                : new Point(НО1.Left + 11, НО1.Bottom + 50);
                            var Point2 = new Point(item.Left + 11, НО1.Bottom + 55);
                            var Point3 = new Point(item.Left + 11, item.Bottom);

                            DrawLine(Point0, Point1, e);
                            DrawLine(Point2, Point3, e);
                            Point1_1.X -= 5;
                            Point2.X += 5;
                            Point2.Y -= 5;
                            DrawLine(Point1_1, Point2, e);
                        }
                        else if (A306Parameters.Выходы[index] == 5)
                        {
                            НО2.Visible = true;
                            НО2.BackgroundImage = ControlElementImages.A306Input;
                            НО2Своб.Visible = false;
                            var Point0 = new Point(НО2.Left + 10, НО2.Bottom);
                            var Point1 = new Point(НО2.Left + 10, НО2.Bottom + 70);
                            var Point1_1 = ((index >= 6 && index <= 10) || index >= 15)
                                ? new Point(НО2.Left + 10, НО2.Bottom + 70)
                                : new Point(НО2.Left + 20, НО2.Bottom + 70);
                            var Point2 = new Point(item.Left + 11, НО2.Bottom + 75);
                            var Point3 = new Point(item.Left + 11, item.Bottom);

                            DrawLine(Point0, Point1, e);
                            DrawLine(Point2, Point3, e);
                            Point1_1.X -= 5;
                            Point2.X += 5;
                            Point2.Y -= 5;
                            DrawLine(Point1_1, Point2, e);
                        }
                    }
                }
            }
        }

        #endregion

        #region Инициализация

        /// <summary>
        /// Обновление формы
        /// </summary>
        public void RefreshFormElements()
        {
            //Лампочки
            ЛампочкаСетьВкл.BackgroundImage = A306Parameters.ЛампочкаСетьВкл
                ? ControlElementImages.lampType5OnRed
                : null;

            ЛампочкаНО1Вкл.BackgroundImage = A306Parameters.ЛампочкаНО1Вкл
                ? ControlElementImages.lampType5OnRed
                : null;

            ЛампочкаНО2Вкл.BackgroundImage = A306Parameters.ЛампочкаНО2Вкл
                ? ControlElementImages.lampType5OnRed
                : null;

            //Тумблер
            ТумблерДистанцМестн.BackgroundImage = A306Parameters.ТумблерДистанцМестн
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            ТумблерПитание.BackgroundImage = A306Parameters.ТумблерПитание
                ? ControlElementImages.tumblerType4Up
                : ControlElementImages.tumblerType4Down;

            //ВходыКаналов
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("ВходКанала"))
                {
                    if (A306Parameters.КабелиВходы[(int)Char.GetNumericValue(item.Name[10])])
                    {
                        item.Visible = true;
                        item.BackgroundImage = ControlElementImages.A306Input;
                        item.Text = (char.GetNumericValue(item.Name[10]) + 1).ToString();
                    }
                    else
                    {
                        item.Visible = false;
                        //item.BackgroundImage = null;
                        item.Text = "";
                    }
                }
                else if (item.Name.Contains("ВходNO"))
                {
                    if (A306Parameters.КабелиВходы[(int)Char.GetNumericValue(item.Name[7]) + 3])
                    {
                        item.Visible = true;
                        item.BackgroundImage = ControlElementImages.A306Input;
                        item.Text = "" + char.GetNumericValue(item.Name[7]);
                    }
                    else
                    {
                        item.Visible = false;
                        //item.BackgroundImage = null;
                        item.Text = "";
                    }
                }
            }

            //ВыходыКаналов
            foreach (Control item in Panel.Controls)
            {
                if (item.Name.Contains("Выход"))
                {
                    int index =
                        int.Parse(Convert.ToString(Convert.ToString(item.Name[5]) + Convert.ToString(item.Name[6])));
                    if (A306Parameters.Выходы[index] != -1)
                    {
                        item.BackgroundImage = ControlElementImages.A306Input;
                        if (A306Parameters.Выходы[index] <= 3)
                        {
                            item.Text = (A306Parameters.Выходы[index] + 1).ToString();
                            item.Font = new Font("Microsoft Sans Serif", 8.25F, (FontStyle.Regular));
                        }
                        else
                        {
                            item.Text = "НО" + (A306Parameters.Выходы[index] - 3);
                            item.Font = new Font("Microsoft Sans Serif", 5.25F, (FontStyle.Regular));
                        }
                    }
                    else
                    {
                        item.BackgroundImage = null;
                        item.Text = "";
                    }
                }
            }

            Panel.Paint += Panel_Paint;
            Panel.Refresh();
        }

        #endregion

        /// <summary>
        /// Для запуска refreshForm после того как вся форма загрузилась
        /// </summary>
        private void PanelDraw_Enter(object sender, EventArgs e)
        {
            RefreshFormElements();
        }

        private void A306Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            A306Parameters.ParameterChanged -= RefreshFormElements;
        }
    }
}