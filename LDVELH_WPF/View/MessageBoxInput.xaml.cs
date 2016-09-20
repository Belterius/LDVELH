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
            TranslateLabel();
        }
        public MessageBoxInput(string title, string content)
        {
            InitializeComponent();
            TranslateLabel();
            this.Title = title;
            labelContent.Content = content;
        }

        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.Translator.ProvideValue("SelectCharacterName");
            buttonOK.Content = GlobalTranslator.Instance.Translator.ProvideValue("OK");
            labelContent.Content = GlobalTranslator.Instance.Translator.ProvideValue("EnterCharacterName");
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
