using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace ShareTypes.SignalTypes
{
    public class KulonSignal
    {
        /// <summary>
        /// Частота сигнала
        /// </summary>
        public int Frequency { get; set; }

        // <summary>
        /// Уровень мощности передачи сигнала.
        /// </summary>
        public double Level { get; set; }

        /// <summary>
        /// Скорость передачи информации в канале.
        /// </summary>
        public double Speed { get; set; }        

        /// <summary>
        /// Канал 1
        /// </summary>
        public Chanel FirstChanel { get; set; }

        /// <summary>
        /// Канал 2
        /// </summary>
        public Chanel SecondChanel { get; set; }

        /// <summary>
        /// Синхропоследовательность1
        /// </summary>
        public int[]  SynchroSequence1 { get; set; }

        /// <summary>
        /// Синхропоследовательность2
        /// </summary>
        public int[] SynchroSequence2 { get; set; }

        /// <summary>
        /// Код Баркера
        /// </summary>
        public bool BarkerCode { get; set; }
        
        public KulonSignal(int frequency)
        {
            Frequency = frequency;
        }
                
        public KulonSignal()
        {

        }

        [JsonConstructor]
        public KulonSignal(int Frequency, double Level,  double Speed, Chanel FirstChanel,
            Chanel SecondChanel, int[] SynchroSequence1, int[] SynchroSequence2, bool BarkerCode)
        {
            this.Frequency = Frequency;
            this.Level = Level;
            this.Speed = Speed;
            this.FirstChanel = FirstChanel;
            this.SecondChanel = SecondChanel;
            this.SynchroSequence1 = SynchroSequence1;
            this.SynchroSequence2 = SynchroSequence2;
            this.BarkerCode = BarkerCode;
        }

        private static int[] clone_array(int[] a)
        {
            if (a == null)
                return null;
            var b = new int[a.Length];
            for (int i = 0; i < a.Length; i++)
                b[i] = a[i];
            return a;
        }

        public KulonSignal Clone()
        {
            return new KulonSignal
            {
                Frequency = this.Frequency,
                Level = this.Level,
                Speed = this.Speed,
                FirstChanel = this.FirstChanel != null ? this.FirstChanel.Clone() : null,
                SecondChanel = this.SecondChanel != null ? this.SecondChanel.Clone() : null,
                SynchroSequence1 = clone_array(this.SynchroSequence1),
                SynchroSequence2 = clone_array(this.SynchroSequence2),
                BarkerCode = this.BarkerCode
            };
        }
    }
}
