using System.Windows;

namespace PersonalScheduler.Notifiers
{
	public class VisualNotifier : INotifier
    {
		public void Notify(ScheduledEvent sv)
		{
			//MessageBox.Show("Sample message");
            VisualNotifierWindow visual = new VisualNotifierWindow(sv);
            visual.ShowDialog();
        }
	}
}
