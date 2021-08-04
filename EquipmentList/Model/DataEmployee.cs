using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataEmployee
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Building { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Room { get; set; }

        public Boolean Active { get; set; }
        public String Status { get; set; }
        public Boolean AddUser { get; set; }
        public Boolean EditUser { get; set; }
        public Boolean DeleteUser { get; set; }
        public Boolean PrintUser { get; set; }
        public Boolean AddOwnEquipment { get; set; }
        public Boolean DeleteOwnEquipment { get; set; }
        public Boolean AddOtherEquipment { get; set; }
        public Boolean DeleteOtherEquipment { get; set; }
        public Boolean EditOtherEquipment { get; set; }
        public Boolean ViewOtherEquipment { get; set; }
        public Boolean PrintOtherEquipment { get; set; }
    }

    public static class DataEmployeeExtensions
    {
        public static DataEmployee GetEmployee(this IList<DataEmployee> list, string name)
        {
            var dataEmployee = list.FirstOrDefault(emmployee => emmployee.Name == name);

            return dataEmployee;
        }
    }
}


