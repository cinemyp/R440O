using R440O.R440OForms.A205M_1;
using R440O.R440OForms.A205M_2;
using R440O.R440OForms.K01M_01;
using R440O.R440OForms.K02M_01;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.K05M_01;
using R440O.R440OForms.N15;
using R440O.R440OForms.N18_M_H28;
using R440O.R440OForms.N18_M;
using R440O.ThirdParty;

namespace R440O.R440OForms.PU_K1_1
{
    public static class PU_K1_1Parameters
    {
        public static bool Включен
        {
            get
            {
                return (N15Parameters.Включен && (ТумблерПитание == 0 && N15Parameters.ТумблерК1_1) || ТумблерПитание == 2)
                    && N15Parameters.Лампочка27В;
            }
        }

        public static bool ПереключателиВыставленыВерно
        {
            get
            {
                return КулонК1Подключен && K05M_01Parameters.СтрелкаУровеньВЗакрашенномСекторе && 
                       (K05M_01Parameters.ПереключательПередачаКонтроль == 0 ||
                        (K05M_01Parameters.ПереключательПередачаКонтроль == 2 && K05M_01Parameters.ПереключательОслабление == 0));
            }
        }
        public static bool КулонК1Подключен
        {
            get { return Включен && N18_M_H28Parameters.АктивныйКабель == 1; }
        }

        #region Лампочка

        public static bool ЛампочкаCеть
        {
            get { return Включен; }
        }

        #endregion
        
        #region Тумблеры
        private static int _тумблерПитание = 1;
        ////Тумблеры 
        /// <summary>
        /// Возможные состояния: 0. Дист - дистанционное управление, 1. Откл - отключено, 2. Мест - местное управление.
        /// </summary>
        public static int ТумблерПитание
        {
            get { return _тумблерПитание; }

            set
            {
                _тумблерПитание = value; 
                ResetParameters();
            }
        }

        private static bool _тумблерВентВкл = false;

        public static bool ТумблерВентВкл
        {
            get { return _тумблерВентВкл; }
            set
            {
                _тумблерВентВкл = value;
                OnParameterChanged();
            }
        }
        #endregion

        #region Переключатели
        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _переключательКаналы = 1;

        public static int ПереключательКаналы
        {
            get
            {
                return _переключательКаналы;
            }

            set
            {
                if (value > 0 && value < 5)
                {
                    _переключательКаналы = value;
                    OnParameterChanged();
                }
            }
        }

        /// <summary>
        /// Положение переключателя контроля
        /// </summary>
        private static int _ПереключательНапряжение = 1;

        public static int ПереключательНапряжение
        {
            get
            {
                return _ПереключательНапряжение;
            }

            set
            {
                if (value > 0 && value < 13)
                {
                    _ПереключательНапряжение = value;
                    if (Включен)
                    {
                        АктивизироватьСтрелкуНапряжения();
                    }
                    OnParameterChanged();
                }
            }
        }
        #endregion

        private static int _напряжение = 0;

        public static int Напряжение
        {
            get { return _напряжение; }
            set
            {
                if (value >= 0 && value <= 20)
                {
                    _напряжение = value;
                }
            }
        }
        public static void АктивизироватьСтрелкуНапряжения()
        {
            Напряжение = 7;
            EasyTimer.SetTimeout((() =>
            {
                Напряжение = 10;
                OnParameterChanged();
            }), 300);
        }

        #region событие

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
            N18_MParameters.ResetParameters();
            if (Включен)
            {
                K03M_01Parameters.НачатьПоискСНачала();
                АктивизироватьСтрелкуНапряжения();

            }
            else
            {
                K03M_01Parameters.ОтменитьПоиск();
                Напряжение = 0;

            }
            K01M_01Parameters.ResetParameters();
            K02M_01Parameters.ResetParameters();
            K03M_01Parameters.ResetParameters();
            K05M_01Parameters.ResetParameters();
            A205M_1Parameters.ResetParameters();
            A205M_2Parameters.ResetParameters();
        }

        #endregion
    }
}
