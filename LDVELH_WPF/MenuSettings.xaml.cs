using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for LanguageSetting.xaml
    /// </summary>
    public partial class MenuSettings : Window
    {
        public MenuSettings()
        {
            InitializeComponent();
            TranslateLabel();
            LoadSupportedLanguage();
            SetDefaultLanguage();
        }
        private void TranslateLabel()
        {
            LabelSelectLanguage.Content = GlobalTranslator.Instance.translator.ProvideValue("SelectLanguage");
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("Settings");
        }
        public void LoadSupportedLanguage(){
            foreach(SupportedLanguage language in Enum.GetValues(typeof(SupportedLanguage))){
                ComboSupportedLanguage.Items.Add(language);
            }
        }
        public void SetDefaultLanguage()
        {
            //We check the settings first, if we have no settings for the language, then we check the system language.
            //If the language is not supported, then we set the language to English
            bool found = false;
            string defaultLanguage;

            if (Properties.Settings.Default.Language != "")
            {
                defaultLanguage = Properties.Settings.Default.Language;
            }
            else
            {
                defaultLanguage = Thread.CurrentThread.CurrentCulture.DisplayName;
            }
            foreach (SupportedLanguage item in ComboSupportedLanguage.Items)
            {
                if (defaultLanguage.Contains(item.ToString()))
                {
                    found = true;
                    ComboSupportedLanguage.SelectedItem = item;
                }
            }
            if (!found)
            {
                ComboSupportedLanguage.SelectedItem = SupportedLanguage.English;
            }
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            ChangeLanguageSettings(ComboSupportedLanguage.SelectedItem.ToString());
            ChangeTranslatorLanguage((SupportedLanguage)ComboSupportedLanguage.SelectedItem);
            MenuLoad menuLoad = new MenuLoad();
            menuLoad.Show();
            WarningMessage();
            this.Close();
        }
        private void ChangeLanguageSettings(String language)
        {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Save();
        }
        private void ChangeTranslatorLanguage(SupportedLanguage language)
        {
            GlobalTranslator.Instance.translator = new Translator(language);
        }
        private void WarningMessage()
        {
            if (!Properties.Settings.Default.Language.Equals("French", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show("Disclaimer : As much content as possible was translated, but sadly the story narration would require too much work (an entire book worth of translation) and still remain in french");
            }
        }
    }
}
