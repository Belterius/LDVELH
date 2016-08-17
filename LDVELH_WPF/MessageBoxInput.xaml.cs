using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("SelectCharacterName");
            buttonOK.Content = GlobalTranslator.Instance.translator.ProvideValue("OK");
            labelContent.Content = GlobalTranslator.Instance.translator.ProvideValue("EnterCharacterName");
        }
        private void buttonOK_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        public string getCharacterName
        {
            get { return textBoxCharacterName.Text; }
        }
    }
}
