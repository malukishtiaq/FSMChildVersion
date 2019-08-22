using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Core.Model;
using MvvmCross.Commands;

namespace FSMChildVersion.Core.ViewModels
{
    public class ViewFarmerViewModel : BaseViewModel
    {

        public ViewFarmerViewModel()
        {
        }
        private ObservableCollection<FarmerModel> famerList;
        private FarmerModel tappedFarmer;
        public ObservableCollection<FarmerModel> FarmerList => famerList ?? (famerList = CreateClubs());

        private ObservableCollection<FarmerModel> CreateClubs()
        {
            return new ObservableCollection<FarmerModel>
            {
                new FarmerModel(){Area = "Liverpool 1", Count = 1, Name = "England 1", MobileNo = "123456 1"},
                new FarmerModel(){Area = "Liverpool 2", Count = 2, Name = "England 2", MobileNo = "123456 2"},
                new FarmerModel(){Area = "Liverpool 3", Count = 3, Name = "England 3", MobileNo = "123456 3"},
                new FarmerModel(){Area = "Liverpool 4", Count = 4, Name = "England 4", MobileNo = "123456 4"},
                new FarmerModel(){Area = "Liverpool 5", Count = 5, Name = "England 5", MobileNo = "123456 5"},
                new FarmerModel(){Area = "Liverpool 6", Count = 6, Name = "England 6", MobileNo = "123456 6"},
                new FarmerModel(){Area = "Liverpool 7", Count = 7, Name = "England 7", MobileNo = "123456 7"},
            };
        }

        public FarmerModel TappedFarmer
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
