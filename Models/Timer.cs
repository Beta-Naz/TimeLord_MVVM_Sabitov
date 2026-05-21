using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TimeLord_MVVM_Сабитов.ViewModels;

namespace TimeLord_MVVM_Сабитов.Models
{
    public class Timer : INotifyPropertyChanged
    {
        public bool Work;
        private int _time;
        public int Time
        {
            get => _time;
            set
            {
                _time = value;
                OnPropertyChanged("Timer");
            }
        }
        private RelayCommand _startTimer;
        public RelayCommand StartTimer
        {
            get
            {
                return _startTimer ??
                    (_startTimer = new RelayCommand(obj => ToogleTimer()));
            }
        }
        private RelayCommand _goToStopwatch;
        public RelayCommand GoToStopwatch
        {
            get
            {
                return _goToStopwatch ??
                    (_goToStopwatch = new RelayCommand(obj =>
                    {
                        MainWindow.Instance.OpenPage(new Views.Main());
                    }));
            }
        }
        public void ToogleTimer()
        {
            if (!Work)
            {
                Interval.Clear();
                Work = true;
                TextButton = "Стоп";
            }
            else
            {
                Work = false;
                TextButton = "Начать";
            }
        }
        private RelayCommand _intervalTimer;
        public RelayCommand IntervalTimer
        {
            get
            {
                return _intervalTimer ??
                    (_intervalTimer = new RelayCommand(obj =>
                    {
                        if (Work)
                        {
                            Interval.Insert(0, TimerString);
                        }
                    }));
            }
        }
        public ObservableCollection<string> Interval {get; set;}
        public Timer()
        {
            Interval = new ObservableCollection<string>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        private string _timerString = "00:00:00";
        public string TimerString
        {
            get => _timerString ;
            set
            {
                if (value != _timerString)
                {
                    if (value.Length == 8 && value.Contains(":"))
                    {
                        Time = ConvertTimer(value);
                        OnPropertyChanged("Timer");
                    }
                    _timerString = value;
                    OnPropertyChanged();
                }
            }
        }
        public void TimerUpdate()
        {
           float hour = Time / 3600f;
           float minute = Time / 60f - (int)hour * 60f;
           float second = Time - (int)hour * 360f - (int)minute * 60f;
           string sHour = ((int)hour).ToString();
           string sMinute = ((int)minute).ToString();
           string sSecond = ((int)second).ToString();
           if(hour < 10) sHour = "0" + sHour;
           if (minute < 10) sMinute = "0" + sMinute;
           if (second < 10) sSecond = "0" + sSecond;
           if(second <= 0)
           {
              sSecond = "00";
           }
           TimerString = $"{sHour}:{sMinute}:{sSecond}";
        }
        public int ConvertTimer(string timerString)
        {
            string[] stringTime = timerString.Trim().Split(':');
            if(stringTime.Length != 3)
            {
                return 0;
            }
            if(!int.TryParse(stringTime[0], out int hour) || !int.TryParse(stringTime[1], out int minute)
                || !int.TryParse(stringTime[2], out int second))
            {
                return 0;
            }
            return hour * 3600 + minute * 60 + second;
        }
        private string _textButton = "Начать";
        public string TextButton
        {
            get => _textButton;
            set
            {
                _textButton = value;
                OnPropertyChanged("TextButton");
            }
            
        }
    }
}
