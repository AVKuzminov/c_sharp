using System.Windows;

namespace PersonalScheduler.Notifiers
{
	class VisualNotifier
	{
		public void Notify(ScheduledEvent ev)
		{
			MessageBox.Show("Sample message");
		}
	}
}
