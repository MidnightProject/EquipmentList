﻿using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
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
        public string OldID { get; set; }
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
            OldID = Equipment.ID;

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
    }
}
