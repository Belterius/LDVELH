
using System;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;
using System.Threading;

namespace LDVELH_WPF
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }

    public class Translator : MarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "LDVELH_WPF.Resources.Strings";

        public Translator()
        {
            ci = Thread.CurrentThread.CurrentCulture;
            //ci = new CultureInfo("fr-FR");
        }
        public Translator(string language)
        {
            switch (language.ToLower())
            {
                case "french":
                    ci = new CultureInfo("fr-FR");
                    break;
                case "english":
                    ci = new CultureInfo("en-GB");
                    break;
                default:
                    ci = new CultureInfo("fr-FR");
                    break;
            }
        }

        public string Text { get; set; }

        override public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }

        public string ProvideValue(string stringToTranslate)
        {
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }


}