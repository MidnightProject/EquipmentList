using EquipmentList.Helpers;
using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfMessageBoxLibrary;
using Clipboard = EquipmentList.Model.Clipboard;

namespace EquipmentList.Windows
{
    public partial class EmployeeWindow : Window
    {
        public ObservableCollection<string> StatusList { get { return new ObservableCollection<string>() { "Enabled", "Disabled" }; } }
        public ObservableCollection<string> JobTitleList { get; set; }
        public ObservableCollection<string> BuildingsList { get; set; }

        public DataEmployee Employee { get; set; }
                
        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public Clipboard Clipboard { get; set; }

        public EmployeeWindow(DataEmployee employee, ObservableCollection<string> jobTitles, ObservableCollection<string> buildingsNames, Clipboard clipboard, string title, string buttonOKText)
        {
            Employee = employee;

            InitializeComponent();
            DataContext = this;

            TitleText = title;
            ButtonOKText = buttonOKText;

            BuildingsList = buildingsNames;
            BuildingsList.Insert(0, String.Empty);

            JobTitleList = jobTitles;
            JobTitleList.Insert(0, String.Empty);

            Clipboard = clipboard;

            Messenger.Default.Register<EditDatabaseMessage>(this, MessageType.PropertyChangedMessage, DatabasePropertyChanged);
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

        private RelayCommand<string> jobCommand;
        public RelayCommand<string> JobCommand
        {
            get
            {
                return jobCommand = new RelayCommand<string>((pararameters) => JobAction(pararameters));
            }
        }
        private void JobAction(string pararameters)
        {
            switch (pararameters)
            {
                case "Add":
                    AddJob();
                    break;
                case "Remove":
                    RemoveJob();
                    break;
                case "Edit":
                    EditJob();
                    break;
            }
        }
        private void AddJob()
        {
            WpfMessageBox messageBox = new WpfMessageBox("Add job title", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = "New job title",
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = JobTitleList.ToList(),

                    Rule = new Rule()
                    {
                        StringIsEmpty = true,
                        StringIsExcluded = true,
                        StringIsWhiteSpace = true,
                        IgnoreCase = true,
                    },
                },

                ButtonOkText = "Add",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.OK)
            {
                Messenger.Default.Send<EditDatabaseMessage>(new EditDatabaseMessage
                {
                    Table = TableType.Job,
                    Command = CommandType.Insert,
                    Value = messageBox.TextBoxText,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void RemoveJob()
        {
            if (Employee.Job == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
            {
                Header = "Remove '" + Employee.Job + "' job title ?",
                ButtonYesText = "Yes, remove job title",
                ButtonNoText = "Cancel, keep job title",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.Yes)
            {
                Messenger.Default.Send<EditDatabaseMessage>(new EditDatabaseMessage
                {
                    Table = TableType.Job,
                    Command = CommandType.Delete,
                    Value = Employee.Job,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void EditJob()
        {
            if (Employee.Job == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Edit job title", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = Employee.Job,
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = JobTitleList.ToList(),

                    Rule = new Rule()
                    {
                        StringIsEmpty = true,
                        StringIsExcluded = true,
                        StringIsWhiteSpace = true,
                        IgnoreCase = true,
                    },
                },

                ButtonOkText = "Edit",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.OK)
            {
                Messenger.Default.Send<EditDatabaseMessage>(new EditDatabaseMessage
                {
                    Table = TableType.Job,
                    Command = CommandType.Update,
                    Value = messageBox.TextBoxText,
                    OldValue = Employee.Job,

                }, MessageType.NotificationMessageAction);
            }
        }

        private void DatabasePropertyChanged(EditDatabaseMessage message)
        {
            if (message.Table == TableType.Job)
            {
                switch (message.Command)
                {
                    case CommandType.Insert:
                        JobTitleList.Add(message.Value);
                        Employee.Job = message.Value;
                        break;
                    case CommandType.Delete:
                        Employee.Job = String.Empty;
                        JobTitleList.Remove(message.Value);
                        break;
                    case CommandType.Update:
                        JobTitleList.Remove(message.OldValue);
                        JobTitleList.Add(message.Value);
                        Employee.Job = message.Value;
                        break;
                }

                return;
            }
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

        private RelayCommand copyEmployeeCommand;
        public RelayCommand CopyEmployeeCommand
        {
            get
            {
                return copyEmployeeCommand = new RelayCommand(() => CopyEmployee());
            }
        }
        private void CopyEmployee()
        {
            Clipboard.Employee.Job = Employee.Job;
            Clipboard.Employee.Building.Name = Employee.Building.Name;
            Clipboard.Employee.Room = Employee.Room;
            Clipboard.Employee.Person.Phone = Employee.Person.Phone;
            Clipboard.Employee.Person.Email = Employee.Person.Email;
        }

        private RelayCommand pasteEmployeeCommand;
        public RelayCommand PasteEmployeeCommand
        {
            get
            {
                return pasteEmployeeCommand = new RelayCommand(() => PasteEmployee());
            }
        }
        private void PasteEmployee()
        {
            Employee.Job = Clipboard.Employee.Job.IsNullGetEmpty();
            Employee.Building.Name = Clipboard.Employee.Building.Name.IsNullGetEmpty();
            Employee.Room = Clipboard.Employee.Room.IsNullGetEmpty();
            Employee.Person.Phone = Clipboard.Employee.Person.Phone.IsNullGetEmpty();
            Employee.Person.Email = Clipboard.Employee.Person.Email.IsNullGetEmpty();
        }

        private RelayCommand clearEmployeeCommand;
        public RelayCommand ClearEmployeeCommand
        {
            get
            {
                return clearEmployeeCommand = new RelayCommand(() => ClearEmployee());
            }
        }
        private void ClearEmployee()
        {
            Employee.Job = String.Empty;
            Employee.Building.Name = String.Empty;
            Employee.Room = String.Empty;
            Employee.Person.Phone = String.Empty;
            Employee.Person.Email = "empty@empty.empty";
            Employee.Person.Email = String.Empty;
        }

        private RelayCommand copyPermissionsCommand;
        public RelayCommand CopyPermissionsCommand
        {
            get
            {
                return copyPermissionsCommand = new RelayCommand(() => CopyPermissions());
            }
        }
        private void CopyPermissions()
        {
            Clipboard.Employee.AddUser = Employee.AddUser;
            Clipboard.Employee.EditUser = Employee.EditUser;
            Clipboard.Employee.DeleteUser = Employee.DeleteUser;
            Clipboard.Employee.PrintUser = Employee.PrintUser;
            Clipboard.Employee.AddOwnEquipment = Employee.AddOwnEquipment;
            Clipboard.Employee.DeleteOwnEquipment = Employee.DeleteOwnEquipment;
            Clipboard.Employee.AddOtherEquipment = Employee.AddOtherEquipment;
            Clipboard.Employee.DeleteOtherEquipment = Employee.DeleteOtherEquipment;
            Clipboard.Employee.EditOtherEquipment = Employee.EditOtherEquipment;
            Clipboard.Employee.ViewOtherEquipment = Employee.ViewOtherEquipment;
            Clipboard.Employee.PrintOtherEquipment = Employee.PrintOtherEquipment;
        }

        private RelayCommand pastePermissionsCommand;
        public RelayCommand PastePermissionsCommand
        {
            get
            {
                return pastePermissionsCommand = new RelayCommand(() => PastePermissions());
            }
        }
        private void PastePermissions()
        {
            Employee.AddUser = Clipboard.Employee.AddUser;
            Employee.EditUser = Clipboard.Employee.EditUser;
            Employee.DeleteUser = Clipboard.Employee.DeleteUser;
            Employee.PrintUser = Clipboard.Employee.PrintUser;
            Employee.AddOwnEquipment = Clipboard.Employee.AddOwnEquipment;
            Employee.DeleteOwnEquipment = Clipboard.Employee.DeleteOwnEquipment;
            Employee.AddOtherEquipment = Clipboard.Employee.AddOtherEquipment;
            Employee.DeleteOtherEquipment = Clipboard.Employee.DeleteOtherEquipment;
            Employee.EditOtherEquipment = Clipboard.Employee.EditOtherEquipment;
            Employee.ViewOtherEquipment = Clipboard.Employee.ViewOtherEquipment;
            Employee.PrintOtherEquipment = Clipboard.Employee.PrintOtherEquipment;
        }

        private RelayCommand clearPermissionsCommand;
        public RelayCommand ClearPermissionsCommand
        {
            get
            {
                return clearPermissionsCommand = new RelayCommand(() => ClearPermissions());
            }
        }
        private void ClearPermissions()
        {
            Employee.AddUser = false;
            Employee.EditUser = false;
            Employee.DeleteUser = false;
            Employee.PrintUser = false;
            Employee.AddOwnEquipment = false;
            Employee.DeleteOwnEquipment = false;
            Employee.AddOtherEquipment = false;
            Employee.DeleteOtherEquipment = false;
            Employee.EditOtherEquipment = false;
            Employee.ViewOtherEquipment = false;
            Employee.PrintOtherEquipment = false;
        }
    }
}
