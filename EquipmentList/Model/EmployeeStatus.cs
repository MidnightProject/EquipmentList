using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentList.Model
{
    public class EmployeeStatus
    {
        public string Name { get; set; }
        public Boolean Active { get; set; }
    }

    public static class EmployeeStatusExtensions
    {
        public static List<EmployeeStatus> Remove(this List<EmployeeStatus> list, string name)
        {
            var employeeToRemove = list.SingleOrDefault(employee => employee.Name == name);
            if (employeeToRemove != null)
            {
                list.Remove(employeeToRemove);
            }

            return list;
        }

        public static List<EmployeeStatus> Add(this List<EmployeeStatus> list, string name)
        {
            var employeeToAdd = list.SingleOrDefault(employee => employee.Name == name);
            if (employeeToAdd != null)
            {
                return list;
            }

            list.Add(new EmployeeStatus() { Name = name });
            return list;
        }
    }
}
