using System;
using System.Text.RegularExpressions;
using System.Windows;

namespace PersonalScheduler
{
	/// <summary>
	/// Interaction logic for EventInfoWindow.xaml
	/// </summary>
	public partial class EventInfoWindow : Window
	{
		EventManager _eventManager;

		public EventInfoWindow(EventManager eventManager)
		{
			InitializeComponent();
			_eventManager = eventManager;

			// By default put the next day as the date
			datePicker.SelectedDate = DateTime.Now.Date.AddDays(1);
			textBoxTime.Text = _previousTimeValue;
		}

		private void buttonOK_Click(object sender, RoutedEventArgs e)
		{
			// The GetDateTime function (implemented inside the template region below)
			// combines data from two UI controls (datePicker and time textbox)
			// to produce a single DateTime? (nullable DateTime) object. Check that it
			// is not null before creating a new event
			var date = GetDateTime();

			// Create a new scheduled event or regular event here and add it to the event manager

			// Event data is inside the following UI controls:
			// textBoxName, textBoxDescription, textBoxPlace, checkBoxVisual, checkBoxSound,
			// checkBoxEmail, checkBoxRepeat, textBoxRepeat, comboBoxUnits

			DialogResult = true;
		}

		#region Template code - don't change it
		private DateTime? GetDateTime()
		{
			if (!datePicker.SelectedDate.HasValue || string.IsNullOrWhiteSpace(textBoxTime.Text))
				return null;
			Match match = _timeRegex.Match(textBoxTime.Text);
			if (!match.Success)
				return null;
			
			DateTime value = datePicker.SelectedDate.Value;

			value = value.AddHours(int.Parse(match.Groups[1].Value))
				.AddMinutes(int.Parse(match.Groups[2].Value));

			return value;
		}

		Regex _timeRegex = new Regex(@"^(\d{0,2}):(\d{0,2})$");
		string _previousTimeValue = "00:00";

		private void textBoxTime_LostFocus(object sender, RoutedEventArgs e)
		{
			Match match = _timeRegex.Match(textBoxTime.Text);
			if (!match.Success || int.Parse(match.Groups[1].Value) > 23
				|| int.Parse(match.Groups[2].Value) > 59)
				textBoxTime.Text = _previousTimeValue;
			else
				_previousTimeValue = textBoxTime.Text;
		}

		private void checkBoxRepeat_Checked(object sender, RoutedEventArgs e)
		{
			textBoxRepeat.IsEnabled = true;
			comboBoxUnits.IsEnabled = true;
		}

		private void checkBoxRepeat_Unchecked(object sender, RoutedEventArgs e)
		{
			textBoxRepeat.IsEnabled = false;
			comboBoxUnits.IsEnabled = false;
		}

		private void buttonCancel_Click(object sender, RoutedEventArgs e)
		{
			DialogResult = false;
		}
		#endregion
	}
}
