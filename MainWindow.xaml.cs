using System.Windows;
using System.Windows.Controls;
using System;

namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public Home homepage;
        public ProfilePage profilePage;
        public MainWindow()
        {
            InitializeComponent();
            homepage= new Home();
            profilePage= new ProfilePage();
        }

        private void btnprofile_Click(object sender, RoutedEventArgs e)
        {
            framain.Content = profilePage;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            framain.Content= homepage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(framain.NavigationService.CanGoBack)
            {
                framain.NavigationService.GoBack();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if(framain.NavigationService.CanGoForward)
            {
                framain.NavigationService.GoForward();
            }
        }
    }
}
