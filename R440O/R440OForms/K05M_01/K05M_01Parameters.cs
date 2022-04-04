using System;
using R440O.R440OForms.A205M_1;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.K05M_01Inside;
using R440O.R440OForms.K04M_01;
using R440O.R440OForms.PU_K1_1;
using R440O.R440OForms.N18_M;
using R440O.R440OForms.BMA_M_1;
using R440O.R440OForms.N18_M_H28;
using R440O.R440OForms.PU_K1_1;
using ShareTypes.SignalTypes;

namespace R440O.R440OForms.K05M_01
{
    public class K05M_01Parameters
    {
        private static K05M_01Parameters instance;
        public static K05M_01Parameters getInstance()
        {
            if (instance == null)
                instance = new K05M_01Parameters();
            return instance;
        }

        private bool Питание
        {
            get { return PU_K1_1Parameters.getInstance().Включен; }
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
            if (N18_M_H28Parameters.getInstance().ПодюклченК11)
                N18_M_H28Parameters.getInstance().ResetParameters();
            OnParameterChanged();
        }

        #endregion

        #region  Перекючатели

        private int _ПереключательПередачаКонтроль = 1;
        private int _ПереключательОслабление;
        private int _ПереключательРодРаботы;
        private int _ПереключательКанал1;
        private int _ПереключательКанал2;


        /// <summary>
        /// 0 - передача работа, 1 - контроль прм, 2 - контроль частота, 3 - контроль борта
        /// </summary>
        public int ПереключательПередачаКонтроль
        {
            get
            {
                return _ПереключательПередачаКонтроль;
            }

            set
            {
                if (value >= 0 && value <= 3)
                {
                    _ПереключательПередачаКонтроль = value;
                    K03M_01Parameters.getInstance().ПересчитатьНайденоИлиНеНайдено();
                    ResetParameters();
                }
            }
        }
        public int ПереключательОслабление
        {
            get
            {
                return _ПереключательОслабление;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _ПереключательОслабление = value;
                    ResetParameters();
                }
            }
        }
        public int ПереключательРодРаботы
        {
            get
            {
                return _ПереключательРодРаботы;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _ПереключательРодРаботы = value;
                    ResetParameters();
                }
            }
        }
        public int ПереключательКанал1
        {
            get
            {
                return _ПереключательКанал1;
            }

            set
            {
                if (value >= 0 && value <= 3)
                {
                    _ПереключательКанал1 = value;
                    ResetParameters();
                }
            }
        }
        public int ПереключательКанал2
        {
            get
            {
                return _ПереключательКанал2;
            }

            set
            {
                if (value >= 0 && value <= 2)
                {
                    _ПереключательКанал2 = value;
                    ResetParameters();
                }
            }
        }
        #endregion

        private int Ослабление
        {
            get
            {
                switch (ПереключательОслабление)
                {
                    case 0: return 0;
                    case 1: return 20;
                    case 2: return 27;
                    // Хотя это и не возможно
                    default: return 0;
                }
            }
        }

        public int СтрелкаУровень
        {
            get
            {
                return Питание ? Math.Max((РегуляторУровень * 4) - Ослабление, -36) : 0;
            }
        }

        private int _регуляторУровень = 0;
        public int РегуляторУровень
        {
            get { return _регуляторУровень; }
            set
            {
                if (value >= -9 && value <= 9 && _регуляторУровень != value)
                {
                    _регуляторУровень = value;
                    ResetParameters();
                }
            }
        }

        public bool СтрелкаУровеньВЗакрашенномСекторе
        {
            get { return СтрелкаУровень >= 0 && СтрелкаУровень <= 9; }
        }

        public KulonSignal Сигнал
        {
            get
            {
                if (!Питание)
                    return null;
                var сигнал = new KulonSignal(K04M_01Parameters.getInstance().ЧастотаПрд);
                сигнал.SynchroSequence1 = K05M_01InsideParameters.getInstance().Переключатель.Синхропоследовательность1;
                сигнал.SynchroSequence2 = K05M_01InsideParameters.getInstance().Переключатель.Синхропоследовательность2;
                if (K05M_01InsideParameters.getInstance().ТумблерВ4)
                    сигнал.BarkerCode = K05M_01InsideParameters.getInstance().ТумблерВ4;
                //сигнал.Level = СтрелкаУровень;

                if (N18_MParameters.getInstance().ПереключательПрдБма12 == 9)
                {
                    if (N18_MParameters.getInstance().ПереключательВходК121 == 2)
                    {
                        сигнал.FirstChanel = BMA_M_1Parameters.getInstance().СигналСБМБ;
                    }
                    else if (N18_MParameters.getInstance().ПереключательВходК121 == 2)
                    {
                        //TODO когда будет готов второй БМА
                    }
                }
                return сигнал;
            }
        }
    }
}
