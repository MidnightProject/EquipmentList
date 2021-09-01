using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EquipmentList.Model
{
    public class DataEmployee : ViewModelBase
    {
        public string Name { get; set; }

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

        public string Phone { get; set; }

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


        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Room { get; set; }

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


