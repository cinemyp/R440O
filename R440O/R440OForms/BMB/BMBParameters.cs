﻿using R440O.ThirdParty;
using ShareTypes.SignalTypes;
using R440O.R440OForms.N18_M;
using System.Windows.Forms;

namespace R440O.R440OForms.BMB
{
    using N15;
    using N502B;
    using BMA_M_1;
    using BMA_M_2;
    using Parameters;
    using СостоянияЭлементов.БМБ;
    using System;
    using global::R440O.JsonAdapter;

    public class BMBParameters
    {
        private static BMBParameters instance;
        public static BMBParameters getInstance()
        {
            if (instance == null)
                instance = new BMBParameters();
            return instance;
        }
        #region ПереключательРаботаКонтроль

        public int ПереключательРаботаКонтроль
        {
            get { return _переключательРаботаКонтроль; }
            set
            {
                int last_value = _переключательРаботаКонтроль;
                if (value > 0 && value < 3)
                    _переключательРаботаКонтроль = value;
                if (_переключательРаботаКонтроль != last_value)
                {
                    ОбнулитьНабор();
                    ПереданнаяКоманда = string.Empty;
                }
                BMA_M_1Parameters.getInstance().ResetParameters();
                BMA_M_2Parameters.getInstance().ResetParameters();
                ResetParameters();
            }
        }

        private int _переключательРаботаКонтроль = 1;

        #endregion

        #region ПереключательПодключениеРезерва

        /// <summary>
        /// Положение переключателя подключение резерва
        /// </summary>
        private int _переключательПодключениеРезерва = 1;

        public int ПереключательПодключениеРезерва
        {
            get { return _переключательПодключениеРезерва; }
            set
            {
                if (value > 0 && value < 4) _переключательПодключениеРезерва = value;
                if (RefreshForm != null)
                {
                    RefreshForm();
                }
            }
        }

        #endregion

        #region ПереключательНаправление

        /// <summary>
        /// Положение переключателя направления
        /// </summary>
        private int _переключательНаправление = 1;

        public int ПереключательНаправление
        {
            get { return _переключательНаправление; }
            set
            {
                if (value > 0 && value < 5) _переключательНаправление = value;
                if (RefreshForm != null)
                {
                    RefreshForm();
                }
            }
        }

        #endregion

        #region Кнопки

        /// <summary>
        /// Горит, если включено питание и сама кнопка нажата.
        /// При нажатии обнуляется команда набранная на блоке. Включается передача вызова по каналу ТЧ.
        /// </summary>
        public Кнопка КнопкаПередачаВызоваТч
        {
            get
            {
                return КнопкаПитание == Кнопка.Горит
                       && _кнопкаПередачаВызоваТч == Кнопка.Нажата
                    ? Кнопка.Горит
                    : _кнопкаПередачаВызоваТч;
            }
            set
            {
                if (value == Кнопка.Нажата)
                {
                    //   ОбнулитьНабор();
                    //   ПереданнаяКоманда = string.Empty;
                    передачаЦифр = false;
                }
                _кнопкаПередачаВызоваТч = value;
                BMA_M_1Parameters.getInstance().ResetParameters();
                BMA_M_2Parameters.getInstance().ResetParameters();
                if (RefreshForm != null) RefreshForm();
            }
        }

        private Кнопка _кнопкаПередачаВызоваТч;

        /// <summary>
        /// Горит, если включено питание и сама кнопка нажата.
        /// При нажатии обнуляется команда набранная на блоке. Включается передача вызова по каналу ДК.
        /// </summary>
        public Кнопка КнопкаПередачаВызоваДк
        {
            get
            {
                return КнопкаПитание == Кнопка.Горит
                       && _кнопкаПередачаВызоваДк == Кнопка.Нажата
                    ? Кнопка.Горит
                    : _кнопкаПередачаВызоваДк;
            }
            set
            {
                if (value == Кнопка.Нажата)
                {
                    ОбнулитьНабор();
                    ПереданнаяКоманда = string.Empty;
                    передачаЦифр = false;
                }
                _кнопкаПередачаВызоваДк = value;

                BMA_M_1Parameters.getInstance().ResetParameters();
                BMA_M_2Parameters.getInstance().ResetParameters();
                if (RefreshForm != null) RefreshForm();
            }
        }

        private Кнопка _кнопкаПередачаВызоваДк;

