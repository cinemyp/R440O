using System;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Extensions.Forms;

using R440O.R440OForms.R440O;
using R440O.R440OForms.C300M_1;
using R440O.R440OForms.N502B;
using R440O.R440OForms.N18_M;
using R440O.R440OForms.BMA_M_1;
using R440O.R440OForms.BMB;
using R440O.R440OForms.A1;
using R440O.R440OForms.B1_1;
using R440O.R440OForms.A205M_1;
using R440O.R440OForms.N15Inside;
using R440O.R440OForms.N18_M_H28;
using R440O.R440OForms.K05M_01;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.K03M_01;
using ShareTypes.SignalTypes;

namespace R440O.Test.MainTest
{
    /// <summary>
    /// ВНИМАНИЕ! Установите NUnit.Extensions.Forms из папки ./libs!
    /// В связи со статичностью классов параметров не возможно окончательно востановить контекст после
    /// выполнения теста. Поэтому если какие-то тесты не проходят, нужно попробовать запустить их отдельно.
    /// </summary>
    [TestFixture]
    class MainTestClass
    {
        [OneTimeSetUp]
        public void SetUpFixture()
        {
            ParametersConfig.SetParameters();
        }

        [SetUp]
        public void SetUpTest()
        {
            OpenR440O();
            N15StrartStation();
            C300M_1Parameters.ЗначениеПоиска = 0;
        }

        [TearDown]
        public void TearDownTest()
        {
            ResetStation();
            CloseR440O();
        }


        private void OpenR440O()
        {
            var r440o = new R440OForm();
            r440o.Show();
        }

        private void CloseR440O()
        {
            Thread.Sleep(2000);
            var formTester = new FormTester("R440OForm");
            formTester.Close();
        }

        private void SetDiscret2()
        {
            A1Parameters.КнопкаСкоростьАб_1ТЛФК = true;
            B1_1Parameters.КнопкаСкоростьАб1ТлфК = true;
        }

        private void SetDiscret3()
        {
            A1Parameters.КнопкаСкоростьГр = true;
            B1_1Parameters.КнопкаСкоростьГР = true;

            // Переключение на скорость 2.4
            N15InsideParameters.ПереключательПУЛ48ПРД_1 = 2;
            N15InsideParameters.ПереключательПУЛ48ПРД_2 = 2;
            N15InsideParameters.ПереключательПУЛ480ПРМ_1 = 2;
            N15InsideParameters.ПереключательПУЛ480ПРМ_2 = 2;
            C300M_1Parameters.КнопкиВидРаботы[4] = true;         
        }

        private void ResetStation()
        {
            A1Parameters.КнопкаСкоростьАб_1ТЛФК = false;
            B1_1Parameters.КнопкаСкоростьАб1ТлфК = false;
            A1Parameters.КнопкаСкоростьГр = false;
            B1_1Parameters.КнопкаСкоростьГР = false;
            N15InsideParameters.ПереключательПУЛ48ПРД_1 = 3;
            N15InsideParameters.ПереключательПУЛ48ПРД_2 = 3;
            N15InsideParameters.ПереключательПУЛ480ПРМ_1 = 3;
            N15InsideParameters.ПереключательПУЛ480ПРМ_2 = 3;
            C300M_1Parameters.КнопкиВидРаботы[5] = true;
            BMA_M_1Parameters.ПереключательРежимы = 2;
            N18_M_H28Parameters.АктивныйКабель = 0;

            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_Б11] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал2_Б11] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал3_Б11] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА2] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_К12] = 0;
            N18_MParameters.Соединения[(int)ГнездаН18.Контроль_Прм_Тлф1] = 0;
        }

        private void N15StrartStation()
        {
            var buttonN15Tester = new ButtonTester("R440OButtonN15", "R440OForm");
            buttonN15Tester.FireEvent("Click");
            var button = new ButtonTester("КнопкаСтанцияВкл", "N15Form");
            button.FireEvent("MouseDown", new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            button.FireEvent("MouseUp", new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
            Thread.Sleep(2000);
        }

        /// <summary>
        /// Проверка по малому шлейфу
        /// </summary>
        [Test]
        public void MainTest()
        {
            Application.DoEvents();
            Assert.IsTrue(C300M_1Parameters.СигналПойман);
        }

        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 1), Браслета по 1вому каналу
        /// </summary>
        [Test]
        public void DiscreteTest1()
        {
            // Соеденияем 1вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_Б11;

            // Сигнал с 1вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 4;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 1), Браслета по 2вому каналу
        /// </summary>
        [Test]
        public void DiscreteTest2()
        {
            // Соеденияем 1вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал2_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал2_Б11;

            // Сигнал с 1вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 5;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 1), Браслета по 3тьему каналу
        /// </summary>
        [Test]
        public void DiscreteTest3()
        {
            // Соеденияем 3вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал3_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал3_Б11;

            // Сигнал с 3вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 6;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 2), Браслета по 1вому каналу
        /// </summary>
        [Test]
        public void DiscreteTest4()
        {
            SetDiscret2();

            BMA_M_1Parameters.ПереключательРежимы = 1;

            // Соеденияем 1вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_Б11;

            // Сигнал с 1вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 4;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 2), Браслета по 2вому каналу
        /// </summary>
        [Test]
        public void DiscreteTest5()
        {
            SetDiscret2();

            // Соеденияем 1вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал2_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал2_Б11;

            // Сигнал с 1вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 5;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }
            
        /// <summary>
        /// Проверка по малому шлефу и проверка Дискрета (Режим 2), Браслета по 2вому каналу
        /// </summary>
        [Test]
        public void DiscreteTest6()
        {
            SetDiscret3();

            // Соеденияем 1вый канал Б1 с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал2_Б11]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал2_Б11;

            // Сигнал с 1вого канала подается на БМА 1
            N18_MParameters.ПереключательПрдБма12 = 5;

            // Сигнал с А1 подается на А205
            N18_MParameters.ПереключательПРД = 2;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        /// <summary>
        /// Проверка по малому шлефу в помехозащитном режиме
        /// </summary>
        [Test]
        public void KulonTest()
        {
            // Соеденияем Кулог с БМА1
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_К12]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_К12;
            N18_MParameters.ПереключательПрдБма12 = 9;
            N18_MParameters.ПереключательВходК121 = 2;
            
            // Настраиваем Кулон
            N18_M_H28Parameters.АктивныйКабель = 1;
            K05M_01Parameters.ПереключательПередачаКонтроль = 0;

            // Престроим частоту приема, чтобы следующий тик таймера нашел сигнал
            K04M_01Parameters.ПереключательПрмКгц100 = 5;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;
            
            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }

        [Test]
        public void BrasletTest()
        {
            // Подлючаем Браслет
            N18_MParameters.Соединения[(int)ГнездаН18.Контроль_Прм_Тлф1]
                = (int)ГнездаН18.КоммутацияПрм_Канал1_БМА1;
            N18_MParameters.Соединения[(int)ГнездаН18.КоммутацияПрм_Канал1_БМА1]
                = (int)ГнездаН18.Контроль_Прм_Тлф1;
            N18_MParameters.ПереключательПРД = 3;
            N18_MParameters.ПереключательПрдБма12 = 7;

            BMBParameters.КнопкаПередачаВызоваДк = СостоянияЭлементов.БМБ.Кнопка.Нажата;

            Application.DoEvents();

            Assert.IsTrue(BMBParameters.ЛампочкаДк);
        }
    }
}
