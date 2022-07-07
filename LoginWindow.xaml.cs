using System.Windows;
using System.IO;
namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // if(txtpassword.Text == txtusername.Text)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.ShowDialog();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string content = $"{txtusername.Text} | {txtage.Text} | {txtedu.Text}";
            File.WriteAllText($"C:\\Users\\SuthaharJegatheesan\\Desktop\\New folder\\{txtusername.Text}.txt", content);
           // File.Create($"C:\\Users\\SuthaharJegatheesan\\Desktop\\New folder\\{txtcontent.Text}.txt");
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string filepath = $"C:\\Users\\SuthaharJegatheesan\\Desktop\\New folder\\{txtusername.Text}.txt";
            if (File.Exists(filepath) == true)
            {
               string value= File.ReadAllText(filepath);
                string[] stringvalue = value.Split('|');
                txtage.Text=stringvalue[1];
                txtedu.Text= stringvalue[2];

                //MessageBox.Show("please enter differnt user id ");
                //txtusername.Text = "";

            }
            else
            {
                MessageBox.Show("user id is not avilable");
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            string filepath = $"C:\\Users\\SuthaharJegatheesan\\Desktop\\New folder\\{txtusername.Text}.txt";
            if (File.Exists(filepath) == true)
            {
                File.Delete(filepath);
                MessageBox.Show("File Delete Success");
            }
        }
    }
}
