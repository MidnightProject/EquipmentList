using System;
using System.Data;
using System.IO;
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
                        break;
                    case DefinedViews.EmployeeView:
                        employeeTable = new DataTable();
                        employeeAdapter.Fill(employeeTable);
                        ViewModel = new EmployeeViewModel(employeeTable);
                        break;
                    case DefinedViews.BuildingView:
                        buildingTable = new DataTable();
                        buildingAdapter.Fill(buildingTable);
                        ViewModel = new BuildingViewModel(buildingTable);
                        break;
                }
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

        private FbDataAdapter buildingAdapter;
        private FbDataAdapter employeeAdapter;
        private DataTable buildingTable;
        private DataTable employeeTable;

        public MainViewModel()
        {
            DatabseToolBar = Visibility.Visible;
            EditToolBar = Visibility.Visible;
            

            string databaseName = Path.Combine(Environment.CurrentDirectory, @"DB\", "EQUIPMENT.FDB");

            FbConnectionStringBuilder stringConnection = new FbConnectionStringBuilder()
            {
                UserID = "SYSDBA",
                Password = "masterkey",
                Database = databaseName,
                DataSource = "localhost",
                Port = 3050,
            };
            

            FbConnection connection = new FbConnection(stringConnection.ToString());
            connection.Open();

            buildingAdapter = new FbDataAdapter("SELECT * FROM BUILDING", connection);
            employeeAdapter = new FbDataAdapter("SELECT * FROM EMPLOYEE", connection);
        }
    }
}