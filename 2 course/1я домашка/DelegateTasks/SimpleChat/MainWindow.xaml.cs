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

namespace SimpleChat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ChatManager _chatManager;
        string[] userNames = { "Bob", "Alice", "Fred" };


        const int ChatWindowWidth = 300;
        const int ChatWindowHeight = 400;
        const int MainWindowHeight = 200;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _chatManager = new ChatManager();

            // YOUR CODE GOES HERE
			
            PlaceChildWindows();
        }

        private void PlaceChildWindows()
        {
            var left = (System.Windows.SystemParameters.PrimaryScreenWidth - ChatWindowWidth * userNames.Length) / 2;
            var top = (System.Windows.SystemParameters.PrimaryScreenHeight - ChatWindowHeight - MainWindowHeight) / 2;
            for (int i = 0; i < userNames.Length; i++)
            {
                var user = new User(userNames[i]);
                var userWindow = new ChatWindow(_chatManager, user);
                userWindow.Left = left + i * ChatWindowWidth;
                userWindow.Width = ChatWindowWidth;
                userWindow.Height = ChatWindowHeight;
                userWindow.Top = top;
                userWindow.Show();
            }
            this.Top = top + ChatWindowHeight;
            this.Left = left;
            this.Width = userNames.Length * ChatWindowWidth;
            this.Height = MainWindowHeight;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
