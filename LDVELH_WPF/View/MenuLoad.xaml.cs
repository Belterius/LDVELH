using LDVELH_WPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for LoadMenu.xaml
    /// </summary>
    public partial class MenuLoad : Window
    {
        public MenuLoad()
        {
            InitializeComponent();
            TranslateLabel();
        }
        private void TranslateLabel()
        {
            this.Title = GlobalTranslator.Instance.Translator.ProvideValue("LoadMenu");
            buttonLoad.Content = GlobalTranslator.Instance.Translator.ProvideValue("Load");
            buttonNew.Content = GlobalTranslator.Instance.Translator.ProvideValue("NewGame");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
