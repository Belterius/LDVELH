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
            this.Title = GlobalTranslator.Instance.translator.ProvideValue("LoadMenu");
            buttonLoad.Content = GlobalTranslator.Instance.translator.ProvideValue("Load");
            buttonNew.Content = GlobalTranslator.Instance.translator.ProvideValue("NewGame");
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }
        
        
    }
}
