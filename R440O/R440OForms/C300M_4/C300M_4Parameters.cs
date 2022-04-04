using System;
using ShareTypes.SignalTypes;
using R440O.InternalBlocks;
using R440O.R440OForms.A304;
using R440O.R440OForms.A306;
using R440O.R440OForms.N15;
using R440O.ThirdParty;
using System.Collections.Generic;
using System.Windows.Forms;

namespace R440O.R440OForms.C300M_4
{
    public class C300M_4Parameters
    {
        private static C300M_4Parameters instance;
        public static C300M_4Parameters getInstance()
        {
            if (instance == null)
                instance = new C300M_4Parameters();
            return instance;
        }

        #region Private

        private bool _сигналПойман = false;
        private bool _кнопкаВидРаботыСброс;
        private bool _кнопкаКонтрольРежимаМинус27;
        private bool _кнопкиПитание;
        private bool _кнопкаПоиск;
        private bool _кнопкаИндикацияВолны;
        private int _переключательВолна1000 = 0;
        private int _переключательВолна100 = 0;
        private int _переключательВолна10 = 0;
        private int _переключательВолна1 = 0;
        private bool _тумблерУправление;
        private bool _тумблерВведение;
        private bool _тумблерБлокировка;
        private bool _тумблерВидВключения;
        private bool _тумблерАнализСимметрии;
        private bool _тумблерРегулировкаУровня;
        private bool _тумблерАСЧ;
        private bool _тумблерВидМодуляции;
        private bool _тумблерПределы;

        #endregion

        #region Таймеры

        public bool OnLeft = false;

        public Timer ТаймерПоискаСигнала = new Timer();
        public Timer ТаймерПроверкиПойманногоСигнала = new Timer();

        #endregion

        #region Параметры Включен/НеполноеВключение

        public bool НеполноеВключение
        {
            get { return N15Parameters.getInstance().Включен; }
        }

        public bool Включен
        {
            get
            {
                return НеполноеВключение &&
                       ((ТумблерУправление && N15Parameters.getInstance().ТумблерЦ300М4) || (!ТумблерУправление && КнопкиПитание));
            }
        }

        #endregion

        #region Кнопки ВИД РАБОТЫ

        /// <summary>
        /// Названия кнопок:
        /// 0 - 0.025,
        /// 1 - 0.05,
        /// 2 - 0.1,
        /// 3 - 1.2,
        /// 4 - 2.4,
        /// 5 - 4.8,
        /// 6 - 48,
        /// 7 - 96/144,
        /// 8 - 240,
        /// 9 - 480.
        /// </summary>
        public C300M_4КнопкиВидРаботы КнопкиВидРаботы = new C300M_4КнопкиВидРаботы();

        public class C300M_4КнопкиВидРаботы
        {
            public bool[] КнопкиВидРаботы = { false, false, false, false, false, false, false, false, false, false, false };

            public bool this[int buttonNumber]
            {
                get { return КнопкиВидРаботы[buttonNumber]; }
                set
                {
                    for (int i = 0; i < 10; i++)
                        КнопкиВидРаботы[i] = false;

                    КнопкиВидРаботы[buttonNumber] = true;

                    //По логике должен быть вызов OnParameterChanged и Search
                    //В ResetParameters аналогичный вызов методов
                    getInstance().ResetParameters();
                }
            }

            public int PressedButton
            {
                get { return Array.IndexOf(КнопкиВидРаботы, true); }
            }
        }
        #endregion

        #region Кнопки КОНТРОЛЬ РЕЖИМА
        /// <summary>
        /// Названия кнопок:
        /// 0 - Уровень сигнала,
        /// 1 - Уровень шума,
        /// 2 - '0' АПЧ,
        /// 3 - Поиск,
        /// 4 - ГЕТ-2,
        /// 5 - +5,
        /// 6 - +6.3,
        /// 7 - +27,
        /// 8 - -5,
        /// 9 - -12.6.
        /// </summary>
        public C300M_4КнопкиКонтрольРежима КнопкиКонтрольРежима = new C300M_4КнопкиКонтрольРежима();
        public class C300M_4КнопкиКонтрольРежима
        {
            public bool[] КнопкиКонтрольРежима = { false, false, false, false, false, false, false, false, false, false, false };

