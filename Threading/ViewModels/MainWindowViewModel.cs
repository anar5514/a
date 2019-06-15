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

        public StopCommandWithEncryption StopCommandWithEncryption => new StopCommandWithEncryption(this);
        public PauseCommandWithEncryption PauseCommandWithEncryption => new PauseCommandWithEncryption(this);
        public ResumeCommandWithEncryption ResumeCommandWithEncryption => new ResumeCommandWithEncryption(this);
        public StartCommandWithEncryption StartCommandWithEncryption => new StartCommandWithEncryption(this);

        public Thread Encrypt_thread;
        public Thread Decrypt_thread;

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

        public void StartEncryption()
        {
            if (Encrypt_thread.ThreadState == ThreadState.Unstarted)
            {
                Encrypt_thread.Start();
            }
        }

        public void StartDecryption()
        {
            if (Decrypt_thread.ThreadState == 
                ThreadState.Unstarted && EncryptList.Count != 0)
            {
                Decrypt_thread.Start();
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
                Thread.Sleep(1000);
            }
        }

        void Decrypt()
        {
            for (int i = 0; i < EncryptList.Count; i++)
            {
                App.Current.Dispatcher.Invoke(() =>
                 DecryptList.Add(EncryptDecrypt.Decrypt(EncryptList[i]))
                    );
                Thread.Sleep(1000);
            }
            Decrypt_thread.Abort();
        }

        public MainWindowViewModel()
        {
            EncryptList = new ObservableCollection<string>();
            DecryptList = new ObservableCollection<string>();
            Encrypt_thread = new Thread(new ThreadStart(Encrypt));
            Decrypt_thread = new Thread(new ThreadStart(Decrypt));
        }

    }
}