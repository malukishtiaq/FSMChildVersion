using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using FSMChildVersion.Core.Services;
using Xamarin.Forms;

namespace FSMChildVersion.Core.ViewModels
{
    public abstract class BaseViewModel : MvxViewModel
    {
        public readonly IMvxNavigationService NavigationService;
        public readonly IUserDialogs PageDialog;
        public bool IsBusy { get; set; }

        public BaseViewModel()
        {
            PageDialog = Mvx.IoCProvider.Resolve<IUserDialogs>();
            NavigationService = Mvx.IoCProvider.Resolve<IMvxNavigationService>();
        }

        public async Task RunSafeAsync(Task task, bool showLoading = true, string loadinMessage = null)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if (showLoading)
                    PageDialog.ShowLoading(loadinMessage ?? "Loading");

                await task;
            }
            catch (Exception e)
            {
                IsBusy = false;
                PageDialog.HideLoading();
                Debug.WriteLine(e.ToString());
                //await Application.Current.MainPage.DisplayAlert("Error", "Check your Internet connection", "OK");
            }
            finally
            {
                IsBusy = false;
                if (showLoading)
                    PageDialog.HideLoading();
            }
        }

    }
}
