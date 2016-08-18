using System;
using System.Windows;

namespace LDVELH_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (languageDefined)
            {
                GlobalTranslator.Instance.translator = new Translator(LDVELH_WPF.Properties.Settings.Default.Language);
                this.StartupUri = new Uri("View/MenuLoad.xaml", UriKind.Relative);
            }
            else
            {
                this.StartupUri = new Uri("View/MenuSettings.xaml", UriKind.Relative);
            }
        }

        private bool languageDefined
        {
            get
            {
                if (LDVELH_WPF.Properties.Settings.Default.Language != "")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
