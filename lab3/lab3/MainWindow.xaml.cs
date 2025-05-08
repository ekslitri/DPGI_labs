using System;
using System.Windows;

namespace lab3
{
    public partial class MainWindow : Window
    {
        private readonly string[] answers = { "Так", "Ні", "Скоріше так", "Скоріше ні" };
        private readonly Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnAskQuestionClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(questionBox.Text))
            {
                MessageBox.Show("Спочатку введи запитання!", "Попередження", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            int index = random.Next(answers.Length);
            answerTextBlock.Text = answers[index];
        }
    }
}
