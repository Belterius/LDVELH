﻿using System;
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
                MessageBox.Show("Disclaimer : the content was translated as best as possible, but sadly there is still some formating problem, such as broken special characters, gameplay information still displayed, monster information in the main narration");
            }
        }
    }
}