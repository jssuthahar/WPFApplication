using System;
using System.Collections.Generic;
using System.Linq;

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
using System.Text;

namespace FirstWpfApplication
{
    /// <summary>
    /// Interaction logic for HotelReg.xaml
    /// </summary>
    public partial class HotelReg : Window
    {
        string currentDir;
        string priceselection;
        public HotelReg(string username)
        {
            InitializeComponent();


            currentDir = System.Environment.CurrentDirectory;
            if (currentDir.Contains("\\bin"))
            {
                int index = currentDir.IndexOf("\\bin");
                currentDir = currentDir.Substring(0, index);
            }
            string masterPath = currentDir + "//Data//Master//";
            // get County
            string[] country = File.ReadAllLines(masterPath + "//Country.txt");
            cmbcounty.ItemsSource = country;
            cmbcounty.SelectedIndex = 0;
            //get State
            string[] state = File.ReadAllLines(masterPath + "//state.txt");
            cmbstate.ItemsSource = state;
            cmbstate.SelectedIndex = 0;

            //get room type

            string[] roomtype = File.ReadAllLines(masterPath + "//RoomType.txt");
            lstroom.ItemsSource = roomtype;
            lstroom.SelectedIndex = 0;
            //get price
            string[] price = File.ReadAllLines(masterPath + "//Price.txt");
            //for (int i = 0; i < price.Length; i++)
            //{
            price1.Content = price[0].ToString();
            price2.Content = price[1].ToString();
            price3.Content = price[2].ToString();
            price4.Content = price[3].ToString();
            //}
            if(!string.IsNullOrEmpty(username))
            {
                string[] values = File.ReadAllLines(username);
                txtname.Text = values[0];
                cmbcounty.SelectedItem = values[1];
                cmbstate.SelectedItem = values[2];
                lstroom.SelectedItem = values[3];
                string[] chkvalue = values[4].Split("|");
                //if (chkvalue != null)
                //{
                    foreach (string item in chkvalue)
                    {
                        if(item.Contains(price1.Content.ToString()))
                        {
                            price1.IsChecked = true;
                        }
                        if (item.Contains(price2.Content.ToString()))
                        {
                            price2.IsChecked = true;
                        }
                        if (item.Contains(price3.Content.ToString()))
                        {
                            price3.IsChecked = true;
                        }
                        if (item.Contains(price4.Content.ToString()))
                        {
                            price4.IsChecked = true;
                        }

                    }
                dtpstatedate.SelectedDate =Convert.ToDateTime(values[5]);
                dtpendate.SelectedDate = Convert.ToDateTime(values[6]);
                txtname.IsReadOnly = true;
                btnreg.Content = "Update";
               // }
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(txtname.Text);
            stringBuilder.AppendLine(cmbcounty.SelectedItem.ToString());
            stringBuilder.AppendLine(cmbstate.SelectedItem.ToString());
            stringBuilder.AppendLine(lstroom.SelectedItem.ToString());
            stringBuilder.AppendLine(priceselection);
            stringBuilder.AppendLine(dtpstatedate.SelectedDate.ToString());
            stringBuilder.AppendLine(dtpendate.SelectedDate.ToString());
          
            
            string userpath = currentDir + "//User";
            if (!Directory.Exists(userpath))
            {
                Directory.CreateDirectory(userpath);
            }
            userpath = userpath + "//" + txtname.Text + ".txt";
            string[] value = stringBuilder.ToString().Split("\r\n");
            File.WriteAllLines(userpath, value);

        }

        private void price1_Click(object sender, RoutedEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            if (cb.IsChecked == true)
            {
                if (string.IsNullOrEmpty(priceselection))
                {
                    priceselection = cb.Content.ToString();
                }
                else
                {
                    // priceselection = priceselection+ cb.Content.ToString();
                    priceselection += "| " + cb.Content.ToString();
                }

            }
            else
            {
                if (string.IsNullOrEmpty(priceselection) == false)
                {
                    priceselection= priceselection.Replace(cb.Content.ToString(), "");
                    
                }

            }
        }
    }
}
