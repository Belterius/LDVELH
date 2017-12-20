
using System;
using System.Resources;
using System.Globalization;
using System.Reflection;
using System.Windows.Markup;

namespace LDVELH_WPF
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
    }

    public sealed class GlobalTranslator
    {
        public readonly Translator Translator = new Translator();

        private GlobalTranslator()
        {

        }

        public static GlobalTranslator Instance { get; } = new GlobalTranslator();
    }
    public sealed class GlobalCulture
    {
        public CultureInfo Ci = new CultureInfo("en-GB");

        private GlobalCulture()
        {

        }

        public static GlobalCulture Instance { get; } = new GlobalCulture();
    }

    public enum SupportedLanguage
    {
        French,
        English
    }

    public class Translator : MarkupExtension
    {
        private const string ResourceId = "LDVELH_WPF.Resources.Strings";

        public Translator()
        {
        }
        public string Text
        {
            private get;
            set;
        }
        /// <inheritdoc />
        /// <summary>
        /// Retrieve the corresponding string from resource depending on the settings Selected Language.
        /// Called from xaml
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{ResourceId}' for culture '{GlobalCulture.Instance.Ci.Name}'.",
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
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

            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{ResourceId}' for culture '{GlobalCulture.Instance.Ci.Name}'.",
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
        /// <summary>
        /// Retrieve the corresponding string from the Book1 resource depending on the settings Selected Language.
        /// </summary>
        /// <param name="stringToTranslate">The resource string code</param>
        /// <returns>The corresponding string, in the correct language</returns>
        public string TranslateBook1(string stringToTranslate)
        {
            const string stringLocation = "LDVELH_WPF.Resources.StringBook1";
            Text = stringToTranslate;
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(stringLocation
                                , typeof(Translator).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, GlobalCulture.Instance.Ci);

            if (translation == null)
            {
#if DEBUG
                throw new ArgumentException(
                    $"Key '{Text}' was not found in resources '{stringLocation}' for culture '{GlobalCulture.Instance.Ci.Name}'.",
                    "Text");
#else
                translation = Text; // HACK: returns the key, which GETS DISPLAYED TO THE USER
#endif
            }
            return translation;
        }
    }


}