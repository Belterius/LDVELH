using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for MessageBoxInput.xaml
    /// </summary>
    public partial class MessageBoxInput : Window
    {
        public MessageBoxInput()
        {
            InitializeComponent();
        }
        public MessageBoxInput(string title, string content)
        {
            InitializeComponent();
            this.Title = title;
            labelContent.Content = content;
        }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        public string GetCharacterName
        {
            get { return textBoxCharacterName.Text; }
        }
    }
}
