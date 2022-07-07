using System.Windows;
using System.IO;

namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for FolderWindows.xaml
    /// </summary>
    public partial class FolderWindows : Window
    {
        public FolderWindows()
        {
            InitializeComponent();
        }
        string mainPath = @"C:\Users\SuthaharJegatheesan\Documents\Job\";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
            if (!Directory.Exists(mainPath + txtusername.Text))
            {
                Directory.CreateDirectory(mainPath + txtusername.Text);
                MessageBox.Show("user created success");
            }
            else
            {
             MessageBoxResult ss=  MessageBox.Show("user already exist, do you want to delete ?","Warning",MessageBoxButton.YesNo);
                if(ss== MessageBoxResult.Yes)
                {
                    Directory.Delete(mainPath + txtusername.Text);
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(mainPath);
          //  directoryInfo.CreateSubdirectory(txtusername.Text);
            //directoryInfo.Delete();
            //directoryInfo.Create();
            DirectoryInfo[] dire = directoryInfo.GetDirectories();
            cmbuser.DisplayMemberPath = "Name";
            cmbuser.ItemsSource = dire;
            //string[] listname= Directory.GetDirectories(mainPath);
          // string[] listname = Directory.GetDirectories(mainPath);
           
            //cmbuser.ItemsSource = listname;
        }
    }
}
