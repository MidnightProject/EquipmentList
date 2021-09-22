using System;
using System.Collections.Generic;
using System.Linq;
using EquipmentList.Helpers;
using GalaSoft.MvvmLight;

namespace EquipmentList.Model 
{
    public class DataEquipment : ViewModelBase
    {
        public Properties Properties { get; set; }

        public DataBuilding Building { get; set; }
        public DataEmployee Employee { get; set; }
        public DataEmployee PostedWorker { get; set; }
        public DataContractor Producer { get; set; }
        public DataContractor Provider { get; set; }
        public DataContractor Service { get; set; }
        public DataContractor Attestation { get; set; }

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
                    id = value.TrimStartString();
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
                    name = value.TrimStartString();
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
                    sn = value.TrimStartString();
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
                    group = value.TrimStartString();
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
                    description = value.TrimStartString();
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
                    comments = value.TrimStartString();
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
                    room = value.TrimStartString();
                    RaisePropertyChanged("Room");
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
                    condition = value.TrimStartString();
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
                    norm = value.TrimStartString();
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
                    certificationNumber = value.TrimStartString();
                    RaisePropertyChanged("CertificationNumber");
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

        private DateTime? productionDate;
        public DateTime? ProductionDate
        {
            get
            {
                return productionDate;
            }

            set
            {
                if (productionDate != value)
                {
                    productionDate = value;
                    RaisePropertyChanged("ProductionDate");
                }
            }
        }

        private DateTime? warrantyDate;
        public DateTime? WarrantyDate
        {
            get
            {
                return warrantyDate;
            }

            set
            {
                if (warrantyDate != value)
                {
                    warrantyDate = value;
                    RaisePropertyChanged("WarrantyDate");
                }
            }
        }

        private DateTime? reviewDate;
        public DateTime? ReviewDate
        {
            get
            {
                return reviewDate;
            }

            set
            {
                if (reviewDate != value)
                {
                    reviewDate = value;
                    RaisePropertyChanged("ReviewDate");
                }
            }
        }

        private DateTime? legalizationDate;
        public DateTime? LegalizationDate
        {
            get
            {
                return legalizationDate;
            }

            set
            {
                if (legalizationDate != value)
                {
                    legalizationDate = value;
                    RaisePropertyChanged("LegalizationDate");
                }
            }
        }

        private DateTime? postingDate;
        public DateTime? PostingDate
        {
            get
            {
                return postingDate;
            }

            set
            {
                if (postingDate != value)
                {
                    postingDate = value;
                    RaisePropertyChanged("PostingDate");
                }
            }
        }

        private int? warrantyAlarm;
        public int? WarrantyAlarm
        {
            get
            {
                return warrantyAlarm;
            }

            set
            {
                if (warrantyAlarm != value)
                {
                    warrantyAlarm = value;
                    RaisePropertyChanged("WarrantyAlarm");
                }
            }
        }

        private int? reviewAlarm;
        public int? ReviewAlarm
        {
            get
            {
                return reviewAlarm;
            }

            set
            {
                if (reviewAlarm != value)
                {
                    reviewAlarm = value;
                    RaisePropertyChanged("ReviewAlarm");
                }
            }
        }

        private int? legalizationAlarm;
        public int? LegalizationAlarm
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
            Properties = new Properties();

            Building = new DataBuilding();
            Producer = new DataContractor();
            Provider = new DataContractor();
            Service = new DataContractor();
            Attestation = new DataContractor();
            Employee = new DataEmployee();
            PostedWorker = new DataEmployee();

            ID = "New ID";
            Name = String.Empty;
            SN = String.Empty;
            Group = String.Empty;
            Description = String.Empty;
            Comments = String.Empty;
            Room = String.Empty;
            Condition = string.Empty;
            Norm = string.Empty;
            CertificationNumber = String.Empty;
            EmployeeActive = false;
            EmployeesName = String.Empty;
            WarrantyAlarm = 0;
            ReviewAlarm = 0;
            LegalizationAlarm = 0;
            ProductionDate = new DateTime();
            WarrantyDate = new DateTime();
            ReviewDate = new DateTime();
            LegalizationDate = new DateTime();
            PostingDate = new DateTime();
        }
    }

    public static class DataEquipmentExtensions
    {
        public static DataEquipment GetEquipment(this IList<DataEquipment> list, string id)
        {
            var dataEquipment = list.FirstOrDefault(equipment => equipment.ID == id);

            return dataEquipment;
        }

        public static DataEquipment Values(this List<DataEquipment> colection)
        {
            DataEquipment dataEquipment = new DataEquipment();

            if (colection.IsSameValue(i => i.ID))
            {
                dataEquipment.ID = colection[0].ID;
            }
            else
            {
                dataEquipment.ID = "[...]";
            }

            if (colection.IsSameValue(i => i.Name))
            {
                dataEquipment.Name = colection[0].Name;
            }
            else
            {
                dataEquipment.Name = "[...]";
            }

            if (colection.IsSameValue(i => i.Description))
            {
                dataEquipment.Description = colection[0].Description;
            }
            else
            {
                dataEquipment.Description = "[...]";
            }

            if (colection.IsSameValue(i => i.Condition))
            {
                dataEquipment.Condition = colection[0].Condition;
            }
            else
            {
                dataEquipment.Condition = "[...]";
            }

            if (colection.IsSameValue(i => i.Producer))
            {
                dataEquipment.Producer = colection[0].Producer;
            }
            else
            {
                dataEquipment.Producer.Name = "[...]";
            }




            return dataEquipment;
        }
    }
}
