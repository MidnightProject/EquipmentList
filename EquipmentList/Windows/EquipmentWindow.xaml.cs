using GalaSoft.MvvmLight.Command;
using System;
using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EquipmentList.Windows
{
    public partial class EquipmentWindow : Window
    {
        private RelayCommand testCommand;
        public RelayCommand TestCommand
        {
            get
            {
                return testCommand = new RelayCommand(null);
            }
        }

        public EquipmentWindow()
        {
            Thread.CurrentThread.CurrentCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy";

            InitializeComponent();
            DataContext = this;
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
                //productionDatePicker.SelectedDate = new DateTime();
                productionDatePicker.Text = string.Empty;
                productionDatePicker.IsDropDownOpen = false;

                return;
            }

            if (warrantyDatePicker.IsDropDownOpen)
            {
                //productionDatePicker.SelectedDate = new DateTime();
                warrantyDatePicker.Text = string.Empty;
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
