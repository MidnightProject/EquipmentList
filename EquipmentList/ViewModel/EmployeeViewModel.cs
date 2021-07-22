using GalaSoft.MvvmLight;
using System.Data;

namespace EquipmentList.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private DataTable employeeTable;
        public DataTable EmployeeTable
        {
            get
            {
                return employeeTable;
            }

            set
            {
                employeeTable = value;
                RaisePropertyChanged("EmployeeTable");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }

        public EmployeeViewModel(DataTable dt)
        {
            EmployeeTable = dt;
            SelectedIndex = -1;
        }
    }
}
