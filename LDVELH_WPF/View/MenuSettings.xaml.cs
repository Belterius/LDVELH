using LDVELH_WPF.ViewModel;
using System;
using System.Threading;
using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for LanguageSetting.xaml
    /// </summary>
    public partial class MenuSettings : Window
    {
        public MenuSettings()
        {
            InitializeComponent();
            TranslateLabel();
        }
        private void TranslateLabel()
        {
            LabelSelectLanguage.Content = GlobalTranslator.Instance.Translator.ProvideValue("SelectLanguage");
            this.Title = GlobalTranslator.Instance.Translator.ProvideValue("Settings");
        }
        
    }
}
