using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSMChildVersion.UI.ResourceDictionaries.ThemeOne;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.UI.ResourceDictionaries
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmallDevicesStyle : ResourceDictionary
    {
        public static SmallDevicesStyle SharedInstance { get; } = new SmallDevicesStyle();
        public SmallDevicesStyle()
        {
            InitializeComponent();
        }
    }
}
