using System;
using System.Windows.Forms;
using R440O.R440OForms.A403_1;
using R440O.R440OForms.N15;

namespace R440O.Parameters
{
    public class N12SParameters
    {
        private static N12SParameters instance;
        public static N12SParameters getInstance()
        {
            if (instance == null)
                instance = new N12SParameters();
            return instance;
        }
        public delegate void TestModuleHandler(JsonAdapter.ActionStation action);
        public event TestModuleHandler Action;
        private void OnAction(string name, int value)
        {
            var action = new JsonAdapter.ActionStation(name, value);
            Action?.Invoke(action);
        }
        public bool Включен { get { return ТумблерСеть && N15Parameters.getInstance().ТумблерН12С && N15Parameters.getInstance().Включен; } }
        public bool FromA403 = false;

        private int _тумблерА;
        private int _тумблерБ;
        private bool _тумблерСеть;
        private bool _кнопкаУскор;
        private float _потенциометрBetaИ = 0;
        private float _потенциометрBetaV = 0;
        private float _потенциометрAlphaИ = 0;
        private float _потенциометрAlphaV = 0;

        #region Тумблеры и кнопка

        public bool ТумблерСеть
        {
            get { return _тумблерСеть; }
            set
            {
                _тумблерСеть = value;
                OnParameterChanged();
                N15Parameters.getInstance().ResetParametersAlternative();
            }
        }

