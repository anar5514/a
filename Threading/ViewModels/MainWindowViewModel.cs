using Threading.ViewModels;

namespace Threading
{
    public class MainWindowViewModel : BaseViewModel
    {
        public StartCommand StartCommand => new StartCommand(this);
        public StopCommand StopCommand => new StopCommand(this);
        public ResumeCommand ResumeCommand => new ResumeCommand(this);
        public PauseCommand PauseCommand => new PauseCommand(this);

        private string allRows;
        public string Allrows
        {
            get
            {
                return allRows;
            }
            set
            {
                allRows = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs(nameof(Allrows)));
            }
        }

    }
}