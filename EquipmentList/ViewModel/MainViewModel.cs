using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using FirebirdSql.Data.FirebirdClient;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using static EquipmentList.View.Views;

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
                        equipmentTable = new DataTable();
                        equipmentAdapter.Fill(equipmentTable);
                        ViewModel = new EquipmentViewModel(equipmentTable);
                        ((EquipmentViewModel)ViewModel).EmployeesName = EmployeesName;
                        break;
                    case DefinedViews.EmployeeView:
                        employeeTable = new DataTable();
                        employeeAdapter.Fill(employeeTable);
                        ViewModel = new EmployeeViewModel(employeeTable);
                        ((EmployeeViewModel)ViewModel).ColumnStatusFilter = "Enabled";
                        break;
                    case DefinedViews.BuildingView:
                        buildingTable = new DataTable();
                        buildingAdapter.Fill(buildingTable);
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

                if (hiddenUserSystem)
                {
                    if (EmployeesName.Contains("Admin"))
                    {
                        EmployeesName.Remove("Admin");
                    }

                    if (EmployeesName.Contains("Guest"))
                    {
                        EmployeesName.Remove("Guest");
                    }
                }
                else
                {
                    if (!EmployeesName.Contains("Admin"))
                    {
                        EmployeesName.Add("Admin");
                    }

                    if (!EmployeesName.Contains("Guest"))
                    {
                        EmployeesName.Add("Guest");
                    }
                }

                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        ((EmployeeViewModel)ViewModel).HiddenSystemUser = value;
                        break;
                    case DefinedViews.EquipmentView:
                        ((EquipmentViewModel)ViewModel).EmployeesName = EmployeesName;
                        break;
                }
            }
        }

        //private List<string> employeesName;
        public List<string> EmployeesName { get; set; }


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
        private int groupBuildingIndex;
        public int GroupIndex
        {
            get
            {
                switch (View)
                {
                    case DefinedViews.EmployeeView:
                        return groupEmployeeIndex;
                    case DefinedViews.BuildingView:
                        return groupBuildingIndex;
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
                    case DefinedViews.BuildingView:
                        groupBuildingIndex = value;
                        ((BuildingViewModel)ViewModel).Group = groupBuilding[groupBuildingIndex];
                        ((BuildingViewModel)ViewModel).SelectedIndex = -1;
                        break;
                }

                RaisePropertyChanged("GroupIndex");
            }
        }

        private FbDataAdapter buildingAdapter;
        private DataTable buildingTable;

        private FbDataAdapter equipmentAdapter;
        private DataTable equipmentTable;

        private FbDataAdapter employeeAdapter;
        private DataTable employeeTable;

        private FbDataAdapter employeeNameAdapter;
        private DataTable employeeNameTable;

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
                Charset = "WIN1250",
            };
            

            FbConnection connection = new FbConnection(stringConnection.ToString());
            connection.Open();

            buildingAdapter = new FbDataAdapter("SELECT * FROM BUILDING", connection);
            employeeAdapter = new FbDataAdapter("SELECT * FROM EMPLOYEEVIEW", connection);
            equipmentAdapter = new FbDataAdapter("SELECT * FROM EQUIPMENTVIEW", connection);
            employeeNameAdapter = new FbDataAdapter("SELECT NAME FROM EMPLOYEE", connection);

            /*
            employeeTable = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append("EMPLOYEE.NAME, EMPLOYEE.JOB, EMPLOYEE.PHONE, EMPLOYEE.EMAIL, EMPLOYEE.BUILDING, EMPLOYEE.ROOM, ");
                sb.Append("BUILDING.COUNTRY, BUILDING.CITY, BUILDING.ADDRESS, BUILDING.POSTCODE, ");
                sb.Append("PERMISSIONS.ACTIVE, PERMISSIONS.ADD_USER, PERMISSIONS.EDIT_USER, PERMISSIONS.DELETE_USER, PERMISSIONS.ADD_OWN_EQUIPMENT, PERMISSIONS.DELETE_OWN_EQUIPMENT, PERMISSIONS.ADD_OTHER_EQUIPMENT, PERMISSIONS.DELETE_OTHER_EQUIPMENT, PERMISSIONS.VIEW_OTHER_EQUIPMENT, PERMISSIONS.EDIT_OTHER_EQUIPMENT, PERMISSIONS.PRINT_USER, PERMISSIONS.PRINT_OTHER_EQUIPMENT ");
                sb.Append("FROM EMPLOYEE ");
                sb.Append("LEFT JOIN BUILDING ON EMPLOYEE.BUILDING = BUILDING.NAME LEFT JOIN PERMISSIONS ON EMPLOYEE.ID = PERMISSIONS.ID ");

                employeeAdapter = new FbDataAdapter(sb.ToString(), connection);
                employeeAdapter.Fill(employeeTable);
            }
            catch (Exception e)
            {

            }
            */
            /*
            equipmentTable = new DataTable();
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("SELECT ");
                sb.Append("EQUIPMENT.ID, EQUIPMENT.NAME, EQUIPMENT.SN, EQUIPMENT.SUBGROUP, EQUIPMENT.EMPLOYEE, EQUIPMENT.DESCRIPTION, EQUIPMENT.ROOM, EQUIPMENT.PRODUCER, EQUIPMENT.BUILDING, EQUIPMENT.PRODUCTION_DATE, EQUIPMENT.WARRANTY_DATE, EQUIPMENT.COMMENTS, EQUIPMENT.LEGALIZATION_DATE, EQUIPMENT.REVIEW_DATE, ");
                sb.Append("EMPLOYEE.NAME AS EMPLOYEE_NAME, EMPLOYEE.ROOM AS EMPLOYEE_ROOM, EMPLOYEE.PHONE AS EMPLOYEE_PHONE, EMPLOYEE.EMAIL AS EMPLOYEE_EMAIL, ");
                sb.Append("EMPLOYEE_BUILDING.NAME AS EMPLOYEE_BUILDING_NAME, EMPLOYEE_BUILDING.COUNTRY AS EMPLOYEE_BUILDING_COUNTRY, EMPLOYEE_BUILDING.CITY AS EMPLOYEE_BUILDING_CITY, EMPLOYEE_BUILDING.ADDRESS AS EMPLOYEE_BUILDING_ADDRESS, EMPLOYEE_BUILDING.POSTCODE AS EMPLOYEE_BUILDING_POSTCODE, ");
                sb.Append("EQUIPMENT_BUILDING.COUNTRY AS EQUIPMENT_BUILDING_COUNTRY, EQUIPMENT_BUILDING.CITY AS EQUIPMENT_BUILDING_CITY, EQUIPMENT_BUILDING.ADDRESS AS EQUIPMENT_BUILDING_ADDRESS, EQUIPMENT_BUILDING.POSTCODE AS EQUIPMENT_BUILDING_POSTCODE ");
                sb.Append("FROM EQUIPMENT ");
                sb.Append("LEFT JOIN EMPLOYEE ON EQUIPMENT.EMPLOYEE = EMPLOYEE.ID ");
                sb.Append("LEFT JOIN BUILDING AS EMPLOYEE_BUILDING ON EMPLOYEE.BUILDING = EMPLOYEE_BUILDING.NAME ");
                sb.Append("LEFT JOIN BUILDING AS EQUIPMENT_BUILDING ON EQUIPMENT.BUILDING = EQUIPMENT_BUILDING.NAME ");

                equipmentAdapter = new FbDataAdapter(sb.ToString(), connection);
                equipmentAdapter.Fill(equipmentTable);
            }
            catch (Exception e)
            {

            }
            */
            /*
            CREATE VIEW EQUIPMENTVIEW
            AS
            SELECT 
            EQUIPMENT.ID, EQUIPMENT."NAME", EQUIPMENT.SN, EQUIPMENT.SUBGROUP, EQUIPMENT.EMPLOYEE, EQUIPMENT.DESCRIPTION, EQUIPMENT.ROOM, EQUIPMENT.PRODUCER, EQUIPMENT.BUILDING, EQUIPMENT.PRODUCTION_DATE, EQUIPMENT.WARRANTY_DATE, EQUIPMENT.COMMENTS, EQUIPMENT.LEGALIZATION_DATE, EQUIPMENT.REVIEW_DATE, 
            EMPLOYEE.NAME AS EMPLOYEE_NAME, EMPLOYEE.ROOM AS EMPLOYEE_ROOM, EMPLOYEE.PHONE AS EMPLOYEE_PHONE, EMPLOYEE.EMAIL AS EMPLOYEE_EMAIL, 
            EMPLOYEE_BUILDING."NAME" AS EMPLOYEE_BUILDING_NAME, EMPLOYEE_BUILDING.COUNTRY AS EMPLOYEE_BUILDING_COUNTRY, EMPLOYEE_BUILDING.CITY AS EMPLOYEE_BUILDING_CITY, EMPLOYEE_BUILDING.ADDRESS AS EMPLOYEE_BUILDING_ADDRESS, EMPLOYEE_BUILDING.POSTCODE AS EMPLOYEE_BUILDING_POSTCODE, 
            EQUIPMENT_BUILDING.COUNTRY AS EQUIPMENT_BUILDING_COUNTRY, EQUIPMENT_BUILDING.CITY AS EQUIPMENT_BUILDING_CITY, EQUIPMENT_BUILDING.ADDRESS AS EQUIPMENT_BUILDING_ADDRESS, EQUIPMENT_BUILDING.POSTCODE AS EQUIPMENT_BUILDING_POSTCODE 
            FROM EQUIPMENT
            LEFT JOIN EMPLOYEE ON EQUIPMENT.EMPLOYEE = EMPLOYEE.ID 
            LEFT JOIN BUILDING AS EMPLOYEE_BUILDING ON EMPLOYEE.BUILDING = EMPLOYEE_BUILDING.NAME 
            LEFT JOIN BUILDING AS EQUIPMENT_BUILDING ON EQUIPMENT.BUILDING = EQUIPMENT_BUILDING.NAME
            LEFT JOIN CONTRACTOR ON EQUIPMENT.PRODUCER = CONTRACTOR."NAME"
            */

            employeeNameTable = new DataTable();
            employeeAdapter.Fill(employeeNameTable);

            EmployeesName = new List<string>();
            EmployeesName.Add(String.Empty);
            foreach (DataRow row in employeeNameTable.Rows)
            {
                EmployeesName.Add(row["NAME"].ToString());
            }


            View = DefinedViews.EquipmentView;
        }
    }
}
 