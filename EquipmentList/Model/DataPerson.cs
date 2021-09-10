using EquipmentList.Helpers;
using GalaSoft.MvvmLight;
using System;

namespace EquipmentList.Model
{
    public class DataPerson : ViewModelBase
    {
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

        public DataPerson()
        {
            Name = String.Empty;
            Phone = String.Empty;
            Email = String.Empty;
        }
    }
}
