using System;
using System.Linq;
using System.Windows.Forms;
using R440O.Parameters;
//using NLog;
using R440O.R440OForms.K02M_01;
using R440O.R440OForms.K02M_01Inside;
using R440O.R440OForms.K03M_01Inside;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.K05M_01;
using R440O.R440OForms.K01M_01;
using R440O.R440OForms.PU_K1_1;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.K03M_01
{
    public static class K03M_01Parameters
    {
        // Внимание, в OnParameterChanged добавлен вызов метода.
        #region событие

        public delegate void ParameterChangedHandler();
        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            // При каждом изменении любого тумблера надо обновлять значения
            ПересчитатьМаксимальноеИМинимальноеЗнчения();
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ОбновитьСигнал()
        {
            НачатьПоискСНачала();
            ResetParameters();
            K02M_01Parameters.ResetParameters();
        }

        public static void ResetParameters()
        {
            OnParameterChanged();
        }

        #endregion

        #region Лампочки

        private static int _нормированноеЗнаечниеПоиска
        {
            get
            {
                return Convert.ToInt32(Math.Abs(_текущееЗначениеПоиска) / 1000);
            }
        }

        public static bool Лампочка0
        {
            get { return (_текущееЗначениеПоиска >= 0 && БлокВключен); }
        }

        public static bool Лампочка1
        {
            get
            {
                return БлокВключен && (_нормированноеЗнаечниеПоиска % 2) != 0;
            }
        }
        public static bool Лампочка2
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 4) / 2) != 0;
            }
        }
        public static bool Лампочка4
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 8) / 4) != 0;
            }
        }
        public static bool Лампочка8
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 16) / 8) != 0;
            }
        }
        public static bool Лампочка16
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 32) / 16) != 0;
            }
        }
        public static bool Лампочка32
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 64) / 32) != 0;
            }
        }
        #endregion

        #region Переключатели
        private static bool _переключатель0 = false;
        private static bool _переключатель1 = false;
        private static bool _переключатель2 = false;
        private static bool _переключатель4 = false;
        private static bool _переключатель8 = false;
        private static bool _переключатель16 = false;
        private static bool _переключатель32 = false;
        private static bool _переключательНепрОднокр = true;
        private static bool _переключательАвтРучн = true;
        private static int _статусПоиска = 0;


        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _переключательЗонаПоиска = 1;

        public static bool Переключатель0
        {
            get
            {
                return _переключатель0;
            }
            set
            {
                _переключатель0 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель1
        {
            get
            {
                return _переключатель1;
            }
            set
            {
                _переключатель1 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель2
        {
            get
            {
                return _переключатель2;
            }
            set
            {
                _переключатель2 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель4
        {
            get
            {
                return _переключатель4;
            }
            set
            {
                _переключатель4 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель8
        {
            get
            {
                return _переключатель8;
            }
            set
            {
                _переключатель8 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель16
        {
            get
            {
                return _переключатель16;
            }
            set
            {
                _переключатель16 = value;
                ResetParameters();
            }
        }
        public static bool Переключатель32
        {
            get
            {
                return _переключатель32;
            }
            set
            {
                _переключатель32 = value;
                ResetParameters();
            }
        }
        public static bool ПереключательНепрОднокр
        {
            get
            {
                return _переключательНепрОднокр;
            }
            set
            {
                _переключательНепрОднокр = value;
                ResetParameters();
                if (value)
                {
                    НачатьПоискСНачала();
                }
                else
                {
                    НачатьРучнойПоиск();
                }
            }
        }
        public static bool ПереключательАвтРучн
        {
            get
            {
                return _переключательАвтРучн;
            }
            set
            {
                _переключательАвтРучн = value;
                ResetParameters();
                if (value)
                {
                    НачатьПоискСНачала();
                }
                else
                {
                    if (СтатусПоиска != 2)
                    {
                        НачатьРучнойПоиск();
                    }
                }
            }
        }

        public static int ПереключательЗонаПоиска
        {
            get
            {
                return _переключательЗонаПоиска;
            }

            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательЗонаПоиска = value;
                    ResetParameters();
                }
            }
        }
        #endregion

        #region Логика работы Поиск

        // 0 и -0 в значении поиска это разные вещи, поэтому, для удобства,
        // все отрицательные значения сдвинуты на 1,
        // То есть -1 это на самом деле -0, а -2 это -1
        // 0 это и есть 0, то есть +0.

        public static bool БлокВключен { get { return PU_K1_1Parameters.Включен; } }

        private static int _временнаяПозицияПоиска;

        public static int ВременнаяПозицияПоиска
        {
            get { return _временнаяПозицияПоиска; }
        }

        public static void ИзменитьВременнуюПозициюПоиска(int delta)
        {
            if (БлокВключен)
            {
                if (СтатусПоиска == 2)
                {
                    _временнаяПозицияПоиска += delta;
                    if (_временнаяПозицияПоиска > 350 || _временнаяПозицияПоиска < -350)
                    {
                        _временнаяПозицияПоиска *= -1;
                    }
                }
                K02M_01Parameters.ResetParameters();
            }
        }


        public static KulonSignal НайденныйСигнал
        {
            get
            {
                if (СтатусПоиска == 0 || СтатусПоиска == 1)
                    return null;
                if (СоотвествиеТумблеровПИ)
                {
                    var сигналы = K01M_01Parameters.Сигнал
                        .Where(s => СоотвествиеСигнала(s))
                        .ToList();
                    if (сигналы.Count == 1)
                        return сигналы[0];
                }
                return null;
            }
        }

        /// <summary>
        /// 0 - Поиск не идёт и ничего не найдено;
        /// 1 - Ищется;
        /// 2 - Найдено;
        /// 3 - Ручной поиск;
        /// </summary>
        public static int СтатусПоиска
        {
            get { return _статусПоиска; }
            private set
            {
                _статусПоиска = value;
            }
        }

        private static bool СоотвествиеЧастотыСигнала(KulonSignal сигнал)
        {
            double dif = сигнал.Frequency + _текущееЗначениеПоиска - K04M_01Parameters.ЧастотаПрм;
            return dif >= 0 && dif < _шагПоиска;
        }

        private static bool СоотвествиеСинхропоследовательностей(KulonSignal сигнал)
        {
            return сигнал.SynchroSequence1.SequenceEqual(K03M_01InsideParameters.Переключатели.Синхропоследовательность1)
                && сигнал.SynchroSequence2.SequenceEqual(K03M_01InsideParameters.Переключатели.Синхропоследовательность2);
        }

        private static bool СоотвествиеСигнала(KulonSignal сигнал)
        {
            return сигнал != null && СоотвествиеЧастотыСигнала(сигнал)
                 && СоотвествиеСинхропоследовательностей(сигнал);
        }

        /// <summary>
        /// Внутри К03 и К02 - тумблеры "П-И" должны иметь одинаковое положение
        /// Прямой/инверсный сигнал
        /// </summary>
        private static bool СоотвествиеТумблеровПИ
        {
            get
            {
                return K03M_01InsideParameters.ТумблерИП == K02M_01InsideParameters.ТумблерБ5;
            }
        }

        public static void ПересчитатьНайденоИлиНеНайдено()
        {
            if (СоотвествиеТумблеровПИ)
            {
                var сигналы = K01M_01Parameters.Сигнал
                        .Where(s => СоотвествиеСигнала(s))
                        .ToList();
                if (сигналы.Count == 1)
                {
                    // Найдено. Поиск останавливается.
                    Найдено();
                    return;
                }
            }

            // Не найдено. Поиск стартует или продолжается.
            if (СтатусПоиска == 2)
            {
                НачатьПоискСНачала();
            }
        }

        private static readonly Timer _таймерДляПоиска = new Timer();
        private static double _текущееЗначениеПоиска;
        private static int _максимальноеЗначениеПоиска;
        private static int _минимальноеЗначениеПоиска;
        private static int _шагПоиска = 500;
        private static int _времяОдногоШага = 500;

        static K03M_01Parameters()
        {
            _таймерДляПоиска.Tick += ТикТаймераДляПоиска;
            _таймерДляПоиска.Interval = _времяОдногоШага;
            _таймерДляПоиска.Enabled = true;
        }

        public static void НачатьПоискСНачала()
        {
            if (БлокВключен)
            {
                _временнаяПозицияПоиска = 0;
                СтатусПоиска = 1;
                ПересчитатьМаксимальноеИМинимальноеЗнчения();
                _текущееЗначениеПоиска = ПолучитьНачальноеЗначениеПоиска();
                ResetParameters();
                K02M_01Parameters.ResetParameters();
            }
        }

        public static void ОтменитьПоиск()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 0;
                ResetParameters();
                K02M_01Parameters.ResetParameters();
            }
        }

        private static void Найдено()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 2;
                ResetParameters();
                K02M_01Parameters.ResetParameters();
            }
        }

        private static void НачатьРучнойПоиск()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 3;
                ResetParameters();
                K02M_01Parameters.ResetParameters();
            }
        }


        /// <summary>
        /// Когда меняются параметры (тумблеры или переключатель), надо изменять
        /// максимальное и минимальное значения поиска.
        /// </summary>
        private static void ПересчитатьМаксимальноеИМинимальноеЗнчения()
        {
            if (БлокВключен)
            {
                // Если зона поиска стоит +-64 то логика другая
                if (ПереключательЗонаПоиска == 4)
                {
                    _максимальноеЗначениеПоиска = 64 * 1000;
                    _минимальноеЗначениеПоиска = (-64 - 1) * 1000;
                }
                else
                {
                    // Которая выставлена переключателем на блоке (+2, +8, +32)
                    // Для +-64 логика другая!
                    int зонаПоиска = 0;
                    switch (ПереключательЗонаПоиска)
                    {
                        case 1:
                            зонаПоиска = 2;
                            break;
                        case 2:
                            зонаПоиска = 8;
                            break;
                        case 3:
                            зонаПоиска = 32;
                            break;
                    }
                    зонаПоиска *= 1000;
                    _минимальноеЗначениеПоиска = ПолучитьНачальноеЗначениеПоиска();
                    _максимальноеЗначениеПоиска = _минимальноеЗначениеПоиска + зонаПоиска - 1;
                };
            }
        }

        private static void ТикТаймераДляПоиска(object o, EventArgs e)
        {
            if (БлокВключен)
            {
                if (СтатусПоиска == 1)
                {
                    // Текущее значение поиска увеличивается на 1, если доходит до максимума, скидывается в минимум.
                    if (_текущееЗначениеПоиска >= _максимальноеЗначениеПоиска ||
                        _текущееЗначениеПоиска < _минимальноеЗначениеПоиска)
                    {
                        _текущееЗначениеПоиска = _минимальноеЗначениеПоиска;
                    }
                    else
                    {
                        _текущееЗначениеПоиска += _шагПоиска;
                    }
                }
                if (СтатусПоиска != 0 && СтатусПоиска != 3)
                {
                    ПересчитатьНайденоИлиНеНайдено();
                    ResetParameters();
                }
            }
        }

        /// <summary>
        /// По тумблерам определяет начальное значение зоны поиска
        /// (тумблеры в двоичной системе число представляют почти)
        /// </summary>
        /// <returns></returns>
        private static int ПолучитьНачальноеЗначениеПоиска()
        {
            int value = 0;
            value += (Переключатель1) ? 1 : 0;
            value += (Переключатель2) ? 2 : 0;
            value += (Переключатель4) ? 4 : 0;
            value += (Переключатель8) ? 8 : 0;
            value += (Переключатель16) ? 16 : 0;
            value += (Переключатель32) ? 32 : 0;
            if (Переключатель0)
            {
                value *= -1;
            }
            return value * 1000;
        }

        #endregion
    }
}
