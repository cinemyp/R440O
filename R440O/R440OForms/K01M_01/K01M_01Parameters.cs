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
    static class K01M_01Parameters
    {
        public static List<KulonSignal> Сигнал
        {
            get
            {
                if (PU_K1_1Parameters.Включен)
                {
                    List<KulonSignal> сигнал = new List<KulonSignal>();
                    if (K05M_01Parameters.ПереключательПередачаКонтроль != 0)
                        сигнал = new List<KulonSignal> { K05M_01Parameters.Сигнал };
                    else
                    {

                        if (N18_M_AngleSwitchParameters.ГнездоПРМ1 == 1 && C300M_1Parameters.ВходящийСигнал != null)
                        {
                            сигнал = C300M_1Parameters.ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.ГнездоПРМ2 == 1 && C300M_2Parameters.ВходящийСигнал != null)
                        {
                            сигнал = C300M_2Parameters.ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.ГнездоПРМ3 == 1 && C300M_3Parameters.ВходящийСигнал != null)
                        {
                            сигнал = C300M_3Parameters.ВходящийСигнал.Signals
                                .Select(s => s.KulonSignal)
                                .Where(k => k != null)
                                .ToList();
                        }
                        else if (N18_M_AngleSwitchParameters.ГнездоПРМ4 == 1 && C300M_4Parameters.ВходящийСигнал != null)
                        {
                            сигнал = C300M_4Parameters.ВходящийСигнал.Signals
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

        public static void ResetParameters()
        {
            if (K05M_01Parameters.ПереключательПередачаКонтроль != 1)
                K03M_01Parameters.ОбновитьСигнал();
        }
    }
}
