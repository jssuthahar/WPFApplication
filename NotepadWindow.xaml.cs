using Microsoft.Win32;
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
    /// Interaction logic for NotepadWindow.xaml
    /// </summary>
    public partial class NotepadWindow : Window
    {
        public NotepadWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if(txtnotepad.Text.Length >0)
            {
              MessageBoxResult messageBoxResult =  MessageBox.Show("Do you want the value", "Confirmation", MessageBoxButton.YesNoCancel);
              if(messageBoxResult == MessageBoxResult.No)
                {
                    txtnotepad.Clear();
                }
                
            }
            
           
        }
        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "JSQUARE";
            openFileDialog.DefaultExt = "*.doc";
            openFileDialog.FilterIndex = 2;
            openFileDialog.CheckFileExists = true;
            openFileDialog.CheckPathExists = true;
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "Text File Praveen|*.txt|Jpeg Image Sabari|*.JPG|Word Docus|*.doc|All Files|*.*";
           
            openFileDialog.ShowDialog();
            string[] filename = openFileDialog.FileNames;
            foreach (string item in filename)
            {
                txtnotepad.Text = txtnotepad.Text + " Next File "+ File.ReadAllText(item);
            }
           // txtnotepad.Text = File.ReadAllText(openFileDialog.FileName);
           // MessageBox.Show(openFileDialog.FileName);

        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "JSQUARE";
            saveFileDialog.DefaultExt = "*.doc";
           // saveFileDialog.FilterIndex = 2;
           // saveFileDialog.CheckFileExists = true;
            saveFileDialog.CheckPathExists = true;
            //openFileDialog.Multiselect = true;
            saveFileDialog.Filter = "Text File Praveen|*.txt|Jpeg Image Sabari|*.JPG|Word Docus|*.doc|All Files|*.*";

            saveFileDialog.ShowDialog();
           File.WriteAllText(saveFileDialog.FileName,txtnotepad.Text);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //ComboBoxItem comboBoxItem = (ComboBoxItem) cmbskill.SelectedItem;
            //MessageBox.Show(comboBoxItem.Content.ToString());

            foreach (object item in listskill.SelectedItems)
            {
                ListBoxItem listBoxItem = (ListBoxItem)item;
                MessageBox.Show(listBoxItem.Content.ToString());
            }
          
        }
    }
}
