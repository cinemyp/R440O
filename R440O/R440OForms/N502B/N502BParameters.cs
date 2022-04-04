using R440O.R440OForms.N16;

namespace R440O.R440OForms.N502B
{
    using System;
    using System.Linq;
    using System.Windows.Forms;
    using Properties;
    using PowerCabel;
    using VoltageStabilizer;
    using N15;
    using global::R440O.BaseClasses;
    using global::R440O.JsonAdapter;

    public class N502BParameters
    {
        private static N502BParameters instance;

        public static N502BParameters getInstance()
        {
            if (instance == null)
                instance = new N502BParameters();
            return instance;
        }
        
        protected N502BParameters()
        {
            StationTimer = new Timer();

            var generator = new Random();
            var zeroToOne = generator.NextDouble();
            Фазировка = zeroToOne > 0.5F ? 4 : 2;
        }

        #region Время работы станции
        public Timer StationTimer;

        /// <summary>
        /// Таймер используемый, для определения времени, которое станция проработала.
        /// </summary>
        public TimeSpan ВремяРаботыСтанции;

        /// <summary>
        /// Проверка условий, при выполнении которых ведётся учёт времени работы на станции.
        /// </summary>
        public void СледитьЗаВременем()
        {
            ВремяРаботыСтанции = Settings.Default.TimeofWork;
            StationTimer = new Timer
            {
                Enabled = false,
                Interval = 60 * 1000
            };
            StationTimer.Tick += StationTimer_Tick;
            if (PowerCabelParameters.getInstance().КабельСеть && ПереключательСеть) StationTimer.Start();
            else StationTimer.Stop();
        }

        private void StationTimer_Tick(object sender, EventArgs e)
        {
            ВремяРаботыСтанции += new TimeSpan(0, 0, 1, 0);
            Settings.Default.TimeofWork = ВремяРаботыСтанции;
            Settings.Default.Save();
            OnParameterChanged();
        }
        #endregion

        #region Лампочки

        /// <summary>
        /// Лампочка сеть - горит при подключенном кабеле Сеть
        /// </summary>
        public bool ЛампочкаСеть
        {
            get { return PowerCabelParameters.getInstance().КабельСеть; }
        }

        /// <summary>
        /// Лампочка сфазировано - горит при наличии нагрузки
        /// </summary>
        public bool ЛампочкаСфазировано
        {
            get { return Нагрузка; }
        }

        //public  bool ЛампочкаРбпПроверка;
        //public  bool ЛампочкаРбпПредохранитель;

        #endregion

        #region Тумблеры
        #region private
        private bool _тумблерЭлектрооборудование;
        private bool _тумблерВыпрямитель27В;
        private bool _тумблерН15;
        private bool _тумблерОсвещение;
        private bool _тумблерН13_1;
        private bool _тумблерН13_2;
        private int _тумблерОсвещение1 = 2;
        private int _тумблерОсвещение2 = 2;
        #endregion

        #region public

