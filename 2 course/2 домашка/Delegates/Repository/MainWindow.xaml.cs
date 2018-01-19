using System;
using System.Windows;

namespace Repository {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
    {
        EmployeeRepository r = new EmployeeRepository();
		Logger l = new Logger();

        public MainWindow()
        {
            InitializeComponent();

			// Binding to lambda expressions
			r.OnEmployeeAdded += e => listBoxEmployees.Items.Add(e);
			r.OnEmployeeRemoved += e => listBoxEmployees.Items.Remove(e);

			// Binding to methods of other objects
			r.OnLog += l.Log;
        }        

        private void buttonRemove_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxEmployees.SelectedItem == null)
                MessageBox.Show("Item not selected!", "Error");
            else
                r.Remove(listBoxEmployees.SelectedItem as Employee);
        }

		private void buttonAdd_Click(object sender, RoutedEventArgs e) {
			EmployeeInfo infoWindow = new EmployeeInfo(r);
			infoWindow.ShowDialog();
		}
	}
}
