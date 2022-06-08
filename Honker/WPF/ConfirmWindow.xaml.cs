using System.Windows;

namespace Honker
{
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow(string message)
        {
            InitializeComponent();
            MessageText.Text = message;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
