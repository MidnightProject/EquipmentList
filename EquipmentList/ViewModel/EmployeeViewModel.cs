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

        public EmployeeViewModel(DataTable dt)
        {
            EmployeeTable = dt;
        }
    }
}
