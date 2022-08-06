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
    public class K03M_01Parameters
    {
        private static K03M_01Parameters instance;
        public static K03M_01Parameters getInstance()
        {
            if (instance == null)
                instance = new K03M_01Parameters();
            return instance;
        }

        // Внимание, в OnParameterChanged добавлен вызов метода.
        #region событие

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            // При каждом изменении любого тумблера надо обновлять значения
            ПересчитатьМаксимальноеИМинимальноеЗнчения();
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ОбновитьСигнал()
        {
            НачатьПоискСНачала();
            ResetParameters();
            K02M_01Parameters.getInstance().ResetParameters();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }

        #endregion

        #region Лампочки

        private int _нормированноеЗнаечниеПоиска
        {
            get
            {
                return Convert.ToInt32(Math.Abs(_текущееЗначениеПоиска) / 1000);
            }
        }

        public bool Лампочка0
        {
            get { return (_текущееЗначениеПоиска >= 0 && БлокВключен); }
        }

        public bool Лампочка1
        {
            get
            {
                return БлокВключен && (_нормированноеЗнаечниеПоиска % 2) != 0;
            }
        }
        public bool Лампочка2
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 4) / 2) != 0;
            }
        }
        public bool Лампочка4
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 8) / 4) != 0;
            }
        }
        public bool Лампочка8
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 16) / 8) != 0;
            }
        }
        public bool Лампочка16
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 32) / 16) != 0;
            }
        }
        public bool Лампочка32
        {
            get
            {
                return БлокВключен && ((_нормированноеЗнаечниеПоиска % 64) / 32) != 0;
            }
        }
        #endregion

        #region Переключатели
        private bool _переключатель0 = false;
        private bool _переключатель1 = false;
        private bool _переключатель2 = false;
        private bool _переключатель4 = false;
        private bool _переключатель8 = false;
        private bool _переключатель16 = false;
        private bool _переключатель32 = false;
        private bool _переключательНепрОднокр = true;
        private bool _переключательАвтРучн = true;
        private int _статусПоиска = 0;


        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private int _переключательЗонаПоиска = 1;

        public bool Переключатель0
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
        public bool Переключатель1
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
        public bool Переключатель2
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
        public bool Переключатель4
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
        public bool Переключатель8
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
        public bool Переключатель16
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
        public bool Переключатель32
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
        public bool ПереключательНепрОднокр
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
        public bool ПереключательАвтРучн
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

        public int ПереключательЗонаПоиска
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

        public bool БлокВключен { get { return PU_K1_1Parameters.getInstance().Включен; } }

        private int _временнаяПозицияПоиска;

        public int ВременнаяПозицияПоиска
        {
            get { return _временнаяПозицияПоиска; }
        }

        public void ИзменитьВременнуюПозициюПоиска(int delta)
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
                K02M_01Parameters.getInstance().ResetParameters();
            }
        }


        public KulonSignal НайденныйСигнал
        {
            get
            {
                if (СтатусПоиска == 0 || СтатусПоиска == 1)
                    return null;
                if (СоотвествиеТумблеровПИ)
                {
                    var сигналы = K01M_01Parameters.getInstance().Сигнал
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
        public int СтатусПоиска
        {
            get { return _статусПоиска; }
            private set
            {
                _статусПоиска = value;
            }
        }

        private bool СоотвествиеЧастотыСигнала(KulonSignal сигнал)
        {
            double dif = сигнал.Frequency + _текущееЗначениеПоиска - K04M_01Parameters.getInstance().ЧастотаПрм;
            return dif >= 0 && dif < _шагПоиска;
        }

        private bool СоотвествиеСинхропоследовательностей(KulonSignal сигнал)
        {
            return сигнал.SynchroSequence1.SequenceEqual(K03M_01InsideParameters.getInstance().Переключатели.Синхропоследовательность1)
                && сигнал.SynchroSequence2.SequenceEqual(K03M_01InsideParameters.getInstance().Переключатели.Синхропоследовательность2);
        }

        private bool СоотвествиеСигнала(KulonSignal сигнал)
        {
            return сигнал != null && СоотвествиеЧастотыСигнала(сигнал)
                 && СоотвествиеСинхропоследовательностей(сигнал);
        }

        /// <summary>
        /// Внутри К03 и К02 - тумблеры "П-И" должны иметь одинаковое положение
        /// Прямой/инверсный сигнал
        /// </summary>
        private bool СоотвествиеТумблеровПИ
        {
            get
            {
                return K03M_01InsideParameters.getInstance().ТумблерИП == K02M_01InsideParameters.getInstance().ТумблерБ5;
            }
        }

        public void ПересчитатьНайденоИлиНеНайдено()
        {
            if (СоотвествиеТумблеровПИ)
            {
                var сигналы = K01M_01Parameters.getInstance().Сигнал
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

        private readonly Timer _таймерДляПоиска = new Timer();
        private double _текущееЗначениеПоиска;
        private int _максимальноеЗначениеПоиска;
        private int _минимальноеЗначениеПоиска;
        private int _шагПоиска = 500;
        private int _времяОдногоШага = 500;

        K03M_01Parameters()
        {
            _таймерДляПоиска.Tick += ТикТаймераДляПоиска;
            _таймерДляПоиска.Interval = _времяОдногоШага;
            _таймерДляПоиска.Enabled = true;
        }

        public void НачатьПоискСНачала()
        {
            if (БлокВключен)
            {
                _временнаяПозицияПоиска = 0;
                СтатусПоиска = 1;
                ПересчитатьМаксимальноеИМинимальноеЗнчения();
                _текущееЗначениеПоиска = ПолучитьНачальноеЗначениеПоиска();
                ResetParameters();
                K02M_01Parameters.getInstance().ResetParameters();
            }
        }

        public void ОтменитьПоиск()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 0;
                ResetParameters();
                K02M_01Parameters.getInstance().ResetParameters();
            }
        }

        private void Найдено()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 2;
                ResetParameters();
                K02M_01Parameters.getInstance().ResetParameters();
            }
        }

        private void НачатьРучнойПоиск()
        {
            if (БлокВключен)
            {
                СтатусПоиска = 3;
                ResetParameters();
                K02M_01Parameters.getInstance().ResetParameters();
            }
        }


        /// <summary>
        /// Когда меняются параметры (тумблеры или переключатель), надо изменять
        /// максимальное и минимальное значения поиска.
        /// </summary>
        private void ПересчитатьМаксимальноеИМинимальноеЗнчения()
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

        private void ТикТаймераДляПоиска(object o, EventArgs e)
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
        private int ПолучитьНачальноеЗначениеПоиска()
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
