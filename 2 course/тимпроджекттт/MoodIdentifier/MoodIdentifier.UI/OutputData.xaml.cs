﻿using MoodIdentifier.AnalysisData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace MoodIdentifier.UI
{
    /// <summary>
    /// Interaction logic for OutputData.xaml
    /// </summary>
    public partial class OutputData : Window
    {
        //private readonly CalenderBackground background;
       
        public delegate void DelegateForOutputDataClosed();
        public event DelegateForOutputDataClosed EventOutputDataClosed;

        List<DataToOutput> Datalist { get; set; }
        Dictionary<DateTime, ClassForAnalysis> Dataframe { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime SecondDate { get; set; }

        public OutputData(Dictionary<DateTime,ClassForAnalysis> dataframe,DateTime firstdate, DateTime seconddate)
        {
            FirstDate = firstdate;
            SecondDate = seconddate;
            Converter convert = new Converter();
            Dataframe = dataframe;
            Datalist = convert.FromDictionaryToList(dataframe);
            InitializeComponent();
            dataGridOutput.ItemsSource = Datalist;
            calendar.SelectedDates.Clear();
            backtoalldata.Visibility = Visibility.Hidden;
            Hide1();
            SetBlackoutDates();
        }

        private void Button_Back_To_MainWindow_Click(object sender, RoutedEventArgs e)
        {
            EventOutputDataClosed?.Invoke();
            this.Close();
        }

        private void dataGridOutput_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridOutput.SelectedItem != null)
            {
                try
                {
                    AngerTextBox.Background = new SolidColorBrush(Colors.White);
                    DisgustTextBox.Background = new SolidColorBrush(Colors.White);
                    FearTextBox.Background = new SolidColorBrush(Colors.White);
                    JoyTextBox.Background = new SolidColorBrush(Colors.White);
                    SadnessTextBox.Background = new SolidColorBrush(Colors.White);
                    Show1();
                    DataToOutput selected = (DataToOutput)dataGridOutput.SelectedItem;
                    textBoxInfoMainEmotion.Text = string.Format("{0} is the main emotion of {1}.", selected.MainEmotion, selected.Date);
                    switch (selected.MainEmotion)
                    {
                        case "Anger":
                            imageEmotion.Source = new BitmapImage(new Uri("Pictures/anger.png", UriKind.Relative));
                            AngerTextBox.Background = new SolidColorBrush(Colors.Orange);
                            break;
                        case "Disgust":
                            imageEmotion.Source = new BitmapImage(new Uri("Pictures/disgust.png", UriKind.Relative));
                            DisgustTextBox.Background = new SolidColorBrush(Colors.Orange);
                            break;
                        case "Fear":
                            imageEmotion.Source = new BitmapImage(new Uri("Pictures/fear.png", UriKind.Relative));
                            FearTextBox.Background = new SolidColorBrush(Colors.Orange);
                            break;
                        case "Joy":
                            imageEmotion.Source = new BitmapImage(new Uri("Pictures/joy.png", UriKind.Relative));
                            JoyTextBox.Background = new SolidColorBrush(Colors.Orange);
                            break;
                        case "Sadness":
                            imageEmotion.Source = new BitmapImage(new Uri("Pictures/sadness.png", UriKind.Relative));
                            SadnessTextBox.Background = new SolidColorBrush(Colors.Orange);
                            break;
                    }
                    var result = (from analyzed in Dataframe
                                  where analyzed.Key.ToString("d") == selected.Date
                                  select analyzed.Value).ToList();
                    var analyzedone = result[0];
                    AngerTextBox.Text = string.Format("Anger that day was about {0}", Math.Round(analyzedone.AllEmotion.Anger, 2));
                    DisgustTextBox.Text = string.Format("Disgsut that day was about {0}", Math.Round(analyzedone.AllEmotion.Disgust, 2));
                    FearTextBox.Text = string.Format("Fear that day was about {0}", Math.Round(analyzedone.AllEmotion.Fear, 2));
                    JoyTextBox.Text = string.Format("Joy that day was about {0}", Math.Round(analyzedone.AllEmotion.Joy, 2));
                    SadnessTextBox.Text = string.Format("Sadness that day was about {0}", Math.Round(analyzedone.AllEmotion.Sadness, 2));
                }

                catch { }
            }
        }

        private void dataGridOutput_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dataGridOutput.Columns[1].Width = new DataGridLength(1, DataGridLengthUnitType.Star);
        }

        private void buttonQuery_Click(object sender, RoutedEventArgs e)
        {
            Hide1();
            backtoalldata.Visibility = Visibility.Visible;
            RepositoryAnalysisData rad = new RepositoryAnalysisData();
            var a = comboBoxSearchQuery.Text;
            var result = (from get in Dataframe
                         where rad.Сomputation(get.Value.AllEmotion, get.Value.CountTweets).Emotion == comboBoxSearchQuery.Text
                         select get).ToList();
            List<DataToOutput> querylist = new List<DataToOutput>();
            foreach (var item in result)
            {
                querylist.Add(new DataToOutput { Date = item.Key.ToString("d"), MainEmotion = rad.Сomputation(item.Value.AllEmotion,item.Value.CountTweets).Emotion});
            }
            dataGridOutput.ItemsSource = querylist;
        }

        private void SetBlackoutDates()
        {
            calendar.BlackoutDates.Add(new CalendarDateRange(FirstDate, SecondDate));
        }

        private void backtoalldata_Click(object sender, RoutedEventArgs e)
        {
            Hide1();
            dataGridOutput.ItemsSource = Datalist;
            backtoalldata.Visibility = Visibility.Hidden;
            comboBoxSearchQuery.SelectedItem = firstone;
        }

        private void Hide1()
        {
            imageEmotion.Visibility = Visibility.Hidden;
            textBoxInfoMainEmotion.Visibility = Visibility.Hidden;
            AngerTextBox.Visibility = Visibility.Hidden;
            DisgustTextBox.Visibility = Visibility.Hidden;
            FearTextBox.Visibility = Visibility.Hidden;
            JoyTextBox.Visibility = Visibility.Hidden;
            SadnessTextBox.Visibility = Visibility.Hidden;
        }
        private void Show1()
        {
            imageEmotion.Visibility = Visibility.Visible;
            textBoxInfoMainEmotion.Visibility = Visibility.Visible;
            AngerTextBox.Visibility = Visibility.Visible;
            DisgustTextBox.Visibility = Visibility.Visible;
            FearTextBox.Visibility = Visibility.Visible;
            JoyTextBox.Visibility = Visibility.Visible;
            SadnessTextBox.Visibility = Visibility.Visible;
        }
    }
}
