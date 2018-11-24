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
using ClassesLibrary;
using System.IO;
using Newtonsoft.Json;

namespace HomeWork2ver3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int option;
        private Repository repo;
        private Product chosenItem;

        public MainWindow()
        {
            InitializeComponent();
            this.Left = SystemParameters.PrimaryScreenWidth / 2 - this.Width;
            this.Top = SystemParameters.PrimaryScreenHeight / 2 - this.Height / 2;
            VendingMachinesWindow vm = new VendingMachinesWindow(this.Left, this.Top, this.Width, this.Height);
            repo = new Repository();
            vm.AddVMEvent += repo.AddTerminal;
            vm.EditVMEvent += repo.EditTerminal;
            vm.UpdateDataGrid += repo.UpdateTerminalGrid;
            vm.RemoveVMEvent += repo.RemoveTerminal;
            vm.Query1Function += repo.Query1;
            vm.Query2Function += repo.Query2;
            UpdateGrid();
            Unavailable();
            //MessageBox.Show("Hit OK to close ", "Please, wait for database loading", MessageBoxButton.OK);
            //Task.Delay(8000).Wait();
            vm.Show();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Unavailable();
            option = ((ComboBox)sender).SelectedIndex;
            switch (option)
            {
                case 0: //add
                    UpdateGrid();
                    NameLabel.IsEnabled = true;
                    Name.IsEnabled = true;
                    SellingPriceLabel.IsEnabled = true;
                    SellingPrice.IsEnabled = true;
                    PurchasePriceLabel.IsEnabled = true;
                    PurchasePrice.IsEnabled = true;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Add";
                    break;
                case 1: //edit
                    NameLabel.IsEnabled = true;
                    Name.IsEnabled = true;
                    SellingPriceLabel.IsEnabled = true;
                    SellingPrice.IsEnabled = true;
                    PurchasePriceLabel.IsEnabled = true;
                    PurchasePrice.IsEnabled = true;
                    dataGridProducts.IsEnabled = true;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Edit";
                    break;
                case 2: //remove
                    dataGridProducts.IsEnabled = true;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Remove";
                    break;
                case 3: //query3
                    calendar.IsEnabled = true;
                    calendar.Visibility = Visibility.Visible;
                    EnterButton.IsEnabled = true;
                    EnterButton.Content = "Perform query 3";
                    break;
            }
        }

        private void EnterButton_Click(object sender, RoutedEventArgs e)
        {
            switch (option)
            {
                case 0: //add
                    if (!String.IsNullOrEmpty(Name.Text) && !String.IsNullOrWhiteSpace(Name.Text)
                        && Checks.IsDouble(SellingPrice.Text) && Checks.IsDouble(PurchasePrice.Text))
                    {

                        string name = Name.Text;
                        double sellingPrice = double.Parse(SellingPrice.Text);
                        double purchasePrice = double.Parse(PurchasePrice.Text);
                        Product product = new Product { Name = name, SellingPrice = sellingPrice, PurchasePrice = purchasePrice };
                        repo.AddProduct(product);
                    }
                    UpdateGrid();
                    break;
                case 1: //edit
                    chosenItem = (Product)dataGridProducts.SelectedItem;
                    if (!String.IsNullOrEmpty(Name.Text) && !String.IsNullOrWhiteSpace(Name.Text)
                        && Checks.IsDouble(SellingPrice.Text) && Checks.IsDouble(PurchasePrice.Text))
                    {
                        string name = Name.Text;
                        double sellingPrice = double.Parse(SellingPrice.Text);
                        double purchasePrice = double.Parse(PurchasePrice.Text);
                        repo.EditProduct(chosenItem.ProductId, name, sellingPrice, purchasePrice);
                    }
                    UpdateGrid();
                    break;
                case 2: //remove
                    chosenItem = (Product)dataGridProducts.SelectedItem;
                    repo.RemoveProduct(chosenItem.ProductId);
                    UpdateGrid();
                    break;
                case 3: //query3
                    var date = calendar.SelectedDate;
                    if (date != null)
                        dataGridProducts.ItemsSource = repo.Query3(date.Value);
                    else
                        MessageBox.Show("Enter the date, plese");
                    break;
            }
        }

        private void dataGridProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (option == 1 && ((DataGrid)sender).SelectedItem != null && dataGridProducts.Items.Count != 0)
            {
                Name.Text = ((Product)(((DataGrid)sender).SelectedItem)).Name;
                NameLabel.IsEnabled = true;
                Name.IsEnabled = true;
                SellingPrice.Text = ((Product)(((DataGrid)sender).SelectedItem)).SellingPrice.ToString();
                SellingPriceLabel.IsEnabled = true;
                SellingPrice.IsEnabled = true;
                PurchasePrice.Text = ((Product)(((DataGrid)sender).SelectedItem)).PurchasePrice.ToString();
                PurchasePriceLabel.IsEnabled = true;
                PurchasePrice.IsEnabled = true;
            }
        }

        private void Unavailable()
        {
            calendar.IsEnabled = false;
            calendar.Visibility = Visibility.Hidden;
            NameLabel.IsEnabled = false;
            Name.IsEnabled = false;
            Name.Text = "";
            SellingPriceLabel.IsEnabled = false;
            SellingPrice.IsEnabled = false;
            SellingPrice.Text = "";
            PurchasePriceLabel.IsEnabled = false;
            PurchasePrice.IsEnabled = false;
            PurchasePrice.Text = "";
            dataGridProducts.IsEnabled = false;
            EnterButton.IsEnabled = false;
            EnterButton.Content = "Enter";
        }

        private void UpdateGrid()
        {
            dataGridProducts.IsEnabled = true;
            using (Context context = new Context())
                repo.Products = context.Products.ToList();
            dataGridProducts.ItemsSource = repo.Products;
            dataGridProducts.IsEnabled = false;
        }
    }
}
