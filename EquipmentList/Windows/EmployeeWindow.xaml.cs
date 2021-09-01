using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Clipboard = EquipmentList.Model.Clipboard;

namespace EquipmentList.Windows
{
    public partial class EmployeeWindow : Window
    {
        public List<string> StatusList { get { return new List<string>() { "ENABLED", "DISABLED" }; } }
        public ObservableCollection<string> JobTitleList { get; set; }
        public ObservableCollection<string> BuildingsList { get; set; }

        public DataEmployee Employee { get; set; }
        public string OldName { get; set; }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                if (status != value)
                {
                    status = value;

                    if (status == "ENABLED")
                    {
                        Employee.Active = true;
                    }
                    else
                    {
                        Employee.Active = false;
                    }
                }
            }
        }

        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public EmployeeWindow(DataEmployee employee, ObservableCollection<string> jobTitles, ObservableCollection<string> buildingsNames, Clipboard clipboard, string title, string buttonOKText)
        {
            Employee = new DataEmployee();
            OldName = Employee.Name;

            InitializeComponent();
            DataContext = this;

            TitleText = title;
            ButtonOKText = buttonOKText;

            Status = "ENABLED";

            BuildingsList = buildingsNames;
            BuildingsList.Insert(0, String.Empty);

            JobTitleList = jobTitles;
            JobTitleList.Insert(0, String.Empty);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(nameTextBox);

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                nameTextBox.SelectAll();
            }));
        }

        private RelayCommand button_OK;
        public RelayCommand Button_OK
        {
            get
            {
                return button_OK = new RelayCommand(() => Click_OK());
            }
        }
        private void Click_OK()
        {
            Result = MessageBoxResult.OK;
            this.Close();
        }

        private RelayCommand button_Cancel;
        public RelayCommand Button_Cancel
        {
            get
            {
                return button_Cancel = new RelayCommand(() => Click_Cancel());
            }
        }
        private void Click_Cancel()
        {
            Result = MessageBoxResult.Cancel;
            this.Close();
        }
    }
}
