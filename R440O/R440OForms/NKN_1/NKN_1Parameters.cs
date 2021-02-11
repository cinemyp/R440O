using R440O.R440OForms.A205M_1;
using R440O.R440OForms.N15;
using R440O.R440OForms.N502B;
using R440O.InternalBlocks;

namespace R440O.R440OForms.NKN_1
{
    /// <summary>
    /// Параметры блока НКН-1
    /// </summary>
    public static class NKN_1Parameters
    {
        public static bool НеполноеВключение //без н15, горит МУ и все
        {
            get { return N502BParameters.ВыпрямительВключен && N502BParameters.ЭлектрообуродованиеВключено; }
        }

        public static bool ПолноеВключение //горят лампочки фаз
        {
            get { return НеполноеВключение && Питание220Включено && N15Parameters.Включен; }
        }

        private static bool _дистанционноеВключение;

        public static bool ДистанционноеВключение
        {
            get { return _дистанционноеВключение; }
            set
            {
                _дистанционноеВключение = value;
            }
        }

        public static bool ЛампочкаМУ
        {
            get { return НеполноеВключение; }
        }

        public static bool ЛампочкаФаза1
        {
            get { return ПолноеВключение; }
        }

        public static bool ЛампочкаФаза2
        {
            get { return ПолноеВключение; }
        }

        public static bool ЛампочкаФаза3
        {
            get { return ПолноеВключение; }
        }

        private static bool _питание220Включено;

        public static bool Питание220Включено
        {
            get { return _питание220Включено; }
            set
            {
                if (!value) _дистанционноеВключение = false;
                _питание220Включено = value;

                OnParameterChanged();
                N15Parameters.ResetParametersAlternative();
                A205M_1Parameters.ResetParameters();
                //A503BParameters.ResetParameters();
            }
        }

        public delegate void ParameterChangedHandler();

        public static event ParameterChangedHandler ParameterChanged;

        private static void OnParameterChanged()
        {
            var handler = ParameterChanged;
            if (handler != null) handler();
        }

        public static void ResetParameters()
        {
            if ((N15Parameters.НеполноеВключение && !N15Parameters.Включен && НеполноеВключение && ПолноеВключение) || !НеполноеВключение)
                _питание220Включено = false;
           // A503BParameters.ResetParameters();
            OnParameterChanged();
        }
    }
}
