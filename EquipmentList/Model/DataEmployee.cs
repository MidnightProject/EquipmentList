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

        public string ID { get; set; }

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
                    job = value.TrimStartString();
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
                    phone = value.TrimStartString();
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
                    email = value.TrimStartString();
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
                    building = value.TrimStartString();
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
                    country = value.TrimStartString();
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
                    city = value.TrimStartString();
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
                    address = value.TrimStartString();
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
                    postcode = value.TrimStartString();
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
                    room = value.TrimStartString();
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

                    if (status == "Enabled")
                    {
                        Active = true;
                    }
                    else
                    {
                        Active = false;
                    }
                }
            }
        }

        private Boolean? addUser;
        public Boolean? AddUser
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

        private Boolean? editUser;
        public Boolean? EditUser
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

        private Boolean? deleteUser;
        public Boolean? DeleteUser
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

        private Boolean? printUser;
        public Boolean? PrintUser
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

        private Boolean? addOwnEquipment;
        public Boolean? AddOwnEquipment
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

        private Boolean? deleteOwnEquipment;
        public Boolean? DeleteOwnEquipment
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

        private Boolean? addOtherEquipment;
        public Boolean? AddOtherEquipment
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

        private Boolean? deleteOtherEquipment;
        public Boolean? DeleteOtherEquipment
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

        private Boolean? editOtherEquipment;
        public Boolean? EditOtherEquipment
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

        private Boolean? viewOtherEquipment;
        public Boolean? ViewOtherEquipment
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

        private Boolean? printOtherEquipment;
        public Boolean? PrintOtherEquipment
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

            Name = "New employee";
            Status = "Enabled";

            AddUser = false;
            EditUser = false;
            DeleteUser = false;
            PrintUser = false;
            AddOwnEquipment = false;
            DeleteOwnEquipment = false;
            AddOtherEquipment = false;
            DeleteOtherEquipment = false;
            EditOtherEquipment = false;
            ViewOtherEquipment = false;
            PrintOtherEquipment = false;
        }
    }

    public static class DataEmployeeExtensions
    {
        public static DataEmployee GetEmployee(this IList<DataEmployee> list, string name)
        {
            var dataEmployee = list.FirstOrDefault(emmployee => emmployee.Name == name);

            return dataEmployee;
        }

        public static Collection<DataEmployee> Remove(this Collection<DataEmployee> colection, string id)
        {
            var employeeToRemove = colection.SingleOrDefault(employee => employee.ID == id);
            if (employeeToRemove != null)
            {
                colection.Remove(employeeToRemove);
            }

            return colection;
        }

        public static Collection<DataEmployee> Update(this Collection<DataEmployee> colection, DataEmployee dataEmployee)
        {
            var employeeToUpdate = colection.SingleOrDefault(employee => employee.ID == dataEmployee.ID);
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = dataEmployee.Name.TrimEndString();
                employeeToUpdate.Job = dataEmployee.Job.TrimEndString();
                employeeToUpdate.Building = dataEmployee.Building.TrimEndString();
                employeeToUpdate.Room = dataEmployee.Room.TrimEndString();
                employeeToUpdate.Phone = dataEmployee.Phone.TrimEndString();
                employeeToUpdate.Email = dataEmployee.Email.TrimEndString();

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

                if (dataEmployee.Active)
                {
                    employeeToUpdate.Status = "Enabled";
                }
                else
                {
                    employeeToUpdate.Status = "Disabled";
                }
            }

            return colection;
        }

        public static DataEmployee Values(this List<DataEmployee> colection)
        {
            DataEmployee dataEmployee = new DataEmployee();

            if (colection.IsSameValue(i => i.Name))
            {
                dataEmployee.Name = colection[0].Name;
            }
            else
            {
                dataEmployee.Name = "[...]";
            }

            if (colection.IsSameValue(i => i.Status))
            {
                dataEmployee.Status = colection[0].Status;
            }
            else
            {
                dataEmployee.Status = "[...]";
            }

            if (colection.IsSameValue(i => i.Job))
            {
                dataEmployee.Job = colection[0].Job;
            }
            else
            {
                dataEmployee.Job = "[...]";
            }

            if (colection.IsSameValue(i => i.Building))
            {
                dataEmployee.Building = colection[0].Building;
            }
            else
            {
                dataEmployee.Building = "[...]";
            }

            if (colection.IsSameValue(i => i.Room))
            {
                dataEmployee.Room = colection[0].Room;
            }
            else
            {
                dataEmployee.Room = "[...]";
            }

            if (colection.IsSameValue(i => i.Phone))
            {
                dataEmployee.Phone = colection[0].Phone;
            }
            else
            {
                dataEmployee.Phone = "[...]";
            }

            if (colection.IsSameValue(i => i.Email))
            {
                dataEmployee.Email = colection[0].Email;
            }
            else
            {
                dataEmployee.Email = "[...]";
            }

            if (colection.IsSameValue(i => i.Status))
            {
                dataEmployee.Status = colection[0].Status;
            }
            else
            {
                dataEmployee.Status = "[...]";
            }

            if (colection.IsSameValue(i => i.AddUser))
            {
                dataEmployee.AddUser = colection[0].AddUser;
            }
            else
            {
                dataEmployee.AddUser = null;
            }

            if(colection.IsSameValue(i => i.EditUser))
            {
                dataEmployee.EditUser = colection[0].EditUser;
            }
            else
            {
                dataEmployee.EditUser = null;
            }

            if (colection.IsSameValue(i => i.DeleteUser))
            {
                dataEmployee.DeleteUser = colection[0].DeleteUser;
            }
            else
            {
                dataEmployee.DeleteUser = null;
            }

            if (colection.IsSameValue(i => i.PrintUser))
            {
                dataEmployee.PrintUser = colection[0].PrintUser;
            }
            else
            {
                dataEmployee.PrintUser = null;
            }

            if (colection.IsSameValue(i => i.AddOwnEquipment))
            {
                dataEmployee.AddOwnEquipment = colection[0].AddOwnEquipment;
            }
            else
            {
                dataEmployee.AddOwnEquipment = null;
            }

            if (colection.IsSameValue(i => i.DeleteOwnEquipment))
            {
                dataEmployee.DeleteOwnEquipment = colection[0].DeleteOwnEquipment;
            }
            else
            {
                dataEmployee.DeleteOwnEquipment = null;
            }

            if (colection.IsSameValue(i => i.AddOtherEquipment))
            {
                dataEmployee.AddOtherEquipment = colection[0].AddOtherEquipment;
            }
            else
            {
                dataEmployee.AddOtherEquipment = null;
            }

            if (colection.IsSameValue(i => i.DeleteOtherEquipment))
            {
                dataEmployee.DeleteOtherEquipment = colection[0].DeleteOtherEquipment;
            }
            else
            {
                dataEmployee.DeleteOtherEquipment = null;
            }

            if (colection.IsSameValue(i => i.EditOtherEquipment))
            {
                dataEmployee.EditOtherEquipment = colection[0].EditOtherEquipment;
            }
            else
            {
                dataEmployee.EditOtherEquipment = null;
            }

            if (colection.IsSameValue(i => i.ViewOtherEquipment))
            {
                dataEmployee.ViewOtherEquipment = colection[0].ViewOtherEquipment;
            }
            else
            {
                dataEmployee.ViewOtherEquipment = null;
            }

            if (colection.IsSameValue(i => i.PrintOtherEquipment))
            {
                dataEmployee.PrintOtherEquipment = colection[0].PrintOtherEquipment;
            }
            else
            {
                dataEmployee.PrintOtherEquipment = null;
            }
            
            return dataEmployee;
        }
    }
}


