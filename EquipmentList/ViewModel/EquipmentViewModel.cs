using EquipmentList.Messages;
using EquipmentList.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using static EquipmentList.View.Views;

namespace EquipmentList.ViewModel
{
    public class EquipmentViewModel : ViewModelBase
    {
        private ObservableCollection<DataEquipment> dataEquipments;
        public ObservableCollection<DataEquipment> DataEquipments
        {
            get
            {
                return dataEquipments;
            }

            set
            {
                dataEquipments = value;
                RaisePropertyChanged("DataEquipments");
            }
        }

        private List<EmployeeStatus> employeesStatus;
        public List<EmployeeStatus> EmployeesStatus
        {
            get
            {
                return employeesStatus;
            }

            set
            {
                employeesStatus = new List<EmployeeStatus>();
                employeesStatus = value;
                RaisePropertyChanged("EmployeesName");

                foreach(DataEquipment equipment in DataEquipments)
                {
                    foreach(EmployeeStatus employee in EmployeesStatus)
                    {
                        if (employee.Name == equipment.Employee.Person.Name)
                        {
                            equipment.EmployeeActive = employee.Active;
                            break;
                        }
                    } 
                }
            }
        }
       
        public List<string> EmployeesName
        {
            get
            {
                List<string> names = new List<string>();
                names.Add("");

                foreach (EmployeeStatus employee in EmployeesStatus)
                {
                    names.Add(employee.Name);
                }

                return names;
            }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }

            set
            {
                selectedIndex = value;
                RaisePropertyChanged("SelectedIndex");
            }
        }

        public int SelectedIndexes { get; set; }

        private RelayCommand selectedIndexCommand;
        public RelayCommand SelectedIndexCommand
        {
            get
            {
                return selectedIndexCommand = new RelayCommand(() => GetSelectedIndexes());
            }
        }
        private void GetSelectedIndexes()
        {
            SelectedIndexes = DataEquipments.Where(i => i.Properties.IsSelected).Count();

            Messenger.Default.Send<SelectedIndexMessage>(new SelectedIndexMessage
            {
                View = DefinedViews.EquipmentView,
                Index = SelectedIndexes,

            }, MessageType.PropertyChangedMessage);
        }

        public DataEquipment SelectedEquipment { get; set; }
        public List<DataEquipment> SelectedEquipments
        {
            get
            {
                return DataEquipments.Where(i => i.Properties.IsSelected).ToList();
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
                switch (value)
                {
                    case "Employee":
                        group = "EMPLOYEE";
                        break;
                    case "Producer":
                        group = "PRODUCER";
                        break;
                    case "Building":
                        group = "BUILDING";
                        break;
                    case "Norm":
                        group = "NORM";
                        break;
                    case "Group":
                        group = "GROUP";
                        break;
                    case "Condition":
                        group = "CONDITION";
                        break;
                    case "Review Date":
                        group = "REVIEW_DATE";
                        break;
                    case "Legalization Date":
                        group = "LEGALIZATION_DATE";
                        break;
                    default:
                        group = String.Empty;
                        break;
                }

                RaisePropertyChanged("Group");
            }
        }

        private SolidColorBrush activeEmployeeColor;
        public SolidColorBrush ActiveEmployeeColor
        {
            get
            {
                return activeEmployeeColor;
            }

            set
            {
                activeEmployeeColor = value;
                RaisePropertyChanged("ActiveEmployeeColor");
            }
        }

        private SolidColorBrush nullEmployeeColor;
        public SolidColorBrush NullEmployeeColor
        {
            get
            {
                return nullEmployeeColor;
            }

            set
            {
                nullEmployeeColor = value;
                RaisePropertyChanged("NullEmployeeColor");
            }
        }

        private SolidColorBrush incorrectReviewDateColor;
        public SolidColorBrush IncorrectReviewDateColor
        {
            get
            {
                return incorrectReviewDateColor;
            }

            set
            {
                incorrectReviewDateColor = value;
                RaisePropertyChanged("IncorrectReviewDateColor");
            }
        }

        private SolidColorBrush incorrectLegalizationDateColor;
        public SolidColorBrush IncorrectLegalizationDateColor
        {
            get
            {
                return incorrectLegalizationDateColor;
            }

            set
            {
                incorrectLegalizationDateColor = value;
                RaisePropertyChanged("IncorrectLegalizationDateColor");
            }
        }

