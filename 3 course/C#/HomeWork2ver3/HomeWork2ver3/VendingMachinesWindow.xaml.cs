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
using ClassesLibrary;

namespace HomeWork2ver3
{
    public delegate void AddVMDelegate(string address);
    public delegate void EditVMDelegate(int terminalId, string address);
    public delegate void RemoveVMDelegate(int terminalId);

    /// <summary>
    /// Interaction logic for VendingMachinesWindow.xaml
    /// </summary>
    public partial class VendingMachinesWindow : Window
    {
        /// <summary>
        /// Interaction logic for Terminals.xaml
        /// </summary>
        public Func<List<Terminal>> Query1Function;
        public Func<DateTime,List<Terminal>> Query2Function;
        public event AddVMDelegate AddVMEvent;
        public event EditVMDelegate EditVMEvent;
        public event RemoveVMDelegate RemoveVMEvent;

        public Func<List<Terminal>> UpdateDataGrid;

        private Terminal chosenItem;
        private string location;
        private int option;

        public VendingMachinesWindow(double x, double y, double width, double height)
        {
            InitializeComponent();
            dataGridTerminals.IsEnabled = true;
            dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
            this.Left = x + width + 10;
            this.Top = y;
            Unavailable();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unavailable();
            option = ((ComboBox)sender).SelectedIndex;
            switch (option)
            {
                case 0: //add
                    dataGridTerminals.IsEnabled = true;
                    dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
                    LocationLabel.IsEnabled = true;
                    LocationText.IsEnabled = true;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Add";
                    break;
                case 1: //edit
                    dataGridTerminals.IsEnabled = true;
                    dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Edit";
                    break;
                /*
                case 2: //remove
                    dataGridTerminals.IsEnabled = true;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Remove";
                    break; */
                case 2: //query1
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Perform Query 1";
                    break;
                case 3: //query2
                    datePicker.Visibility = Visibility.Visible;
                    EnterButton.IsEnabled = true;
                    datePicker.IsEnabled = true;
                    LocationLabel.Content = "Choose date for query 2";
                    EnterButton.Content = "Perform Query 2";
                    break;
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            switch (option)
            {
                case 0: //add
                    location = LocationText.Text;
                    if (location == "")
                        MessageBox.Show("Please, enter the address");
                    else
                    {
                        AddVMEvent?.Invoke(location);
                        dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
                    }
                    break;
                case 1: //edit
                    chosenItem = (Terminal)dataGridTerminals.SelectedItem;
                    location = LocationText.Text;
                    if (location == "")
                        MessageBox.Show("Please, enter the address");
                    else
                    {
                        EditVMEvent?.Invoke(chosenItem.TerminalID, location);
                        dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
                    }
                    break;
               /* case 2: //remove
                    chosenItem = (Terminal)dataGridTerminals.SelectedItem;
                    if (chosenItem != null)
                    {
                        RemoveVMEvent?.Invoke(chosenItem.TerminalID);
                        dataGridTerminals.ItemsSource = UpdateDataGrid?.Invoke();
                    }
                    break;*/
                case 2: //query1
                    dataGridTerminals.IsEnabled = true;
                    dataGridTerminals.ItemsSource = Query1Function?.Invoke();
                    break;
                case 3: //query2
                    if (datePicker.SelectedDate == null)
                        MessageBox.Show("Please, choose date");
                    else
                    {
                        DateTime date = (DateTime)datePicker.SelectedDate;
                        dataGridTerminals.ItemsSource = Query2Function?.Invoke(date);
                    }
                    break;
            }
        }

        private void dataGridTerminals_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (option == 1 && (((DataGrid)sender).SelectedItem != null))
            {
                try
                {
                    LocationText.Text = ((Terminal)(((DataGrid)sender).SelectedItem)).Address;
                    LocationLabel.IsEnabled = true;
                    LocationText.IsEnabled = true;
                }
                catch { }
            }
        }

        private void Unavailable()
        {
            datePicker.IsEnabled = false;
            datePicker.Visibility = Visibility.Hidden;
            LocationText.IsEnabled = false;
            LocationLabel.IsEnabled = false;
            LocationText.Text = "";
            dataGridTerminals.IsEnabled = false;
            EnterButton.IsEnabled = false;
        }

    }
}
