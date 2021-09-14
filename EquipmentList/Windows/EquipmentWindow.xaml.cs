using EquipmentList.Model;
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

namespace EquipmentList.Windows
{
    public partial class EquipmentWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<string> EquipmentsNames { get; set; }

        public DataEquipment Equipment { get; set; }
        public string OldID { get; set; }
        public Boolean IDIsEnabled { get; set; }

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
                }
                else if (value == new DateTime())
                {
                    WatermarkProductionDate = "N/A";
                    productionDate = null;
                }
                else
                {
                    WatermarkProductionDate = "N/A";
                    productionDate = value;
                }               
            }
        }

        public EquipmentWindow(DataEquipment equipment)
        {
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";
                        
            Equipment = equipment;
            OldID = Equipment.ID;

            InitializeComponent();
            DataContext = this;

            if (Equipment.ID == "[...]")
            {
                IDIsEnabled = false;
            }
            else
            {
                IDIsEnabled = true;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(indexTextBox);

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                indexTextBox.SelectAll();
            }));
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
                //productionDatePicker.Text = string.Empty;
                productionDatePicker.IsDropDownOpen = false;

                return;
            }

            if (warrantyDatePicker.IsDropDownOpen)
            {
                productionDatePicker.SelectedDate = new DateTime();
                //warrantyDatePicker.Text = string.Empty;
                warrantyDatePicker.IsDropDownOpen = false;

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
        }
    }
}
