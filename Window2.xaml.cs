using System;
using System.Windows;
using System.IO;
using System.Windows.Media;

namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            this.Resources["SolidAquamarine"] = new SolidColorBrush(Colors.LightGray);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
          string folderpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
          string rootPath = folderpath + "//JsquareJob";
            if (!Directory.Exists(rootPath))
            {
                Directory.CreateDirectory(rootPath);
            }
            string userpath = rootPath + "//" + txtname.Text;
            if (!Directory.Exists(userpath))
            {
                Directory.CreateDirectory(userpath);
                string content = $"{txtname.Text}|{pwdbox.Password}";
                File.WriteAllText(userpath+"//"+txtname.Text+".txt", content);
            }
            else
            {
                MessageBox.Show("User already existes");
            }
        }

        //private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        //{
        //    txtblock.Text = txtnamevalue.Text;
        //}
    }
}
