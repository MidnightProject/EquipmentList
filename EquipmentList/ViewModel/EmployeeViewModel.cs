using EquipmentList.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Data;

namespace EquipmentList.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private Collection<DataEmployee> dataEmployees;
        public Collection<DataEmployee> DataEmployees
        {
            get
            {
                return dataEmployees;
            }

            set
            {
                dataEmployees = value;
                RaisePropertyChanged("DataEmployees");
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
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
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
            DataEmployees = new Collection<DataEmployee>();
            foreach (DataRow row in dt.Rows)
            {
                DataEmployees.Add(new DataEmployee()
                {
                    Name = row["NAME"].ToString(),
                    Job = row["JOB"].ToString(),
                    Phone = row["PHONE"].ToString(),
                    Email = row["Email"].ToString(),
                    Building = row["BUILDING"].ToString(),
                    Country = row["COUNTRY"].ToString(),
                    City = row["CITY"].ToString(),
                    Postcode = row["POSTCODE"].ToString(),
                    Address = row["ADDRESS"].ToString(),
                    Active = row["ACTIVE"].ToBoolean(),
                    AddUser = row["ADD_USER"].ToBoolean(),
                    EditUser = row["EDIT_USER"].ToBoolean(),
                    DeleteUser = row["DELETE_USER"].ToBoolean(),
                    PrintUser = row["PRINT_USER"].ToBoolean(),
                    AddOwnEquipment = row["ADD_OWN_EQUIPMENT"].ToBoolean(),
                    DeleteOwnEquipment = row["DELETE_OWN_EQUIPMENT"].ToBoolean(),
                    AddOtherEquipment = row["ADD_OTHER_EQUIPMENT"].ToBoolean(),
                    DeleteOtherEquipment = row["DELETE_OTHER_EQUIPMENT"].ToBoolean(),
                    EditOtherEquipment = row["EDIT_OTHER_EQUIPMENT"].ToBoolean(),
                    ViewOtherEquipment = row["VIEW_OTHER_EQUIPMENT"].ToBoolean(),
                    PrintOtherEquipment = row["PRINT_OTHER_EQUIPMENT"].ToBoolean(),
                });
            }
        }
    }


    public static class DataTableExtensions
    {
        public static Boolean ToBoolean(this object val)
        {
            if (String.IsNullOrEmpty(val.ToString()))
            {
                return false;
            }

            return (Boolean)val;
        }
    }
}