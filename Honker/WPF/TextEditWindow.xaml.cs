using System.Windows;
using System.Windows.Controls;

namespace Honker.WPF
{
    public partial class TextEditWindow : Window
    {
        private readonly Button LinkedButton;

        public TextEditWindow(Button linkedButton, bool isLarge = false)
        {
            InitializeComponent();
            LinkedButton = linkedButton;
            TextField.Text = LinkedButton.Content.ToString();

            if (isLarge)
                IncreaseTextFieldSize();

            TextField.Focus();
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            LinkedButton.Content = TextField.Text;
            Close();
        }

        private void IncreaseTextFieldSize()
        {
            TextField.Height += 150;
            TextField.TextWrapping = TextWrapping.Wrap;
            TextField.AcceptsReturn = true;
        }
    }
}
