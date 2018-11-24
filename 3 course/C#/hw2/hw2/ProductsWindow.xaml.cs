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
using System.Windows.Shapes;

namespace hw2
{
    public delegate void AddProduct(string name, double sellingPrice, double purchasePrice);
    public delegate void EditProduct(int id, string name, double sellingPrice, double purchasePrice);
    public delegate void DeleteProduct(int id);

    /// <summary>
    /// Interaction logic for products.xaml
    /// </summary>
    public partial class ProductsWindow : Window
    {
        private enum State {None, Add, Edit, Delete, ThirdQuery };
        private State option;
        private Product tempProduct;
        private string name;
        private double sellingPrice;
        private double purchasePrice;
        public event AddProduct AddProductEvent;
        public event EditProduct EditProductEvent;
        public event DeleteProduct DeleteProductEvent;
        public Func<List<Product>> FuncGridUpdate;
        public Func<int,int,List<Product>> FuncThirdQuery;

        public ProductsWindow(List<Product> startProducts)
        {
            InitializeComponent();
            comboBox.SelectedIndex = 0;
            this.Left = SystemParameters.PrimaryScreenWidth / 2.5;
            this.Top = 0;
            this.Height = SystemParameters.PrimaryScreenHeight / 2;
            this.Width = SystemParameters.PrimaryScreenWidth / 1.75;
            ProductsDataGrid.ItemsSource = startProducts;
            datePicker.IsEnabled = false;
            NameLabel.IsEnabled = true;
            NameTextBox.IsEnabled = true;
            SellingLabel.IsEnabled = true;
            SellingTextBox.IsEnabled = true;
            PurchaseLabel.IsEnabled = true;
            PurchaseTextBox.IsEnabled = true;
            ExecuteButton.IsEnabled = true;
            ExecuteButton.Content = "Add";
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            option = (State)(((ComboBox)sender).SelectedIndex+1);
            switch (option)
            {
                case State.Add:
                    GridUpdate();
                    datePicker.IsEnabled = false;
                    NameLabel.IsEnabled = true;
                    NameTextBox.IsEnabled = true;
                    SellingLabel.IsEnabled = true;
                    SellingTextBox.IsEnabled = true;
                    PurchaseLabel.IsEnabled = true;
                    PurchaseTextBox.IsEnabled = true;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Add";
                    break;
                case State.Edit:
                    datePicker.IsEnabled = false;
                    ProductsDataGrid.IsEnabled = true;
                    NameLabel.IsEnabled = true;
                    NameTextBox.IsEnabled = true;
                    SellingLabel.IsEnabled = true;
                    SellingTextBox.IsEnabled = true;
                    PurchaseLabel.IsEnabled = true;
                    PurchaseTextBox.IsEnabled = true;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Edit";
                    break;
                case State.Delete:
                    datePicker.IsEnabled = false;
                    ProductsDataGrid.IsEnabled = true;
                    NameLabel.IsEnabled = false;
                    NameTextBox.IsEnabled = false;
                    SellingLabel.IsEnabled = false;
                    SellingTextBox.IsEnabled = false;
                    PurchaseLabel.IsEnabled = false;
                    PurchaseTextBox.IsEnabled = false;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Delete";
                    break;
                case State.ThirdQuery:
                    datePicker.IsEnabled = true;
                    ProductsDataGrid.IsEnabled = false;
                    NameLabel.IsEnabled = false;
                    NameTextBox.IsEnabled = false;
                    SellingLabel.IsEnabled = false;
                    SellingTextBox.IsEnabled = false;
                    PurchaseLabel.IsEnabled = false;
                    PurchaseTextBox.IsEnabled = false;
                    ExecuteButton.IsEnabled = true;
                    ExecuteButton.Content = "Perform";
                    break;
            }
        }

        private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (option)
            {
                case State.Add:
                    if (NameTextBox.Text != "" && SellingTextBox.Text != "" && PurchaseTextBox.Text != "")
                    {
                        name = NameTextBox.Text;
                        if (double.TryParse(SellingTextBox.Text, out sellingPrice) && double.TryParse(PurchaseTextBox.Text, out purchasePrice))
                            if (purchasePrice < sellingPrice)
                                AddProductEvent?.Invoke(name, purchasePrice, sellingPrice);
                            else
                                MessageBox.Show("Selling price must be bigger than purchase price");
                        else
                            MessageBox.Show("Enter numbers of correct type");
                    }
                    else
                        MessageBox.Show("Enter data to all the fields");
                    GridUpdate();
                    break;
                case State.Edit:
                    if (ProductsDataGrid.SelectedItem != null)
                    {
                        tempProduct = (Product)ProductsDataGrid.SelectedItem;
                        if (tempProduct != null)
                        {
                            if (NameTextBox.Text != "" && SellingTextBox.Text != "" && PurchaseTextBox.Text != "")
                            {
                                name = NameTextBox.Text;
                                if (double.TryParse(SellingTextBox.Text, out sellingPrice) && double.TryParse(PurchaseTextBox.Text, out purchasePrice))
                                    if (purchasePrice < sellingPrice)
                                        EditProductEvent?.Invoke(tempProduct.Id, name, sellingPrice, purchasePrice);
                                    else
                                        MessageBox.Show("Selling price must be bigger than purchase price");
                                else
                                    MessageBox.Show("Enter numbers of correct type");
                            }
                            else
                                MessageBox.Show("Enter data to all the fields");
                        }
                        else
                            MessageBox.Show("Choose a product you want to change");
                    }
                    GridUpdate();
                    break;
                case State.Delete:
                    
                    if (ProductsDataGrid.SelectedItem != null)
                    {
                        tempProduct = (Product)ProductsDataGrid.SelectedItem;
                        DeleteProductEvent?.Invoke(tempProduct.Id);
                    }
                    else
                        MessageBox.Show("Choose a product you want to delete");
                    GridUpdate();
                    break;
                case State.ThirdQuery:
                    if (datePicker.SelectedDate != null)
                    {
                        DateTime dt = (DateTime)datePicker.SelectedDate;
                        ProductsDataGrid.IsEnabled = true;
                        ProductsDataGrid.ItemsSource = FuncThirdQuery?.Invoke(dt.Month,dt.Year);
                    }
                    else
                        MessageBox.Show("Select month and year by choosing a date");
                    break;
            }
        }

        private void GridUpdate()
        {
            ProductsDataGrid.IsEnabled = true;
            ProductsDataGrid.ItemsSource = FuncGridUpdate?.Invoke();
        }
    }
}
