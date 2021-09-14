using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace R440O.ThirdParty
{
    public class EasyTimer
    {
        public static IDisposable SetInterval(Action method, int delayMilliseconds)
        {
            Timer timer = new Timer(delayMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };
            timer.Enabled = true;
            timer.Start();
            return timer as IDisposable;
        }

        public static IDisposable SetTimeout(Action method, int delayMilliseconds)
        {
            Timer timer = new Timer(delayMilliseconds);
            timer.Elapsed += (source, e) =>
            {
                method();
            };
            timer.AutoReset = false;
            timer.Enabled = true;
            timer.Start();
            return timer as IDisposable;
        }
    }
}