        private SolidColorBrush postedWorkerColor;
        public SolidColorBrush PostedWorkerColor
        {
            get
            {
                return postedWorkerColor;
            }

            set
            {
                postedWorkerColor = value;
                RaisePropertyChanged("PostedWorkerColor");
            }
        }

        private SolidColorBrush alarmColor;
        public SolidColorBrush AlarmColor
        {
            get
            {
                return alarmColor;
            }

            set
            {
                alarmColor = value;
                RaisePropertyChanged("AlarmColor");
            }
        }

        private RelayCommand<string> copyStringCommand;
        public RelayCommand<string> CopyStringCommand
        { 
            get
            {
                return copyStringCommand = new RelayCommand<string>((pararameters) => CopyStringToClipboard(pararameters));
            }
        }
        private void CopyStringToClipboard(string pararameters)
        {
            System.Windows.Clipboard.SetData(DataFormats.Text, pararameters);
        }

        public EquipmentViewModel(List<EmployeeStatus> employeeStatus, DataTable equipment, SolidColorBrush alarmColor, SolidColorBrush postedWorkerColor, SolidColorBrush activeEmployeeColor , SolidColorBrush nullEmployeeColor, SolidColorBrush incorrectReviewDateColor, SolidColorBrush incorrectLegalizationDateColor)
        {
            AlarmColor = alarmColor;
            PostedWorkerColor = postedWorkerColor;
            ActiveEmployeeColor = activeEmployeeColor;
            NullEmployeeColor = nullEmployeeColor;
            IncorrectReviewDateColor = incorrectReviewDateColor;
            IncorrectLegalizationDateColor = incorrectLegalizationDateColor;

            DataEquipments = new ObservableCollection<DataEquipment>();
            EmployeesStatus = employeeStatus;
      
            foreach (DataRow row in equipment.Rows)
            {
                DateTime postingDate = row["REPLACEMENT_DATE"].ToDateTime();
                string replacementEmployeeName;

                if (postingDate == new DateTime())
                {
                    replacementEmployeeName = row["REPLACEMENT_EMPLOYEE_NAME"].ToString();
                }
                else if (postingDate < DateTime.Now)
                {
                    replacementEmployeeName = String.Empty;
                }
                else
                {
                    replacementEmployeeName = row["REPLACEMENT_EMPLOYEE_NAME"].ToString();
                }

                Boolean active = false;
                string employeeName = row["EMPLOYEE_NAME"].ToString();
                if (String.IsNullOrEmpty(employeeName))
                {
                    active = true;
                }
                else
                {
                    foreach (EmployeeStatus employee in EmployeesStatus)
                    {
                        if (employee.Name == employeeName)
                        {
                            active = employee.Active;
                            break;
                        }
                    }
                }

                DataEquipments.Add(new DataEquipment()
                {
                    ID = row["ID"].ToString(),
                    Name = row["NAME"].ToString(),
                    SN = row["SN"].ToString(),
                    Description = row["DESCRIPTION"].ToString(),
                    Comments = row["COMMENTS"].ToString(),
                    Room = row["ROOM"].ToString(),
                    Building = new DataBuilding()
                    {
                        Name = row["BUILDING"].ToString(),
                        Country = row["EQUIPMENT_BUILDING_COUNTRY"].ToString(),
                        City = row["EQUIPMENT_BUILDING_CITY"].ToString(),
                        Address = row["EQUIPMENT_BUILDING_ADDRESS"].ToString(),
                        Postcode = row["EQUIPMENT_BUILDING_POSTCODE"].ToString(),
                    },
                    Group = row["SUBGROUP"].ToString(),
                    PostedWorker = new DataEmployee()
                    {
                        ID = row["REPLACEMENT_EMPLOYEE_ID"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = row["REPLACEMENT_EMPLOYEE_NAME"].ToString(),
                        }
                    },
                    EmployeesName = employeeName + "#" + replacementEmployeeName,
                    Employee = new DataEmployee()
                    {
                        Room = row["EMPLOYEE_ROOM"].ToString(),
                        ID = row["EMPLOYEE"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = employeeName,
                            Phone = row["EMPLOYEE_PHONE"].ToString(),
                            Email = row["EMPLOYEE_EMAIL"].ToString(),
                        },

                       Building = new DataBuilding()
                       {
                           Name = row["EMPLOYEE_BUILDING_NAME"].ToString(),
                           Country = row["EMPLOYEE_BUILDING_COUNTRY"].ToString(),
                           City = row["EMPLOYEE_BUILDING_CITY"].ToString(),
                           Address = row["EMPLOYEE_BUILDING_ADDRESS"].ToString(),
                           Postcode = row["EMPLOYEE_BUILDING_POSTCODE"].ToString(),
                       },
                    },
                    EmployeeActive = active,
                    ProductionDate = row["PRODUCTION_DATE"].ToDateTime(),
                    WarrantyDate = row["WARRANTY_DATE"].ToDateTime(),
                    LegalizationDate = row["LEGALIZATION_DATE"].ToDateTime(),
                    ReviewDate = row["REVIEW_DATE"].ToDateTime(),
                    Producer = new DataContractor()
                    {
                        Name = row["PRODUCER"].ToString(),
                        WWW = row["PRODUCER_WWW"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = row["PRODUCER_PERSON"].ToString(),
                            Phone = row["PRODUCER_PHONE"].ToString(),
                            Email = row["PRODUCER_EMAIL"].ToString(),
                        },

                        Building = new DataBuilding()
                        {
                            Address = row["PRODUCER_ADDRESS"].ToString(),
                            City = row["PRODUCER_CITY"].ToString(),
                            Postcode = row["PRODUCER_POSTCODE"].ToString(),
                            Country = row["PRODUCER_COUNTRY"].ToString(),
                        }
                    },
                    Provider = new DataContractor()
                    {
                        Name = row["PROVIDER"].ToString(),
                        WWW = row["PROVIDER_WWW"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = row["PROVIDER_PERSON"].ToString(),
                            Phone = row["PROVIDER_PHONE"].ToString(),
                            Email = row["PROVIDER_EMAIL"].ToString(),
                        },

                        Building = new DataBuilding()
                        {
                            Address = row["PROVIDER_ADDRESS"].ToString(),
                            City = row["PROVIDER_CITY"].ToString(),
                            Postcode = row["PROVIDER_POSTCODE"].ToString(),
                            Country = row["PROVIDER_COUNTRY"].ToString(),
                        }
                    },
                    Service = new DataContractor()
                    {
                        Name = row["SERVICE"].ToString(),
                        WWW = row["SERVICE_WWW"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = row["SERVICE_PERSON"].ToString(),
                            Phone = row["SERVICE_PHONE"].ToString(),
                            Email = row["SERVICE_EMAIL"].ToString(),
                        },

                        Building = new DataBuilding()
                        {
                            Address = row["SERVICE_ADDRESS"].ToString(),
                            City = row["SERVICE_CITY"].ToString(),
                            Postcode = row["SERVICE_POSTCODE"].ToString(),
                            Country = row["SERVICE_COUNTRY"].ToString(),
                        }
                    },
                    Attestation = new DataContractor()
                    {
                        Name = row["ATTESTATION"].ToString(),
                        WWW = row["ATTESTATION_WWW"].ToString(),

                        Person = new DataPerson()
                        {
                            Name = row["ATTESTATION_PERSON"].ToString(),
                            Phone = row["ATTESTATION_PHONE"].ToString(),
                            Email = row["ATTESTATION_EMAIL"].ToString(),
                        },

                        Building = new DataBuilding()
                        {
                            Address = row["ATTESTATION_ADDRESS"].ToString(),
                            City = row["ATTESTATION_CITY"].ToString(),
                            Postcode = row["ATTESTATION_POSTCODE"].ToString(),
                            Country = row["ATTESTATION_COUNTRY"].ToString(),
                        }
                    },
                    Condition = row["CONDITION"].ToString(),
                    Norm = row["NORM"].ToString(),
                    CertificationNumber = row["CERTIFICATE_NUMBER"].ToString(),
                    PostingDate = postingDate,
                });
            }
        }

        public void RemoveEquipment(string id)
        {
            DataEquipments.Remove(id);
        }
    }
}