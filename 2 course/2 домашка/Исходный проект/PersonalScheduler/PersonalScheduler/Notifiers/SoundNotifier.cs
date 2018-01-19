namespace PersonalScheduler.Notifiers
{
	class SoundNotifier
	{
		public void Notify()
		{
			System.Media.SystemSounds.Exclamation.Play();
		}
	}
}
