using GalaSoft.MvvmLight;

namespace EquipmentList.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase viewModel;
        public ViewModelBase ViewModel
        {
            get
            {
                return viewModel;
            }

            set
            {
                viewModel = value;
                RaisePropertyChanged("ViewModel");
            }
        }

        public MainViewModel()
        {
            ViewModel = new BuildingViewModel();
            ViewModel = new EmployeeViewModel();
        }
    }
}