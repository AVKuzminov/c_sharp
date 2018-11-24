using DatabaseClasses;
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

namespace hw2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TerminalsWindow : Window
    {
        private enum State { Add, Edit, FirstQuery, SecondQuery}
        private State option;
        private Repository repo = new Repository();
        private string location;

        public TerminalsWindow()
        {
            InitializeComponent();
            Message();
            this.Left = 0;
            this.Top = 0;
            this.Height = SystemParameters.PrimaryScreenHeight/2;
            this.Width = SystemParameters.PrimaryScreenWidth / 2.5;
            TerminalsDataGrid.ItemsSource = repo.ReturnGridTerminals();
            ProductsWindow pw = new ProductsWindow(repo.ReturnGridProducts());
            pw.AddProductEvent += repo.AddProduct;
            pw.EditProductEvent += repo.EditProduct;
            pw.DeleteProductEvent += repo.DeleteProduct;
            pw.FuncThirdQuery += repo.ThirdQuery;
            pw.FuncGridUpdate += repo.ReturnGridProducts;
            comboBox.SelectedIndex = 0;
            datePicker.IsEnabled = false;
            TerminalsDataGrid.IsEnabled = false;
            LocationLabel.IsEnabled = true;
            LocationTextBox.IsEnabled = true;
            ExecuteButton.IsEnabled = true;
            ExecuteButton.Content = "Add";
            TerminalsDataGrid.IsEnabled = true;
            TerminalsDataGrid.ItemsSource = repo.ReturnGridTerminals();
            pw.Show();
        }

        private async void Message()
        {
            await Task.Run(() => MessageBox.Show("Please, wait. Database is loading\nHit OK to close", "Attention!", MessageBoxButton.OK));
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            option = (State)(((ComboBox)sender).SelectedIndex);
            switch (option)
            {
                case State.Add:
                    datePicker.IsEnabled = false;
                    TerminalsDataGrid.IsEnabled = true;
                    TerminalsDataGrid.ItemsSource = repo.ReturnGridTerminals();
                    LocationLabel.IsEnabled = true;
                    LocationTextBox.IsEnabled = true;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Add";
                    break;
                case State.Edit:
                    datePicker.IsEnabled = false;
                    TerminalsDataGrid.IsEnabled = true;
                    LocationTextBox.IsEnabled = true;
                    LocationLabel.IsEnabled = true;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Edit";
                    break;
                case State.FirstQuery:
                    LocationTextBox.IsEnabled = false;
                    LocationLabel.IsEnabled = false;
                    ExecuteButton.Content = "Perform";
                    ExecuteButton.IsEnabled = true;
                    TerminalsDataGrid.IsEnabled = false;
                    datePicker.IsEnabled = false;
                    break;
                case State.SecondQuery:
                    LocationTextBox.IsEnabled = false;
                    LocationLabel.IsEnabled = false;
                    ExecuteButton.Content = "Perform";
                    ExecuteButton.IsEnabled = true;
                    TerminalsDataGrid.IsEnabled = false;
                    datePicker.IsEnabled = true;
                    break;
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (option)
            {
                case State.Add:
                    location = LocationTextBox.Text;
                    if (location != "")
                    {
                        repo.AddTerminal(location);
                        TerminalsDataGrid.IsEnabled = true;
                        TerminalsDataGrid.ItemsSource = repo.ReturnGridTerminals();
                    }
                    else
                        MessageBox.Show("Enter location");
                    break;
                case State.Edit:
                    
                    if (TerminalsDataGrid.SelectedItem != null)
                    {
                        Terminal tempTerminal = (Terminal)TerminalsDataGrid.SelectedItem;
                        location = LocationTextBox.Text;
                        repo.EditTerminal(tempTerminal.Id, location);
                        TerminalsDataGrid.ItemsSource = repo.ReturnGridTerminals();
                    }
                    else
                        MessageBox.Show("Select an item what you want to be changed");
                    break;
                case State.FirstQuery:
                    TerminalsDataGrid.IsEnabled = true;
                    TerminalsDataGrid.ItemsSource = repo.FirstQuery();
                    break;
                case State.SecondQuery:
                    if (datePicker.SelectedDate != null)
                    {
                        TerminalsDataGrid.IsEnabled = true;
                        DateTime dt = (DateTime)datePicker.SelectedDate;
                        TerminalsDataGrid.ItemsSource = repo.SecondQuery(dt.Month, dt.Year);
                    }
                    else
                        MessageBox.Show("Select month and year by choosing a date");
                    break;
            }
        }

        private void TerminalsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalsDataGrid.SelectedItem is Terminal)
                LocationTextBox.Text = ((Terminal)TerminalsDataGrid.SelectedItem).Location;
        }
    }
}
