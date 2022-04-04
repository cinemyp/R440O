﻿namespace R440O.InternalBlocks
{
    using ShareTypes.SignalTypes;
    using R440OForms.A304;
    using R440OForms.N15;
    using R440OForms.OrderScheme;
    using R440OForms.A306;

    using System.Collections.Generic;

    public class MSHUParameters
    {
        private static MSHUParameters instance;
        public static MSHUParameters getInstance()
        {
            if (instance == null)
                instance = new MSHUParameters();
            return instance;
        }

        public bool Включен
        {
            get { return N15Parameters.getInstance().ТумблерМШУ; }
        }

        /// <summary>
        /// Волна приводится в соответствие номинальной волне на приём. 
        /// Значение выходного сигнала, как после блока А304, т.к. его включение зависит от включения МШУ.
        /// Начало приемного тракта
        /// </summary>
        public BroadcastSignal ВыходнойСигнал
        {
            get
            {
                if (!Включен) return new BroadcastSignal();

                var inputSignal = N15Parameters.getInstance().ТумблерАнтЭкв ? Antenna.ВыходнойСигнал
                    : A503BParameters.ВыходнойСигнал;

                if (inputSignal == null) return new BroadcastSignal();

                //Входной СВЧ сигнал в диапазоне 3400...3900 МГц усиливается в МШУ и преобразуется в сигнал первой ПЧ - 320...370 МГц, 
                //Частота выходного сигнала = Частота входного сигнала - 8*(частота с A304)

                if (A304Parameters.getInstance().ВыходнаяЧастота == null) return new BroadcastSignal();

                var outputSignals = new List<Signal>();
                foreach (var signal in inputSignal.Signals)
                {
                    signal.Frequency = signal.Frequency - 8 * (int)A304Parameters.getInstance().ВыходнаяЧастота;
                    //outputSignal.Wave = outputSignal.Frequency/10 - 571000;

                    //На блок А306
                    //С проверкой попадания в диапазон 320...370 МГц
                    if (signal.Frequency >= 320000 && signal.Frequency <= 370000)
                        outputSignals.Add(signal);
                }
                return new BroadcastSignal { Signals = outputSignals };
                
            }
        }
    }
}