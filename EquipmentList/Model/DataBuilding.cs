﻿using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataBuilding : ViewModelBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value.TrimStart();
                RaisePropertyChanged("Name");
            }
        }

        private string country;
        public string Country
        {
            get
            {
                return country;
            }

            set
            {
                country = value.TrimStart();
                RaisePropertyChanged("Country");
            }
        }

        private string city;
        public string City
        {
            get
            {
                return city;
            }

            set
            {
                city = value.TrimStart();
                RaisePropertyChanged("City");
            }
        }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value.TrimStart();
                RaisePropertyChanged("Address");
            }
        }

        private string postcode;
        public string Postcode
        {
            get
            {
                return postcode;
            }

            set
            {
                postcode = value.TrimStart();
                RaisePropertyChanged("Postcode");
            }
        }
    }

    public static class DataBuildingExtensions
    {
        public static List<DataBuilding> Remove(this List<DataBuilding> list, string name)
        {
            var buildingToRemove = list.SingleOrDefault(building => building.Name == name);
            if (buildingToRemove != null)
            {
                list.Remove(buildingToRemove);
            }

            return list;
        }

        public static Collection<DataBuilding> Remove(this Collection<DataBuilding> colection, string name)
        {
            var buildingToRemove = colection.SingleOrDefault(building => building.Name == name);
            if (buildingToRemove != null)
            {
                colection.Remove(buildingToRemove);
            }

            return colection;
        }

        public static ICollection<DataBuilding> Remove(this ICollection<DataBuilding> colection, string name)
        {
            var buildingToRemove = colection.SingleOrDefault(building => building.Name == name);
            if (buildingToRemove != null)
            {
                colection.Remove(buildingToRemove);
            }

            return colection;
        }
    }
}
