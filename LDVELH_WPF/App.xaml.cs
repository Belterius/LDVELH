using System;
using System.Globalization;
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
                switch (LDVELH_WPF.Properties.Settings.Default.Language.ToLower())
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
                            String.Format("Language '{0}' is not yet present in the options, if you added the corresponding ressource please add a corresponding case.", LDVELH_WPF.Properties.Settings.Default.Language.ToLower()),
                            "Text");
#else
                GlobalCulture.Instance.Ci = new CultureInfo("en-GB");
#endif
                        
                        break;
                }
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
