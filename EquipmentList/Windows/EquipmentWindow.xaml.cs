using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using WpfMessageBoxLibrary;
using Clipboard = EquipmentList.Model.Clipboard;

namespace EquipmentList.Windows
{
    public partial class EquipmentWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> EquipmentsIDList { get; set; }
        public ObservableCollection<string> ConditionsList { get; set; }
        public ObservableCollection<string> ContractorsList { get; set; }
        public ObservableCollection<string> GroupsList { get; set; }
        public ObservableCollection<string> NormsList { get; set; }
        public ObservableCollection<string> BuildingsList { get; set; }
        public Model.Employee EmployeesList { get; set; }
        public ObservableCollection<string> EmployeesNamesList { get; set; }

        public DataEquipment Equipment { get; set; }
        public Boolean IDIsEnabled { get; set; }

        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public Clipboard Clipboard { get; set; }


        public string AssignedEmployee
        {
            get
            {
                int index = EmployeesList.ID.IndexOf(Equipment.Employee.ID);

                if (index != -1)
                {
                    return EmployeesList.Name[index];
                }

                return String.Empty;
            }

            set
            {
                int index = EmployeesList.Name.IndexOf(value);

                Equipment.Employee.ID = EmployeesList.ID[index];
            }
        }

        public string PostedWorker
        {
            get
            {
                int index = EmployeesList.ID.IndexOf(Equipment.PostedWorker.ID);

                if (index != -1)
                {
                    return EmployeesList.Name[index];
                }

                return String.Empty;
            }

            set
            {
                int index = EmployeesList.Name.IndexOf(value);

                Equipment.PostedWorker.ID = EmployeesList.ID[index];
            }
        }

