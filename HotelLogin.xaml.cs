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
using System.Windows.Shapes;
using System.IO;
namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for HotelLogin.xaml
    /// </summary>
    public partial class HotelLogin : Window
    {
        string currentDir;
        public HotelLogin()
        {
            InitializeComponent();
            currentDir = System.Environment.CurrentDirectory;
            if (currentDir.Contains("\\bin"))
            {
                int index = currentDir.IndexOf("\\bin");
                currentDir = currentDir.Substring(0, index);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           HotelReg hotelReg = new HotelReg("");
            hotelReg.ShowDialog();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string userpath = currentDir + "//User";
             userpath = userpath + "//" + txtname.Text + ".txt";
            if (File.Exists(userpath))
                {

                HotelReg hotelReg = new HotelReg(userpath);
                hotelReg.ShowDialog();
            }
            else
            {
                MessageBox.Show("user not avilable");
            }
        }
    }
}
