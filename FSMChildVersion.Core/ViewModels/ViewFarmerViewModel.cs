using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Common.RequestResponseModel.Farmer;
using MediatR;
using MvvmCross.Commands;

namespace FSMChildVersion.Core.ViewModels
{
    public class ViewFarmerViewModel : BaseViewModel
    {
        private readonly IMediator mediator;
        public ViewFarmerViewModel(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public override void Prepare()
        {
            var allFarmersRequest = new GetAllFarmersRequest();
            List<GetAllFarmersResponse> result = null;// mediator.Send(allFarmersRequest).Result;
            //FarmerList = result.ToObservableCollection();
        }

        public async Task InitializeAsync()
        {
            await base.Initialize();
        }
        private ObservableCollection<GetAllFarmersResponse> famerList;
        private GetAllFarmersResponse tappedFarmer;
        public ObservableCollection<GetAllFarmersResponse> FarmerList
        {
            get => famerList;
            set => SetProperty(ref famerList, value);
        }

        public GetAllFarmersResponse TappedFarmer
        {
            get => tappedFarmer;
            set
            {
                if (tappedFarmer == value)
                    return;

                tappedFarmer = value;
                RaisePropertyChanged(() => TappedFarmer);
            }
        }

        public ICommand NavigateToReminder => new MvxCommand(async () => await RunSafeAsync(SomeMethodAsync()));

        private Task SomeMethodAsync()
        {
            return default;
        }
    }
}
