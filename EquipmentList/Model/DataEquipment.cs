using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight;

namespace EquipmentList.Model 
{
    public class DataEquipment : ViewModelBase
    {
        private string id;
        public string ID
        {
            get
            {
                return id;
            }

            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged("ID");
                }
            }
        }

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
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        private string sn;
        public string SN
        {
            get
            {
                return sn;
            }

            set
            {
                if (sn != value)
                {
                    sn = value;
                    RaisePropertyChanged("SN");
                }
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
                if (group != value)
                {
                    group = value;
                    RaisePropertyChanged("Group");
                }
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged("Description");
                }
            }
        }

        private string comments;
        public string Comments
        {
            get
            {
                return comments;
            }

            set
            {
                if (comments != value)
                {
                    comments = value;
                    RaisePropertyChanged("Comments");
                }
            }
        }

        private string room;
        public string Room
        {
            get
            {
                return room;
            }

            set
            {
                if (room != value)
                {
                    room = value;
                    RaisePropertyChanged("Room");
                }
            }
        }

        private string building;
        public string Building
        {
            get
            {
                return building;
            }

            set
            {
                if (building != value)
                {
                    building = value;
                    RaisePropertyChanged("Building");
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
                    country = value;
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
                    city = value;
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
                    address = value;
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
                    postcode = value;
                    RaisePropertyChanged("Postcode");
                }
            }
        }

        private string condition;
        public string Condition
        {
            get
            {
                return condition;
            }

            set
            {
                if (condition != value)
                {
                    condition = value;
                    RaisePropertyChanged("Condition");
                }
            }
        }

        private string norm;
        public string Norm
        {
            get
            {
                return norm;
            }

            set
            {
                if (norm != value)
                {
                    norm = value;
                    RaisePropertyChanged("Norm");
                }
            }
        }


        private string certificationNumber;
        public string CertificationNumber
        {
            get
            {
                return certificationNumber;
            }

            set
            {
                if (certificationNumber != value)
                {
                    certificationNumber = value;
                    RaisePropertyChanged("CertificationNumber");
                }
            }
        }

        private string employeeName;
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }

            set
            {
                if (employeeName != value)
                {
                    employeeName = value;
                    RaisePropertyChanged("EmployeeName");
                }
            }
        }

        private string employeeRoom;
        public string EmployeeRoom
        {
            get
            {
                return employeeRoom;
            }

            set
            {
                if (employeeRoom != value)
                {
                    employeeRoom = value;
                    RaisePropertyChanged("EmployeeRoom");
                }
            }
        }

        private string employeePhone;
        public string EmployeePhone
        {
            get
            {
                return employeePhone;
            }

            set
            {
                if (employeePhone != value)
                {
                    employeePhone = value;
                    RaisePropertyChanged("EmployeePhone");
                }
            }
        }

        private string employeeEmail;
        public string EmployeeEmail
        {
            get
            {
                return employeeEmail;
            }

            set
            {
                if (employeeEmail != value)
                {
                    employeeEmail = value;
                    RaisePropertyChanged("EmployeeEmail");
                }
            }
        }

        private string employeeBuilding;
        public string EmployeeBuilding
        {
            get
            {
                return employeeBuilding;
            }

            set
            {
                if (employeeBuilding != value)
                {
                    employeeBuilding = value;
                    RaisePropertyChanged("EmployeeBuilding");
                }
            }
        }

        private string employeeBuildingCountry;
        public string EmployeeBuildingCountry
        {
            get
            {
                return employeeBuildingCountry;
            }

            set
            {
                if (employeeBuildingCountry != value)
                {
                    employeeBuildingCountry = value;
                    RaisePropertyChanged("EmployeeBuildingCountry");
                }
            }
        }

        private string employeeBuildingCity;
        public string EmployeeBuildingCity
        {
            get
            {
                return employeeBuildingCity;
            }

            set
            {
                if (employeeBuildingCity != value)
                {
                    employeeBuildingCity = value;
                    RaisePropertyChanged("EmployeeBuildingCity");
                }
            }
        }

        private string employeeBuildingAddress;
        public string EmployeeBuildingAddress
        {
            get
            {
                return employeeBuildingAddress;
            }

            set
            {
                if (employeeBuildingAddress != value)
                {
                    employeeBuildingAddress = value;
                    RaisePropertyChanged("EmployeeBuildingAddress");
                }
            }
        }

        private string employeeBuildingPostcode;
        public string EmployeeBuildingPostcode
        {
            get
            {
                return employeeBuildingPostcode;
            }

            set
            {
                if (employeeBuildingPostcode != value)
                {
                    employeeBuildingPostcode = value;
                    RaisePropertyChanged("EmployeeBuildingPostcode");
                }
            }
        }

        private Boolean employeeActive;
        public Boolean EmployeeActive
        {
            get
            {
                return employeeActive;
            }

            set
            {
                if (employeeActive != value)
                {
                    employeeActive = value;
                    RaisePropertyChanged("EmployeeActive");
                }
            }
        }

        private string employeesName;
        public string EmployeesName
        {
            get
            {
                return employeesName;
            }

            set
            {
                if (employeesName != value)
                {
                    employeesName = value;
                    RaisePropertyChanged("EmployeesName");
                }
            }
        }
        public string PostedWorkerName { get; set; }

        public string ProducerName { get; set; }
        public string ProducerPerson { get; set; }
        public string ProducerPhone { get; set; }
        public string ProducerEmail { get; set; }
        public string ProducerWWW { get; set; }
        public string ProducerCountry { get; set; }
        public string ProducerCity { get; set; }
        public string ProducerAddress { get; set; }
        public string ProducerPostcode { get; set; }

        public string ProviderName { get; set; }
        public string ProviderPerson { get; set; }
        public string ProviderPhone { get; set; }
        public string ProviderEmail { get; set; }
        public string ProviderWWW { get; set; }
        public string ProviderCountry { get; set; }
        public string ProviderCity { get; set; }
        public string ProviderAddress { get; set; }
        public string ProviderPostcode { get; set; }

        public string ServiceName { get; set; }
        public string ServicePerson { get; set; }
        public string ServicePhone { get; set; }
        public string ServiceEmail { get; set; }
        public string ServiceWWW { get; set; }
        public string ServiceCountry { get; set; }
        public string ServiceCity { get; set; }
        public string ServiceAddress { get; set; }
        public string ServicePostcode { get; set; }

        public string AttestationName { get; set; }
        public string AttestationPerson { get; set; }
        public string AttestationPhone { get; set; }
        public string AttestationEmail { get; set; }
        public string AttestationWWW { get; set; }
        public string AttestationCountry { get; set; }
        public string AttestationCity { get; set; }
        public string AttestationAddress { get; set; }
        public string AttestationPostcode { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime WarrantyDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime LegalizationDate { get; set; }
        public DateTime PostingDate { get; set; }

        public int WarrantyAlarm { get; set; }
        public int ReviewAlarm { get; set; }

        private int legalizationAlarm;
        public int LegalizationAlarm
        {
            get
            {
                return legalizationAlarm;
            }

            set
            {
                if (legalizationAlarm != value)
                {
                    legalizationAlarm = value;
                    RaisePropertyChanged("LegalizationAlarm");
                }
            }
        }

        public DataEquipment()
        {

        }
    }

    public static class DataEquipmentExtensions
    {
        public static DataEquipment GetEquipment(this IList<DataEquipment> list, string name)
        {
            var dataEquipment = list.FirstOrDefault(equipment => equipment.Name == name);

            return dataEquipment;
        }
    }
}
