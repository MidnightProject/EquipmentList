using GalaSoft.MvvmLight;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataBuilding : ViewModelBase
    {
        private string name;
        public string Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        private string address;
        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
                RaisePropertyChanged("Address");
            }
        }
        public string Postcode { get; set; }
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
