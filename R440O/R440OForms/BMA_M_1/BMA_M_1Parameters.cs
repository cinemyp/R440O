using R440O.R440OForms.BMB;
using R440O.R440OForms.N502B;
using R440O.R440OForms.TLF_TCH;
using R440O.R440OForms.N15;
using R440O.ThirdParty;
using ShareTypes.SignalTypes;
using R440O.R440OForms.N18_M;
using R440O.R440OForms.B1_1;
using R440O.R440OForms.C300M_1;
using R440O.R440OForms.K02M_01;
using System;

namespace R440O.R440OForms.BMA_M_1
{
    public class BMA_M_1Parameters
    {
        /// <summary>
        /// В принципе это не "включен", а состояние при котором он может быть включен нажатием кнопок, т.е. питание подается
        /// а "Питание" это как раз "включен"
        /// </summary>

        public static bool ПитаниеН502
        {
            get { return N502BParameters.ЭлектрообуродованиеВключено && N502BParameters.ВыпрямительВключен; }
        }

        #region Питание

        private static bool _питание;

        public static bool Питание
        {
            get { return _питание && ПитаниеН502; }
            set
            {
                bool last = _питание;
                _питание = value;
                if (!last && _питание)
                {
                    BMBParameters.ОбнулитьНабор();
                    BMBParameters.МерцаниеЛампочиНаправления(1);
                }
                N15Parameters.ResetParametersAlternative();
                OnParameterChanged();
            }
        }



        #endregion

        #region Переключатели

        #region ПереключательКонтроль

        private static void ПрокеркаКомплекта()
        {
            _лампочкаКонтрольНорм = true;
            _лампочкаКонтрольНенорм = true;
            if (timer_ЛампочкаКонтрольНенорм != null)
                timer_ЛампочкаКонтрольНенорм.Dispose();
            timer_ЛампочкаКонтрольНенорм = EasyTimer.SetTimeout(() =>
            {
                _лампочкаКонтрольНенорм = false;
                OnParameterChanged();
            }, 4000);
        }

        private static IDisposable timer_ЛампочкаКонтрольНенорм = null;
        private static int _переключательКонтроль = 1;

        /// <summary>
        /// 1 - работа_1, 2 - тест, 3 - дк, 4 - тч, 5 - компл, 6 - работа_2
        /// </summary>
        public static int ПереключательКонтроль
        {
            get { return _переключательКонтроль; }
            set
            {
                if (value >= 1 && value <= 6)
                {
                    _переключательКонтроль = value;
                    if (value != 1 && value != 6)
                        ПрокеркаКомплекта();
                    //ЛампочкаКонтрольНенорм = true;
                    //ЛампочкаКонтрольНорм = false;

                    OnParameterChanged();
                }
            }
        }

        #endregion

        #region ПереключательРекуррента

        private static int _переключательРекуррента = 1;

