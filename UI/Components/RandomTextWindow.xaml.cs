using System;
using System.Windows;

namespace UI
{
    public partial class RandomTextWindow : Window
    {
        public RandomTextWindow()
        {
            InitializeComponent();
        }

        private void GenerateRandomText()
        {
            // Generate random text and display it in the TextBox
            string randomText = GenerateRandomTextMethod();
            txtRandomText.Text = randomText;
        }

        private string GenerateRandomTextMethod()
        {
            // Add your logic here to generate random text
            // For example, you can use Random class to generate random characters or words
            Random random = new Random();
            string[] words = { "Lorem", "ipsum", "dolor", "sit", "amet" };
            string randomText = "";
            for (int i = 0; i < 5; i++)
            {
                int index = random.Next(words.Length);
                randomText += words[index] + " ";
            }
            return randomText.Trim();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GenerateRandomText();
        }
    }
}