        /// <summary>
        /// Тумблер для вращения индикатора альфа
        /// Возможные состояния: -1 - вращение влево, 0 - никуда, 1 - вправо
        /// </summary>
        public int ТумблерА
        {
            get { return _тумблерА; }
            set
            {
                _тумблерА = value;

                if (ЛампочкаГотовность)
                    switch (_тумблерА)
                    {
                        case -1:
                            {
                                timer.Enabled = true;
                                timer.Interval = КнопкаУскор ? 5 : 50;
                                timer.Tick += timerAlphaLeft_Tick;
                                timer.Tick -= timerAlphaReturn_Tick;
                                timer.Start();
                                break;
                            }
                        case 0:
                            {
                                timer.Tick -= timerAlphaLeft_Tick;
                                timer.Tick -= timerAlphaRight_Tick;
                                timer.Tick += timerAlphaReturn_Tick;
                                break;
                            }
                        case 1:
                            {
                                timer.Enabled = true;
                                timer.Interval = КнопкаУскор ? 5 : 50;
                                timer.Tick += timerAlphaRight_Tick;
                                timer.Tick -= timerAlphaReturn_Tick;
                                timer.Start();
                                break;
                            }

                    }
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Тумблер для вращения индикатора бета
        /// Возможные состояния: -1 - вращение влево, 0 - никуда, 1 - вправо
        /// </summary>
        public int ТумблерБ
        {
            get { return _тумблерБ; }
            set
            {
                _тумблерБ = value;

                if (ЛампочкаГотовность)
                    switch (_тумблерБ)
                    {
                        case -1:
                            {
                                timer.Enabled = true;
                                timer.Interval = КнопкаУскор ? 5 : 50;
                                timer.Tick += timerBetaLeft_Tick;
                                timer.Tick -= timerBetaReturn_Tick;
                                timer.Start();
                                break;
                            }
                        case 0:
                            {
                                timer.Tick -= timerBetaLeft_Tick;
                                timer.Tick -= timerBetaRight_Tick;
                                timer.Tick += timerBetaReturn_Tick;
                                break;
                            }
                        case 1:
                            {
                                timer.Enabled = true;
                                timer.Interval = КнопкаУскор ? 5 : 50;
                                timer.Tick -= timerBetaReturn_Tick;
                                timer.Tick += timerBetaRight_Tick;
                                timer.Start();
                                break;
                            }
                    }
                OnParameterChanged();
            }
        }

        /// <summary>
        /// Кнопка для увеличения скорости вращения индикаторов
        /// </summary>
        public bool КнопкаУскор
        {
            get { return _кнопкаУскор; }
            set
            {
                _кнопкаУскор = value;
                OnParameterChanged();
            }
        }
        #endregion

        #region Лампочки
        public bool ЛампочкаУпорА
        {
            get { return (ИндикаторAlpha <= -270 || ИндикаторAlpha >= 270) && Включен; }
        }

        public bool ЛампочкаУпорБ
        {
            get { return (ИндикаторBeta <= 0 || ИндикаторBeta >= 90) && Включен; }
        }

        public bool ЛампочкаГотовность
        {
            get { return Включен; }
        }
        #endregion

        #region Индикаторы

        /// <summary>
        /// значения от -270 до 270, но крутиться могут произвольно
        /// </summary>
        public float ИндикаторAlpha { get; set; }

        /// <summary>
        /// значения от 0 до 90, но крутиться могут произвольно
        /// </summary>
        public float ИндикаторBeta { get; set; }

        #endregion

        #region Потенциометры

        #region ПотенциометрBetaИ

        public float ПотенциометрBetaИ
        {
            get
            {
                return Включен ? _потенциометрBetaИ : 0;
            }
            set
            {
                if (FromA403 && value >= 0 && value <= 90)
                {
                    _потенциометрBetaИ = value;
                    ИндикаторBeta = ПотенциометрBetaИ;
                }
                if (value >= 0 && value <= 90 && !ЛампочкаУпорБ) _потенциометрBetaИ = value;
                OnParameterChanged();
                A403_1Parameters.getInstance().ResetDisplay();
            }
        }
        #endregion

        #region ПотенциометрBetaV

        public float ПотенциометрBetaV
        {
            get
            {
                if (!Включен)
                {
                    _потенциометрBetaV = 0;
                    timer.Stop();
                    timer.Enabled = false;
                }
                else
                {
                    if (ЛампочкаУпорБ && !timer.Enabled)
                        _потенциометрBetaV = 0;
                }

                if (_потенциометрBetaV >= -0.2 && _потенциометрBetaV <= 0.2)
                    timer.Tick -= timerBetaReturn_Tick;

                return _потенциометрBetaV;
            }
            set
            {
                if (((!КнопкаУскор && value >= -10 && value <= 10) || (КнопкаУскор && value >= -20 && value <= 20))
                    && !(_потенциометрBetaV - value < 0 && ПотенциометрBetaИ < 45 && ЛампочкаУпорБ)
                    && !(_потенциометрBetaV - value > 0 && ПотенциометрBetaИ > 45 && ЛампочкаУпорБ)
                    && !(_потенциометрBetaV >= -0.2 && _потенциометрBetaV <= 0.2 && ЛампочкаУпорБ))

                    _потенциометрBetaV = value;
            }
        }
        #endregion

        #region ПотенциометрAlphaИ

        public float ПотенциометрAlphaИ
        {
            get
            {
                return Включен ? _потенциометрAlphaИ : 0;
            }
            set
            {
                if (FromA403 && value >= 0 && value <= 90)
                {
                    _потенциометрAlphaИ = value;
                    ИндикаторAlpha = ПотенциометрAlphaИ;
                }
                if (value >= -270 && value <= 270 && !ЛампочкаУпорА) _потенциометрAlphaИ = value;
                OnParameterChanged();
                A403_1Parameters.getInstance().ResetDisplay();
            }
        }
        #endregion

        #region ПотенциометрAlphaV

        public float ПотенциометрAlphaV
        {
            get
            {
                if (!Включен)
                {
                    _потенциометрAlphaV = 0;
                    timer.Stop();
                    timer.Enabled = false;
                }
                else
                {
                    if (ЛампочкаУпорА && !timer.Enabled)
                        _потенциометрAlphaV = 0;
                }

                if (_потенциометрAlphaV >= -0.05 && _потенциометрAlphaV <= 0.05)
                    timer.Tick -= timerAlphaReturn_Tick;

                return _потенциометрAlphaV;
            }
            set
            {
                if (((!КнопкаУскор && value >= -10 && value <= 10) || (КнопкаУскор && value >= -20 && value <= 20))
                    && !(_потенциометрAlphaV - value < 0 && ПотенциометрAlphaИ < 0 && ЛампочкаУпорА)
                    && !(_потенциометрAlphaV - value > 0 && ПотенциометрAlphaИ > 0 && ЛампочкаУпорА)
                    && !(_потенциометрAlphaV >= -0.05 && _потенциометрAlphaV <= 0.05 && ЛампочкаУпорА))

                    _потенциометрAlphaV = value;
            }
        }
        #endregion

        #endregion

        #region Вращение индикаторов и потенциометров

        /// <summary>
        /// Таймер для доведения потенциометров
        /// </summary>
        private Timer timer = new Timer();

        #region Альфа
        /// <summary>
        /// Вращение индиктора альфа вправо
        /// </summary>
        void timerAlphaRight_Tick(object sender, EventArgs e)
        {
            ИндикаторAlpha += 0.5F;
            ПотенциометрAlphaИ += 0.5F;
            ПотенциометрAlphaV -= 0.1F;

            if (ЛампочкаУпорА)
                if (ПотенциометрAlphaV > 0)
                    ПотенциометрAlphaV -= 0.1F;
                else
                    ПотенциометрAlphaV += 0.1F;

            OnParameterChanged();
        }

        /// <summary>
        /// Вращение индиктора альфа влево
        /// </summary>
        void timerAlphaLeft_Tick(object sender, EventArgs e)
        {
            ИндикаторAlpha -= 0.5F;
            ПотенциометрAlphaИ -= 0.5F;
            ПотенциометрAlphaV += 0.1F;

            if (ЛампочкаУпорА)
                if (ПотенциометрAlphaV > 0)
                    ПотенциометрAlphaV -= 0.1F;
                else
                    ПотенциометрAlphaV += 0.1F;

            OnParameterChanged();
        }

        /// <summary>
        /// возврат стрелки потенциометра альфа
        /// </summary>
        void timerAlphaReturn_Tick(object sender, EventArgs e)
        {
            if (ПотенциометрAlphaV > 0)
                ПотенциометрAlphaV -= 0.1F;
            else
                ПотенциометрAlphaV += 0.1F;

            OnParameterChanged();
        }
        #endregion

        #region Бета
        /// <summary>
        /// Вращение индиктора бета вправо
        /// </summary>
        void timerBetaRight_Tick(object sender, EventArgs e)
        {
            ИндикаторBeta += 0.5F;
            ПотенциометрBetaИ += 0.5F;
            ПотенциометрBetaV -= 0.2F;

            if (ЛампочкаУпорБ)
                if (ПотенциометрBetaV > 0)
                    ПотенциометрBetaV -= 0.2F;
                else
                    ПотенциометрBetaV += 0.2F;

            OnParameterChanged();
        }

        /// <summary>
        /// Вращение индиктора бета влево
        /// </summary>
        void timerBetaLeft_Tick(object sender, EventArgs e)
        {
            ИндикаторBeta -= 0.5F;
            ПотенциометрBetaИ -= 0.5F;
            ПотенциометрBetaV += 0.2F;

            if (ЛампочкаУпорБ)
                if (ПотенциометрBetaV > 0)
                    ПотенциометрBetaV -= 0.2F;
                else
                    ПотенциометрBetaV += 0.2F;

            OnParameterChanged();
        }

        /// <summary>
        /// возврат стрелки потенциометра бета
        /// </summary>
        void timerBetaReturn_Tick(object sender, EventArgs e)
        {
            if (ПотенциометрBetaV > 0)
                ПотенциометрBetaV -= КнопкаУскор ? 0.2F : 0.4F;
            else
                ПотенциометрBetaV += КнопкаУскор ? 0.2F : 0.4F;

            OnParameterChanged();
        }
        #endregion

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
