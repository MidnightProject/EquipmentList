using EquipmentList.Helpers;
using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Clipboard = EquipmentList.Model.Clipboard;

namespace EquipmentList.Windows
{
    public partial class BuildingWindow : Window
    {
        public ObservableCollection<string> BuildingsNames { get; set; }

        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public DataBuilding Building { get; set; }
        public string OldName { get; set; }
        public Boolean NameIsEnabled { get; set; }

        public Clipboard Clipboard { get; set; }

        public BuildingWindow(DataBuilding building, ObservableCollection<string> buildingsNames, Clipboard clipboard, string title, string buttonOKText)
        {
            Building = building;
            OldName = Building.Name;

            InitializeComponent();
            DataContext = this;

            if (Building.Name == "[...]")
            {
                NameIsEnabled = false;
            }
            else
            {
                NameIsEnabled = true;
            }

            Clipboard = clipboard;

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
            Clipboard.Building.Address = Building.Address;
            Clipboard.Building.City = Building.City;
            Clipboard.Building.Postcode = Building.Postcode;
            Clipboard.Building.Country = Building.Country;
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
            Building.Address = Clipboard.Building.Address.IsNullGetEmpty();
            Building.City = Clipboard.Building.City.IsNullGetEmpty();
            Building.Postcode = Clipboard.Building.Postcode.IsNullGetEmpty();
            Building.Country = Clipboard.Building.Country.IsNullGetEmpty();
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
