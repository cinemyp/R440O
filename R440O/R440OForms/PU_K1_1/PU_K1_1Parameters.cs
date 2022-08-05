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
using System.Linq;

namespace R440O.R440OForms.PU_K1_1
{
    public class PU_K1_1Parameters
    {
        private static PU_K1_1Parameters instance;
        public static PU_K1_1Parameters getInstance()
        {
            if (instance == null)
                instance = new PU_K1_1Parameters();
            return instance;
        }

        private bool[] VoltagePoints = new bool[12];
        public bool VoltageChecked
        {
            get
            {
                return VoltagePoints.All(item => item == true);
            }
        }


        public bool Включен
        {
            get
            {
                return (N15Parameters.getInstance().Включен && (ТумблерПитание == 0 && N15Parameters.getInstance().ТумблерК1_1) || ТумблерПитание == 2)
                    && N15Parameters.getInstance().Лампочка27В;
            }
        }

        public bool ПереключателиВыставленыВерно
        {
            get
            {
                return КулонК1Подключен && K05M_01Parameters.getInstance().СтрелкаУровеньВЗакрашенномСекторе &&
                       (K05M_01Parameters.getInstance().ПереключательПередачаКонтроль == 0 ||
                        (K05M_01Parameters.getInstance().ПереключательПередачаКонтроль == 2 && 
                        K05M_01Parameters.getInstance().ПереключательОслабление == 0));
            }
        }
        public bool КулонК1Подключен
        {
            get { return Включен && N18_M_H28Parameters.getInstance().АктивныйКабель == 1; }
        }

        #region Лампочка

        public bool ЛампочкаCеть
        {
            get { return Включен; }
        }

        #endregion

        #region Тумблеры
        private int _тумблерПитание = 1;
        ////Тумблеры 
        /// <summary>
        /// Возможные состояния: 0. Дист - дистанционное управление, 1. Откл - отключено, 2. Мест - местное управление.
        /// </summary>
        public int ТумблерПитание
        {
            get { return _тумблерПитание; }

            set
            {
                _тумблерПитание = value;
                ResetParameters();
            }
        }

        private bool _тумблерВентВкл = false;

        public bool ТумблерВентВкл
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
        private int _переключательКаналы = 1;

        public int ПереключательКаналы
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
        private int _ПереключательНапряжение = 1;

        public int ПереключательНапряжение
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
                        АктивизироватьСтрелкуНапряжения(value);
                    }
                    OnParameterChanged();
                }
            }
        }
        #endregion

        private int _напряжение = 0;

        public int Напряжение
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
        public void АктивизироватьСтрелкуНапряжения(int voltagePoint = 1)
        {
            Напряжение = 7;
            EasyTimer.SetTimeout((() =>
            {
                Напряжение = 10;
                VoltagePoints[voltagePoint - 1] = true;
                OnParameterChanged();
            }), 300);
        }

        #region событие

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
            N18_MParameters.getInstance().ResetParameters();
            if (Включен)
            {
                K03M_01Parameters.getInstance().НачатьПоискСНачала();
                АктивизироватьСтрелкуНапряжения();

            }
            else
            {
                K03M_01Parameters.getInstance().ОтменитьПоиск();
                Напряжение = 0;

            }
            K01M_01Parameters.getInstance().ResetParameters();
            K02M_01Parameters.getInstance().ResetParameters();
            K03M_01Parameters.getInstance().ResetParameters();
            K05M_01Parameters.getInstance().ResetParameters();
            A205M_1Parameters.getInstance().ResetParameters();
            A205M_2Parameters.ResetParameters();
        }

        #endregion
    }
}
