using LDVELH_WPF.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace LDVELH_WPF.ViewModel
{
    class MenuSettingsViewModel : ViewModelBase
    {
        SupportedLanguage _SelectedLanguage;
        public SupportedLanguage SelectedLanguage
        {
            get
            {
                return _SelectedLanguage;
            }
            set
            {
                if (_SelectedLanguage != value)
                {
                    _SelectedLanguage = value;
                    RaisePropertyChanged("SelectedLanguage");
                }
            }
        }
        ObservableCollection<SupportedLanguage> _ListLanguage = new ObservableCollection<SupportedLanguage>();
        public ObservableCollection<SupportedLanguage> ListLanguage
        {
            get
            {
                return _ListLanguage;
            }
            set
            {
                _ListLanguage = value;
            }
        }

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
            string defaultLanguage;

            if (Properties.Settings.Default.Language != "")
            {
                defaultLanguage = Properties.Settings.Default.Language;
            }
            else
            {
                defaultLanguage = Thread.CurrentThread.CurrentCulture.DisplayName;
            }
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
            GlobalTranslator.Instance.translator = new Translator(language);
        }
        private void WarningMessage()
        {
            if (!Properties.Settings.Default.Language.Equals("French", StringComparison.InvariantCultureIgnoreCase))
            {
                MessageBox.Show(GlobalTranslator.Instance.translator.ProvideValue("Disclaimer"));
            }
        }
    }
}
