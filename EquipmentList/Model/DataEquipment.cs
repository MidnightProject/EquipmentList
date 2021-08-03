using System;

namespace EquipmentList.Model
{
    public class DataEquipment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string SN { get; set; }
        public string Group { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public string Room { get; set; }
        public string Building { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Condition { get; set; }
        public string Norm { get; set; }
        public string CertificationNumber { get; set; }

        public string EmployeeName { get; set; }
        public string EmployeeRoom { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeBuilding { get; set; }
        public string EmployeeBuildingCountry { get; set; }
        public string EmployeeBuildingCity { get; set; }
        public string EmployeeBuildingAddress { get; set; }
        public string EmployeeBuildingPostcode { get; set; }

        public string EmployeesName { get; set; }
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
        public int LegalizationAlarm { get; set; }
    }
}
