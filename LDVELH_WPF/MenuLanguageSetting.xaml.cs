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
    public partial class LanguageSetting : Window
    {
        public LanguageSetting()
        {
            InitializeComponent();
            LoadSupportedLanguage();
            SetDefaultLanguage();
        }
        public void LoadSupportedLanguage(){
            foreach(SupportedLanguage language in Enum.GetValues(typeof(SupportedLanguage))){
                ComboSupportedLanguage.Items.Add(language);
            }
        }
        public void SetDefaultLanguage()
        {
            bool found = false;
            foreach (SupportedLanguage item in ComboSupportedLanguage.Items)
            {
                if (Thread.CurrentThread.CurrentCulture.DisplayName.Contains(item.ToString()))
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
            GlobalTranslator.Instance.translator = new Translator((SupportedLanguage)ComboSupportedLanguage.SelectedItem);
            MenuLoad menuLoad = new MenuLoad();
            menuLoad.Show();
            this.Close();
        }
    }
}
