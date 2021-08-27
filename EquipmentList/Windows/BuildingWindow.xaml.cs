using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace EquipmentList.Windows
{
    public partial class BuildingWindow : Window
    {
        public ObservableCollection<string> BuildingsNames { get; set; }

        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public DataBuilding Building { get; set; }

        public DataBuilding BuildingClipboard { get; set; }

        public BuildingWindow(DataBuilding building, ObservableCollection<string> buildingsNames, DataBuilding buildingClipboard, string title, string buttonOKText)
        {
            InitializeComponent();
            DataContext = this;

            Building = building;

            if (String.IsNullOrEmpty(Building.Name))
            {
                Building.Name = "Add new bulding";
            }

            BuildingClipboard = buildingClipboard;

            TitleText = title;
            ButtonOKText = buttonOKText;

            BuildingsNames = buildingsNames;
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

        private RelayCommand copyAddressCommand;
        public RelayCommand CopyAddressCommand
        {
            get
            {
                return copyAddressCommand = new RelayCommand(() => CopyAddress());
            }
        }
        private void CopyAddress()
        {
            if (String.IsNullOrEmpty(Building.Address))
            {
                BuildingClipboard.Address = String.Empty;
            }
            else
            {
                BuildingClipboard.Address = Building.Address;
            }

            if (String.IsNullOrEmpty(Building.City))
            {
                BuildingClipboard.City = String.Empty;
            }
            else
            {
                BuildingClipboard.City = Building.City;
            }

            if (String.IsNullOrEmpty(Building.Postcode))
            {
                BuildingClipboard.Postcode = String.Empty;
            }
            else
            {
                BuildingClipboard.Postcode = Building.Postcode;
            }

            if (String.IsNullOrEmpty(Building.Country))
            {
                BuildingClipboard.Country = String.Empty;
            }
            else
            {
                BuildingClipboard.Country = Building.Country;
            }
        }

        private RelayCommand pasteAddressCommand;
        public RelayCommand PasteAddressCommand
        {
            get
            {
                return pasteAddressCommand = new RelayCommand(() => PasteAddress());
            }
        }
        private void PasteAddress()
        {
            Building.Address = BuildingClipboard.Address;
            Building.City = BuildingClipboard.City;
            Building.Postcode = BuildingClipboard.Postcode;
            Building.Country = BuildingClipboard.Country;
        }

        private RelayCommand clearAddressCommand;
        public RelayCommand ClearAddressCommand
        {
            get
            {
                return clearAddressCommand = new RelayCommand(() => ClearAddress());
            }
        }
        private void ClearAddress()
        {
            Building.Address = String.Empty;
            Building.City = String.Empty;
            Building.Postcode = String.Empty;
            Building.Country = String.Empty;
        }
    } 
}
