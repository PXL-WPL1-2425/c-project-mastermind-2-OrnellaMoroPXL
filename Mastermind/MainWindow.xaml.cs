using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Mastermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _colors = new string[6]
        {
            "Red", // 0
            "Yellow", // 1
            "Orange", // 2
            "White", // 3
            "Green", // 4
            "Blue" // 5
        };

        private string[] _code = new string[4];
        private string[] _playerGuess = new string[4];
        private Label[] _labels = new Label[4];
        private int _Maxattempts = 10;
        private int _attempts = 0;
        private bool _solution = true;

        public MainWindow()
        {
            InitializeComponent();
            GenerateColorCode();
            _labels[0] = colorLabel1;
            _labels[1] = colorLabel2;
            _labels[2] = colorLabel3;
            _labels[3] = colorLabel4;
        }

        private void GenerateColorCode()
        {
            Random random = new Random();

            for (int i = 0; i < 4; i++)
            {
                int randomColorIndex = random.Next(6);
                _code[i] = _colors[randomColorIndex];
            }

            UpdateTitle();
        }

        private void UpdateTitle()
        {
            Title = $"Mastermind";
            if (_solution)
            {
                Title += $" ({string.Join(", ", _code)})";
            }
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
                    _playerGuess[0] = selectedColor;
                    colorLabel1.BorderBrush = Brushes.LightGray;
                    colorLabel1.BorderThickness = new Thickness(1);
                    colorLabel1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox2)
                {
                    _playerGuess[1] = selectedColor;
                    colorLabel2.BorderBrush = Brushes.LightGray;
                    colorLabel2.BorderThickness = new Thickness(1);
                    colorLabel2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox3)
                {
                    _playerGuess[2] = selectedColor;
                    colorLabel3.BorderBrush = Brushes.LightGray;
                    colorLabel3.BorderThickness = new Thickness(1);
                    colorLabel3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
                else if (comboBox == comboBox4)
                {
                    _playerGuess[3] = selectedColor;
                    colorLabel4.BorderBrush = Brushes.LightGray;
                    colorLabel4.BorderThickness = new Thickness(1);
                    colorLabel4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(selectedColor));
                }
            }
        }

        private void ValidateAnswers_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (_code[i] == _playerGuess[i])
                {
                    _labels[i].BorderBrush = Brushes.DarkRed;
                    _labels[i].BorderThickness = new Thickness(3);
                }
                else if (_code.Contains(_playerGuess[i]))
                {
                    _labels[i].BorderBrush = Brushes.Wheat;
                    _labels[i].BorderThickness = new Thickness(3);
                }
            }

            _attempts++;
            UpdateAttempt();

            if (_attempts >= 10)
            {
                attemptLabel.Content = $"10/10\r\nGame over";
            }
        }

        private void UpdateAttempt()
        {
            attemptLabel.Content = $"{_attempts}/10";
        }
    }
}