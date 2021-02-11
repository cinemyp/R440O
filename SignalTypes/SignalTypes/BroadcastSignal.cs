using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ShareTypes.SignalTypes
{
    public class BroadcastSignal
    {
        public List<Signal> Signals { get; set; }

        public BroadcastSignal()
        {
            Signals = new List<Signal>();
        }

        [JsonConstructor]
        public BroadcastSignal( List<Signal> signals)
        {
            Signals = signals;
        }

        public BroadcastSignal Clone()
        {
            return new BroadcastSignal
            {
                Signals = this.Signals.Select(s => s.Clone()).ToList()
            };
        }
    }
}
