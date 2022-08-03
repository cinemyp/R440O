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

namespace R440O.R440OForms.BMA_M_2
{
    class BMA_M_2Parameters
    {
        private static BMA_M_2Parameters instance;
        public static BMA_M_2Parameters getInstance()
        {
            if (instance == null)
                instance = new BMA_M_2Parameters();
            return instance;
        }

        /// <summary>
        /// В принципе это не "включен", а состояние при котором он может быть включен нажатием кнопок, т.е. питание подается
        /// а "Питание" это как раз "включен"
        /// </summary>

        public bool ПитаниеН502
        {
            get { return N502BParameters.getInstance().ЭлектрообуродованиеВключено && N502BParameters.getInstance().ВыпрямительВключен; }
        }

        #region Питание

        private bool _питание;

        public bool Питание
        {
            get { return _питание && ПитаниеН502; }
            set
            {
                bool last = _питание;
                _питание = value;
                if (!last && _питание)
                {
                    BMBParameters.getInstance().ОбнулитьНабор();
                    BMBParameters.getInstance().МерцаниеЛампочиНаправления(2);
                }
                N15Parameters.getInstance().ResetParametersAlternative();
                OnParameterChanged();
            }
        }



        #endregion

        #region Переключатели

        #region ПереключательКонтроль

        private void ПрокеркаКомплекта()
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

        private IDisposable timer_ЛампочкаКонтрольНенорм = null;
        private int _переключательКонтроль = 1;

        /// <summary>
        /// 1 - работа_1, 2 - тест, 3 - дк, 4 - тч, 5 - компл, 6 - работа_2
        /// </summary>
        public int ПереключательКонтроль
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

        private int _переключательРекуррента = 1;

        /// <summary>
        /// 1 - 15, 2 - 31, 3 - 511, 4 - 1023
        /// </summary>
        public int ПереключательРекуррента
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
        private int _переключательРежимРаботы = 1;

        public int ПереключательРежимРаботы
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

        private int _переключательКоррАчх = 1;

        /// <summary>
        /// 1 - 6
        /// </summary>
        public int ПереключательКоррАЧХ
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

        private int _переключательЧастотаВызова = 1;

        /// <summary>
        /// 1 - 2d1, 2 - 1d8, 3 - 2d6, 4 - 3d2
        /// </summary>
        public int ПереключательЧастотаВызова
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

        private int _переключательУровниСигналаПрдПрм = 1;

        /// <summary>
        /// 1 - m13 m13, 2 - m23 m5d7, 3 - m10d5 m28, 4 - 28 m10d5
        /// </summary>
        public int ПереключательУровниСигналаПрдПрм
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

        private int _переключательРежимы = 1;

        /// <summary>
        /// 1 - дофт, 2 - офт, 3 - 2х1200б 4 - чт
        /// </summary>
        public int ПереключательРежимы
        {
            get { return _переключательРежимы; }
            set
            {
                if (value >= 1 && value <= 4)
                    _переключательРежимы = value;
                BMBParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        #endregion

        #region ПереключательЗапретЗапроса

        private int _переключательЗапретЗапроса = 1;

        /// <summary>
        /// 1 - выкл, 2 - вкл
        /// </summary>
        public int ПереключательЗапретЗапроса
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

        private int _ПереключательКоррКанала = 1;

        /// <summary>
        /// 1 - выкл, 2 - вкл
        /// </summary>
        public int ПереключательКоррКанала
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

        private int _кнопкаШлейфТЧ;
        private int _кнопкаШлейфДК;
        private int _кнопкаПитаниеВыкл;
        private int _кнопкаПитаниеВкл;
        private int _кнопкаПроверка;

        private IDisposable timer_лампочкаАвтомКоманда1ON = null;
        private IDisposable timer_лампочкаАвтомКоманда1OFF = null;
        private void Проверка_Автокоманда1()
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
        public int КнопкаПроверка
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
        public int КнопкаПитаниеВыкл
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
        public int КнопкаПитаниеВкл
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
        public int КнопкаШлейфДК
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
                BMBParameters.getInstance().ResetParameters();
            }
        }

