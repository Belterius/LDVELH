using LDVELH_WPF.Helpers;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace LDVELH_WPF.ViewModel
{
    public class MenuSettingsViewModel : ViewModelBase
    {
        private SupportedLanguage _selectedLanguage;
        public SupportedLanguage SelectedLanguage
        {
            get
            {
                return _selectedLanguage;
            }
            set
            {
                if (_selectedLanguage != value)
                {
                    _selectedLanguage = value;
                    RaisePropertyChanged("SelectedLanguage");
                }
            }
        }

        public ObservableCollection<SupportedLanguage> ListLanguage { get; set; } = new ObservableCollection<SupportedLanguage>();

        public MenuSettingsViewModel()
        {
            ConfirmCommand = new RelayCommand(Confirm);
            LoadSupportedLanguage();

        }
        public RelayCommand ConfirmCommand { get; set; }

        
        private void LoadSupportedLanguage()
        {
            foreach (SupportedLanguage language in Enum.GetValues(typeof(SupportedLanguage)))
            {
                ListLanguage.Add(language);
            }
        }
        private void SetDefaultLanguage()
        {
            //We check the settings first, if we have no settings for the language, then we check the system language.
            //If the language is not supported, then we set the language to English
            bool found = false;
            string defaultLanguage = Properties.Settings.Default.Language != "" ? Properties.Settings.Default.Language : Thread.CurrentThread.CurrentCulture.DisplayName;
            foreach (SupportedLanguage item in ListLanguage)
            {
                if (defaultLanguage.Contains(item.ToString()))
                {
                    found = true;
                    SelectedLanguage = item;
                }
            }
            if (!found)
            {
                SelectedLanguage = SupportedLanguage.English;
            }
        }
        private void Confirm(object language)
        {
            ChangeLanguageSettings(SelectedLanguage.ToString());
            ChangeTranslatorLanguage((SupportedLanguage)SelectedLanguage);
            MenuLoad menuLoad = new MenuLoad { DataContext = new MenuLoadViewModel() };
            menuLoad.Show();
            WarningMessage();
            CloseWindow();
        }
        private void ChangeLanguageSettings(String language)
        {
            Properties.Settings.Default.Language = language;
            Properties.Settings.Default.Save();
        }
        private void ChangeTranslatorLanguage(SupportedLanguage language)
        {
            switch (language.ToString().ToLower())
            {
                case "french":
                    GlobalCulture.Instance.Ci = new CultureInfo("fr-FR");
                    break;
                case "english":
                    GlobalCulture.Instance.Ci = new CultureInfo("en-GB");
                    break;
                default:
#if DEBUG
                    throw new ArgumentException(
                        $"Language '{Properties.Settings.Default.Language.ToLower()}' is not yet present in the options, if you added the corresponding ressource please add a corresponding case.",
                        "Text");
#else
                GlobalCulture.Instance.Ci = new CultureInfo("en-GB");
                    break;
#endif

            }
        }
        private void WarningMessage()
        {
            if (!Properties.Settings.Default.Language.Equals("French", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show(GlobalTranslator.Instance.Translator.ProvideValue("Disclaimer"));
            }
        }
    }
}
