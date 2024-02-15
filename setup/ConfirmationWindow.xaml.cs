using System.Windows;

namespace MyProject
{
    public partial class ConfirmationWindow : Window
    {
        public bool? UserChoice { get; private set; }

        public ConfirmationWindow(string message)
        {
            InitializeComponent();
            ConfirmationText.Text = message;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            UserChoice = true;
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            UserChoice = false;
            Close();
        }
    }
}
