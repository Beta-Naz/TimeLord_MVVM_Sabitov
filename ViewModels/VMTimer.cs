using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using TimeLord_MVVM_Сабитов.Models;

namespace TimeLord_MVVM_Сабитов.ViewModels
{
    public class VMTimer : INotifyPropertyChanged
    {
        public Timer Timer { get; set; }
        private DispatcherTimer _timer = new DispatcherTimer()
        {
            Interval = new System.TimeSpan(0, 0, 1),
        };
        public VMTimer()
        {
            Timer = new Timer()
            {
                Work = false,
                Time = 0
            };
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (Timer.Work)
            {
                Timer.Time--;
                if (Timer.Time <= 0)
                {
                    Timer.ToogleTimer();
                }
                Timer.TimerUpdate();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
