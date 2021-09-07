using EquipmentList.Helpers;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataBuilding : ViewModelBase
    {
        public Properties Properties { get; set; }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                if (name != value)
                {
                    name = value.TrimStart();
                    RaisePropertyChanged("Name");
                }   
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
                if (country != value)
                {
                    country = value.TrimStart();
                    RaisePropertyChanged("Country");
                }
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
                if (city != value)
                {
                    city = value.TrimStart();
                    RaisePropertyChanged("City");
                }
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
                if (address != value)
                {
                    address = value.TrimStart();
                    RaisePropertyChanged("Address");
                }    
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
                if (postcode != value)
                {
                    postcode = value.TrimStart();
                    RaisePropertyChanged("Postcode");
                }
            }
        }

        public DataBuilding()
        {
            Properties = new Properties();

            Name = "New bulding";
            Address = String.Empty;
            City = String.Empty;
            Postcode = String.Empty;
            Country = String.Empty;
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

        public static Collection<DataBuilding> Update(this Collection<DataBuilding> colection, string name, DataBuilding dataBuilding)
        {
            var buildingToUpdate = colection.SingleOrDefault(building => building.Name == name);
            if (buildingToUpdate != null)
            {
                buildingToUpdate.Name = dataBuilding.Name.TrimEndString();
                buildingToUpdate.Address = dataBuilding.Address.TrimEndString();
                buildingToUpdate.City = dataBuilding.City.TrimEndString();
                buildingToUpdate.Postcode = dataBuilding.Postcode.TrimEndString();
                buildingToUpdate.Country = dataBuilding.Country.TrimEndString();
            }

            return colection;
        }

        public static DataBuilding Values(this List<DataBuilding> colection)
        {
            DataBuilding dataBuilding = new DataBuilding();

            if (colection.IsSameValue(i => i.Name))
            {
                dataBuilding.Name = colection[0].Name;
            }
            else
            {
                dataBuilding.Name = "[...]";
            }

            if (colection.IsSameValue(i => i.Address))
            {
                dataBuilding.Address = colection[0].Address;
            }
            else
            {
                dataBuilding.Address = "[...]";
            }

            if (colection.IsSameValue(i => i.Postcode))
            {
                dataBuilding.Postcode = colection[0].Postcode;
            }
            else
            {
                dataBuilding.Postcode = "[...]";
            }

            if (colection.IsSameValue(i => i.City))
            {
                dataBuilding.City = colection[0].City;
            }
            else
            {
                dataBuilding.City = "[...]";
            }

            if (colection.IsSameValue(i => i.Country))
            {
                dataBuilding.Country = colection[0].Country;
            }
            else
            {
                dataBuilding.Country = "[...]";
            }

            return dataBuilding;
        }
    }
}
