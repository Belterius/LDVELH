
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
    public sealed class GlobalCulture
    {
        public CultureInfo Ci = new CultureInfo("en-GB");

        static readonly GlobalCulture INSTANCE = new GlobalCulture();

        private GlobalCulture()
        {

        }

        public static GlobalCulture Instance
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
        const string ResourceId = "LDVELH_WPF.Resources.Strings";

        public Translator()
        {
        }
        public string Text
        {
            get;
            set;
        }
        /// <summary>
        /// Retrieve the corresponding string from resource depending on the settings Selected Language.
        /// Called from xaml
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        override public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, GlobalCulture.Instance.Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }
        /// <summary>
        /// Retrieve the corresponding string from resource depending on the settings Selected Language.
        /// </summary>
        /// <param name="stringToTranslate">The resource string code</param>
        /// <returns>The corresponding string, in the correct language</returns>
        public string ProvideValue(string stringToTranslate)
        {
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, ResourceId, GlobalCulture.Instance.Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }
        /// <summary>
        /// Retrieve the corresponding string from the Book1 resource depending on the settings Selected Language.
        /// </summary>
        /// <param name="stringToTranslate">The resource string code</param>
        /// <returns>The corresponding string, in the correct language</returns>
        public string TranslateBook1(string stringToTranslate)
        {
            string StringLocation = "LDVELH_WPF.Resources.StringBook1";
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager Resmgr = new ResourceManager(StringLocation
                                , typeof(Translator).GetTypeInfo().Assembly);

            var Translation = Resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (Translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    String.Format("Key '{0}' was not found in resources '{1}' for culture '{2}'.", Text, StringLocation, GlobalCulture.Instance.Ci.Name),
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return Translation;
        }
    }


}