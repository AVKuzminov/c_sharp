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

namespace ShoppingCart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var c = new Cart();
            // Дублирование - Sku и тип производного класса
            c.AddItem(new NormalItem { Sku = "NORMAL_WINE_121230", Count = 3, Price = 800 });
            c.AddItem(new ThreeForTwoItem { Sku = "EACH_CHOCOLATE_12380", Count = 5, Price = 40 });

            decimal total = c.TotalCost();
            textBlockTotalCost.Text = "Total cost: " + total.ToString();
        }
    }
}
