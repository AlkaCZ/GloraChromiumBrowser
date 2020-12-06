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
            if ((WebPages.Count + PageNumber) >= 0)
            {
                LoadWeb(WebPages[PageNumber], false);
                PageNumber--;

                if (PageNumber == -1)
                {
                    PageNumber = 0;
                    LoadWeb(WebPages[PageNumber], false);
                    MessageBox.Show("You are on your first page, you cannot go back anymore", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

                }

            }
            else
            {
                MessageBox.Show("You are on your first page, you cannot go back anymore", "Error", MessageBoxButton.OK, MessageBoxImage.Information);

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
        private void History_Clicked(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            LoadWeb(item.Header.ToString());
            
        }

        private void HistoryButt_Click(object sender, RoutedEventArgs e)
        {
            if (PageNumber > 0)
            {
                HistoryMenu.PlacementTarget = HistoryButt;
                HistoryMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
                HistoryMenu.IsOpen = true;
            }

        }
        void LoadWeb(string Link, bool Side = true)
        {
            Browser.Address = Link;
            Input.Text = Link;
            MenuItem item = new MenuItem();
            item.Click += History_Clicked;
            item.Header = Link;
            item.Width = 190;
            //item.Icon = //Dodelat ikony
            HistoryMenu.HorizontalOffset = -142;
            HistoryMenu.Items.Add(item);



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
