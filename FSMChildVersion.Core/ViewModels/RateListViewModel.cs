using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using FSMChildVersion.Core.Model;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace FSMChildVersion.Core.ViewModels
{
    public class RateListViewModel : BaseViewModel
    {
        public RateListViewModel()
        {

        }
        private ObservableCollection<InsecticidesModel> insecticidesList;
        private ObservableCollection<WeedCidesModel> weedCidesList;
        public ObservableCollection<InsecticidesModel> InsecticidesList => insecticidesList ?? (insecticidesList = CreateInsecticidesList());
        public ObservableCollection<WeedCidesModel> WeedCidesList => weedCidesList ?? (weedCidesList = CreateWeedCidesList());

        private ObservableCollection<InsecticidesModel> CreateInsecticidesList()
        {
            return new ObservableCollection<InsecticidesModel>
            {
                new InsecticidesModel(){ProductName = "Insecticides 1", Rate = 1},
                new InsecticidesModel(){ProductName = "Insecticides 2", Rate = 2},
                new InsecticidesModel(){ProductName = "Insecticides 3", Rate = 3},
                new InsecticidesModel(){ProductName = "Insecticides 4", Rate = 4},
                new InsecticidesModel(){ProductName = "Insecticides 5", Rate = 5},
                new InsecticidesModel(){ProductName = "Insecticides 6", Rate = 6},
                new InsecticidesModel(){ProductName = "Insecticides 7", Rate = 7},
            };
        }
        private ObservableCollection<WeedCidesModel> CreateWeedCidesList()
        {
            return new ObservableCollection<WeedCidesModel>
            {
                new WeedCidesModel(){ProductName = "WeedCides 1", Rate = 1},
                new WeedCidesModel(){ProductName = "WeedCides 2", Rate = 2},
                new WeedCidesModel(){ProductName = "WeedCides 3", Rate = 3},
                new WeedCidesModel(){ProductName = "WeedCides 4", Rate = 4},
                new WeedCidesModel(){ProductName = "WeedCides 5", Rate = 5},
                new WeedCidesModel(){ProductName = "WeedCides 6", Rate = 6},
                new WeedCidesModel(){ProductName = "WeedCides 7", Rate = 7},
            };
        }

        public ICommand NavigateToReminder => new MvxCommand(() => SomeMethodAsync());

        private void SomeMethodAsync()
        {
            //return Task.Run(default);
        }
    }
}
