using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp.Wpf;

namespace GloraChromiumBrowser
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        List<string> WebPages;
        int PageNumber = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BackwardButt_Click(object sender, RoutedEventArgs e)
        {
            if ((WebPages.Count + PageNumber - 1) >= 0)
            {
                PageNumber--;
                LoadWeb(WebPages[PageNumber], false);
            }
        }

        private void ForwardButt_Click(object sender, RoutedEventArgs e)
        {

            if ((WebPages.Count - PageNumber - 1) != 0)
            {
                PageNumber++;
                LoadWeb(WebPages[PageNumber], false);
            }
        }

        private void RefreschButt_Click(object sender, RoutedEventArgs e)
        {
            LoadWeb(WebPages[PageNumber]);
        }

        private void HomeButt_Click(object sender, RoutedEventArgs e)
        {
            LoadWeb(WebPages[0]);
        }

        private void HistoryButt_Click(object sender, RoutedEventArgs e)
        {

        }
        void LoadWeb(string Link, bool Side = true)
        {
            Browser.Address = Link;
            Input.Text = Link;
            if (Side)
            {
                PageNumber++;
                WebPages.Add(Link);
            }
        }
        void Home()
        {
            Input.Text = "www.google.com";
            Browser.Address = "www.google.com";
            WebPages.Add("www.google.com");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WebPages = new List<string>();
            Home();
        }

        private void Input_KeyDown(object sender, KeyEventArgs e)// Potřebuje úpravu zatím basic model
        {
            if (e.Key == Key.Enter)
            {
                LoadWeb(Input.Text);
            }
        }
    }
}