        /// <summary>
        /// Горит, если включено питание и сама кнопка нажата.
        /// При нажатии включается режим передачи служебной связи.
        /// </summary>
        public Кнопка КнопкаСлСвязь
        {
            get
            {
                return КнопкаПитание == Кнопка.Горит
                       && _кнопкаСлСвязь == Кнопка.Нажата
                    ? Кнопка.Горит
                    : _кнопкаСлСвязь;
            }
            set
            {
                ОбнулитьНабор();
                _кнопкаСлСвязь = value;
                BMA_M_1Parameters.getInstance().ResetParameters();
                BMA_M_2Parameters.getInstance().ResetParameters();
                if (RefreshForm != null) RefreshForm();
            }
        }

        private Кнопка _кнопкаСлСвязь;

        public Кнопка КнопкаПитание
        {
            get
            {
                return N502BParameters.getInstance().ТумблерВыпрямитель27В
                       && N502BParameters.getInstance().ТумблерЭлектрооборудование
                       && N502BParameters.getInstance().ЛампочкаСфазировано
                       && _кнопкаПитание == Кнопка.Нажата
                    ? Кнопка.Горит
                    : _кнопкаПитание;
            }
            set
            {
                ОбнулитьНабор();
                ПереданнаяКоманда = string.Empty;
                _кнопкаПитание = value;

                BMA_M_1Parameters.getInstance().ResetParameters();
                BMA_M_2Parameters.getInstance().ResetParameters();
                if (RefreshForm != null) RefreshForm();
            }
        }

        private Кнопка _кнопкаПитание;

        /// <summary>
        /// Горит, если включено питание и сама кнопка нажата.
        /// При нажатии включается режим звуковой синализации.
        /// </summary>
        public Кнопка КнопкаЗвСигнал
        {
            get
            {
                return КнопкаПитание == Кнопка.Горит
                     && _кнопкаЗвСигнал == Кнопка.Нажата
                  ? Кнопка.Горит
                  : _кнопкаЗвСигнал;
            }
            set
            {
                _кнопкаЗвСигнал = value;
                if (RefreshForm != null) RefreshForm();
            }
        }

        private Кнопка _кнопкаЗвСигнал;

        #endregion

        #region Лампочки

        /// <summary>
        /// Горит если включена кнопка передачи вызова ДК и режим контроль.
        /// В режиме работа лампочка горит, если правильно настроен блок БМА.
        /// Переменная мерцание лампочки нужна для того, чтобы лампочка моргнула при включении БМА.
        /// </summary>
        private bool _мерцаниеЛампочкиДк;
        public bool ЛампочкаДк
        {
            get
            {
                return _мерцаниеЛампочкиДк || КнопкаПитание == Кнопка.Горит && КнопкаПередачаВызоваДк == Кнопка.Горит
                       && (ПереключательРаботаКонтроль == 2 ||
                           (КнопкаСлСвязь == Кнопка.Горит && ВходнойСигнал != null));
            }
        }


        /// <summary>
        /// Горит если включена кнопка передачи вызова ТЧ и режим контроль.
        /// В режиме работа лампочка горит, если правильно настроен блок БМА.
        /// Переменная мерцание лампочки нужна для того, чтобы лампочка моргнула при включении БМА.
        /// </summary>
        private bool _мерцаниеЛампочкиТч;
        public bool ЛампочкаТч
        {
            get
            {
                return _мерцаниеЛампочкиТч || КнопкаПитание == Кнопка.Горит && КнопкаПередачаВызоваТч == Кнопка.Горит
                       && (ПереключательРаботаКонтроль == 2 ||
                           (КнопкаСлСвязь == Кнопка.Горит && БМАПодключенВерно &&
                            (BMA_M_1Parameters.getInstance().КнопкаШлейфТЧ == 3 && ПереключательНаправление == 1
                            || BMA_M_2Parameters.getInstance().КнопкаШлейфТЧ == 3 && ПереключательНаправление == 2)));
            }
        }

        /// <summary>
        /// Лампочка-табло прием вызова.
        /// </summary>
        public bool ЛампочкаПриемВызова
        {
            get
            {
                return ЛампочкаТч || ЛампочкаДк;
            }
        }

        private bool _лампочкаРезервВкл;

        /// <summary>
        /// Горит если идёт прием вызова и выбрано данное направление.
        /// </summary>
        public bool ЛампочкаНаправление1
        {
            get
            {
                return (ЛампочкаПриемВызова && ПереключательРаботаКонтроль == 1 && ПереключательНаправление == 1) ||
                       _номерМерцающейЛампочкиНаправления == 1;

            }
        }

