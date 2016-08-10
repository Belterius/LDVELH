
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

    public sealed class GlobalTranslator
    {
        public Translator translator = new Translator();

        static readonly GlobalTranslator INSTANCE = new GlobalTranslator();

        private GlobalTranslator()
        {

        }

        public static GlobalTranslator Instance
        {
            get
            {
                return INSTANCE;
            }
        }
    }

    public enum SupportedLanguage
    {
        French,
        English
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
        public Translator(String language)
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
                    ci = new CultureInfo("en-GB");
                    break;
            }
        }
        public Translator(SupportedLanguage language)
        {
            switch (language)
            {
                case SupportedLanguage.French:
                    ci = new CultureInfo("fr-FR");
                    break;
                case SupportedLanguage.English:
                    ci = new CultureInfo("en-GB");
                    break;
                default:
                    ci = new CultureInfo("en-GB");
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
        public string TranslateBook1(string stringToTranslate)
        {
            string StringLocation = "LDVELH_WPF.Resources.StringBook1";
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(StringLocation
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
#if DEBUG
                //throw new ArgumentException(
                //    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, StringLocation, ci.Name),
                //    "Text");
                System.Diagnostics.Debug.WriteLine(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, StringLocation, ci.Name),
                    "Text");
                translation = Text;
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }


}