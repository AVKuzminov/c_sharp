namespace PersonalScheduler.Notifiers
{
	public class SoundNotifier : INotifier
    {
		public void Notify(ScheduledEvent sv)
		{
			System.Media.SystemSounds.Exclamation.Play();
		}
	}
}
