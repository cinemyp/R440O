using R440O.R440OForms.P220_27G_2;
using R440O.R440OForms.P220_27G_3;

namespace R440O.R440OForms.B1_1
{
    using System.Collections.Generic;
    using N15Inside;
    using N18_M;
    using ShareTypes.SignalTypes;
    using N15;
    using B2_1;

    public class B1_1Parameters
    {
        private static B1_1Parameters instance;
        public static B1_1Parameters getInstance()
        {
            if (instance == null)
                instance = new B1_1Parameters();
            return instance;
        }

        #region Работа блока

        public bool Включен
        {
            get
            {
                return (P220_27G_2Parameters.getInstance().Включен || P220_27G_3Parameters.getInstance().Включен) &&
                       (ТумблерМуДу || !ТумблерМуДу && N15Parameters.getInstance().ТумблерБ1_1);
            }
        }

        /// <summary>
        /// Сигнал от блока Б2 или от ПУЛ ПРМ.
        /// </summary>
        public Signal ВходнойСигнал
        {
            get
            {
                if (Включен &&
                    N15InsideParameters.getInstance().ВыходПриемногоТракта != null &&
                    N18_MParameters.getInstance().ПереключательПРМ1 == 4)
                    return N15InsideParameters.getInstance().ВыходПриемногоТракта;

                if (Включен && B2_1Parameters.getInstance().ВыходнойСигнал1 != null && B2_1Parameters.getInstance().ВыходнойСигнал1.SelectedGroupElements.Count != 0)
                    return B2_1Parameters.getInstance().ВыходнойСигнал1;
                return null;
            }
        }

        /// <summary>
        /// Соответствует ли входящий сигнал нажатым кнопкам.
        /// </summary>
        public bool ВходящийСигналПравильный
        {
            get
            {
                if (ВходнойСигнал != null)
                {
                    return ВходнойСигнал.SpeedOfChanel(1) == НеобходимыйСигнал.SpeedOfChanel(1) &&
                        ВходнойСигнал.SpeedOfChanel(2) == НеобходимыйСигнал.SpeedOfChanel(2) &&
                        ВходнойСигнал.SpeedOfChanel(3) == НеобходимыйСигнал.SpeedOfChanel(3);
                }

                return false;
            }
        }

        public Signal ВыходнойСигнал
        {
            get
            {
                return ВходящийСигналПравильный ? ВходнойСигнал : null;
            }
        }


        /// <summary>
        /// Сигнал с одним элементом, скорости каналов которого соответствуют текущим выбранным настройкам.
        /// </summary>
        private Signal НеобходимыйСигнал
        {
            get
            {
                if (КнопкаСкоростьГР)
                    return new Signal
                    {
                        GroupSpeed = 2.4,
                        Elements = new List<SignalElement>
                        {
                            new SignalElement(new[] {-1, 0, 1.2, 0, 0.1, 0.1, 0.05, 0.025})
                        }
                    };

                if (КнопкаСкоростьАб1ТлфК)
                {
                    return new Signal
                    {
                        GroupSpeed = 4.8,
                        Elements = new List<SignalElement>
                        {
                            new SignalElement(new[] {-1, 2.4, 1.2, 0, 0.1, 0.1, 0.05, 0.025})
                        }
                    };
                }

                return new Signal
                {
                    GroupSpeed = 4.8,
                    Elements = new List<SignalElement>
                    {
                        new SignalElement(new[] {-1, 1.2, 1.2, 1.2, 0.1, 0.1, 0.05, 0.025})
                    }
                };
            }
        }



        #endregion

        private bool _тумблерМуДу;
        private bool _кнопкаСкоростьГР;
        private bool _кнопкаСкоростьАб1Тлфк;
        private bool _колодкаТлГпр11;
        private bool _колодкаТлГпр12;
        private bool _колодкаТлГпр21;
        private bool _колодкаТлГпр22;
        private bool _колодкаТлГпр31;
        private bool _колодкаТлГпр32;

        #region Лампочки

        #region Левые
        public bool ЛампочкаБОЧ { get; set; }

        public bool ЛампочкаПУЛ_1
        {
            get { return Включен && ВходнойСигнал == null; }
        }

        public bool ЛампочкаПУЛ_2
        {
            get { return Включен && ВходнойСигнал != null; ; }
        }

        public bool ЛампочкаПРСС { get; set; }
        #endregion

        #region Каналы

        /// <summary>
        /// Лампочка Авария горит: не соответствуют скорости.
        /// </summary>
        public bool ЛампочкаТКБтк1_1
        {
            get
            {
                if (ЛампочкаТКБтк1_2 && !Signal.IsEquivalentSpeed(ВходнойСигнал.SpeedOfChanel(1),
                    НеобходимыйСигнал.SpeedOfChanel(1)))
                    return true;
                return false;
            }
        }

