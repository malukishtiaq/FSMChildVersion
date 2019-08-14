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
