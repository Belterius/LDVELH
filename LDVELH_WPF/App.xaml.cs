using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
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
            this.StartupUri = new Uri("HackResx.xaml", UriKind.Relative);
            //if (languageDefined)
            //{
            //    GlobalTranslator.Instance.translator = new Translator(LDVELH_WPF.Properties.Settings.Default.Language);
            //    this.StartupUri = new Uri("MenuLoad.xaml", UriKind.Relative);
            //}
            //else
            //{
            //    this.StartupUri = new Uri("MenuSettings.xaml", UriKind.Relative);
            //}
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
