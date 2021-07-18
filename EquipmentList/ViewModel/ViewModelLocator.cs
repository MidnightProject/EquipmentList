using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;

namespace EquipmentList.ViewModel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<BuildingViewModel>();
            SimpleIoc.Default.Register<EmployeeViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public BuildingViewModel Bulding
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BuildingViewModel>();
            }
        }

        public EmployeeViewModel Employee
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EmployeeViewModel>();
            }
        }

        public static void Cleanup()
        {

        }
    }
}