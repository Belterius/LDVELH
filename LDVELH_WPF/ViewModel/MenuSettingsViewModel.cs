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
            foreach (SupportedLanguage Language in Enum.GetValues(typeof(SupportedLanguage)))
            {
                ListLanguage.Add(Language);
            }
        }
        private void SetDefaultLanguage()
        {
            //We check the settings first, if we have no settings for the language, then we check the system language.
            //If the language is not supported, then we set the language to English
            bool Found = false;
            string DefaultLanguage;

            if (Properties.Settings.Default.Language != "")
            {
                DefaultLanguage = Properties.Settings.Default.Language;
            }
            else
            {
                DefaultLanguage = Thread.CurrentThread.CurrentCulture.DisplayName;
            }
            foreach (SupportedLanguage Item in ListLanguage)
            {
                if (DefaultLanguage.Contains(Item.ToString()))
                {
                    Found = true;
                    SelectedLanguage = Item;
                }
            }
            if (!Found)
            {
                SelectedLanguage = SupportedLanguage.English;
            }
        }
        private void Confirm(object language)
        {
            ChangeLanguageSettings(SelectedLanguage.ToString());
            ChangeTranslatorLanguage((SupportedLanguage)SelectedLanguage);
            MenuLoad MenuLoad = new MenuLoad { DataContext = new MenuLoadViewModel() };
            MenuLoad.Show();
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
            GlobalTranslator.Instance.Translator = new Translator(language);
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
