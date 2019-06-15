using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Threading.Security;

namespace Threading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new MainWindowViewModel();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists("text.txt"))
            {
                string content = "Hello! This is a generator for text fonts of the 'cool' variety. " +
                    "I noticed people were trying to find a generator like fancy letters, but were ending up on actual font " +
                    "sites rather than generators of copy-paste text like this one. So currently this is basically a duplicate " +
                    "of the above, but I think I'll try to collect a few more 'cool' text fonts, like the old enlgish one, and specialise " +
                    "this a bit." +
                    "If you're wondering how one produces cool text fonts like you see above, it's fairly simple(but maybe not what you'd " +
                    "expect). Basically, the text that gets generated isn't actually a font - it's a bunch of symbols that are in the " +
                    "unicode standard. You're reading symbols that are in the unicode standard right now - the alphabet is a part of it, " +
                    "as are all the regular " +
                    "symbols " +
                    "on your keyboard: !@#$%^&*() etc." +
                    "So the difference is, these rad 'fonts' that are produces, just don't happen to appear on your keyboard - there's not enough room." +
                    "The unicode standard has" +
                    "more than 100, 000 symbols defined in it.That's a lot of symbols. And amongst those symbols are many different 'alphabets' - some of " +
                    "which this translator is able to produce.";

                string[] arr = content.Split(' ');

                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = EncryptDecrypt.Encrypt(arr[i]);
                }

                File.WriteAllLines("text.txt", arr);
            }
        }

    }
}
