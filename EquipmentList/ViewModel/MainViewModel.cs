using System;
using System.Data;
using System.IO;
using System.Text;
using System.Windows;
using FirebirdSql.Data.FirebirdClient;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using static EquipmentList.Model.Views;

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

                switch (value)
                {
                    case DefinedViews.EquipmentView:
                        ViewModel = null;
                        break;
                    case DefinedViews.EmployeeView:
                        employeeExtendedTable = new DataTable();
                        employeeExtendedAdapter.Fill(employeeExtendedTable);
                        ViewModel = null;
                        ViewModel = new EmployeeViewModel(employeeExtendedTable);
                        ((EmployeeViewModel)ViewModel).ColumnStatusFilter = "Enabled";
                        break;
                    case DefinedViews.BuildingView:
                        buildingTable = new DataTable();
                        buildingAdapter.Fill(buildingTable);
                        ViewModel = null;
                        ViewModel = new BuildingViewModel(buildingTable);
                        break;
                }

                RaisePropertyChanged("Group");              
                GroupIndex = GroupIndex;
                HiddenUserSystem = HiddenUserSystem;
            }
        }

        private RelayCommand<string> viewCommand;
        public RelayCommand<string> ViewCommand
        {
            get
            {
                return viewCommand = new RelayCommand<string>((pararameters) => ChangeView(pararameters));
            }
        }
        private void ChangeView(string pararameters)
        {
            switch (pararameters)
            {
                case "EquipmentView":
                    View = DefinedViews.EquipmentView;
                    break;
                case "EmployeeView":
                    View = DefinedViews.EmployeeView;
                    break;
                case "BuildingView":
                    View = DefinedViews.BuildingView;
                    break;
            }
        }

        private Visibility databseToolBar;
        public Visibility DatabseToolBar
        {
            get
            {
                return databseToolBar;
            }

            set
            {
                databseToolBar = value;
                RaisePropertyChanged("DatabseToolBar");
            }
        }

        private Visibility editToolBar;
        public Visibility EditToolBar
        {
            get
            {
                return editToolBar;
            }

            set
            {
                editToolBar = value;
                RaisePropertyChanged("EditToolBar");
            }
        }

        private Boolean hiddenUserSystem;
        public Boolean HiddenUserSystem
        {
            get
            {
                return hiddenUserSystem;
            }

            set
            {
                hiddenUserSystem = value;
                RaisePropertyChanged("HiddenUserSystem");

                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        ((EmployeeViewModel)ViewModel).HiddenSystemUser = value;
                        break;
                }
            }
        }

        private static String[] groupEmployee = new String[] {  String.Empty,
                                                                "Name",
                                                                "Job title",
                                                                "Building",
                                                                "Status", };

        private static String[] groupBuilding = new String[] {  String.Empty,
                                                                "Country",
                                                                "City", };
        public String[] Group
        {
            get
            {
                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        return groupEmployee;
                    case DefinedViews.BuildingView:
                        return groupBuilding;
                    default:
                        return new string[] { };
                }
            }
        }

        private int groupEmployeeIndex;
        public int GroupIndex
        {
            get
            {
                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        return groupEmployeeIndex;
                    default:
                        return 0;
                }
            }

            set
            {
                if (value == -1)
                {
                    return;
                }

                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        groupEmployeeIndex = value;
                        ((EmployeeViewModel)ViewModel).Group = groupEmployee[groupEmployeeIndex];
                        ((EmployeeViewModel)ViewModel).SelectedIndex = -1;
                        break;
                }

                RaisePropertyChanged("GroupIndex");
            }
        }

        private FbDataAdapter buildingAdapter;
        private DataTable buildingTable;

        //private FbDataAdapter employeeAdapter;
        //private DataTable employeeTable;

        private FbDataAdapter employeeExtendedAdapter;
        private DataTable employeeExtendedTable;

        public MainViewModel()
        {
            DatabseToolBar = Visibility.Visible;
            EditToolBar = Visibility.Visible;
            

            string databaseName = Path.Combine(Environment.CurrentDirectory, @"DB\", "EQUIPMENT.FDB");

            FbConnectionStringBuilder stringConnection = new FbConnectionStringBuilder()
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                //UserID = "Admin",
                //Password = "0f8fad5b-d9cb-469f-a165-70867728950e",
                Database = databaseName,
                DataSource = "localhost",
                Port = 3050,
            };
            

            FbConnection connection = new FbConnection(stringConnection.ToString());
            connection.Open();

            buildingAdapter = new FbDataAdapter("SELECT * FROM BUILDING", connection);
            employeeExtendedTable = new DataTable();
            
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append("EMPLOYEE.NAME, EMPLOYEE.JOB, EMPLOYEE.PHONE, EMPLOYEE.EMAIL, EMPLOYEE.BUILDING, EMPLOYEE.ROOM, ");
                sb.Append("BUILDING.COUNTRY, BUILDING.CITY, BUILDING.ADDRESS, BUILDING.POSTCODE, ");
                sb.Append("PERMISSIONS.ACTIVE, PERMISSIONS.ADD_USER, PERMISSIONS.EDIT_USER, PERMISSIONS.DELETE_USER, PERMISSIONS.ADD_OWN_EQUIPMENT, PERMISSIONS.DELETE_OWN_EQUIPMENT, PERMISSIONS.ADD_OTHER_EQUIPMENT, PERMISSIONS.DELETE_OTHER_EQUIPMENT, PERMISSIONS.VIEW_OTHER_EQUIPMENT, PERMISSIONS.EDIT_OTHER_EQUIPMENT, PERMISSIONS.PRINT_USER, PERMISSIONS.PRINT_OTHER_EQUIPMENT ");
                sb.Append("FROM EMPLOYEE LEFT JOIN BUILDING ON EMPLOYEE.BUILDING = BUILDING.NAME LEFT JOIN PERMISSIONS ON EMPLOYEE.ID = PERMISSIONS.ID ");

                employeeExtendedAdapter = new FbDataAdapter(sb.ToString(), connection);
                employeeExtendedAdapter.Fill(employeeExtendedTable);
            }
            catch (Exception e)
            {

            }
          
        }
    }
}