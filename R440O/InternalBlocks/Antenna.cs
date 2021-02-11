using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShareTypes.SignalTypes;
using System.Threading.Tasks;
using R440O.R440OForms.N15;
using R440O.ThirdParty;
using R440O.R440OForms.N16;
using R440O.R440OForms.OrderScheme;

namespace R440O.InternalBlocks
{
    static class Antenna
    {
        private static IDisposable timer;

        public static event Action ErrorEvent;

        public static BroadcastSignal ВыходнойСигнал
        {
            get
            {
                return ВходнойСигнал != null ? ВходнойСигнал.Clone() : null;
            }
        }

        private static BroadcastSignal ВходнойСигнал { get; set; }

        public static void StartServerPing()
        {
            if (!string.IsNullOrEmpty(OrderSchemeParameters.СхемаПриказ.УникальныйИдентификаторСтанции))
            {
                timer = EasyTimer.SetInterval(async () =>
                {
                    try
                    {
                        ВходнойСигнал = await HttpHelper.ПослатьИПолучитьСигнал(new SendSignalDTO
                        {
                            Signal = ShouldSendSignal ? N16Parameters.ВыходнойСигнал : null,
                            Id = OrderSchemeParameters.СхемаПриказ.УникальныйИдентификаторСтанции
                        });
                    }
                    catch
                    {
                        StopServerPing();
                        ErrorEvent();
                    }
                }, 1000);
            }
        }

        private static bool ShouldSendSignal
        {
            get
            {
                return HttpHelper.СерверНайден && !HttpHelper.ПоискИдет;
            }
        }

        public static void StopServerPing()
        {
            if (timer != null)
            {
                timer.Dispose();
                timer = null;
            }
        }
    }
}
