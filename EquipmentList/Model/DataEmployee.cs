using EquipmentList.Helpers;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataEmployee : ViewModelBase
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

        private string job;
        public string Job
        {
            get
            {
                return job;
            }

            set
            {
                if (job != value)
                {
                    job = value.TrimStart();
                    RaisePropertyChanged("Job");
                }
            }
        }

        private string phone;
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                if (phone != value)
                {
                    phone = value.TrimStart();
                    RaisePropertyChanged("Phone");
                }
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                if (email != value)
                {
                    email = value.TrimStart();
                    RaisePropertyChanged("Email");
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
                    building = value.TrimStart();
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
                    room = value.TrimStart();
                    RaisePropertyChanged("Room");
                }
            }
        }

        private Boolean active;
        public Boolean Active
        {
            get
            {
                return active;
            }

            set
            {
                if (active != value)
                {
                    active = value;
                    RaisePropertyChanged("Active");
                }
            }
        }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                if (status != value)
                {
                    status = value;
                    RaisePropertyChanged("Status");
                }
            }
        }

        private Boolean addUser;
        public Boolean AddUser
        {
            get
            {
                return addUser;
            }

            set
            {
                if (addUser != value)
                {
                    addUser = value;
                    RaisePropertyChanged("AddUser");
                }
            }
        }

        private Boolean editUser;
        public Boolean EditUser
        {
            get
            {
                return editUser;
            }

            set
            {
                if (editUser != value)
                {
                    editUser = value;
                    RaisePropertyChanged("EditUser");
                }
            }
        }

        private Boolean deleteUser;
        public Boolean DeleteUser
        {
            get
            {
                return deleteUser;
            }

            set
            {
                if (deleteUser != value)
                {
                    deleteUser = value;
                    RaisePropertyChanged("DeleteUser");
                }
            }
        }

        private Boolean printUser;
        public Boolean PrintUser
        {
            get
            {
                return printUser;
            }

            set
            {
                if (printUser != value)
                {
                    printUser = value;
                    RaisePropertyChanged("PrintUser");
                }
            }
        }

        private Boolean addOwnEquipment;
        public Boolean AddOwnEquipment
        {
            get
            {
                return addOwnEquipment;
            }

            set
            {
                if (addOwnEquipment != value)
                {
                    addOwnEquipment = value;
                    RaisePropertyChanged("AddOwnEquipment");
                }
            }
        }

        private Boolean deleteOwnEquipment;
        public Boolean DeleteOwnEquipment
        {
            get
            {
                return deleteOwnEquipment;
            }

            set
            {
                if (deleteOwnEquipment != value)
                {
                    deleteOwnEquipment = value;
                    RaisePropertyChanged("DeleteOwnEquipment");
                }
            }
        }

        private Boolean addOtherEquipment;
        public Boolean AddOtherEquipment
        {
            get
            {
                return addOtherEquipment;
            }

            set
            {
                if (addOtherEquipment != value)
                {
                    addOtherEquipment = value;
                    RaisePropertyChanged("AddOtherEquipment");
                }
            }
        }

        private Boolean deleteOtherEquipment;
        public Boolean DeleteOtherEquipment
        {
            get
            {
                return deleteOtherEquipment;
            }

            set
            {
                if (deleteOtherEquipment != value)
                {
                    deleteOtherEquipment = value;
                    RaisePropertyChanged("DeleteOtherEquipment");
                }
            }
        }

        private Boolean editOtherEquipment;
        public Boolean EditOtherEquipment
        {
            get
            {
                return editOtherEquipment;
            }

            set
            {
                if (editOtherEquipment != value)
                {
                    editOtherEquipment = value;
                    RaisePropertyChanged("EditOtherEquipment");
                }
            }
        }

        private Boolean viewOtherEquipment;
        public Boolean ViewOtherEquipment
        {
            get
            {
                return viewOtherEquipment;
            }

            set
            {
                if (viewOtherEquipment != value)
                {
                    viewOtherEquipment = value;
                    RaisePropertyChanged("ViewOtherEquipment");
                }
            }
        }

        private Boolean printOtherEquipment;
        public Boolean PrintOtherEquipment
        {
            get
            {
                return printOtherEquipment;
            }

            set
            {
                if (printOtherEquipment != value)
                {
                    printOtherEquipment = value;
                    RaisePropertyChanged("PrintOtherEquipment");
                }
            }
        }

        public DataEmployee()
        {
            Properties = new Properties();
        }
    }

    public static class DataEmployeeExtensions
    {
        public static DataEmployee GetEmployee(this IList<DataEmployee> list, string name)
        {
            var dataEmployee = list.FirstOrDefault(emmployee => emmployee.Name == name);

            return dataEmployee;
        }

        public static Collection<DataEmployee> Remove(this Collection<DataEmployee> colection, string name)
        {
            var employeeToRemove = colection.SingleOrDefault(employee => employee.Name == name);
            if (employeeToRemove != null)
            {
                colection.Remove(employeeToRemove);
            }

            return colection;
        }

        public static Collection<DataEmployee> Update(this Collection<DataEmployee> colection, string name, DataEmployee dataEmployee)
        {
            var employeeToUpdate = colection.SingleOrDefault(employee => employee.Name == name);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Job = dataEmployee.Job.TrimString();
                employeeToUpdate.Building = dataEmployee.Building.TrimString();
                employeeToUpdate.Room = dataEmployee.Room.TrimString();
                employeeToUpdate.Phone = dataEmployee.Phone.TrimString();
                employeeToUpdate.Email = dataEmployee.Email.TrimString();

                employeeToUpdate.AddUser = dataEmployee.AddUser;
                employeeToUpdate.EditUser = dataEmployee.EditUser;
                employeeToUpdate.DeleteUser = dataEmployee.DeleteUser;
                employeeToUpdate.PrintUser = dataEmployee.PrintUser;
                employeeToUpdate.AddOwnEquipment = dataEmployee.AddOwnEquipment;
                employeeToUpdate.DeleteOwnEquipment = dataEmployee.DeleteOwnEquipment;
                employeeToUpdate.AddOtherEquipment = dataEmployee.AddOtherEquipment;
                employeeToUpdate.DeleteOtherEquipment = dataEmployee.DeleteOtherEquipment;
                employeeToUpdate.EditOtherEquipment = dataEmployee.EditOtherEquipment;
                employeeToUpdate.ViewOtherEquipment = dataEmployee.ViewOtherEquipment;
                employeeToUpdate.PrintOtherEquipment = dataEmployee.PrintOtherEquipment;
            }

            return colection;
        }
    }
}


