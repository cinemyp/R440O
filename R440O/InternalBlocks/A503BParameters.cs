using ShareTypes.SignalTypes;
using R440O.R440OForms.N16;
using R440O.R440OForms.NKN_1;
using R440O.R440OForms.NKN_2;
using R440O.R440OForms.N15;
using System.Collections.Generic;
using System.CodeDom;

namespace R440O.InternalBlocks
{
    public static class A503BParameters
    {
        /// <summary>
        /// Величина сдвига несущей частоты.
        /// </summary>
        private const int WaveShift = 1500;

        /// <summary>
        /// Частота сдвига
        /// </summary>
        private const int FrequencyShift = 2325000;

        /// <summary>
        /// Условие, при котором на данный блок подано питание.
        /// </summary>
        public static bool Включен
        {
            get { return N15Parameters.НеполноеВключение && N15Parameters.ТумблерА503Б; }
        }

        /// <summary>
        /// Значение сигнала после прохождения данного блока.
        /// В данном блоке происходит преобразование частоты волны, при проверке на себя.
        /// Также добавляется уровень мощности сигнала, в соответствии с регулятором на Н15.
        /// </summary>
        public static BroadcastSignal ВыходнойСигнал
        {
            get
            {
                if (!Включен) return null;

                var inputSignal = N16Parameters.ВыходнойСигнал;                

                if (inputSignal == null) return null;

                var outputSignal = inputSignal;
                outputSignal.Wave -= WaveShift;
                outputSignal.Frequency -= FrequencyShift;
                var outputSignals = new List<Signal>();
                outputSignals.Add(outputSignal);
                return new BroadcastSignal { Signals = outputSignals };
            }
        }

        /*
        public static void ResetParameters()
        {
            MSHUParameters.ResetParameters();
        }
        */ 
         
    }
}
