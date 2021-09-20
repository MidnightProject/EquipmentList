using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentList.Model
{
    public class Employee
    {
        
        public Boolean Active { get; set; }

        public List<string> Name { get; set; }
        public List<string> ID { get; set; }

        public Employee(List<string> id, List<string> name)
        {
            Name = name;
            Name.Insert(0, String.Empty);

            ID = id;
            ID.Insert(0, String.Empty);
        }
    }

    public static class EmployeeExtensions
    {
        /*
        public static List<Employee> Remove(this List<Employee> list, string id)
        {
            var employeeToRemove = list.SingleOrDefault(employee => employee.ID == id);
            if (employeeToRemove != null)
            {
                list.Remove(employeeToRemove);
            }

            return list;
        }

        public static List<Employee> AddEmployee(this List<Employee> list, string id, string name)
        {
            var employeeToAdd = list.SingleOrDefault(employee => employee.ID == id);
            if (employeeToAdd != null)
            {
                return list;
            }

            //list.Add(new Employee() { ID = id, Name = name });
            return list;
        }

        public static ObservableCollection<Employee> Add(this ObservableCollection<Employee> list, string id, string name)
        {
            var employeeToAdd = list.SingleOrDefault(employee => employee.ID == id);
            if (employeeToAdd != null)
            {
                return list;
            }

            //list.Add(new Employee() { ID = id, Name = name });
            return list;
        }

        public static ObservableCollection<string> Names(this ObservableCollection<Employee> list)
        {
            ObservableCollection<string> name = new ObservableCollection<string>();

            foreach (Model.Employee employee in list)
            {
                //name.Add(employee.Name);
            }
            return name;
        }
        */

    }
}
