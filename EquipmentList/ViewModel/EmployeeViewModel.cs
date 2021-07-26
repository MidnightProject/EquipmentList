using GalaSoft.MvvmLight;
using System;
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

        private string group;
        public string Group
        {
            get
            {
                return group;
            }

            set
            {
                switch (value)
                {
                    case "Name":
                        group = "NAME";
                        break;
                    case "Job title":
                        group = "JOB";
                        break;
                    case "Building":
                        group = "BUILDING";
                        break;
                    case "Status":
                        group = "ACTIVE";
                        break;
                    default:
                        group = String.Empty;
                        break;
                }

                RaisePropertyChanged("Group");
            }
        }

        public EmployeeViewModel(DataTable dt)
        {
            EmployeeTable = dt;
            
        }
    }
}
