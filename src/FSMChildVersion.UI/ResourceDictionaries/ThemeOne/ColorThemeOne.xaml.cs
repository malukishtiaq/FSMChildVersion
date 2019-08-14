using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.Core.ResourceDictionaries.ThemeOne
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ColorThemeOne
    {
        public static ColorThemeOne SharedInstance { get; } = new ColorThemeOne();
        public ColorThemeOne()
        {
            InitializeComponent();
        }
    }
}
