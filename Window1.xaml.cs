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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 owindows = new Window2();   
            owindows.Show();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            
            string rootPath= Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "//JsquareJob";
            
          if( Directory.Exists(rootPath))
            {
                string usernamefolder = rootPath + "//" + txtusername.Text;
                if(Directory.Exists(usernamefolder))
                    {
                    string filepath = usernamefolder + "//" + txtusername.Text + ".txt";
                    if (File.Exists(filepath))
                    {
                        string fildata = File.ReadAllText(filepath);
                        string[] value = fildata.Split('|');
                        if(value.Length > 0)
                        {
                            if(value[0] == txtusername.Text && value[1] == pwdpassword.Password)
                            {
                                MessageBox.Show("Login success");
                            }
                            else
                            {
                                MessageBox.Show("please continue the regisattion");
                            }
                        }
                        else
                        {

                            MessageBox.Show("please continue the regisattion");
                        }
                        }
                        else
                        {
                            MessageBox.Show("please continue the regisattion");
                        }
                    }
                else
                {
                    MessageBox.Show("please continue the regisattion");
                }
                    }
                else
                {

                    MessageBox.Show("please continue the regisattion");
                }

        }
    }
}
