using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R440O.LearnModule
{
    public class HighLightModule
    {
        public Control element;
        CancellationTokenSource ct = new CancellationTokenSource();

        public HighLightModule(Control element)
        {
            this.element = element;
        }

        public async void HighLighting ()
        {
           try
           {
             await PlaySuccessAnimation(element, ct.Token);
           } catch { }     
        }

        public void StopHighLight ()
        {
            ct.Cancel();
        }



        async Task PlaySuccessAnimation(Control b, CancellationToken ct)
        {
            var origColor = b.BackColor;

            var on = TimeSpan.FromSeconds(0.1);
            try
            {
                while (true)
                {
                    // 2 раза по 0.2 секунды
                    await Blink(b, Color.FromArgb(75, 197, 232, 0), on, TimeSpan.FromSeconds(0.3), 2, ct);
                    ct.ThrowIfCancellationRequested();
                }
            }
            catch (OperationCanceledException ex)
            {
                b.BackColor = origColor;
                throw;
            }
        }

        async Task Blink(Control b, Color color,TimeSpan on, TimeSpan off, int n, CancellationToken ct)
        {
        
            var origColor = b.BackColor;
            for (int i = 0; i < n; i++)
            {
                b.BackColor = color;
                await Task.Delay(on, ct);
                b.BackColor = origColor;
                await Task.Delay(off, ct);
            }
        }
    }
}
