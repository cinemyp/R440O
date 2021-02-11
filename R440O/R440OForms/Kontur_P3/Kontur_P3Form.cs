//-----------------------------------------------------------------------
// <copyright file="Kontur_P3Form.cs" company="VKISPU">
//      R440O station.
// </copyright>
//-----------------------------------------------------------------------

namespace R440O.R440OForms.Kontur_P3
{
    using System.Windows.Forms;
    using BaseClasses;
    using ThirdParty;
    using СостоянияЭлементов.Контур_П;
    using Параметры;

    /// <summary>
    /// Форма блока Контур-П3
    /// </summary>
    public partial class Kontur_P3Form : Form, IRefreshableForm
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Kontur_P3Form"/>
        /// </summary>
        public Kontur_P3Form()
        {
            this.InitializeComponent();
            Kontur_P3Parameters.RefreshForm += RefreshFormElements;
            RefreshFormElements();
        }

        #region Переключатели
        private void Kontur_P3ПереключательПриоритет_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Kontur_P3Parameters.ПереключательПриоритет += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Kontur_P3Parameters.ПереключательПриоритет -= 1;
            }
        }
        #endregion

        #region Тумблеры
        private void Kontur_P3ТумблерКонтроль_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.ТумблерКонтроль = Kontur_P3Parameters.ТумблерКонтроль == EТумблерКонтроль.КОНТРОЛЬ_1
                ? EТумблерКонтроль.КОНТРОЛЬ_2
                : EТумблерКонтроль.КОНТРОЛЬ_1;
        }

        private void Kontur_P3ТумблерДокументирование_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.ТумблерДокументирование = Kontur_P3Parameters.ТумблерДокументирование ==
                                                          EТумблерДокументирование.ОТКЛ
                ? EТумблерДокументирование.ВКЛ
                : EТумблерДокументирование.ОТКЛ;
        }

        private void Kontur_P3ТумблерАсинхрСинхр_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.ТумблерАсинхрСинхр = Kontur_P3Parameters.ТумблерАсинхрСинхр == EТумблерАсинхрСинхр.СИНХР
                ? EТумблерАсинхрСинхр.АСИНХР
                : EТумблерАсинхрСинхр.СИНХР;
        }

        private void Kontur_P3ТумблерРежим_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.ТумблерРежим = Kontur_P3Parameters.ТумблерРежим == EТумблерРежим.РЕЖИМ_1
                ? EТумблерРежим.РЕЖИМ_2
                : EТумблерРежим.РЕЖИМ_1;
        }

        #endregion

        #region Круглые кнопки
        private void Kontur_P3КнопкаПуск_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаПуск.BackgroundImage = null;
        }

        private void Kontur_P3КнопкаПуск_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаПуск.BackgroundImage = ControlElementImages.buttonRoundType8;
        }
        #endregion

        #region КП7
        #region Тумблеры
        private void ТумблерСеть_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.ТумблерСеть = Kontur_P3Parameters.ТумблерСеть == EТумблерСеть.ОТКЛ
               ? EТумблерСеть.ВКЛ
               : EТумблерСеть.ОТКЛ;
        }
        #endregion

        #region Переключатели
        private void ПереключательКонтроль_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Kontur_P3Parameters.ПереключательКонтроль += 1;
            }

            if (e.Button == MouseButtons.Right)
            {
                Kontur_P3Parameters.ПереключательКонтроль -= 1;
            }
        }
        #endregion
        #endregion

        #region КП5
        #region Кнопки
        private void КнопкаАдресУСС_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаАдресУСС = !Kontur_P3Parameters.КнопкаАдресУСС;
            if (Kontur_P3Parameters.КнопкаАдресУСС)
            {
                КнопкаАдресУСС.BackgroundImage = null;
                КнопкаАдресУСС.Text = "";
            }
            else
            {
                КнопкаАдресУСС.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
                КнопкаАдресУСС.Text = "УСС";
            }
        }

        private void КнопкаАдресК_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаАдресК = !Kontur_P3Parameters.КнопкаАдресК;
            if (Kontur_P3Parameters.КнопкаАдресК)
            {
                КнопкаАдресК.BackgroundImage = null;
                КнопкаАдресК.Text = "";
            }
            else
            {
                КнопкаАдресК.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
                КнопкаАдресК.Text = "К";
            }
        }

        private void КнопкаПодпись1_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаПодпись1 = !Kontur_P3Parameters.КнопкаПодпись1;
            if (Kontur_P3Parameters.КнопкаПодпись1)
            {
                КнопкаПодпись1.BackgroundImage = null;
                КнопкаПодпись1.Text = "";
            }
            else
            {
                КнопкаПодпись1.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                КнопкаПодпись1.Text = "1";
            }
        }

        private void КнопкаПодпись2_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаПодпись2 = !Kontur_P3Parameters.КнопкаПодпись2;
            if (Kontur_P3Parameters.КнопкаПодпись2)
            {
                КнопкаПодпись2.BackgroundImage = null;
                КнопкаПодпись2.Text = "";
            }
            else
            {
                КнопкаПодпись2.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                КнопкаПодпись2.Text = "2";
            }
        }

        private void КнопкаПодпись3_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаПодпись3 = !Kontur_P3Parameters.КнопкаПодпись3;
            if (Kontur_P3Parameters.КнопкаПодпись3)
            {
                КнопкаПодпись3.BackgroundImage = null;
                КнопкаПодпись3.Text = "";
            }
            else
            {
                КнопкаПодпись3.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                КнопкаПодпись3.Text = "3";
            }
        }

        private void Kontur_P3КнопкаГруппа_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаГруппа.BackgroundImage = null;
        }

        private void Kontur_P3КнопкаГруппа_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаГруппа.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Kontur_P3Parameters.ПоменятьГруппу();
        }

        private void Kontur_P3КнопкаОбщийС_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОбщийС.BackgroundImage = null;
            КнопкаОбщийС.Text = null;
        }

        private void Kontur_P3КнопкаОбщийС_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОбщийС.BackgroundImage = ControlElementImages.buttonSquareRed_small;
            КнопкаОбщийС.Text = "C";
            Kontur_P3Parameters.СбросОбщий();
        }

        private void КнопкаВызов_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаВызов.BackgroundImage = null;
            Kontur_P3Parameters.КнопкаВызов = true;
        }

        private void КнопкаВызов_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаВызов.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
        }

        private void Kontur_P3КнопкаОтбой_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОтбой.BackgroundImage = null;
        }

        private void Kontur_P3КнопкаОтбой_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОтбой.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
        }

        private void Kontur_P3КнопкаИнформ_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаИнформ.BackgroundImage = null;
            Kontur_P3Parameters.КнопкаИнформ = true;
        }

        private void Kontur_P3КнопкаИнформ_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаИнформ.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
        }

        private void Kontur_P3КнопкаНаборКК_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаНаборКК.BackgroundImage = null;
            КнопкаНаборКК.Text = null;
            Kontur_P3Parameters.КнопкаНаборКК = !Kontur_P3Parameters.КнопкаНаборКК;
        }

        private void Kontur_P3КнопкаНаборКК_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаНаборКК.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            КнопкаНаборКК.Text = "ПРМ";
        }

        private void КнопкаКонтрольЗанятости_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.КнопкаКонтрольЗанятости = !Kontur_P3Parameters.КнопкаКонтрольЗанятости;
            КнопкаКонтрольЗанятости.BackgroundImage = Kontur_P3Parameters.КнопкаКонтрольЗанятости
                ? null
                : ControlElementImages.buttonSquareBlack_small;
        }

        private void Kontur_P3КнопкаОтклЗС_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаОтклЗС.BackgroundImage = null;
        }

        private void Kontur_P3КнопкаОтклЗС_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаОтклЗС.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
        }
        private void Kontur_P3Кнопка7_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка7.BackgroundImage = null;
            Кнопка7.Text = null;
        }

        private void Kontur_P3Кнопка7_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка7.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка7.Text = " 7";
            Kontur_P3Parameters.НажатаКнопка(7);
        }

        private void Kontur_P3Кнопка8_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка8.BackgroundImage = null;
            Кнопка8.Text = null;
        }

        private void Kontur_P3Кнопка8_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка8.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка8.Text = " 8";
            Kontur_P3Parameters.НажатаКнопка(8);
        }

        private void Kontur_P3Кнопка9_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка9.BackgroundImage = null;
            Кнопка9.Text = null;
        }

        private void Kontur_P3Кнопка9_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка9.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка9.Text = " 9";
            Kontur_P3Parameters.НажатаКнопка(9);
        }

        private void Kontur_P3Кнопка4_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка4.BackgroundImage = null;
            Кнопка4.Text = null;
        }

        private void Kontur_P3Кнопка4_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка4.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка4.Text = " 4";
            Kontur_P3Parameters.НажатаКнопка(4);
        }

        private void Kontur_P3Кнопка5_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка5.BackgroundImage = null;
            Кнопка5.Text = null;
        }

        private void Kontur_P3Кнопка5_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка5.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка5.Text = " 5";
            Kontur_P3Parameters.НажатаКнопка(5);
        }

        private void Kontur_P3Кнопка6_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка6.BackgroundImage = null;
            Кнопка6.Text = null;
        }

        private void Kontur_P3Кнопка6_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка6.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка6.Text = " 6";
            Kontur_P3Parameters.НажатаКнопка(6);
        }

        private void Kontur_P3Кнопка1_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка1.BackgroundImage = null;
            Кнопка1.Text = null;
        }

        private void Kontur_P3Кнопка1_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка1.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка1.Text = " 1";
            Kontur_P3Parameters.НажатаКнопка(1);
        }

        private void Kontur_P3Кнопка2_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка2.BackgroundImage = null;
            Кнопка2.Text = null;
        }

        private void Kontur_P3Кнопка2_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка2.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка2.Text = " 2";
            Kontur_P3Parameters.НажатаКнопка(2);
        }

        private void Kontur_P3Кнопка3_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка3.BackgroundImage = null;
            Кнопка3.Text = null;
        }

        private void Kontur_P3Кнопка3_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка3.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка3.Text = " 3";
            Kontur_P3Parameters.НажатаКнопка(3);
        }

        private void Kontur_P3Кнопка0_MouseDown(object sender, MouseEventArgs e)
        {
            Кнопка0.BackgroundImage = null;
            Кнопка0.Text = null;
        }

        private void Kontur_P3Кнопка0_MouseUp(object sender, MouseEventArgs e)
        {
            Кнопка0.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
            Кнопка0.Text = " 0";
            Kontur_P3Parameters.НажатаКнопка(0);
        }

        private void Kontur_P3КнопкаИнформКОН_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаИнформКОН.BackgroundImage = null;
            КнопкаИнформКОН.Text = null;
        }

        private void Kontur_P3КнопкаИнформКОН_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаИнформКОН.BackgroundImage = ControlElementImages.buttonSquareRed_small;
            КнопкаИнформКОН.Text = "КОН";
            Kontur_P3Parameters.НажатаКнопкаКонец();
        }

        private void Kontur_P3КнопкаИнформС_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаИнформС.BackgroundImage = null;
            КнопкаИнформС.Text = null;
        }

        private void Kontur_P3КнопкаИнформС_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаИнформС.BackgroundImage = ControlElementImages.buttonSquareRed_small;
            КнопкаИнформС.Text = "С";
        }
        #endregion

        #region Тумблеры
        private void ТумблерМткПУ_Click(object sender, System.EventArgs e)
        {
            this.ТумблерМткПУ.BackgroundImage = Kontur_P3Parameters.ТумблерМткПУ == EТумблерМткПУ.МТК
                ? ControlElementImages.tumblerType4Down
                : ControlElementImages.tumblerType4Up;
            Kontur_P3Parameters.ТумблерМткПУ = Kontur_P3Parameters.ТумблерМткПУ == EТумблерМткПУ.МТК
                ? EТумблерМткПУ.ПУ
                : EТумблерМткПУ.МТК;

        }
        #endregion
        #endregion

        #region КП4
        private void КнопкаКП4Контроль_MouseClick(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КнопкаКП4Контроль = !Kontur_P3Parameters.КнопкаКП4Контроль;
            КнопкаКП4Контроль.BackgroundImage = (Kontur_P3Parameters.КнопкаКП4Контроль)
                ? null
                : ControlElementImages.buttonRoundType8;
        }
        private void КнопкаКП4Контроль_MouseDown(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КП4Контроль = true;
            if (!Kontur_P3Parameters.КнопкаКП4Контроль)
            {
                КнопкаКП4Контроль.BackgroundImage = null;
            }
        }

        private void КнопкаКП4Контроль_MouseUp(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КП4Контроль = false;
            if(!Kontur_P3Parameters.КнопкаКП4Контроль)
                КнопкаКП4Контроль.BackgroundImage = ControlElementImages.buttonRoundType8;
        }
        
        #endregion

        #region КП3
        private void Kontur_P3КнопкаКан10_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаКан10.BackgroundImage = null;
            Kontur_P3Parameters.НажатаКнопкаКанал10();
            Kontur_P3Parameters.КнопкаКП3Канал10 = true;
        }

        private void Kontur_P3КнопкаКан10_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаКан10.BackgroundImage = ControlElementImages.buttonRoundType8;
            Kontur_P3Parameters.КнопкаКП3Канал10 = false;
        }

        private void Kontur_P3КнопкаКан11_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаКан11.BackgroundImage = null;
            Kontur_P3Parameters.НажатаКнопкаКанал11();
            Kontur_P3Parameters.КнопкаКП3Канал11 = true;
        }

        private void Kontur_P3КнопкаКан11_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаКан11.BackgroundImage = ControlElementImages.buttonRoundType8;
            Kontur_P3Parameters.КнопкаКП3Канал11 = false;
        }

        private void Kontur_P3КнопкаКан12_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаКан12.BackgroundImage = null;
            Kontur_P3Parameters.НажатаКнопкаКанал12();
            Kontur_P3Parameters.КнопкаКП3Канал12 = true;
        }

        private void Kontur_P3КнопкаКан12_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаКан12.BackgroundImage = ControlElementImages.buttonRoundType8;
            Kontur_P3Parameters.КнопкаКП3Канал12 = false;
        }
        #endregion

        #region КП2
        private void Kontur_P3КнопкаСдвиг1_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаСдвиг1.BackgroundImage = null;
            Kontur_P3Parameters.НажатаКнопкаСдвиг1();
        }

        private void Kontur_P3КнопкаСдвиг1_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаСдвиг1.BackgroundImage = ControlElementImages.buttonRoundType8;
        }

        private void Kontur_P3КнопкаСдвиг10_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаСдвиг10.BackgroundImage = null;
        }

        private void Kontur_P3КнопкаСдвиг10_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаСдвиг10.BackgroundImage = ControlElementImages.buttonRoundType8;
        }

        private void Kontur_P3КнопкаНачИнформ_MouseDown(object sender, MouseEventArgs e)
        {
            КнопкаНачИнформ.BackgroundImage = null;
            Kontur_P3Parameters.НажатаКнопкаНачалоИнформации();
        }

        private void Kontur_P3КнопкаНачИнформ_MouseUp(object sender, MouseEventArgs e)
        {
            КнопкаНачИнформ.BackgroundImage = ControlElementImages.buttonRoundType8;
        }
        #endregion

        #region КП1
        #region Кнопки
        private void КнопкаКП1Контроль_Click(object sender, System.EventArgs e)
        {
            Kontur_P3Parameters.КнопкаКП1Контроль = !Kontur_P3Parameters.КнопкаКП1Контроль;
            КнопкаКП1Контроль.BackgroundImage = (Kontur_P3Parameters.КнопкаКП1Контроль)
                ? null
                : ControlElementImages.buttonRoundType8;
        }
        private void КнопкаКП1Контроль_MouseDown(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КП1Контроль = true;
            if (!Kontur_P3Parameters.КнопкаКП1Контроль)
                КнопкаКП1Контроль.BackgroundImage = null;
        }

        private void КнопкаКП1Контроль_MouseUp(object sender, MouseEventArgs e)
        {
            Kontur_P3Parameters.КП1Контроль = false;
            if (!Kontur_P3Parameters.КнопкаКП1Контроль)
                КнопкаКП1Контроль.BackgroundImage = ControlElementImages.buttonRoundType8;
        }
        #endregion
        #endregion

        #region Обновление формы
        public void RefreshFormElements()
        {
            try
            {
                #region КП7
                #region Тумблеры
                this.ТумблерСеть.BackgroundImage = Kontur_P3Parameters.ТумблерСеть == EТумблерСеть.ОТКЛ
                   ? ControlElementImages.tumblerType4Down
                   : ControlElementImages.tumblerType4Up;
                #endregion

                #region Индикатор Сеть
                var angle = Kontur_P3Parameters.ИндикаторСеть * 1.15F;
                ИндикаторСеть.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.arrow2, angle);
                #endregion

                #region Переключатели
                angle = (int)Kontur_P3Parameters.ПереключательКонтроль * 36 - 180;
                ПереключательКонтроль.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);
                #endregion

                #region Лампочки
                ЛампочкаСеть.BackgroundImage = Kontur_P3Parameters.ЛампочкаСеть
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                #endregion
                #endregion

                #region КП6
                #region Тумблеры
                this.ТумблерДокументирование.BackgroundImage = Kontur_P3Parameters.ТумблерДокументирование == EТумблерДокументирование.ОТКЛ
                   ? ControlElementImages.tumblerType4Down
                   : ControlElementImages.tumblerType4Up;

                this.ТумблерАсинхрСинхр.BackgroundImage = Kontur_P3Parameters.ТумблерАсинхрСинхр == EТумблерАсинхрСинхр.СИНХР
                   ? ControlElementImages.tumblerType4Down
                   : ControlElementImages.tumblerType4Up;

                this.ТумблерРежим.BackgroundImage = Kontur_P3Parameters.ТумблерРежим == EТумблерРежим.РЕЖИМ_1
                   ? ControlElementImages.tumblerType4Down
                   : ControlElementImages.tumblerType4Up;
                #endregion
                #endregion


                #region КП5
                #region Тумблеры
                this.ТумблерМткПУ.BackgroundImage = Kontur_P3Parameters.ТумблерМткПУ == EТумблерМткПУ.ПУ
                    ? ControlElementImages.tumblerType4Down
                    : ControlElementImages.tumblerType4Up;
                #endregion

                #region Кнопки
                КнопкаКонтрольЗанятости.BackgroundImage = Kontur_P3Parameters.КнопкаКонтрольЗанятости
                ? null
                : ControlElementImages.buttonSquareBlack_small;
                if (Kontur_P3Parameters.КнопкаАдресУСС)
                {
                    КнопкаАдресУСС.BackgroundImage = null;
                    КнопкаАдресУСС.Text = "";
                }
                else
                {
                    КнопкаАдресУСС.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
                    КнопкаАдресУСС.Text = "УСС";
                }

                if (Kontur_P3Parameters.КнопкаАдресК)
                {
                    КнопкаАдресК.BackgroundImage = null;
                    КнопкаАдресК.Text = "";
                }
                else
                {
                    КнопкаАдресК.BackgroundImage = ControlElementImages.buttonSquareBlack_small;
                    КнопкаАдресК.Text = "К";
                }

                if (Kontur_P3Parameters.КнопкаПодпись1)
                {
                    КнопкаПодпись1.BackgroundImage = null;
                    КнопкаПодпись1.Text = "";
                }
                else
                {
                    КнопкаПодпись1.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                    КнопкаПодпись1.Text = "1";
                }

                if (Kontur_P3Parameters.КнопкаПодпись2)
                {
                    КнопкаПодпись2.BackgroundImage = null;
                    КнопкаПодпись2.Text = "";
                }
                else
                {
                    КнопкаПодпись2.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                    КнопкаПодпись2.Text = "2";
                }

                if (Kontur_P3Parameters.КнопкаПодпись3)
                {
                    КнопкаПодпись3.BackgroundImage = null;
                    КнопкаПодпись3.Text = "";
                }
                else
                {
                    КнопкаПодпись3.BackgroundImage = ControlElementImages.buttonSquareRed_small;
                    КнопкаПодпись3.Text = "3";
                }
                #endregion

                #region Лампочки
                ЛампочкаСбойПодписи.BackgroundImage = Kontur_P3Parameters.ЛампочкаСбойПодписи
                    ? ControlElementImages.lampType5OnRed
                    : null;
                ЛампочкаНеиспр.BackgroundImage = Kontur_P3Parameters.ЛампочкаНеиспр
                    ? ControlElementImages.lampType5OnRed
                    : null;
                ЛампочкаПередача.BackgroundImage = Kontur_P3Parameters.ЛампочкаПередача
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП5Прием.BackgroundImage = Kontur_P3Parameters.ЛампочкаПрием
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаИнформПринята.BackgroundImage = Kontur_P3Parameters.ЛампочкаИнформПринята
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКонтроль.BackgroundImage = Kontur_P3Parameters.ЛампочкаКонтроль
                    ? ControlElementImages.lampType5OnRed
                    : null;
                #endregion

                #region Табло
                try
                {
                    ТаблоАдрес1.Text = Kontur_P3Parameters.ТаблоАдрес1;
                    ТаблоАдрес2.Text = Kontur_P3Parameters.ТаблоАдрес2;
                    ТаблоГруппа.Text = Kontur_P3Parameters.ТаблоГруппа;
                    ТаблоИнформация.Text = Kontur_P3Parameters.ТаблоИнформация;
                }
                catch
                {
                }
                #endregion
                #endregion

                #region КП4
                ЛампочкаКП4Канал1.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал1)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал2.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал2)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал3.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал3)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал4.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал4)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал5.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал5)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал6.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал6)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал7.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал7)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал8.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал8)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП4Канал9.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП4Канал9)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                КнопкаКП4Контроль.BackgroundImage = (Kontur_P3Parameters.КнопкаКП4Контроль)
                    ? null
                    : ControlElementImages.buttonRoundType8;
                #endregion

                #region КП3
                #region Лампочки
                ЛампочкаКП3Канал10.BackgroundImage = Kontur_P3Parameters.ЛампочкаКП3Канал10
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП3Канал11.BackgroundImage = Kontur_P3Parameters.ЛампочкаКП3Канал11
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП3Канал12.BackgroundImage = Kontur_P3Parameters.ЛампочкаКП3Канал12
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                #endregion
                #region Переключатели
                angle = (int)Kontur_P3Parameters.ПереключательПриоритет * 36 - 162;
                ПереключательПриоритет.BackgroundImage =
                    TransformImageHelper.RotateImageByAngle(ControlElementImages.toggleType6, angle);
                #endregion
                #endregion

                #region КП2
                #region Тумблеры
                this.ТумблерКонтроль.BackgroundImage = Kontur_P3Parameters.ТумблерКонтроль == EТумблерКонтроль.КОНТРОЛЬ_1
                   ? ControlElementImages.tumblerType4Down
                   : ControlElementImages.tumblerType4Up;
                #endregion
                #region Лампочки
                ЛампочкаКП2Прием.BackgroundImage = Kontur_P3Parameters.ЛампочкаКП2Прием
                   ? ControlElementImages.lampType9OnGreen
                   : null;
                #endregion
                #endregion

                #region КП1
                #region Кнопки
                КнопкаКП1Контроль.BackgroundImage = (Kontur_P3Parameters.КнопкаКП1Контроль)
                ? null
                : ControlElementImages.buttonRoundType8;
                #endregion

                #region Лампочки
                ЛампочкаКП1Канал10.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП1Канал10)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКП1Канал11.BackgroundImage = (Kontur_P3Parameters.ЛампочкаКП1Канал11)
                    ? ControlElementImages.lampType9OnGreen
                   : null;
                ЛампочкаКонтрольПодписи.BackgroundImage = Kontur_P3Parameters.ЛампочкаКонтрольПодписи
                    ? ControlElementImages.lampType5OnRed
                    : null;
                #endregion

                #region Табло
                ТаблоКП2Информация1.Text = Kontur_P3Parameters.ТекущееЗначение1КП2;
                ТаблоКП2Информация2.Text = Kontur_P3Parameters.ТекущееЗначение2КП2;
                ТаблоКП2Группа.Text = Kontur_P3Parameters.ТекущееЗначениеГрупыКП2;
                #endregion
                #endregion
            }
            catch
            {
            }

        }
        #endregion

        

       

        
    }
}