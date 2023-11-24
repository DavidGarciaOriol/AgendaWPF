using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Agenda
{
    public partial class MainWindow : Window
    {

        private int comboBoxItemToDeleteIndex;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += prohibirDiasAnteriores;
        }

        private void agregarButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!textTarea.Text.Equals(""))
            {

                if (calendar.SelectedDate != null)
                {
                    calendar.BorderBrush = new SolidColorBrush(Colors.Black);
                    textTarea.BorderBrush = new SolidColorBrush(Colors.Black);

                    textTareaLabel.Content = "Tarea";
                    textTareaLabel.Foreground = new SolidColorBrush(Colors.Black);

                    ComboBoxItem comboBoxItem = new ComboBoxItem();
                    comboBoxItem.Content = ((DateTime) calendar.SelectedDate).ToShortDateString() + " - " + textTarea.Text;
                    comboBox.Items.Add(comboBoxItem);
                    comboBox.SelectedItem = comboBoxItem;

                    textTarea.Clear();
                    textTarea.Focus();

                    actualizarProgressBar();
                } else
                {
                    calendar.BorderBrush = new SolidColorBrush(Colors.Red);
                }
            }
            else
            {
                textTarea.BorderBrush = new SolidColorBrush(Colors.Red);

                textTareaLabel.Content += " !";
                textTareaLabel.FontWeight = FontWeights.Bold;
                textTareaLabel.Foreground = new SolidColorBrush(Colors.Red);
            }

        }

        private void eliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (comboBox.Items.Count > 0)
            {
                comboBox.Items.RemoveAt(comboBoxItemToDeleteIndex);
                actualizarProgressBar();
                if (comboBox.Items.Count > 0) comboBox.SelectedItem = comboBox.Items.GetItemAt(comboBox.Items.Count-1);
            }
        }

        private void actualizarProgressBar()
        {
            switch (comboBox.Items.Count)
            {
                case 0:
                    progressBarComboBoxItems.IsIndeterminate = true;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.Pink);
                    break;
                case 1:
                    progressBarComboBoxItems.Value = 14;
                    progressBarComboBoxItems.IsIndeterminate = false;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.LightGreen);
                    break;
                case 2:
                    progressBarComboBoxItems.Value = 28;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.LightGreen);
                    break;
                case 3:
                    progressBarComboBoxItems.Value = 42;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.Orange);
                    break;
                case 4:
                    progressBarComboBoxItems.Value = 57;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.Orange);
                    break;
                case 5:
                    progressBarComboBoxItems.Value = 71;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    break;
                case 6:
                    progressBarComboBoxItems.Value = 85;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.OrangeRed);
                    break;
                default:
                    progressBarComboBoxItems.Value = 100;
                    progressBarComboBoxItems.Foreground = new SolidColorBrush(Colors.Red);
                    break;
            }
        }

        private void prohibirDiasAnteriores(Object sender, RoutedEventArgs e)
        {
            calendar.BlackoutDates.AddDatesInPast();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            comboBoxItemToDeleteIndex = comboBox.SelectedIndex;
        }

        private void salirButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