        /// <summary>
        /// Лампочка Сигнал горит: сигнал в наличии (имеет опр. скорость) и нет информации в канале.
        /// </summary>
        public bool ЛампочкаТКБтк1_2
        {
            get
            {
                if (ВходнойСигнал != null && НеобходимыйСигнал.SpeedOfChanel(1) != 0 &&
                    !ВходнойСигнал.InformationOfChanel(1))
                    return true;
                return false;
            }
        }
        public bool ЛампочкаТКБтк2_1
        {
            get
            {
                if (ЛампочкаТКБтк2_2 &&
                    !Signal.IsEquivalentSpeed(ВходнойСигнал.SpeedOfChanel(2),
                    НеобходимыйСигнал.SpeedOfChanel(2)))
                    return true;
                return false;
            }
        }

        public bool ЛампочкаТКБтк2_2
        {
            get
            {
                if (ВходнойСигнал != null && НеобходимыйСигнал.SpeedOfChanel(2) != 0 &&
                    !ВходнойСигнал.InformationOfChanel(2))
                    return true;
                return false;
            }
        }

        public bool ЛампочкаТКБтк3_1
        {
            get
            {
                if (ЛампочкаТКБтк3_2 &&
                    !Signal.IsEquivalentSpeed(ВходнойСигнал.SpeedOfChanel(3),
                    НеобходимыйСигнал.SpeedOfChanel(3)))
                    return true;
                return false;
            }
        }
        public bool ЛампочкаТКБтк3_2
        {
            get
            {
                if (ВходнойСигнал != null && НеобходимыйСигнал.SpeedOfChanel(3) != 0 &&
                    !ВходнойСигнал.InformationOfChanel(3))
                    return true;
                return false;
            }
        }
        public bool ЛампочкаТКБАвар { get; set; }
        #endregion

        #region Эластичная память

        /// <summary>
        /// Лампочка Авария эластичной памяти горит, если не совпадают скорости, либо канал отсутствует(скорости нет).
        /// </summary>
        public bool ЛампочкаДФАПЧ1
        {
            get
            {
                return ВходнойСигнал != null && (!Signal.IsEquivalentSpeed
                    (ВходнойСигнал.SpeedOfChanel(1), НеобходимыйСигнал.SpeedOfChanel(1))
                    || ВходнойСигнал.SpeedOfChanel(1) == 0);
            }
        }

        public bool ЛампочкаДФАПЧ2
        {
            get
            {
                return ВходнойСигнал != null && (!Signal.IsEquivalentSpeed
                    (ВходнойСигнал.SpeedOfChanel(2), НеобходимыйСигнал.SpeedOfChanel(2))
                    || ВходнойСигнал.SpeedOfChanel(2) == 0);
            }
        }

        public bool ЛампочкаДФАПЧ3
        {
            get
            {
                return ВходнойСигнал != null && (!Signal.IsEquivalentSpeed
                    (ВходнойСигнал.SpeedOfChanel(3), НеобходимыйСигнал.SpeedOfChanel(3))
                    || ВходнойСигнал.SpeedOfChanel(3) == 0);
            }
        }
        #endregion

        public bool ЛампочкаТЛГпр1 { get; set; }
        public bool ЛампочкаТЛГпр2 { get; set; }
        public bool ЛампочкаТЛГпр3 { get; set; }
        public bool ЛампочкаВУП_1 { get { return Включен; } }
        public bool ЛампочкаВУПНеиспр { get; set; }

        #endregion

        #region Колодки

        public bool КолодкаТлГпр11
        {
            get { return _колодкаТлГпр11; }
            set
            {
                if (value) _колодкаТлГпр12 = false;
                _колодкаТлГпр11 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр12
        {
            get { return _колодкаТлГпр12; }
            set
            {
                if (value) _колодкаТлГпр11 = false;
                _колодкаТлГпр12 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр21
        {
            get { return _колодкаТлГпр21; }
            set
            {
                if (value) _колодкаТлГпр22 = false;
                _колодкаТлГпр21 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр22
        {
            get { return _колодкаТлГпр22; }
            set
            {
                if (value) _колодкаТлГпр21 = false;
                _колодкаТлГпр22 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр31
        {
            get { return _колодкаТлГпр31; }
            set
            {
                if (value) _колодкаТлГпр32 = false;
                _колодкаТлГпр31 = value;
                OnParameterChanged();
            }
        }

        public bool КолодкаТлГпр32
        {
            get { return _колодкаТлГпр32; }
            set
            {
                if (value) _колодкаТлГпр31 = false;
                _колодкаТлГпр32 = value;
                OnParameterChanged();
            }
        }

        #endregion

        #region Тумблеры и Кнопки
        /// <summary>
        /// Возможные состояния: Му - true, Ду - false
        /// </summary>
        public bool ТумблерМуДу
        {
            get { return _тумблерМуДу; }
            set
            {
                _тумблерМуДу = value;
                N18_MParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool КнопкаСкоростьГР
        {
            get { return _кнопкаСкоростьГР; }
            set
            {
                _кнопкаСкоростьГР = value;
                N18_MParameters.getInstance().ResetParameters();
                OnParameterChanged();
            }
        }

        public bool КнопкаСкоростьАб1ТлфК
        {
            get { return _кнопкаСкоростьАб1Тлфк; }
            set
            {
                _кнопкаСкоростьАб1Тлфк = value;
                N18_MParameters.getInstance().ResetParameters();
                OnParameterChanged();
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
    }
}
