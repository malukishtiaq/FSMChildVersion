using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FSMChildVersion.Core.ViewModels.Page;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FSMChildVersion.Core.Pages.Master
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxContentPagePresentation(WrapInNavigationPage = false)]
    public partial class Page1 : MvxContentPage<Page1ViewModel>
    {
        public Page1()
        {
            InitializeComponent();
        }
    }
}
