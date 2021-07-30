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
        public string EmployeeName { get; set; }
        public string EmployeeRoom { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeBuilding { get; set; }
        public string EmployeeBuildingCountry { get; set; }
        public string EmployeeBuildingCity { get; set; }
        public string EmployeeBuildingAddress { get; set; }
        public string EmployeeBuildingPostcode { get; set; }

        public DateTime ProductionDate { get; set; }
        public DateTime WarrantyDate { get; set; }
        public DateTime ReviewDate { get; set; }
        public DateTime LegalizationDate { get; set; }
    }
}