        public bool ЛампочкаНаправление2
        {
            get
            {
                return (ЛампочкаПриемВызова && ПереключательРаботаКонтроль == 1 && ПереключательНаправление == 2) ||
                       _номерМерцающейЛампочкиНаправления == 2;
            }
        }

        public bool ЛампочкаНаправление3
        {
            get
            {
                return (ЛампочкаПриемВызова && ПереключательРаботаКонтроль == 1 && ПереключательНаправление == 3) ||
                   _номерМерцающейЛампочкиНаправления == 3;
            }
        }

        public bool ЛампочкаНаправление4
        {
            get
            {
                return (ЛампочкаПриемВызова && ПереключательРаботаКонтроль == 1 && ПереключательНаправление == 4) ||
                       _номерМерцающейЛампочкиНаправления == 4;
            }
        }

        public bool ЛампочкаРезервВкл
        {
            get { return _лампочкаРезервВкл; }
            set { _лампочкаРезервВкл = value; }
        }

        #endregion

        #region Мерцание лампочки
        private int _номерМерцающейЛампочкиНаправления = -1;
        /// <summary>
        /// Метод мерцания лампочки перюключателя направления при включении БМА
        /// </summary>
        public void МерцаниеЛампочиНаправления(int НомерНаправления)
        {
            if (КнопкаПитание == Кнопка.Горит)
            {
                _номерМерцающейЛампочкиНаправления = НомерНаправления;
                _мерцаниеЛампочкиДк = true;
                _мерцаниеЛампочкиТч = true;
                ResetParameters();
                EasyTimer.SetTimeout(() =>
                {
                    _номерМерцающейЛампочкиНаправления = -1;
                    _мерцаниеЛампочкиДк = false;
                    _мерцаниеЛампочкиТч = false;
                    ResetParameters();

                }, 500);
            }

        }
        #endregion

        #region НаборКоманды

        /// <summary>
        /// 0 - первый регистр; 1 - второй регистр;
        /// </summary>
        private int[] Команда = { -1, -1 };

        /// <summary>
        /// Правило отображение введеной команды на табло "Набор команды"
        /// </summary>
        /// <returns></returns>
        private bool ПодсветкаНабора()
        {
            return КнопкаПитание == Кнопка.Горит && КнопкаПередачаВызоваДк == Кнопка.Отжата
                && БМАПодключенВерно && ((ПереключательРаботаКонтроль == 1 && КнопкаСлСвязь == Кнопка.Горит)
                    || (ПереключательРаботаКонтроль == 2));
        }

        /// <summary>
        /// Обнуление значени, используемых для вывода информации на табло.
        /// </summary>
        public void ОбнулитьНабор()
        {
            передачаЦифр = false;
            Команда = new[] { -1, -1 };
        }

        /// <summary>
        /// Добавление числа в команду. Число добавляется при определённых условиях.
        /// </summary>
        public void ДобавитьЧисло(int value)
        {
            if (ПодсветкаНабора())
            {
                if (Команда[0] != -1 && Команда[1] == -1)
                    Команда[1] = value;
                else if (value < 3 && Команда[0] == -1)
                {
                    Команда[0] = value;
                }
                else
                    if (Команда[0] != -1 && Команда[1] != -1 && value < 3)
                {
                    //ПереданнаяКоманда = string.Empty;
                    передачаЦифр = false;
                    Команда[0] = value;
                    Команда[1] = -1;
                }
            }

            if (RefreshForm != null) RefreshForm();
        }

        /// <summary>
        /// Обработка вывода информации на табло "Набор Команды" в соответствии с текущими значениями.
        /// </summary>
        public string НаборКоманды
        {
            get
            {
                if (!ПодсветкаНабора() || (Команда[0] == -1 && Команда[1] == -1))
                    return string.Empty;
                var symbol1 = Команда[0] != -1 ? string.Empty + Команда[0] : "-";
                var symbol2 = Команда[1] != -1 ? string.Empty + Команда[1] : "-";
                return symbol1 + symbol2;
            }
        }

        /// <summary>
        /// Команда передаётся, если отжаты режимы ТЧ и ДК, и набрана правильная команда.
        /// </summary>
        public Кнопка КнопкаПередачаКоманды
        {
            get
            {
                if (КнопкаПитание == Кнопка.Горит && КнопкаПередачаВызоваТч != Кнопка.Горит &&
                    КнопкаПередачаВызоваДк != Кнопка.Горит && передачаЦифр && _кнопкаПередачаКоманды == Кнопка.Отжата)
                    return Кнопка.Горит;

                return _кнопкаПередачаКоманды;
            }
            set
            {
                _кнопкаПередачаКоманды = value;
            }
        }

