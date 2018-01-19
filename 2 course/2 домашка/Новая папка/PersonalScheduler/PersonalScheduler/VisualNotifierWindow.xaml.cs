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
using System.Windows.Shapes;

namespace PersonalScheduler
{
    /// <summary>
    /// Interaction logic for VisualNotifierWindow.xaml
    /// </summary>
    public partial class VisualNotifierWindow : Window
    {
        public VisualNotifierWindow(ScheduledEvent sv)
        {
            InitializeComponent();
            textBoxName.Text = sv.Name;
            textBoxTime.Text = sv.DateTime.ToString();
            textBoxDescription.Text = sv.Description;
            textBoxPlace.Text = sv.Place;
        }
    }
}
