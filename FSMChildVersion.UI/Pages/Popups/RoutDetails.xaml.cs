using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.UI.Pages.Popups
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoutDetails : Rg.Plugins.Popup.Pages.PopupPage
    {
        public RoutDetails()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }
    }
}
