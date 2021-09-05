using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using static EquipmentList.View.Views;

namespace EquipmentList.ViewModel
{
    public class EmployeeViewModel : ViewModelBase
    {
        private DefinedViews view;
        public DefinedViews View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
                RaisePropertyChanged("View");
            }
        }

        private ObservableCollection<DataEmployee> dataEmployees;
        public ObservableCollection<DataEmployee> DataEmployees
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

        private string columnStatusFilter;
        public string ColumnStatusFilter
        {
            get
            {
                return columnStatusFilter;
            }

            set
            {
                columnStatusFilter = value;
                RaisePropertyChanged("ColumnStatusFilter");
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


        public int SelectedIndexes { get; set; }

        private RelayCommand selectedIndexCommand;
        public RelayCommand SelectedIndexCommand
        {
            get
            {
                return selectedIndexCommand = new RelayCommand(() => GetSelectedIndexes());
            }
        }
        private void GetSelectedIndexes()
        {
            SelectedIndexes = DataEmployees.Where(i => i.Properties.IsSelected).Count();

            Messenger.Default.Send<SelectedIndexMessage>(new SelectedIndexMessage
            {
                View = DefinedViews.EmployeeView,
                Index = SelectedIndexes,

            }, MessageType.PropertyChangedMessage);
        }

        public DataEmployee SelectedEmployee { get; set; }
        public List<DataEmployee> SelectedEmployees
        {
            get
            {
                return DataEmployees.Where(i => i.Properties.IsSelected).ToList();
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

        private Boolean hiddenSystemUser;
        public Boolean HiddenSystemUser
        {
            get
            {
                return hiddenSystemUser;
            }

            set
            {
                if (hiddenSystemUser != value)
                {
                    hiddenSystemUser = value;
                    RaisePropertyChanged("HiddenSystemUser");
                }
            }
        }

        public EmployeeViewModel(DataTable dt)
        {
            View = DefinedViews.EmployeeView;

            HiddenSystemUser = true;

            DataEmployees = new ObservableCollection<DataEmployee>();
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
                    Room = row["ROOM"].ToString(),
                    Active = row["ACTIVE"].ToBoolean(),
                    Status = row["ACTIVE"].ToStatus(),
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

        public void RemoveEmployee(string name)
        {
            DataEmployees.Remove(name);
        }

        public void AddBuilding(DataEmployee employee)
        {
            DataEmployees.Add(employee);
        }

        public void UpdateBuilding(DataEmployee employee)
        {
            DataEmployees.Update(SelectedEmployee.Name, employee);
        }
    }
}