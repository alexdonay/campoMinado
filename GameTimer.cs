using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace campoMinado
{
    public class GameTimer
    {
        private Timer timer;
        private int tempoDecorrido;

        public event EventHandler<int> TempoAtualizado;

        public GameTimer()
        {
            if (timer != null) { timer.Dispose(); }
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += TimerTick;
        }
        
        public void Iniciar()
        {
            tempoDecorrido = 0;
            timer.Start();
        }

        public void Parar()
        {
            
            timer.Stop();
        }
        public void Reset()
        {
            timer.Stop();
            tempoDecorrido = 0;
        }

        private void TimerTick(object sender, EventArgs e)
        {
            tempoDecorrido++;
            TempoAtualizado?.Invoke(this, tempoDecorrido);
        }
    }
}
