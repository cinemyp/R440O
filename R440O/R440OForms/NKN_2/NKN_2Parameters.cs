﻿using R440O.R440OForms.A205M_2;
using R440O.R440OForms.N15;
using R440O.R440OForms.N502B;

namespace R440O.R440OForms.NKN_2
{
    /// <summary>
    /// Параметры блока НКН-2
    /// </summary>
    public class NKN_2Parameters
    {
        private static NKN_2Parameters instance;
        public static NKN_2Parameters getInstance()
        {
            if (instance == null)
                instance = new NKN_2Parameters();
            return instance;
        }

        public bool НеполноеВключение //без н15, горит МУ и все
        {
            get { return N502BParameters.getInstance().ВыпрямительВключен && N502BParameters.getInstance().ЭлектрообуродованиеВключено; }
        }

        public bool ПолноеВключение //горят лампочки фаз
        {
            get { return НеполноеВключение && Питание220Включено && N15Parameters.getInstance().Включен; }
        }

        private bool _дистанционноеВключение;

        public bool ДистанционноеВключение
        {
            get { return _дистанционноеВключение; }
            set
            {
                _дистанционноеВключение = value;
            }
        }

        public bool ЛампочкаМУ
        {
            get { return НеполноеВключение; }
        }

        public bool ЛампочкаФаза1
        {
            get { return ПолноеВключение; }
        }

        public bool ЛампочкаФаза2
        {
            get { return ПолноеВключение; }
        }

        public bool ЛампочкаФаза3
        {
            get { return ПолноеВключение; }
        }

        private bool _питание220Включено;

        public bool Питание220Включено
        {
            get { return _питание220Включено; }
            set
            {
                if (!value) _дистанционноеВключение = false;
                _питание220Включено = value;

                OnParameterChanged();
                N15Parameters.getInstance().ResetParametersAlternative();
                A205M_2Parameters.ResetParameters();
            }
        }

        public delegate void ParameterChangedHandler();
        public event ParameterChangedHandler ParameterChanged;

        private void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public void ResetParameters()
        {
            if ((N15Parameters.getInstance().НеполноеВключение && !N15Parameters.getInstance().Включен && НеполноеВключение && ПолноеВключение) || !НеполноеВключение)
                _питание220Включено = false;
            OnParameterChanged();
        }
    }
}
