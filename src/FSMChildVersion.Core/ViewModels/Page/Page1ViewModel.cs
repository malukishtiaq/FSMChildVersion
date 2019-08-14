using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross;
using MvvmCross.Commands;
using FSMChildVersion.Core.Model;
using FSMChildVersion.Core.Services;
using Newtonsoft.Json;

namespace FSMChildVersion.Core.ViewModels.Page
{
    public class Page1ViewModel : BaseViewModel
    {
        private readonly IMakeUpService makeUpService;
        private readonly IReddItService reddItService;
        private readonly IMakeupLocalDbService makeupLocalDbService;

        public Page1ViewModel(IMakeUpService makeUpService, IReddItService reddItService, IMakeupLocalDbService makeupLocalDbService)
        {
            this.makeUpService = makeUpService;
            this.reddItService = reddItService;
            this.makeupLocalDbService = makeupLocalDbService;
        }
        public override void Prepare()
        {
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        public ICommand NavigateToReminder => new MvxCommand(async () => await RunSafeAsync(SomeMethodAsync()));

        public ObservableCollection<MakeUpModel> MakeUps { get; set; }
        public ObservableCollection<News> News { get; set; }

        private async Task SomeMethodAsync()
        {
            //await MakupsAsync();
            //await NewsAsync();
            await GetMakupsAsync();
        }

        private async Task NewsAsync()
        {
            HttpResponseMessage timelineResponse = await reddItService.GetNewsAsync();

            if (timelineResponse.IsSuccessStatusCode)
            {
                var response = await timelineResponse.Content.ReadAsStringAsync();
                RootNews json = await Task.Run(() => JsonConvert.DeserializeObject<RootNews>(response));
                News = new ObservableCollection<News>(json.Data.News);
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }

        private async Task MakupsAsync()
        {
            HttpResponseMessage makeUpsResponse = await makeUpService.GetMakeUpsAsync("maybelline");

            if (makeUpsResponse.IsSuccessStatusCode)
            {
                var response = await makeUpsResponse.Content.ReadAsStringAsync();
                var json = await Task.Run(() => JsonConvert.DeserializeObject<List<MakeUpModel>>(response));
                MakeUps = new ObservableCollection<MakeUpModel>(json);
                var result = await makeupLocalDbService.AddMakeupLocalDataAsync(new List<MakeUpModel>(MakeUps));
            }
            else
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
        }
        private async Task GetMakupsAsync()
        {
            var makeUpModels = new ObservableCollection<MakeUpModel>(); 
            List<MakeUpModel> makeUpsResponse = await makeupLocalDbService.GetMakeupLocalDataAsync();

            if (makeUpsResponse is null || makeUpsResponse.Count == 0)
            {
                await PageDialog.AlertAsync("Unable to get data", "Error", "Ok");
            }
            else
            {
                makeUpModels = new ObservableCollection<MakeUpModel>(makeUpsResponse);
            }
        }
    }
}
