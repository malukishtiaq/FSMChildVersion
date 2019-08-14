using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSMChildVersion.Core.ResourceDictionaries.ThemeOne;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.Core.ResourceDictionaries
{
    public partial class GeneralDevicesStyle : ResourceDictionary
    {
        public static GeneralDevicesStyle SharedInstance { get; } = new GeneralDevicesStyle();
        public GeneralDevicesStyle()
        {
            InitializeComponent();

            //SharedInstance.MergedDictionaries.Add(ColorThemeOne.SharedInstance);
            //SharedInstance.MergedDictionaries.Add(StyleThemeOne.SharedInstance);
        }
    }
}
