using System.Collections.Generic;
using System.Linq;
using ShareTypes.SignalTypes;
using R440O.R440OForms.K05M_01;
using R440O.R440OForms.K03M_01;
using R440O.R440OForms.PU_K1_1;
using R440O.R440OForms.N18_M_AngleSwitch;
using R440O.R440OForms.C300M_1;
using R440O.R440OForms.C300M_2;
using R440O.R440OForms.C300M_3;
using R440O.R440OForms.C300M_4;

namespace R440O.R440OForms.K01M_01
{
    class K01M_01Parameters
    {
        private static K01M_01Parameters instance;
        public static K01M_01Parameters getInstance()
        {
            if (instance == null)
                instance = new K01M_01Parameters();
            return instance;
        }

        public List<KulonSignal> Сигнал
        {
            get
            {
                if (PU_K1_1Parameters.getInstance().Включен)
                {
                    List<KulonSignal> сигнал = new List<KulonSignal>();
                    if (K05M_01Parameters.getInstance().ПереключательПередачаКонтроль != 0)
                        сигнал = new List<KulonSignal> { K05M_01Parameters.getInstance().Сигнал };
                    else
                    {

                        if (N18_M_AngleSwitchParameters.getInstance().ГнездоПРМ1 == 1 && C300M_1Parameters.getInstance().ВходящийСигнал != null)
                        {
                            сигнал = C300M_1Parameters.getInstance().ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.getInstance().ГнездоПРМ2 == 1 && C300M_2Parameters.getInstance().ВходящийСигнал != null)
                        {
                            сигнал = C300M_2Parameters.getInstance().ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.getInstance().ГнездоПРМ3 == 1 && C300M_3Parameters.getInstance().ВходящийСигнал != null)
                        {
                            сигнал = C300M_3Parameters.getInstance().ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.getInstance().ГнездоПРМ4 == 1 && C300M_4Parameters.getInstance().ВходящийСигнал != null)
                        {
                            сигнал = C300M_4Parameters.getInstance().ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                    }
                    return сигнал;
                }
                return new List<KulonSignal>();
            }
        }

        public void ResetParameters()
        {
            if (K05M_01Parameters.getInstance().ПереключательПередачаКонтроль != 1)
                K03M_01Parameters.getInstance().ОбновитьСигнал();
        }
    }
}