            public bool this[int buttonNumber]
            {
                get { return КнопкиКонтрольРежима[buttonNumber]; }
                set
                {
                    for (int i = 0; i < 10; i++)
                        КнопкиКонтрольРежима[i] = false;

                    КнопкиКонтрольРежима[buttonNumber] = value;

                    //По логике должен быть вызов OnParameterChanged и ТаймерПоискаСигналаSet
                    //В ResetParameters аналогичный вызов методов
                    //ТаймерПоискаСигналаSet будет вызвано и Search
                    getInstance().ResetParameters();
                }
            }

            public int PressedButton
            {
                get { return Array.IndexOf(КнопкиКонтрольРежима, true); }
            }
        }
        #endregion

        #region Кнопки ПИТАНИЕ и ПОИСК
        /// <summary>
        /// Кнопки Питание
        /// Данный параметр отвечает за логику кнопок Вкл/Выкл на блоке
        /// </summary>
        public bool КнопкиПитание
        {
            get { return _кнопкиПитание; }
            set
            {
                if (НеполноеВключение)
                {
                    //Если блок включен , то по нажатию на кнопку ВКЛ, значение поиска должно ставиться в -50
                    if (value && Включен)
                    {
                        ЗначениеПоиска = -50;
                    }
                    //Значение не должно менятся при нажатии на кнопки, когда тумблер поставлен дистанционно
                    //при дистанционном отключении параметр должен быть сброшен в ResetParameters()
                    _кнопкиПитание = !ТумблерУправление && value;
                }
                УправлениеПоиском();
                OnParameterChanged();
            }
        }

        public bool КнопкаПоиск
        {
            get { return _кнопкаПоиск; }
            set
            {
                _кнопкаПоиск = value;

                //Если блок включен, поиск не идет, и блокировка не включена, то поиск необходимо запустить снова.
                if (Включен && !ПоискИдет && !ТумблерБлокировка && КнопкаПоиск)
                {
                    if (СигналПойман)
                    {
                        СигналПойман = false;
                        ЗначениеПоиска += 5;
                    }
                    ЗапуститьТаймер();
                }
                OnParameterChanged();
            }
        }
        #endregion

        #region Индикация волны
        /// <summary>
        /// Вспомогательный метод для получения числового значения выставленной волны.
        /// </summary>
        public int ВыставленнаяВолна
        {
            get
            {
                return Включен ?
                    ((ПереключательВолна1000 > 4) ? 4 : ПереключательВолна1000) * 1000 + ПереключательВолна100 * 100 +
                       ПереключательВолна10 * 10 + ПереключательВолна1
                       : 0;
            }
        }