        /// <summary>
        /// 1 - 15, 2 - 31, 3 - 511, 4 - 1023
        /// </summary>
        public static int ПереключательРекуррента
        {
            get { return _переключательРекуррента; }
            set
            {
                if (value >= 1
                    && value <= 4)
                    _переключательРекуррента = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательРежимРаботы

        /// <summary>
        /// 1 - му авт, 2 - му ручн, 3 - до ручн, 4 - до авт
        /// </summary>
        private static int _переключательРежимРаботы = 1;

        public static int ПереключательРежимРаботы
        {
            get { return _переключательРежимРаботы; }
            set
            {
                if (value >= 1 && value <= 4)
                    _переключательРежимРаботы = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательКоррАЧХ

        private static int _переключательКоррАчх = 1;

        /// <summary>
        /// 1 - 6
        /// </summary>
        public static int ПереключательКоррАЧХ
        {
            get { return _переключательКоррАчх; }
            set
            {
                if (value >= 1 && value <= 6)
                    _переключательКоррАчх = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательЧастотаВызова

        private static int _переключательЧастотаВызова = 1;

        /// <summary>
        /// 1 - 2d1, 2 - 1d8, 3 - 2d6, 4 - 3d2
        /// </summary>
        public static int ПереключательЧастотаВызова
        {
            get { return _переключательЧастотаВызова; }
            set
            {
                if (value >= 1 && value <= 4)
                    _переключательЧастотаВызова = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательУровниСигналаПрдПрм

        private static int _переключательУровниСигналаПрдПрм = 1;

        /// <summary>
        /// 1 - m13 m13, 2 - m23 m5d7, 3 - m10d5 m28, 4 - 28 m10d5
        /// </summary>
        public static int ПереключательУровниСигналаПрдПрм
        {
            get { return _переключательУровниСигналаПрдПрм; }
            set
            {
                if (value >= 1 && value <= 4)
                    _переключательУровниСигналаПрдПрм = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательРежимы

        private static int _переключательРежимы = 1;

        /// <summary>
        /// 1 - дофт, 2 - офт, 3 - 2х1200б 4 - чт
        /// </summary>
        public static int ПереключательРежимы
        {
            get { return _переключательРежимы; }
            set
            {
                if (value >= 1 && value <= 4)
                    _переключательРежимы = value;
                BMBParameters.ResetParameters();
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательЗапретЗапроса

        private static int _переключательЗапретЗапроса = 1;

        /// <summary>
        /// 1 - выкл, 2 - вкл
        /// </summary>
        public static int ПереключательЗапретЗапроса
        {
            get { return _переключательЗапретЗапроса; }
            set
            {
                if (value >= 1 && value <= 2)
                    _переключательЗапретЗапроса = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательКоррКанала

        private static int _ПереключательКоррКанала = 1;

        /// <summary>
        /// 1 - выкл, 2 - вкл
        /// </summary>
        public static int ПереключательКоррКанала
        {
            get { return _ПереключательКоррКанала; }
            set
            {
                if (value >= 1 && value <= 2)
                    _ПереключательКоррКанала = value;
                OnParameterChanged();
            }
        }

        #endregion

        #endregion

        #region Кнопки

        private static int _кнопкаШлейфТЧ;
        private static int _кнопкаШлейфДК;
        private static int _кнопкаПитаниеВыкл;
        private static int _кнопкаПитаниеВкл;
        private static int _кнопкаПроверка;

        private static IDisposable timer_лампочкаАвтомКоманда1ON = null;
        private static IDisposable timer_лампочкаАвтомКоманда1OFF = null;
        private static void Проверка_Автокоманда1()
        {
            _лампочкаАвтомКоманда1 = false;
            if (timer_лампочкаАвтомКоманда1ON != null)
                timer_лампочкаАвтомКоманда1ON.Dispose();

            if (timer_лампочкаАвтомКоманда1OFF != null)
                timer_лампочкаАвтомКоманда1OFF.Dispose();

            timer_лампочкаАвтомКоманда1ON = EasyTimer.SetTimeout(() =>
            {
                _лампочкаАвтомКоманда1 = true;
                OnParameterChanged();
            }, 2000);
            timer_лампочкаАвтомКоманда1OFF =
                        EasyTimer.SetTimeout(() =>
                        {
                            _лампочкаАвтомКоманда1 = false;
                            OnParameterChanged();
                        }, 5000);
        }
        // 0 - отжата, 1 - нажата
        public static int КнопкаПроверка
        {
            get { return _кнопкаПроверка; }
            set
            {
                _кнопкаПроверка = value;
                if (_кнопкаПроверка == 1 && Питание)
                    Проверка_Автокоманда1();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 0 - отжата не горит, 1 - нажата не горит, 2 - отжата горит, 3 - нажата горит
        /// </summary>
        public static int КнопкаПитаниеВыкл
        {
            get { return _кнопкаПитаниеВыкл; }
            set
            {
                if (value < 0 || value > 3) return;
                if (value - _кнопкаПитаниеВыкл > 0)
                {
                    _кнопкаПитаниеВыкл = ПитаниеН502 ? 3 : 1;
                }
                else
                {
                    if (ПитаниеН502)
                    {
                        _кнопкаПитаниеВыкл = 2;
                        _кнопкаПитаниеВкл = 0;
                    }
                    else
                        _кнопкаПитаниеВыкл = 0;
                }
                if (КнопкаПитаниеВыкл != 3) Питание = false;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 0 - отжата не горит, 1 - нажата не горит, 2 - отжата горит, 3 - нажата горит
        /// </summary>
        public static int КнопкаПитаниеВкл
        {
            get { return _кнопкаПитаниеВкл; }
            set
            {
                if (value < 0 || value > 3) return;
                if (value - _кнопкаПитаниеВкл > 0)
                {
                    _кнопкаПитаниеВкл = ПитаниеН502 ? 3 : 1;
                }
                else
                {
                    if (ПитаниеН502)
                    {
                        _кнопкаПитаниеВкл = 2;
                        _кнопкаПитаниеВыкл = 0;
                    }
                    else
                        _кнопкаПитаниеВкл = 0;
                }
                if (КнопкаПитаниеВкл == 3) Питание = true;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 0 - отжата не горит, 1 - нажата не горит, 2 - отжата горит, 3 - нажата горит
        /// </summary>
        public static int КнопкаШлейфДК
        {
            get
            {
                // Подсветка при проверке комплекта
                if (ПереключательКонтроль == 5 && Питание)
                    return _кнопкаШлейфДК == 3 ? 3 : 2;
                return _кнопкаШлейфДК;
            }
            set
            {
                if (_кнопкаШлейфДК == 0 || _кнопкаШлейфДК == 2)
                {
                    _кнопкаШлейфДК = ПитаниеН502 ? 3 : 1;
                }
                else
                {
                    //_кнопкаШлейфДК = Включен ? 2 : 0;
                    _кнопкаШлейфДК = 0;
                }
                OnParameterChanged();
                BMBParameters.ResetParameters();
            }
        }

        /// <summary>
        /// 0 - отжата не горит, 1 - нажата не горит, 2 - отжата горит, 3 - нажата горит
        /// </summary>
        public static int КнопкаШлейфТЧ
        {
            get
            {
                // Подсветка при проверке комплекта
                if (ПереключательКонтроль == 5 && Питание)
                    return _кнопкаШлейфТЧ == 3 ? 3 : 2;
                return _кнопкаШлейфТЧ;
            }
            set
            {
                if (_кнопкаШлейфТЧ == 0 || _кнопкаШлейфТЧ == 2)
                {
                    _кнопкаШлейфТЧ = ПитаниеН502 ? 3 : 1;
                }
                else
                {
                    // _кнопкаШлейфТЧ = Включен ? 2 : 0;
                    _кнопкаШлейфТЧ = 0;
                }
                BMBParameters.ResetParameters();
                OnParameterChanged();
            }
        }

        #endregion

        #region Лампочки

        public static bool ЛампочкаДК
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && !(BMBParameters.ЛампочкаДк && BMBParameters.ПереключательРаботаКонтроль == 1
                                                || КнопкаШлейфДК == 3);
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаСинхрТЧ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && (КнопкаШлейфТЧ == 3);
                        }
                    case 4:
                        {
                            return Питание && (КнопкаШлейфДК == 3 || (!TLF_TCHParametrs.БМА1ПередачаКаналТЧ));
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаСинхрДК = false;

        public static bool ЛампочкаТЧБ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && (BMBParameters.ЛампочкаТч &&
                                               КнопкаШлейфТЧ == 3 && BMBParameters.ПереключательРаботаКонтроль == 1);
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаФЗ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && (КнопкаШлейфТЧ == 3);
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаПрдТЧ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && КнопкаШлейфТЧ != 3;
                            /*return Питание
                                   && !(КнопкаШлейфТЧ == 3
                                        && BMBParameters.ПереключательРаботаКонтроль == 1
                                        && BMBParameters.КнопкаПередачаВызоваТч == СостоянияЭлементов.БМБ.Кнопка.Горит
                                        && BMBParameters.КнопкаСлСвязь == СостоянияЭлементов.БМБ.Кнопка.Горит);*/
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаПрмТЧ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && КнопкаШлейфТЧ != 3;
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
                //        && !TLF_TCHParametrs.БМА1ПриемКаналТЧ;
            }
        }

        public static bool ЛампочкаПрдДК
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание //N15Parameters.ЛампочкаБМА_1                            
                                   && !(КнопкаШлейфДК == 3
                                        && BMBParameters.ПереключательРаботаКонтроль == 1
                                        && BMBParameters.КнопкаПередачаВызоваДк == СостоянияЭлементов.БМБ.Кнопка.Горит
                                        && BMBParameters.КнопкаСлСвязь == СостоянияЭлементов.БМБ.Кнопка.Горит);
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаПрмФР
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание //N15Parameters.ЛампочкаБМА_1                            
                                   && КнопкаШлейфТЧ == 3;
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаПрмДК1
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && !(BMBParameters.ЛампочкаДк && BMBParameters.ПереключательРаботаКонтроль == 1
                                                || КнопкаШлейфДК == 3);
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }

        public static bool ЛампочкаПрмДК2 = false;
        public static bool ЛампочкаПитание_5В = false;
        public static bool ЛампочкаПитание_10В = false;
        public static bool ЛампочкаПитание_12В = false;
        public static bool ЛампочкаПитание_15В = false;
        public static bool ЛампочкаПитание_15Вplus = false;

        private static bool _лампочкаКонтрольНенорм = true;
        public static bool ЛампочкаКонтрольНенорм
        {
            get
            {
                return Питание //N15Parameters.ЛампочкаБМА_1
                    && (ПереключательКонтроль > 1 && ПереключательКонтроль < 6)
                    && _лампочкаКонтрольНенорм;
            }
            set { _лампочкаКонтрольНенорм = value; }
        }

        private static bool _лампочкаКонтрольНорм = false;
        public static bool ЛампочкаКонтрольНорм
        {
            get
            {
                if (Питание
                    && (ПереключательКонтроль > 1 && ПереключательКонтроль < 6)
                    && _лампочкаКонтрольНорм)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            set { _лампочкаКонтрольНорм = value; }
        }

        public static bool ЛампочкаКонтрольТест
        {
            get { return Питание && ПереключательКонтроль == 2; }
        }

        public static bool ЛампочкаКонтрольДК
        {
            get { return Питание && ПереключательКонтроль == 3; }
        }

        public static bool ЛампочкаКонтрольТЧ
        {
            get { return Питание && ПереключательКонтроль == 4; }
        }

        public static bool ЛампочкаКонтрольКомпл
        {
            get { return Питание && ПереключательКонтроль == 5; }
        }

        public static bool ЛампочкаРекуррента15
        {
            get { return Питание && ПереключательРекуррента == 1; }
        }

        public static bool ЛампочкаРекуррента31
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 2;
            }
        }

        public static bool ЛампочкаРекуррента511
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 3;
            }
        }

        public static bool ЛампочкаРекуррента1023
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 4;
            }
        }
        public static bool _лампочкаАвтомКоманда1;
        public static bool ЛампочкаАвтомКоманда1
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return _лампочкаАвтомКоманда1;
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }
        public static bool ЛампочкаАвтомКоманда2
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && КнопкаШлейфТЧ != 3 && ПереключательЧастотаВызова == 1
                               && ПереключательРежимы == 2;
                        }
                    case 4:
                        {
                            return false;
                        }
                    case 3:
                        {
                            return false;
                        }
                }
                return false;
            }
        }
        public static bool ЛампочкаИсправно
        {
            get { return Питание; }
        }

        public static bool ЛампочкаНеисправно = false;
        public static bool ЛампочкаРРР = false;
        public static bool ЛампочкаДист = false;

        #endregion

        #region Сигнал

        private static bool _синхронизироваля = true;
        private static IDisposable _interval = null;

        #region Сигнал С Б1 через Н18

        public static Chanel СигналКанал1
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал1_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА1) &&
                     B1_1Parameters.ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.ВыходнойСигнал.ChanelbyNumber(1);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        public static Chanel СигналКанал2
        {
            get
            {
                // Получение сингала по каналу 2 с Б1 через Н18
                if (N18_MParameters.Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал2_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА1)
                    && B1_1Parameters.ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.ВыходнойСигнал.ChanelbyNumber(2);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        public static Chanel СигналКанал3
        {
            get
            {
                // Получение сингала по каналу 3 с Б1 через Н18
                if (N18_MParameters.Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал3_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА1)
                    && B1_1Parameters.ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.ВыходнойСигнал.ChanelbyNumber(3);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        #endregion

        #region Сигнал с Кулона через Н18

        public static Chanel СигналКулона
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал1_К12, ГнездаН18.КоммутацияПрм_Канал1_БМА1) &&
                     K02M_01Parameters.Сигнал != null)
                {
                    var сигнал = K02M_01Parameters.Сигнал.FirstChanel;
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;

                }
                return null;
            }
        }

        #endregion

        #region Сигнал с Ц300

        public static Chanel СигналЦ3001
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.Проверить_комутацию(ГнездаН18.Контроль_Прм_Тлф1, ГнездаН18.КоммутацияПрм_Канал1_БМА1) &&
                    C300M_1Parameters.ПойманныйСигнал != null)
                {
                    var сигнал = C300M_1Parameters.ПойманныйСигнал.ChanelbyNumber(1);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        #endregion

        public static Chanel СигалНаБМБ
        {
            get
            {
                if (КнопкаШлейфДК == 3)
                {
                    return BMBParameters.ВыходнойСигнал;
                }
                var сигнал = СигналКанал1 ?? СигналКанал2 ?? СигналКанал3 ?? СигналКулона ?? СигналЦ3001;
                if (сигнал == null)
                    return null;
                switch (ПереключательРежимы)
                {
                    case 1:
                        {
                            _синхронизироваля = сигнал.Speed == 2.4;
                            break;
                        }
                    case 2:
                        {
                            if (сигнал.Speed == 2.4)
                            {
                                if (_interval != null)
                                    _interval.Dispose();
                                _interval =
                                  ThirdParty.EasyTimer.SetTimeout(() => { _синхронизироваля = !_синхронизироваля; BMBParameters.ResetParameters(); }, 2000);
                            }
                            else
                                _синхронизироваля = сигнал.Speed == 1.2;
                            break;
                        }
                    case 3:
                        {
                            _синхронизироваля = false;
                            break;
                        }
                    case 4:
                        {
                            _синхронизироваля = false;
                            break;
                        }
                }
                return _синхронизироваля ? сигнал : null;
            }
        }

        public static Chanel СигналСБМБ
        {
            get
            {
                return BMBParameters.ВыходнойСигнал;
            }
        }

        #endregion

        public delegate void ParameterChangedHandler();

        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

        public static void DisposeAllTimers()
        {
            if (timer_ЛампочкаКонтрольНенорм != null)
                timer_ЛампочкаКонтрольНенорм.Dispose();
        }

        public static void ResetLampsValue()
        {
            ЛампочкаКонтрольНенорм = N15Parameters.ЛампочкаБМА_1;
            ЛампочкаКонтрольНорм = !ЛампочкаКонтрольНенорм;
        }
    }
}
