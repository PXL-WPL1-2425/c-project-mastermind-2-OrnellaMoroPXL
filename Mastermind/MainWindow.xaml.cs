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
        private int _attempts = 0;

        private readonly Color[] _colors = new Color[6]
        {
            (Color)ColorConverter.ConvertFromString("Red"), // 0
            (Color)ColorConverter.ConvertFromString("Yellow"), // 1
            (Color)ColorConverter.ConvertFromString("Orange"), // 2
            (Color)ColorConverter.ConvertFromString("White"), // 3
            (Color)ColorConverter.ConvertFromString("Green"), // 4
            (Color)ColorConverter.ConvertFromString("Blue") // 5
        };

        private readonly string[] _colorNames = new string[6]
        {
            "Red", // 0
            "Yellow", // 1
            "Orange", // 2
            "White", // 3
            "Green", // 4
            "Blue" // 5
        };

        private Color[] _code = new Color[4];

        public MainWindow()
        {
            InitializeComponent();
            GenerateColorCode();
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
            Title = $"Mastermind ({string.Join(", ", _code.Select((color) => GetColorName(color)))})";
            if (_attempts > 0)
            {
                Title += $" - Attemps: {_attempts}";
            }
        }

        private string GetColorName(Color color)
        {
            for (int i = 0; i < _colors.Length; i++)
            {
                if (_colors[i] == color)
                {
                    return _colorNames[i];
                }
            }

            return "Unknown";
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
            ClearBorders();
            _attempts++;
            UpdateTitle();
        }

        private void ClearBorders()
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