        private string watermarkProductionDate;
        public string WatermarkProductionDate
        {
            get
            {
                return watermarkProductionDate;
            }

            set
            {
                watermarkProductionDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? productionDate;
        public DateTime? ProductionDate
        {
            get
            {
                return productionDate;
            }

            set
            {
                if (value == null)
                {
                    WatermarkProductionDate = "[...]";
                    productionDate = null;
                    Equipment.ProductionDate = null;
                }
                else if (value == new DateTime())
                {
                    WatermarkProductionDate = "N/A";
                    productionDate = null;
                    Equipment.ProductionDate = new DateTime();
                }
                else
                {
                    WatermarkProductionDate = "N/A";
                    productionDate = value;
                    Equipment.ProductionDate = value;
                }               
            }
        }

        private string watermarkWarrantyDate;
        public string WatermarkWarrantyDate
        {
            get
            {
                return watermarkWarrantyDate;
            }

            set
            {
                watermarkWarrantyDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? warrantyDate;
        public DateTime? WarrantyDate
        {
            get
            {
                return warrantyDate;
            }

            set
            {
                if (value == null)
                {
                    WatermarkWarrantyDate = "[...]";
                    warrantyDate = null;
                    Equipment.WarrantyDate = null;
                }
                else if (value == new DateTime())
                {
                    WatermarkWarrantyDate = "N/A";
                    warrantyDate = null;
                    Equipment.WarrantyDate = new DateTime();
                }
                else
                {
                    WatermarkWarrantyDate = "N/A";
                    warrantyDate = value;
                    Equipment.WarrantyDate = value;
                }
            }
        }

        private string watermarkPostingDate;
        public string WatermarkPostingDate
        {
            get
            {
                return watermarkPostingDate;
            }

            set
            {
                watermarkPostingDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? postingDate;
        public DateTime? PostingDate
        {
            get
            {
                return postingDate;
            }

            set
            {
                if (value == null)
                {
                    WatermarkPostingDate = "[...]";
                    postingDate = null;
                    Equipment.PostingDate = null;
                }
                else if (value == new DateTime())
                {
                    WatermarkPostingDate = "N/A";
                    postingDate = null;
                    Equipment.PostingDate = new DateTime();
                }
                else
                {
                    WatermarkPostingDate = "N/A";
                    postingDate = value;
                    Equipment.PostingDate = value;
                }
            }
        }

        private string watermarkReviewDate;
        public string WatermarkReviewDate
        {
            get
            {
                return watermarkReviewDate;
            }

            set
            {
                watermarkReviewDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? reviewDate;
        public DateTime? ReviewDate
        {
            get
            {
                return reviewDate;
            }

            set
            {
                if (value == null)
                {
                    WatermarkReviewDate = "[...]";
                    reviewDate = null;
                    Equipment.ReviewDate = null;
                }
                else if (value == new DateTime())
                {
                    WatermarkReviewDate = "N/A";
                    reviewDate = null;
                    Equipment.ReviewDate = new DateTime();
                }
                else
                {
                    WatermarkReviewDate = "N/A";
                    reviewDate = value;
                    Equipment.ReviewDate = value;
                }
            }
        }

        private string watermarkLegalizationDate;
        public string WatermarkLegalizationDate
        {
            get
            {
                return watermarkLegalizationDate;
            }

            set
            {
                watermarkLegalizationDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime? legalizationDate;
        public DateTime? LegalizationDate
        {
            get
            {
                return legalizationDate;
            }

            set
            {
                if (value == null)
                {
                    WatermarkLegalizationDate = "[...]";
                    legalizationDate = null;
                    Equipment.LegalizationDate = null;
                }
                else if (value == new DateTime())
                {
                    WatermarkLegalizationDate = "N/A";
                    legalizationDate = null;
                    Equipment.LegalizationDate = new DateTime();
                }
                else
                {
                    WatermarkLegalizationDate = "N/A";
                    legalizationDate = value;
                    Equipment.LegalizationDate = value;
                }
            }
        }

        public EquipmentWindow(DataEquipment equipment, ObservableCollection<string> equipmentsID, ObservableCollection<string> condition,
                                ObservableCollection<string> contractor, ObservableCollection<string> group, ObservableCollection<string> norm,
                                ObservableCollection<string> building, Model.Employee employee, Clipboard clipboard, string title, string buttonOKText)
        {
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            Equipment = equipment;

            InitializeComponent();
            DataContext = this;

            Clipboard = clipboard;

            TitleText = title;
            ButtonOKText = buttonOKText;

            if (Equipment.ID == "[...]")
            {
                IDIsEnabled = false;
            }
            else
            {
                IDIsEnabled = true;
            }

            EquipmentsIDList = equipmentsID;

            ConditionsList = condition;
            ConditionsList.Insert(0, String.Empty);

            ContractorsList = contractor;
            ContractorsList.Insert(0, String.Empty);

            GroupsList = group;
            GroupsList.Insert(0, String.Empty);

            NormsList = norm;
            NormsList.Insert(0, String.Empty);

            BuildingsList = building;
            BuildingsList.Insert(0, String.Empty);

            ProductionDate = Equipment.ProductionDate;
            WarrantyDate = Equipment.WarrantyDate;
            PostingDate = Equipment.PostingDate;
            ReviewDate = Equipment.ReviewDate;
            LegalizationDate = Equipment.LegalizationDate;

            EmployeesList = employee;

            Messenger.Default.Register<EditDatabaseMessage>(this, MessageType.PropertyChangedMessage, DatabasePropertyChanged);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(indexTextBox);

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                indexTextBox.SelectAll();
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

        private RelayCommand naDateCommand;
        public RelayCommand NADateCommand
        {
            get
            {
                return naDateCommand = new RelayCommand(() => SetNADate());
            }
        }
        private void SetNADate()
        {
            if (productionDatePicker.IsDropDownOpen)
            {
                productionDatePicker.SelectedDate = new DateTime();
                productionDatePicker.IsDropDownOpen = false;

                return;
            }

            if (warrantyDatePicker.IsDropDownOpen)
            {
                warrantyDatePicker.SelectedDate = new DateTime();
                warrantyDatePicker.IsDropDownOpen = false;

                return;
            }

            if (postingDatePicker.IsDropDownOpen)
            {
                postingDatePicker.SelectedDate = new DateTime();
                postingDatePicker.IsDropDownOpen = false;

                return;
            }

            if (reviewDatePicker.IsDropDownOpen)
            {
                reviewDatePicker.SelectedDate = new DateTime();
                reviewDatePicker.IsDropDownOpen = false;

                return;
            }

            if (legalizationDatePicker.IsDropDownOpen)
            {
                legalizationDatePicker.SelectedDate = new DateTime();
                legalizationDatePicker.IsDropDownOpen = false;

                return;
            }
        }

        private RelayCommand todayDateCommand;
        public RelayCommand TodayDateCommand
        {
            get
            {
                return todayDateCommand = new RelayCommand(() => SetTodayDate());
            }
        }
        private void SetTodayDate()
        {
            if (productionDatePicker.IsDropDownOpen)
            {
                productionDatePicker.SelectedDate = DateTime.Today;
                productionDatePicker.IsDropDownOpen = false;

                return;
            }

            if (warrantyDatePicker.IsDropDownOpen)
            {
                warrantyDatePicker.SelectedDate = DateTime.Today;
                warrantyDatePicker.IsDropDownOpen = false;

                return;
            }

            if (postingDatePicker.IsDropDownOpen)
            {
                postingDatePicker.SelectedDate = DateTime.Today;
                postingDatePicker.IsDropDownOpen = false;

                return;
            }

            if (reviewDatePicker.IsDropDownOpen)
            {
                reviewDatePicker.SelectedDate = DateTime.Today;
                reviewDatePicker.IsDropDownOpen = false;

                return;
            }

            if (legalizationDatePicker.IsDropDownOpen)
            {
                legalizationDatePicker.SelectedDate = DateTime.Today;
                legalizationDatePicker.IsDropDownOpen = false;

                return;
            }
        }

        private RelayCommand<string> groupCommand;
        public RelayCommand<string> GroupCommand
        {
            get
            {
                return groupCommand = new RelayCommand<string>((pararameters) => GroupAction(pararameters));
            }
        }
        private void GroupAction(string pararameters)
        {
            switch (pararameters)
            {
                case "Add":
                    AddGroup();
                    break;
                case "Remove":
                    RemoveGroup();
                    break;
                case "Edit":
                    EditGroup();
                    break;
            }
        }
        private void AddGroup()
        {
            WpfMessageBox messageBox = new WpfMessageBox("Add group name", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = "New group name",
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = GroupsList.ToList(),

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
                    Table = TableType.Group,
                    Command = CommandType.Insert,
                    Value = messageBox.TextBoxText,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void RemoveGroup()
        {
            if (Equipment.Group == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
            {
                Header = "Remove '" + Equipment.Group + "' group name ?",
                ButtonYesText = "Yes, remove group name",
                ButtonNoText = "Cancel, keep group name",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.Yes)
            {
                Messenger.Default.Send<EditDatabaseMessage>(new EditDatabaseMessage
                {
                    Table = TableType.Group,
                    Command = CommandType.Delete,
                    Value = Equipment.Group,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void EditGroup()
        {
            if (Equipment.Group == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Edit group name", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = Equipment.Group,
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = GroupsList.ToList(),

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
                    Table = TableType.Group,
                    Command = CommandType.Update,
                    Value = messageBox.TextBoxText,
                    OldValue = Equipment.Group,

                }, MessageType.NotificationMessageAction);
            }
        }

        private RelayCommand<string> conditionCommand;
        public RelayCommand<string> ConditionCommand
        {
            get
            {
                return conditionCommand = new RelayCommand<string>((pararameters) => ConditionAction(pararameters));
            }
        }
        private void ConditionAction(string pararameters)
        {
            switch (pararameters)
            {
                case "Add":
                    AddCondition();
                    break;
                case "Remove":
                    RemoveCondition();
                    break;
                case "Edit":
                    EditCondition();
                    break;
            }
        }
        private void AddCondition()
        {
            WpfMessageBox messageBox = new WpfMessageBox("Add condition", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = "New condition",
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = ConditionsList.ToList(),

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
                    Table = TableType.Condition,
                    Command = CommandType.Insert,
                    Value = messageBox.TextBoxText,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void RemoveCondition()
        {
            if (Equipment.Condition == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Information", "Warning: this cannot be undone.", MessageBoxButton.YesNo, MessageBoxImage.Information, new WpfMessageBoxProperties()
            {
                Header = "Remove '" + Equipment.Condition + "' condition ?",
                ButtonYesText = "Yes, remove condition",
                ButtonNoText = "Cancel, keep condition",
            });
            messageBox.ShowDialog();

            if (messageBox.Result == WpfMessageBoxResult.Yes)
            {
                Messenger.Default.Send<EditDatabaseMessage>(new EditDatabaseMessage
                {
                    Table = TableType.Condition,
                    Command = CommandType.Delete,
                    Value = Equipment.Condition,

                }, MessageType.NotificationMessageAction);
            }
        }
        private void EditCondition()
        {
            if (Equipment.Condition == String.Empty)
            {
                return;
            }

            WpfMessageBox messageBox = new WpfMessageBox("Edit condition", String.Empty, MessageBoxButton.OKCancel, MessageBoxImage.None, new WpfMessageBoxProperties()
            {
                TextBoxText = Equipment.Condition,
                IsTextBoxVisible = true,
                TextBoxMaxLength = 25,
                TextValidationRule = new Validation()
                {
                    TextExclusionList = GroupsList.ToList(),

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
                    Table = TableType.Condition,
                    Command = CommandType.Update,
                    Value = messageBox.TextBoxText,
                    OldValue = Equipment.Condition,

                }, MessageType.NotificationMessageAction);
            }
        }

        private void DatabasePropertyChanged(EditDatabaseMessage message)
        {
            if (message.Table == TableType.Group)
            {
                switch (message.Command)
                {
                    case CommandType.Insert:
                        GroupsList.Add(message.Value);
                        Equipment.Group = message.Value;
                        break;
                    case CommandType.Delete:
                        GroupsList.Remove(message.Value);
                        Equipment.Group = String.Empty;
                        break;
                    case CommandType.Update:
                        GroupsList.Remove(message.OldValue);
                        GroupsList.Add(message.Value);
                        Equipment.Group = message.Value;
                        break;
                }

                return;  
            }

            if (message.Table == TableType.Condition)
            {
                switch (message.Command)
                {
                    case CommandType.Insert:
                        ConditionsList.Add(message.Value);
                        Equipment.Condition = message.Value;
                        break;
                    case CommandType.Delete:
                        ConditionsList.Remove(message.Value);
                        Equipment.Condition = String.Empty;
                        break;
                    case CommandType.Update:
                        ConditionsList.Remove(message.OldValue);
                        ConditionsList.Add(message.Value);
                        Equipment.Condition = message.Value;
                        break;
                }

                return;
            }
        }

        private void reviewAlarmText_GotFocus(object sender, RoutedEventArgs e)
        {
            reviewAlarmText.Visibility = Visibility.Collapsed;
            FocusManager.SetFocusedElement(main, reviewAlarmUpDonw); 
        }

        private void reviewAlarm_GotFocus(object sender, RoutedEventArgs e)
        {
            reviewAlarmText.Visibility = Visibility.Collapsed;
        }

        private void legalizationAlarmText_GotFocus(object sender, RoutedEventArgs e)
        {
            legalizationAlarmText.Visibility = Visibility.Collapsed;
            FocusManager.SetFocusedElement(main, legalizationAlarmUpDonw);
        }

        private void legalizationAlarm_GotFocus(object sender, RoutedEventArgs e)
        {
            legalizationAlarmText.Visibility = Visibility.Collapsed;
        }

        private void warrantyAlarmText_GotFocus(object sender, RoutedEventArgs e)
        {
            warrantyAlarmText.Visibility = Visibility.Collapsed;
            FocusManager.SetFocusedElement(main, warrantyAlarmUpDonw);
        }

        private void warrantyAlarm_GotFocus(object sender, RoutedEventArgs e)
        {
            warrantyAlarmText.Visibility = Visibility.Collapsed;
        }
    }
}
