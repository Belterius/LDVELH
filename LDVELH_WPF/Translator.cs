
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
        public Translator Translator = new Translator();

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
        readonly CultureInfo Ci;
        const string ResourceId = "LDVELH_WPF.Resources.Strings";

        public Translator()
        {
            Ci = Thread.CurrentThread.CurrentCulture;
        }
        public Translator(String language)
        {
            switch (language.ToLower())
            {
                case "french":
                    Ci = new CultureInfo("fr-FR");
                    break;
                case "english":
                    Ci = new CultureInfo("en-GB");
                    break;
                default:
                    Ci = new CultureInfo("en-GB");
                    break;
            }
        }
        public Translator(SupportedLanguage language)
        {
            switch (language)
            {
                case SupportedLanguage.French:
                    Ci = new CultureInfo("fr-FR");
                    break;
                case SupportedLanguage.English:
                    Ci = new CultureInfo("en-GB");
                    break;
                default:
                    Ci = new CultureInfo("en-GB");
                    break;
            }
        }

        public string Text
        {
            get;
            set;
        }

        override public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }

        public string ProvideValue(string stringToTranslate)
        {
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }
        public string TranslateBook1(string stringToTranslate)
        {
            string StringLocation = "LDVELH_WPF.Resources.StringBook1";
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(StringLocation
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, StringLocation, Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }
    }


}