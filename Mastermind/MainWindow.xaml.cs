using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            // GeneratedSolution();
        }

        private void GeneratedSolution()
        {
            Random randomColorGenerator = new Random();
            string solution = "";

            for (int i = 0; i < 4; i++)
            {
                int randomColorIndex = randomColorGenerator.Next(6);

                switch (randomColorIndex)
                {
                    case 0:
                        solution += "Red";
                        break;

                    case 1:
                        solution += "Orange";
                        break;

                    case 2:
                        solution += "Yellow";
                        break;

                    case 3:
                        solution += "Green";
                        break;

                    case 4:
                        solution += "Blue";
                        break;

                    case 5:
                        solution += "White";
                        break;
                }
                if (i < 3)
                {
                    solution += ", ";
                }
            }

            //  this.Title = solution;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            ComboBoxItem selectedItem = comboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string selectedColor = selectedItem.Content.ToString();

                if (comboBox == comboBox1)
                {
                    colorLabel1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox2)
                {
                    colorLabel2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox3)
                {
                    colorLabel3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox4)
                {
                    colorLabel4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
            }
        }

        private void ValidateAnswers_Click(object sender, RoutedEventArgs e)
        {
            NoBorders();
            NoBorders();
            int userAttempts = 0;
            string attempts = $"Poging {userAttempts}";
            this.Title = attempts;
        }

        private void NoBorders()
        {
            border1.BorderBrush = Brushes.Transparent;
            border2.BorderBrush = Brushes.Transparent;
            border3.BorderBrush = Brushes.Transparent;
            border4.BorderBrush = Brushes.Transparent;
        }

        private void ToggleDebug()
        {
        }

        private void StartCountDown()
        {
        }

        private void DtopCountDown()
        {
        }
    }
}