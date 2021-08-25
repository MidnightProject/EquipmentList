using EquipmentList.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace EquipmentList.Windows
{
    public partial class BuildingWindow : Window
    {
        public ObservableCollection<string> BuildingsNamesList { get; set; }

        public MessageBoxResult Result { get; set; }

        public string TitleText { get; set; }
        public string ButtonOKText { get; set; }

        public DataBuilding Building { get; set; }

        public BuildingWindow(DataBuilding building, string title, string buttonOKText)
        {
            InitializeComponent();
            DataContext = this;

            Building = building;

            if (String.IsNullOrEmpty(Building.Name))
            {
                Building.Name = "Add new bulding";
            }

            TitleText = title;
            ButtonOKText = buttonOKText;
            
            BuildingsNamesList = new ObservableCollection<string>() { "Gliwice", "TEST" };
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
            
        }
    } 
}