        private bool передачаЦифр;

        #endregion

        #region ПредачаКоманды

        private string ПереданнаяКоманда;
        private Кнопка _кнопкаПередачаКоманды;

        /// <summary>
        /// Обработка нажатия на клавишу передать команду, с правильным заннулением предыдущих цифр.
        /// </summary>
        public void ПередатьКоманду()
        {
            if (КнопкаПитание == Кнопка.Горит)
                передачаЦифр = true;
            // Обработка вынесена из блока приема команды, чтобы не думать отображать команду или нет
            if (ПереключательРаботаКонтроль == 2 && БМАПодключенВерно)
            {
                if (Команда[1] != -1)
                    ПереданнаяКоманда = НаборКоманды;
            }
            else
            {
                if (ВходнойСигнал != null && (!ЛампочкаДк) && Команда[1] != -1)
                    ПереданнаяКоманда = НаборКоманды;
            }
            произвестиПередачу();
        }

        private IDisposable _таймерПередачиКоманды = null;
        private void произвестиПередачу()
        {
            if (_таймерПередачиКоманды != null)
            {
                _таймерПередачиКоманды.Dispose();
            }
            _идетПередачаКоманды = true;
            _таймерПередачиКоманды = EasyTimer.SetTimeout(() =>
            {
                _идетПередачаКоманды = false;
            }, 3000);
            BMA_M_1Parameters.getInstance().ResetParameters();
        }

        #endregion

        #region Прием команды

        /// <summary>
        /// Вывод информации на тамбло "Прием информации". При передаче по ДК высвечивает 0.
        /// </summary>
        public string ПриемКоманды
        {
            get
            {
                if (КнопкаПитание == Кнопка.Горит)
                {
                    if (ВходнойСигнал != null && ПереключательПодключениеРезерва == 1 &&
                        !string.IsNullOrEmpty(ВходнойСигнал.InformationString))
                    {
                        ПереданнаяКоманда = ВходнойСигнал.InformationString;
                    }
                    return ПереданнаяКоманда;
                }
                else
                    return string.Empty;
            }
        }

        #endregion

        #region Сигнал

        /// <summary>
        /// Проверка правильности подключения одного из блоков БМА к БМБ.
        /// </summary>
        /// <returns></returns>
        private bool БМАПодключенВерно
        {
            // Нам срать какой именно подключен
            get
            {
                return БМА1ПодключенВерно || БМА2ПодключенВерно;
            }
        }

        /// <summary>
        /// БМА1 подключен верно
        /// </summary>
        /// <returns></returns>
        private bool БМА1ПодключенВерно
        {
            get
            {
                return BMA_M_1Parameters.getInstance().Питание && ПереключательНаправление == 1;
            }
        }

        /// <summary>
        /// БМА2 подключен верно
        /// </summary>
        /// <returns></returns>
        private bool БМА2ПодключенВерно
        {
            get { return BMA_M_2Parameters.getInstance().Питание && ПереключательНаправление == 2; }
        }

        public Chanel ВходнойСигнал
        {
            get
            {
                if (БМА1ПодключенВерно)
                    return BMA_M_1Parameters.getInstance().СигалНаБМБ;
                if (БМА2ПодключенВерно)
                    return BMA_M_2Parameters.getInstance().СигалНаБМБ;
                return null;
            }
        }

        private bool _идетПередачаКоманды = false;
        public Chanel ВыходнойСигнал
        {
            get
            {
                if (ПереключательРаботаКонтроль == 1)
                {
                    var сигнал = new Chanel(1.2, _идетПередачаКоманды ? ПереданнаяКоманда : "");
                    return сигнал;
                }
                return null;
            }
        }

        #endregion

        #region Таймер

        BMBParameters()
        {
            таймерОбновленияФормы.Tick += тикТаймераОбновленияФормы;
            таймерОбновленияФормы.Enabled = true;
            таймерОбновленияФормы.Interval = 1000;
            таймерОбновленияФормы.Start();
        }

        private Timer таймерОбновленияФормы = new Timer();

        private void тикТаймераОбновленияФормы(object sender, EventArgs e)
        {
            ResetParameters();
        }

        #endregion
        public delegate void TestModuleHandler(ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new ActionStation(name, value);
            Action?.Invoke(action);
        }

        public void ResetParameters()
        {
            if (RefreshForm != null) RefreshForm();
        }

        public delegate void VoidVoidSignature();
        public event VoidVoidSignature RefreshForm;
    }
}
