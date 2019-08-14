using System.Globalization;
using FSMChildVersion.Core.ResourceDictionaries;
using Plugin.Multilingual;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FSMChildVersion.UI
{
    public partial class App : Application
    {
        private const int SmallWightResolution = 768;
        private const int SmallHeightResolution = 1280;
        public App()
        {
            InitializeComponent();
            LoadStyles();
        }
        private static void MultiLanguageSetup()
        {
            CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");

            //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
        }

        private void LoadStyles()
        {
            if (IsASmallDevice())
            {
                dictionary.MergedDictionaries.Add(SmallDevicesStyle.SharedInstance);
            }
            else
            {
                dictionary.MergedDictionaries.Add(GeneralDevicesStyle.SharedInstance);
            }
        }

        public static bool IsASmallDevice()
        {
            // Get Metrics
            DisplayInfo mainDisplayInfo = DeviceDisplay.MainDisplayInfo;

            // Width (in pixels)
            var width = mainDisplayInfo.Width;

            // Height (in pixels)
            var height = mainDisplayInfo.Height;
            return (width <= SmallWightResolution && height <= SmallHeightResolution);
        }
    }
}