        /// <summary>
        /// 0 - отжата не горит, 1 - нажата не горит, 2 - отжата горит, 3 - нажата горит
        /// </summary>
        public int КнопкаШлейфТЧ
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
                BMBParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        #endregion

        #region Лампочки

        public bool ЛампочкаДК
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && !(BMBParameters.getInstance().ЛампочкаДк && BMBParameters.getInstance().ПереключательРаботаКонтроль == 1
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

        public bool ЛампочкаСинхрТЧ
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
                            return Питание && (КнопкаШлейфДК == 3 || (!TLF_TCHParametrs.getInstance().БМА1ПередачаКаналТЧ));
                        }
                }
                return false;
            }
        }

        public bool ЛампочкаСинхрДК = false;

        public bool ЛампочкаТЧБ
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && (BMBParameters.getInstance().ЛампочкаТч &&
                                               КнопкаШлейфТЧ == 3 && BMBParameters.getInstance().ПереключательРаботаКонтроль == 1);
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

        public bool ЛампочкаФЗ
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

        public bool ЛампочкаПрдТЧ
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
                                        && BMBParameters.getInstance().ПереключательРаботаКонтроль == 1
                                        && BMBParameters.getInstance().КнопкаПередачаВызоваТч == СостоянияЭлементов.БМБ.Кнопка.Горит
                                        && BMBParameters.getInstance().КнопкаСлСвязь == СостоянияЭлементов.БМБ.Кнопка.Горит);*/
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

        public bool ЛампочкаПрмТЧ
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
                //        && !TLF_TCHParametrs.getInstance().БМА1ПриемКаналТЧ;
            }
        }

        public bool ЛампочкаПрдДК
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание //N15Parameters.getInstance().ЛампочкаБМА_1                            
                                   && !(КнопкаШлейфДК == 3
                                        && BMBParameters.getInstance().ПереключательРаботаКонтроль == 1
                                        && BMBParameters.getInstance().КнопкаПередачаВызоваДк == СостоянияЭлементов.БМБ.Кнопка.Горит
                                        && BMBParameters.getInstance().КнопкаСлСвязь == СостоянияЭлементов.БМБ.Кнопка.Горит);
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

        public bool ЛампочкаПрмФР
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание //N15Parameters.getInstance().ЛампочкаБМА_1                            
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

        public bool ЛампочкаПрмДК1
        {
            get
            {
                switch (ПереключательКонтроль)
                {
                    case 1:
                    case 6:
                        {
                            return Питание && !(BMBParameters.getInstance().ЛампочкаДк && BMBParameters.getInstance().ПереключательРаботаКонтроль == 1
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

        public bool ЛампочкаПрмДК2 = false;
        public bool ЛампочкаПитание_5В = false;
        public bool ЛампочкаПитание_10В = false;
        public bool ЛампочкаПитание_12В = false;
        public bool ЛампочкаПитание_15В = false;
        public bool ЛампочкаПитание_15Вplus = false;

        private bool _лампочкаКонтрольНенорм = true;
        public bool ЛампочкаКонтрольНенорм
        {
            get
            {
                return Питание //N15Parameters.getInstance().ЛампочкаБМА_1
                    && (ПереключательКонтроль > 1 && ПереключательКонтроль < 6)
                    && _лампочкаКонтрольНенорм;
            }
            set { _лампочкаКонтрольНенорм = value; }
        }

        private bool _лампочкаКонтрольНорм = false;
        public bool ЛампочкаКонтрольНорм
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

        public bool ЛампочкаКонтрольТест
        {
            get { return Питание && ПереключательКонтроль == 2; }
        }

        public bool ЛампочкаКонтрольДК
        {
            get { return Питание && ПереключательКонтроль == 3; }
        }

        public bool ЛампочкаКонтрольТЧ
        {
            get { return Питание && ПереключательКонтроль == 4; }
        }

        public bool ЛампочкаКонтрольКомпл
        {
            get { return Питание && ПереключательКонтроль == 5; }
        }

        public bool ЛампочкаРекуррента15
        {
            get { return Питание && ПереключательРекуррента == 1; }
        }

        public bool ЛампочкаРекуррента31
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 2;
            }
        }

        public bool ЛампочкаРекуррента511
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 3;
            }
        }

        public bool ЛампочкаРекуррента1023
        {
            get
            {
                return Питание &&
                       ПереключательРекуррента == 4;
            }
        }
        public bool _лампочкаАвтомКоманда1;
        public bool ЛампочкаАвтомКоманда1
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
        public bool ЛампочкаАвтомКоманда2
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
        public bool ЛампочкаИсправно
        {
            get { return Питание; }
        }

        public bool ЛампочкаНеисправно = false;
        public bool ЛампочкаРРР = false;
        public bool ЛампочкаДист = false;

        #endregion

        #region Сигнал

        private bool _синхронизироваля = true;
        private IDisposable _interval = null;

        #region Сигнал С Б1 через Н18

        public Chanel СигналКанал1
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.getInstance().Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал1_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА2) &&
                     B1_1Parameters.getInstance().ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.getInstance().ВыходнойСигнал.ChanelbyNumber(1);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        public Chanel СигналКанал2
        {
            get
            {
                // Получение сингала по каналу 2 с Б1 через Н18
                if (N18_MParameters.getInstance().Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал2_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА2)
                    && B1_1Parameters.getInstance().ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.getInstance().ВыходнойСигнал.ChanelbyNumber(2);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        public Chanel СигналКанал3
        {
            get
            {
                // Получение сингала по каналу 3 с Б1 через Н18
                if (N18_MParameters.getInstance().Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал3_Б11, ГнездаН18.КоммутацияПрм_Канал1_БМА2)
                    && B1_1Parameters.getInstance().ВыходнойСигнал != null)
                {
                    var сигнал = B1_1Parameters.getInstance().ВыходнойСигнал.ChanelbyNumber(3);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        #endregion

        #region Сигнал с Кулона через Н18

        public Chanel СигналКулона
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.getInstance().Проверить_комутацию(ГнездаН18.КоммутацияПрм_Канал1_К12, ГнездаН18.КоммутацияПрм_Канал1_БМА2) &&
                     K02M_01Parameters.getInstance().Сигнал != null)
                {
                    var сигнал = K02M_01Parameters.getInstance().Сигнал.FirstChanel;
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;

                }
                return null;
            }
        }

        #endregion

        #region Сигнал с Ц300

        public Chanel СигналЦ3001
        {
            get
            {
                // Получение сингала по каналу 1 с Б1 через Н18
                if (N18_MParameters.getInstance().Проверить_комутацию(ГнездаН18.Контроль_Прм_Тлф1, ГнездаН18.КоммутацияПрм_Канал1_БМА2) &&
                    C300M_1Parameters.getInstance().ПойманныйСигнал != null)
                {
                    var сигнал = C300M_1Parameters.getInstance().ПойманныйСигнал.ChanelbyNumber(1);
                    if (сигнал == null)
                        return null;
                    return сигнал.Information ? сигнал : null;
                }
                return null;
            }
        }

        #endregion

        public Chanel СигалНаБМБ
        {
            get
            {
                if (КнопкаШлейфДК == 3)
                {
                    return BMBParameters.getInstance().ВыходнойСигнал;
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
                                  ThirdParty.EasyTimer.SetTimeout(() => { _синхронизироваля = !_синхронизироваля; BMBParameters.getInstance().ResetParameters(); }, 2000);
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

        public Chanel СигналСБМБ
        {
            get
            {
                return BMBParameters.getInstance().ВыходнойСигнал;
            }
        }

        #endregion

        public delegate void ParameterChangedHandler();

        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        public void DisposeAllTimers()
        {
            if (timer_ЛампочкаКонтрольНенорм != null)
                timer_ЛампочкаКонтрольНенорм.Dispose();
        }

        public void ResetLampsValue()
        {
            ЛампочкаКонтрольНенорм = N15Parameters.getInstance().ЛампочкаБМА_2;
            ЛампочкаКонтрольНорм = !ЛампочкаКонтрольНенорм;
        }
    }
}
