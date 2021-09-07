using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using static EquipmentList.View.Views;

namespace EquipmentList.ViewModel
{
    public class BuildingViewModel : ViewModelBase
    {
        private ObservableCollection<DataBuilding> dataBuildings;
        public ObservableCollection<DataBuilding> DataBuildings
        {
            get
            {
                return dataBuildings;
            }

            set
            {
                dataBuildings = value;
                RaisePropertyChanged("DataBuildings");
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    RaisePropertyChanged("SelectedIndex");
                }
            }
        }

        public int SelectedIndexes { get; set; }

        private RelayCommand selectedIndexCommand;
        public RelayCommand SelectedIndexCommand
        {
            get
            {
                return selectedIndexCommand = new RelayCommand(() => GetSelectedIndexes());
            }
        }
        private void GetSelectedIndexes()
        {
            SelectedIndexes = DataBuildings.Where(i => i.Properties.IsSelected).Count();

            Messenger.Default.Send<SelectedIndexMessage>(new SelectedIndexMessage
            {
                View = DefinedViews.BuildingView,
                Index = SelectedIndexes,

            }, MessageType.PropertyChangedMessage);
        }

        public DataBuilding SelectedBuilding { get; set; }
        public List<DataBuilding> SelectedBuildins
        {
            get
            {
                return DataBuildings.Where(i => i.Properties.IsSelected).ToList();
            }
        }

        private string group;
        public string Group
        {
            get
            {
                return group;
            }

            set
            {
                switch (value)
                {
                    case "Country":
                        group = "COUNTRY";
                        break;
                    case "City":
                        group = "CITY";
                        break;
                    default:
                        group = String.Empty;
                        break;
                }

                RaisePropertyChanged("Group");
            }
        }

        public BuildingViewModel(DataTable dt)
        {
            DataBuildings = new ObservableCollection<DataBuilding>();
            foreach (DataRow row in dt.Rows)
            {
                DataBuildings.Add(new DataBuilding()
                {
                    Name = row["NAME"].ToString(),
                    Country = row["COUNTRY"].ToString(),
                    City = row["CITY"].ToString(),
                    Postcode = row["POSTCODE"].ToString(),
                    Address = row["ADDRESS"].ToString(),
                });
            }

        }

        public void RemoveBuilding(string name)
        {
            DataBuildings.Remove(name);
        }

        public void AddBuilding(DataBuilding building)
        {
            DataBuildings.Add(building);
        }

        public void UpdateBuilding(DataBuilding building)
        {
            DataBuildings.Update(SelectedBuilding.Name, building);
        }
    }
}