        /// <summary>
        /// 0 - 4
        /// </summary>
        public int ПереключательВолна1000
        {
            get { return _переключательВолна1000; }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательВолна1000 = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 0 - 9
        /// </summary>
        public int ПереключательВолна100
        {
            get { return _переключательВолна100; }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательВолна100 = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 0 - 9
        /// </summary>
        public int ПереключательВолна10
        {
            get { return _переключательВолна10; }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательВолна10 = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// 0 - 9
        /// </summary>
        public int ПереключательВолна1
        {
            get { return _переключательВолна1; }

            set
            {
                if (value >= 0 && value <= 9)
                {
                    _переключательВолна1 = value;
                    OnParameterChanged();
                }
            }
        }

        public bool КнопкаИндикацияВолны
        {
            get { return _кнопкаИндикацияВолны; }
            set
            {
                if (Включен && value)
                    _кнопкаИндикацияВолны = value;
            }
        }

        #endregion

        #region Тумблеры
        /// <summary>
        /// Возможные состояния: true - Дистанционное; false - Местное;
        /// </summary>
        public bool ТумблерУправление
        {
            get { return _тумблерУправление; }
            set
            {
                _тумблерУправление = value;

                //Если блок включен дистанционно и мы переключаем тумблер на местное управление,
                //то питание должно остаться, для этого нужно присвоить КнопкамПитание значение true;
                КнопкиПитание = (!value && N15Parameters.getInstance().ТумблерЦ300М4);
            }
        }

        /// <summary>
        /// Возможные состояния: true - ЧТ, false - ОФТ
        /// </summary>
        public bool ТумблерВведение
        {
            get { return _тумблерВведение; }
            set
            {
                _тумблерВведение = value;
                OnParameterChanged();
            }
        }


        /// <summary>
        /// Возможные состояния: true - Вкл, false - Откл
        /// Если стоит блокировка, то запустить поиск кнопкой поиск нельзя, если был сигнал, то он останется пойманным
        /// Если же шёл поиск, то он останавливается и возобновляется только при отключении тумблера
        /// </summary>
        public bool ТумблерБлокировка
        {
            get { return _тумблерБлокировка; }
            set
            {
                _тумблерБлокировка = value;
                if (value && Включен) ОстановитьТаймер();
                else ЗапуститьТаймер();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - Автоматическое, false - Ручное
        /// Поиск автоматически возобновляется если сигнал был сброшен.
        /// </summary>
        public bool ТумблерВидВключения
        {
            get { return _тумблерВидВключения; }
            set
            {
                _тумблерВидВключения = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - С анализом симметрии, false - Откл
        /// </summary>
        public bool ТумблерАнализСимметрии
        {
            get { return _тумблерАнализСимметрии; }
            set
            {
                _тумблерАнализСимметрии = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - Автоматическое слежение частоты, false - Откл
        /// </summary>
        public bool ТумблерАСЧ
        {
            get { return _тумблерАСЧ; }
            set
            {
                _тумблерАСЧ = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - Автоматическая регулировка уровня, false - Ручная регулировка уровня
        /// </summary>
        public bool ТумблерРегулировкаУровня
        {
            get { return _тумблерРегулировкаУровня; }
            set
            {
                _тумблерРегулировкаУровня = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - ЧТ, false - ОФТ
        /// </summary>
        public bool ТумблерВидМодуляции
        {
            get { return _тумблерВидМодуляции; }
            set
            {
                _тумблерВидМодуляции = value;
                ПопытатьсяСброситьСигнал();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: true - +-60, false - +-300
        /// </summary>
        public bool ТумблерПределы
        {
            get { return _тумблерПределы; }
            set
            {
                _тумблерПределы = value;
                ПопытатьсяСброситьСигнал();
                OnParameterChanged();
            }
        }

        #endregion

        #region Лампочки

        public bool ЛампочкаСигнал
        {
            get { return Включен && !ПоискИдет && СигналПойман || ВременноПоймать; }
        }

        public bool ЛампочкаПитание
        {
            get { return Включен; }
        }

        public bool ЛампочкаПоиск
        {
            get { return Включен && ПоискИдет; }
        }

        #endregion

        #region Индикатор

        private float _индикаторСигнал;
        public float ИндикаторСигнал
        {
            get
            {
                if (НеполноеВключение)
                {
                    if (Включен)
                    {
                        switch (КнопкиКонтрольРежима.PressedButton)
                        {
                            case 0:
                                if (!ЛампочкаСигнал)
                                    return 0;
                                return _индикаторСигнал = (float)((N15Parameters.getInstance().РегуляторУровень - ПойманныйСигнал.Level) / 2);

                            case 1:
                                if (ТумблерРегулировкаУровня)
                                    return _индикаторСигнал = (КнопкиВидРаботы.PressedButton == -1 || КнопкиВидРаботы.PressedButton == 10)
                                        ? 10
                                        : 30;
                                return _индикаторСигнал = (КнопкиВидРаботы.PressedButton == -1 || КнопкиВидРаботы.PressedButton == 10)
                                        ? 10
                                        : 60;
                            case 2:
                                return _индикаторСигнал = 0;
                            case 3:
                                return _индикаторСигнал = _значениеПоиска;
                            case 4:
                                return _индикаторСигнал = 30;
                            case 5:
                            case 6:
                            case 7:
                                return _индикаторСигнал = 41;
                            case 8:
                            case 9:
                                return _индикаторСигнал = -43;
                            case 10:
                                return _индикаторСигнал = -43;
                        }
                    }
                    else
                    {
                        return _индикаторСигнал = (КнопкиКонтрольРежима[7]) ? 41 : 0;
                    }
                }
                return _индикаторСигнал = 0;
            }
        }
        #endregion


        #region Входящий/Выходящий сигналы
        /// <summary>
        /// Переменная для обращения к поступающему сигналу
        /// </summary>
        public BroadcastSignal ВходящийСигнал
        {
            get
            {
                return Включен ? A306Parameters.getInstance().ВыходнойСигнал4 : new BroadcastSignal();
            }
        }

        public Signal ПойманныйСигнал
        {
            get
            {
                if (СигналПойман)
                {
                    foreach (var сигнал in ВходящийСигнал.Signals)
                    {
                        //***Условие на поиск сигнала***//
                        if (УсловиеПоимкиСигнала(сигнал) && СоответствиеМодуляции(сигнал))
                        {
                            return сигнал;
                        }
                    }
                }
                return null;
            }
        }

        #endregion

        #region ПОИСК

        //-----------------------------------------------------------------------------------------------------------------//
        // Поиск на блоке работает в скрытом режиме, и запускается при включении.
        //-----------------------------------------------------------------------------------------------------------------//

        public bool _поискИдет;

        /// <summary>
        /// Переменная флаг, необходимая для запуска и отключения поиска.
        /// </summary>
        public bool ПоискИдет
        {
            get { return _поискИдет; }
            set { _поискИдет = (value && !ТумблерБлокировка); }
        }

        private void ОстановитьТаймер()
        {
            ТаймерПоискаСигнала.Stop();
            ТаймерПоискаСигнала.Tick -= ПоискСигнала;

            ПоискИдет = false;
            ТаймерПоискаСигнала.Enabled = false;
        }

        private void ЗапуститьТаймер()
        {
            ТаймерПоискаСигнала.Stop();
            ТаймерПоискаСигнала.Tick -= ПоискСигнала;

            ПоискИдет = true;
            ТаймерПоискаСигнала.Enabled = true;
            ТаймерПоискаСигнала.Tick += ПоискСигнала;
            ТаймерПоискаСигнала.Start();
        }

        /// <summary>
        /// Метод для управления таймером поиска
        /// Включается при включении и выключении блока
        /// Также при внешних изменениях
        /// </summary>
        [MTAThread]
        public void УправлениеПоиском()
        {
            ТаймерПоискаСигнала.Stop();
            ТаймерПоискаСигнала.Tick -= ПоискСигнала;
            if (!СигналПойман || ПойманныйСигнал == null)
                if (Включен)
                {
                    ПоискИдет = true;
                    ТаймерПоискаСигнала.Enabled = true;
                    ТаймерПоискаСигнала.Tick += ПоискСигнала;
                    ТаймерПоискаСигнала.Start();
                }
                else
                {
                    ПоискИдет = false;
                    ТаймерПоискаСигнала.Enabled = false;
                    ВременноПоймать = false;
                }
        }

        private float _значениеПоиска;

        /// <summary>
        /// Значение для внутреннего поиска, при нажатии на кнопку контроля режима Поиск, данное значение дублируется на индикатор.
        /// </summary>
        public float ЗначениеПоиска
        {
            get { return _значениеПоиска; }
            set
            {
                _значениеПоиска = value;
                if (КнопкиКонтрольРежима[3]) OnIndicatorChanged();
            }
        }

        public bool _временноПоймать = false;

        /// <summary>
        /// Переменная для временной поимки сигнала, при несоответствии модуляции.
        /// </summary>
        public bool ВременноПоймать
        {
            get { return _временноПоймать; }
            set { _временноПоймать = value; }
        }

        public void ПопытатьсяСброситьСигнал()
        {
            ОстановитьТаймер();
            if (ТумблерВидВключения && СигналПойман)
            {
                СигналПойман = false;
                ЗапуститьТаймер();
            }
        }

        /// <summary>
        /// Метод обработки тика таймера, осуществляет изменение значения поиска и проверку на поиск сигнала.
        /// Поиск идёт всегда когда включен блок
        /// </summary>
        private void ПоискСигнала(object sender, EventArgs e)
        {
            ТаймерПоискаСигналаSpeedChange();
            if (ТумблерБлокировка) ПоискИдет = false;
            //Обработка поиска сигнала
            if (ПоискИдет)
            {
                int Predel1 = (ТумблерПределы)
                    ? -35
                    : -50;
                int Predel2 = (ТумблерПределы)
                    ? -20
                    : 50;

                if (OnLeft)
                {
                    ЗначениеПоиска -= 0.3F;
                    if (ЗначениеПоиска < Predel1)
                        OnLeft = false;
                }
                else
                {
                    ЗначениеПоиска += 0.3F;
                    if (ЗначениеПоиска > Predel2)
                        OnLeft = true;
                }


                foreach (var сигнал in ВходящийСигнал.Signals)
                {
                    //***Условие на поиск сигнала***//
                    if (УсловиеПоимкиСигнала(сигнал))
                    {
                        if (СоответствиеМодуляции(сигнал))
                        {
                            ОстановитьТаймер();
                            СигналПойман = true;
                            break;
                        }
                        else
                        {
                            ВременноПоймать = true;
                            break;
                        }
                    }
                    else
                    {
                        СигналПойман = false;
                        if (ВременноПоймать)
                            ВременноПоймать = false;
                    }
                }
            }
            OnParameterChanged();
        }

        #region Второстепенные методы для ПОИСКА



        public bool СигналПойман
        {
            get { return _сигналПойман; }
            set
            {
                var last_value = _сигналПойман;
                _сигналПойман = value;
                if (_сигналПойман ^ last_value)
                {
                    N15Parameters.getInstance().ResetParametersAlternative();
                }
                if (_сигналПойман)
                {
                    ЗапутитьТаймерПроверкиПоймангоСигнала();
                }
                else
                {
                    ОстановитьТаймерПроверкиПоймангоСигнала();
                }
            }
        }

        private void ЗапутитьТаймерПроверкиПоймангоСигнала()
        {
            ОстановитьТаймерПроверкиПоймангоСигнала();
            ТаймерПроверкиПойманногоСигнала.Enabled = true;
            ТаймерПроверкиПойманногоСигнала.Tick += ПроверкаПойманогоСигнала;
            ТаймерПроверкиПойманногоСигнала.Start();
        }

        private void ОстановитьТаймерПроверкиПоймангоСигнала()
        {
            ТаймерПроверкиПойманногоСигнала.Stop();
            ТаймерПроверкиПойманногоСигнала.Tick -= ПроверкаПойманогоСигнала;
            ТаймерПроверкиПойманногоСигнала.Enabled = false;
        }

        private void ПроверкаПойманогоСигнала(object sender, EventArgs e)
        {
            if (ПойманныйСигнал == null)
            {
                СигналПойман = false;
                ResetParameters();
            }
        }

        /// <summary>
        /// Изменение скорости работы таймера
        /// </summary>
        public void ТаймерПоискаСигналаSpeedChange()
        {
            if (ТаймерПоискаСигнала.Enabled)
            {
                ТаймерПоискаСигнала.Interval = (КнопкиВидРаботы.PressedButton == 10 || (КнопкиВидРаботы.PressedButton == -1))
                    ? 10
                    : 100 - КнопкиВидРаботы.PressedButton * 10;
            }
        }

        /// <summary>
        /// Вспомогательный метод, для проверки соответствия модуляции сигнала и выставленных тумблеров модуляции
        /// </summary>
        public bool СоответствиеМодуляции(Signal сигнал)
        {
            return (сигнал.Modulation == Модуляция.ОФТ && !ТумблерВведение &&
                         !ТумблерВидМодуляции) ||
                        (сигнал.Modulation == Модуляция.ЧТ && ТумблерВведение &&
                          ТумблерВидМодуляции);
        }

        /// <summary>
        /// Вспомогательный метод для сравнения скорости сигнала и выставленной кнопки Вид работы
        /// </summary>
        public bool СоответствиеСкорости(Signal сигнал)
        {
            var speed = new[]
                {
                    0.025, 0.05, 0.1, 1.2, 2.4, 4.8, 48, 96, 240, 480, -5
                };

            var tekSpeed = (КнопкиВидРаботы.PressedButton == -1) ? 0 : speed[КнопкиВидРаботы.PressedButton];

            return Math.Abs(сигнал.GroupSpeed - tekSpeed) < 0.005;
        }


        public bool СоответствиеЧастоты(Signal сигнал)
        {
            return (Math.Abs(ЧастотаПоиска - сигнал.Frequency - 70000) <= 300 && !ТумблерПределы ||
                   (Math.Abs(ЧастотаПоиска - сигнал.Frequency - 70000) <= 60 && ТумблерПределы));
        }

        public int ТочкаПоиска(Signal сигнал)
        {
            if (СоответствиеЧастоты(сигнал) && СоответствиеСкорости(сигнал))
            {
                return (!ТумблерПределы) ?
                    (ЧастотаПоиска - сигнал.Frequency - 70000) / 10 : -27 + (ЧастотаПоиска - сигнал.Frequency - 70000) / 10;
            }
            return -10000;
        }

        public bool ШирокополосныйСигнал(Signal сигнал)
        {
            return сигнал.KulonSignal != null;
        }

        /// <summary>
        /// Условие для поимки сигнала
        /// </summary>
        public bool УсловиеПоимкиСигнала(Signal сигнал)
        {
            //При зажатой кнопке поиск сигнал не ловится
            //Сначала проверка на попадание частоты передачи в диапазон
            //Разница между частотой приема, и частотой со 2ого гетеродина должна быть 70Мгц +-300/60 Кгц
            //А также регулятор уровень на Н15 должен быть выше чем уровень сигнала.
            return !КнопкаПоиск && Math.Abs(ЗначениеПоиска - ТочкаПоиска(сигнал)) < 2 &&
                N15Parameters.getInstance().РегуляторУровень > сигнал.Level && !ШирокополосныйСигнал(сигнал);
        }

        /// <summary>
        /// Диапазон частот для поиска приемника вычисляется следующим образом
        /// В соответствии с выставленной волной блок 2ого гетеродина генерирует тактовую частоту в пределах от 390 до 440 МГц
        /// </summary>
        public int ЧастотаПоиска
        {
            get { return ВыставленнаяВолна * 10 + 390000; }
        }
        #endregion

        #endregion

        #region ParameterChanged

        public delegate void ParameterChangedHandler();

        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            //Для сброса питания
            if (!Включен)
            {
                _кнопкиПитание = false;
                _значениеПоиска = -50;
            }
            УправлениеПоиском();
            OnParameterChanged();
        }

        public delegate void IndicatorChangedHandler();

        public event IndicatorChangedHandler IndicatorChanged;

        private void OnIndicatorChanged()
        {
            var handler = IndicatorChanged;
            if (handler != null) handler();
        }

        public void ResetIndicator()
        {
            OnIndicatorChanged();
        }
    }

    #endregion
}
