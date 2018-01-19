using System.Windows;

namespace GoogleSearch.Interfaces
{
	public interface IDialogService
	{
		void ShowMessage(string message);
	}

	class MessageBoxService : IDialogService
	{
		public void ShowMessage(string message)
		{
			MessageBox.Show(message, "Search app");
		}
	}
}