        public bool ТумблерЭлектрооборудование
        {
            get { return _тумблерЭлектрооборудование; }
            set
            {
                _тумблерЭлектрооборудование = value;
                N15Parameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool ТумблерВыпрямитель27В
        {
            get { return _тумблерВыпрямитель27В; }
            set
            {
                _тумблерВыпрямитель27В = value;
                N15Parameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }
        public bool ТумблерН15
        {
            get { return _тумблерН15; }
            set
            {
                _тумблерН15 = value;
                N15Parameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool ТумблерОсвещение
        {
            get { return _тумблерОсвещение; }
            set
            {
                _тумблерОсвещение = value;
                OnParameterChanged();
            }
        }

        public bool ТумблерН13_1
        {
            get { return _тумблерН13_1; }
            set
            {
                _тумблерН13_1 = value;
                N15Parameters.getInstance().Н13_1 = false;
                N15Parameters.getInstance().ResetParametersAlternative();
                N16Parameters.ResetParameters();
                OnParameterChanged();
            }
        }

        public bool ТумблерН13_2
        {
            get { return _тумблерН13_2; }
            set
            {
                _тумблерН13_2 = value;
                N15Parameters.getInstance().Н13_2 = false;
                N15Parameters.getInstance().ResetParametersAlternative();
                N16Parameters.ResetParameters();
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: 1 - Полное, 2 - Откл, 3- Дежурное
        /// </summary>
        public int ТумблерОсвещение1
        {
            get { return _тумблерОсвещение1; }
            set
            {
                _тумблерОсвещение1 = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Возможные состояния: 1- Полное, 2- Откл, 3- Частичное
        /// </summary>
        public int ТумблерОсвещение2
        {
            get { return _тумблерОсвещение2; }
            set
            {
                _тумблерОсвещение2 = value;
                OnParameterChanged();
            }
        }
        #endregion
        #endregion

        #region Переключатели

        private bool _переключательСеть;
        private int _переключательНапряжение = 1;
        private int _переключательФазировка = 1;
        private int _переключательКонтрольНапряжения = 2;
        private int _переключательТокНагрузкиИЗаряда = 1;

        /// <summary>
        /// Переключатель включения блока.
        /// При неправильно подключенном кабеле на блоке Стабилизатора, выводится сообщение об ошибке
        /// </summary>
        public bool ПереключательСеть
        {
            get { return _переключательСеть; }
            set
            {
                if (!VoltageStabilizerParameters.getInstance().КабельПодключенПравильно
                    && VoltageStabilizerParameters.getInstance().КабельВход != 0
                    && !_переключательСеть
                    && ЛампочкаСеть
                    && СтанцияСгорела != null)
                {
                    СтанцияСгорела();
                }
                else
                {
                    _переключательСеть = value;
                    //Нагрузка слетает при переключении
                    Нагрузка = false;
                }
                VoltageStabilizerParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }


        /// <summary>
        /// 1,2,3 - сеть. 4 - нейтральное. 5,6,7 - нагрузка. 
        /// </summary>
        public int ПереключательНапряжение
        {
            get { return _переключательНапряжение; }
            set
            {
                if (value > 0 && value < 8)
                    _переключательНапряжение = value;
                OnParameterChanged();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ПереключательФазировка
        {
            get { return _переключательФазировка; }
            set
            {
                if (value >= 0 && value <= 5)
                    if (ЛампочкаСфазировано && ПереключательСеть
                        && НекорректноеДействие != null)
                    {
                        НекорректноеДействие();
                    }
                    else
                    {
                        _переключательФазировка = value;
                        Нагрузка = false;
                    }
                OnParameterChanged();
            }
        }


        public int ПереключательКонтрольНапряжения
        {
            get { return _переключательКонтрольНапряжения; }
            set
            {
                if (value > 0 && value < 4) _переключательКонтрольНапряжения = value;
                OnParameterChanged();

            }
        }

        public int ПереключательТокНагрузкиИЗаряда
        {
            get { return _переключательТокНагрузкиИЗаряда; }
            set
            {
                if (value > 0 && value < 9) _переключательТокНагрузкиИЗаряда = value;
                OnParameterChanged();

            }
        }
        #endregion

        #region Нагрузка и Фазировка
        private bool _нагрузка = false;

        /// <summary>
        /// Переменная определяющая наличие нагрузки. Сбрасывает все зависимые блоки в том случае, если значение нагрузки изменило
        /// сь
        /// </summary>
        public bool Нагрузка
        {
            get { return _нагрузка; }
            set
            {
                bool flag = value != _нагрузка;
                _нагрузка = value;
                if (flag) N15Parameters.getInstance().ResetParameters();
            }
        }

        /// <summary>
        /// Текущее требуемое для фазировки положение.
        /// </summary>
        public int Фазировка;

        private bool _кнопкаВклНагрузки;

        /// <summary>
        /// Кнопка подачи нагрузки. Если всё выставлено верно, то при нажатии будет нагрузка.
        /// </summary>
        public bool КнопкаВклНагрузки
        {
            get { return _кнопкаВклНагрузки; }
            set
            {
                _кнопкаВклНагрузки = value;
                if (value && !Нагрузка && ПереключательСеть && VoltageStabilizerParameters.getInstance().КабельПодключенПравильно &&
                    ЛампочкаСеть && ПереключательФазировка == Фазировка) Нагрузка = true;
                OnParameterChanged();
            }
        }

        #endregion

        #region Индикаторы
        public int ИндикаторНапряжение
        {
            get
            {
                if (ЛампочкаСеть && ПереключательСеть && (ПереключательФазировка == 2 || ПереключательФазировка == 4))
                {
                    switch (ПереключательНапряжение)
                    {
                        case 1:
                        case 2:
                        case 3:
                            return PowerCabelParameters.getInstance().Напряжение;
                        case 5:
                        case 6:
                        case 7:
                            if ((Нагрузка && VoltageStabilizerParameters.getInstance().КабельПодключенПравильно) &&
                                (ЛампочкаСфазировано || (КнопкаВклНагрузки && !ЛампочкаСфазировано))) return 220;
                            else return 0;
                        default:
                            return 0;

                    }
                }
                return 0;
            }
        }

        /// <summary>
        /// Вычисление величины тока, используемой на станции.
        /// </summary>
        public int ИндикаторТокНагрузки
        {
            get
            {
                return ((КнопкаВклНагрузки && !ЛампочкаСфазировано) || ЛампочкаСфазировано) ? ВключенныеБлоки() * 5 : 0;
            }
        }

        /// <summary>
        /// Определяет количество включенных на данный момент блоков.
        /// </summary>
        /// <returns></returns>
        private int ВключенныеБлоки()
        {
            var propertyList = typeof(N15Parameters).GetProperties().ToArray();
            var quantity = 0;
            foreach (var property in propertyList)
            {
                if (property.Name.Contains("Лампочка"))
                {
                    if ((bool)property.GetValue(N15Parameters.getInstance()))
                    {
                        quantity++;
                    }
                }
            }

            return quantity;
        }

        public int ИндикаторКонтрольНапряжения
        {
            get
            {
                if (ЛампочкаСфазировано && ПереключательКонтрольНапряжения == 1 && ТумблерЭлектрооборудование)
                    return 30;
                if (ЛампочкаСфазировано && ПереключательКонтрольНапряжения == 3 && ТумблерЭлектрооборудование)
                {
                    if (ПереключательТокНагрузкиИЗаряда == 2)
                    {
                        return 30;
                    }
                    if (ПереключательТокНагрузкиИЗаряда == 3)
                    {
                        return 20;
                    }
                    return ПереключательТокНагрузкиИЗаряда * 10 - 10;
                }

                return 0;
            }
        }

        public int ИндикаторТокНагрузкиИЗаряда
        {
            get
            {
                if (ЛампочкаСфазировано && ТумблерЭлектрооборудование)
                {
                    return ПереключательТокНагрузкиИЗаряда * 5;
                }

                return 5;
            }
        }
        #endregion

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        /// <summary>
        /// Событие возникающее, если пользователь осуществил неправильные действия, которые привели к выходу станции из строя.
        /// </summary>
        public event ParameterChangedHandler СтанцияСгорела;
        public event ParameterChangedHandler НекорректноеДействие;

        private void OnParameterChanged()
        {
            ParameterChanged?.Invoke();
        }

        public void ResetParameters()
        {
            OnParameterChanged();
        }


        #region Вспомогательные переменные, для обращения к блоку
        /// <summary>
        /// Определение, включено ли Электрообуродование
        /// </summary>
        public bool ЭлектрообуродованиеВключено
        {
            get { return ЛампочкаСфазировано && ТумблерЭлектрооборудование; }
        }

        /// <summary>
        /// Определение, включён ли Выпрямитель
        /// </summary>
        public bool ВыпрямительВключен
        {
            get { return ЛампочкаСфазировано && ТумблерВыпрямитель27В; }
        }

        /// <summary>
        /// Определение, включён ли Н15
        /// </summary>
        public bool Н15Включен
        {
            get { return ЛампочкаСфазировано && ТумблерН15; }
        }
        #endregion

        public void SetDefaultParameters()
        {
            ПереключательСеть = false;
            ПереключательНапряжение = 1;
            ПереключательФазировка = 1;
            ПереключательКонтрольНапряжения = 1;
            ПереключательТокНагрузкиИЗаряда = 1;
            ТумблерЭлектрооборудование = false;
            ТумблерВыпрямитель27В = false;
            ТумблерОсвещение = false;
            ТумблерН13_1 = false;
            ТумблерН13_2 = false;
            ТумблерН15 = false;
        }

    }
}
