using System;
using System.Globalization;
using System.Windows;

namespace LDVELH_WPF
{
    /// <inheritdoc />
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (LanguageDefined)
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
                            $@"Language '{LDVELH_WPF.Properties.Settings.Default.Language.ToLower()}' is not yet present in the options, if you added the corresponding ressource please add a corresponding case.",
                            "Text");

#else
                GlobalCulture.Instance.Ci = new CultureInfo("en-GB");
                        break;
#endif

                }
                StartupUri = new Uri("View/MenuLoad.xaml", UriKind.Relative);
            }
            else
            {
                StartupUri = new Uri("View/MenuSettings.xaml", UriKind.Relative);
            }
        }

        private static bool LanguageDefined => LDVELH_WPF.Properties.Settings.Default.Language != "";
    }
}
