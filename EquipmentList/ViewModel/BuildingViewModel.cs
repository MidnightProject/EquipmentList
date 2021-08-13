using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Data;
using static EquipmentList.View.Views;

namespace EquipmentList.ViewModel
{
    public class BuildingViewModel : ViewModelBase
    {
        private Collection<DataBuilding> dataBuildings;
        public Collection<DataBuilding> DataBuildings
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
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");

                Messenger.Default.Send<SelectedIndexMessage>(new SelectedIndexMessage
                {
                    View = DefinedViews.BuildingView,
                }, MessageType.PropertyChangedMessage);
            }
        }

        private DataBuilding selectedBuilding;
        public DataBuilding SelectedBuilding
        {
            get
            {
                return selectedBuilding;
            }

            set
            {
                selectedBuilding = value;
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
            DataBuildings = new Collection<DataBuilding>();
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
    }
}
