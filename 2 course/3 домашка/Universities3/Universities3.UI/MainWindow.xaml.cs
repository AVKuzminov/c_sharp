using System;
using System.Collections.Generic;
using System.IO;
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
using Universities3.Data;

namespace Universities3.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //OutputDataGrid.ItemsSource = repo.Query1(2012);
            //List<ResultForQuery2> _resultforquery2 = repo.Query2(2012);
            //OutputDataGrid.ItemsSource = repo.Query4();
            //OutputDataGrid.ItemsSource = какой-то лист => вывод в датагрид
        }

        private void StartQuery1Button_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            int _year;
            if (int.TryParse(textBoxYear.Text, out _year))
                OutputDataGrid.ItemsSource = repo.Query1(_year);
            else
                MessageBox.Show("Enter correct year");           
        }

        private void StartQuery2Button_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            int _year;
            if (int.TryParse(textBoxYear.Text, out _year))
            {
                List<ResultForQuery2> _resultsforquery2list = repo.Query2(_year);
                List<ResultForQuery1> _outputlist = new List<ResultForQuery1>();
                foreach (var item in _resultsforquery2list)
                {
                    _outputlist.Add(new ResultForQuery1 { WorldRank = null, Institution = null, Location = item.Country,
                    NationalRank = null, QualityOfEducation = null, AlumniEmployment = null, Publications = null,
                    Influence = null, Citations = null, BroadImpact = null, Patents = null, Score = null});
                    foreach (var rating in item.Results)
                    {
                        _outputlist.Add(rating);
                    }
                }
                OutputDataGrid.ItemsSource = _outputlist;
            }
            else
                MessageBox.Show("Enter correct year");
        }

        private void StartQuery3Button_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            string _institution = textBoxUniversity.Text;
            if (string.IsNullOrEmpty(_institution))
                MessageBox.Show("Enter correct university");
            else
                OutputDataGrid.ItemsSource = repo.Query3(_institution);
        }

        private void StartQuery4Button_Click(object sender, RoutedEventArgs e)
        {
            Repository repo = new Repository();
            OutputDataGrid.ItemsSource = repo.Query4();
        }
    }
}
