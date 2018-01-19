using System;
using System.Windows;

namespace Repository {
	/// <summary>
	/// Interaction logic for EmployeeInfo.xaml
	/// </summary>
	public partial class EmployeeInfo : Window {

		EmployeeRepository _repository;

		public EmployeeInfo(EmployeeRepository r) {
			InitializeComponent();
			_repository = r;
		}

		private void buttonOK_Click(object sender, RoutedEventArgs e) {
			var employee = new Employee
			{
				Name = textBoxName.Text,
				BirthDate = datePickerBirthDate.SelectedDate,
				Department = textBoxDepartment.Text
			};

			try {
				_repository.Add(employee);

				// The following line makes the second window dissapear
				DialogResult = true;
			}
			catch (ArgumentException ex) {
				MessageBox.Show(ex.Message);
			}
		}

		private void buttonCancel_Click(object sender, RoutedEventArgs e) {
			DialogResult = false;
		}
	}

	
}
