using EquipmentList.Helpers;
using GalaSoft.MvvmLight;
using System;

namespace EquipmentList.Model 
{
    public class DataContractor : ViewModelBase
    {
        public Properties Properties { get; set; }

        public DataPerson Person { get; set; }
        public DataBuilding Building { get; set; }

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
                    name = value.TrimStartString();
                    RaisePropertyChanged("Name");
                }
            }
        }

        private string www;
        public string WWW
        {
            get
            {
                return www;
            }

            set
            {
                if (www != value)
                {
                    www = value.TrimStartString();
                    RaisePropertyChanged("WWW");
                }
            }
        }

        public DataContractor()
        {
            Properties = new Properties();

            Person = new DataPerson();
            Building = new DataBuilding();

            Name = String.Empty;
            WWW = String.Empty; 
        }
    }
}
