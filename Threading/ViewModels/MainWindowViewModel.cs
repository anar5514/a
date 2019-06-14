using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using Threading.Commands;
using Threading.Security;
using Threading.ViewModels;

namespace Threading
{
    public class MainWindowViewModel : BaseViewModel
    {
        public StartCommand StartCommand => new StartCommand(this);
        public StopCommand StopCommand => new StopCommand(this);
        public ResumeCommand ResumeCommand => new ResumeCommand(this);
        public PauseCommand PauseCommand => new PauseCommand(this);

        StopCommandWithEncryption StopCommandWithEncryption => new StopCommandWithEncryption(this);
        PauseCommandWithEncryption PauseCommandWithEncryptioncs => new PauseCommandWithEncryption(this);
        ResumeCommandWithEncryption ResumeCommandWithEncryption => new ResumeCommandWithEncryption(this);
        StartCommandWithEncryption StartCommandWithEncryption => new StartCommandWithEncryption(this);

        public Thread Encrypt_thread;
        public Thread Dectypt_thread;

        ObservableCollection<string> encryptList;
        public ObservableCollection<string> EncryptList
        {
            get
            {
                return encryptList;
            }
            set
            {
                encryptList = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(EncryptList)));
            }
        }

        ObservableCollection<string> decryptList;
        public ObservableCollection<string> DecryptList
        {
            get
            {
                return decryptList;
            }
            set
            {
                decryptList = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(DecryptList)));
            }
        }

        public void Start()
        {
            if (Encrypt_thread.ThreadState == ThreadState.Unstarted)
            {
                Encrypt_thread.Start();
            }
        }

        public void Start1()
        {
            if (Dectypt_thread.ThreadState == ThreadState.Unstarted && EncryptList.Count != 0)
            {
                Dectypt_thread.Start();
            }
        }

        void Encrypt()
        {
            StreamReader file = new StreamReader("Text.txt");
            string Name;

            while ((Name = file.ReadLine()) != null)
            {
                App.Current.Dispatcher.Invoke(() =>
                EncryptList.Add(Name));
                System.Threading.Thread.Sleep(1000);
            }
        }

        void Dectypt()
        {
            for (int i = 0; i < EncryptList.Count; i++)
            {
                App.Current.Dispatcher.Invoke(() =>
                 DecryptList.Add(EncryptDecrypt.Decrypt(EncryptList[i]))
                    );
                System.Threading.Thread.Sleep(1000);
            }
            Dectypt_thread.Abort();
        }

        public MainWindowViewModel()
        {
            EncryptList = new ObservableCollection<string>();
            DecryptList = new ObservableCollection<string>();
            Encrypt_thread = new System.Threading.Thread(new System.Threading.ThreadStart(Encrypt));
            Dectypt_thread = new System.Threading.Thread(new System.Threading.ThreadStart(Dectypt));
        }

    }
}