using EquipmentList.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace EquipmentList.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private Collection<DataEmployee> employeeTable;
        public Collection<DataEmployee> EmployeeTable
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
            EmployeeTable = new Collection<DataEmployee>();
            foreach (DataRow row in dt.Rows)
            {
                Boolean active;
                if (String.IsNullOrEmpty(row["ACTIVE"].ToString()))
                {
                    active = false;
                }
                else
                {
                    active = (Boolean)row["ACTIVE"];
                }

                EmployeeTable.Add(new DataEmployee()
                {
                    NAME = row["NAME"].ToString(),
                    ADDRESS = row["ADDRESS"].ToString(),
                    BUILDING = row["BUILDING"].ToString(),
                    ACTIVE = active
                });
            }

        }
    }
}