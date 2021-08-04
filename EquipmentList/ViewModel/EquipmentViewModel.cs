using EquipmentList.Model;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace EquipmentList.ViewModel
{
    public class EquipmentViewModel : ViewModelBase
    {
        private Collection<DataEquipment> dataEquipments;
        public Collection<DataEquipment> DataEquipments
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
                        if (employee.Name == equipment.EmployeeName)
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
            Clipboard.SetData(DataFormats.Text, pararameters);
        }

        public EquipmentViewModel(List<EmployeeStatus> employeeStatus, DataTable equipment)
        {
            DataEquipments = new Collection<DataEquipment>();
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
                    Building = row["BUILDING"].ToString(),
                    Country = row["EQUIPMENT_BUILDING_COUNTRY"].ToString(),
                    City = row["EQUIPMENT_BUILDING_CITY"].ToString(),
                    Address = row["EQUIPMENT_BUILDING_ADDRESS"].ToString(),
                    Postcode = row["EQUIPMENT_BUILDING_POSTCODE"].ToString(),
                    Group = row["SUBGROUP"].ToString(),
                    EmployeeName = employeeName,
                    PostedWorkerName = row["REPLACEMENT_EMPLOYEE_NAME"].ToString(),
                    EmployeesName = employeeName + "#" + replacementEmployeeName,
                    EmployeeRoom = row["EMPLOYEE_ROOM"].ToString(),
                    EmployeePhone = row["EMPLOYEE_PHONE"].ToString(),
                    EmployeeEmail = row["EMPLOYEE_EMAIL"].ToString(),
                    EmployeeBuilding = row["EMPLOYEE_BUILDING_NAME"].ToString(),
                    EmployeeBuildingCountry = row["EMPLOYEE_BUILDING_COUNTRY"].ToString(),
                    EmployeeBuildingCity = row["EMPLOYEE_BUILDING_CITY"].ToString(),
                    EmployeeBuildingAddress = row["EMPLOYEE_BUILDING_ADDRESS"].ToString(),
                    EmployeeBuildingPostcode = row["EMPLOYEE_BUILDING_POSTCODE"].ToString(),
                    EmployeeActive = active,
                    ProductionDate = row["PRODUCTION_DATE"].ToDateTime(),
                    WarrantyDate = row["WARRANTY_DATE"].ToDateTime(),
                    LegalizationDate = row["LEGALIZATION_DATE"].ToDateTime(),
                    ReviewDate = row["REVIEW_DATE"].ToDateTime(),
                    ProducerName = row["PRODUCER"].ToString(),
                    ProducerPerson = row["PRODUCER_PERSON"].ToString(),
                    ProducerPhone = row["PRODUCER_PHONE"].ToString(),
                    ProducerEmail = row["PRODUCER_EMAIL"].ToString(),
                    ProducerWWW = row["PRODUCER_WWW"].ToString(),
                    ProducerCountry = row["PRODUCER_COUNTRY"].ToString(),
                    ProducerCity = row["PRODUCER_CITY"].ToString(),
                    ProducerAddress = row["PRODUCER_ADDRESS"].ToString(),
                    ProducerPostcode = row["PRODUCER_POSTCODE"].ToString(),
                    ProviderName = row["PROVIDER"].ToString(),
                    ProviderPerson = row["PROVIDER_PERSON"].ToString(),
                    ProviderPhone = row["PROVIDER_PHONE"].ToString(),
                    ProviderEmail = row["PROVIDER_EMAIL"].ToString(),
                    ProviderWWW = row["PROVIDER_WWW"].ToString(),
                    ProviderCountry = row["PROVIDER_COUNTRY"].ToString(),
                    ProviderCity = row["PROVIDER_CITY"].ToString(),
                    ProviderAddress = row["PROVIDER_ADDRESS"].ToString(),
                    ProviderPostcode = row["PROVIDER_POSTCODE"].ToString(),
                    ServiceName = row["SERVICE"].ToString(),
                    ServicePerson = row["SERVICE_PERSON"].ToString(),
                    ServicePhone = row["SERVICE_PHONE"].ToString(),
                    ServiceEmail = row["SERVICE_EMAIL"].ToString(),
                    ServiceWWW = row["SERVICE_WWW"].ToString(),
                    ServiceCountry = row["SERVICE_COUNTRY"].ToString(),
                    ServiceCity = row["SERVICE_CITY"].ToString(),
                    ServiceAddress = row["SERVICE_ADDRESS"].ToString(),
                    ServicePostcode = row["SERVICE_POSTCODE"].ToString(),
                    AttestationName = row["ATTESTATION"].ToString(),
                    AttestationPerson = row["ATTESTATION_PERSON"].ToString(),
                    AttestationPhone = row["ATTESTATION_PHONE"].ToString(),
                    AttestationEmail = row["ATTESTATION_EMAIL"].ToString(),
                    AttestationWWW = row["ATTESTATION_WWW"].ToString(),
                    AttestationCountry = row["ATTESTATION_COUNTRY"].ToString(),
                    AttestationCity = row["ATTESTATION_CITY"].ToString(),
                    AttestationAddress = row["ATTESTATION_ADDRESS"].ToString(),
                    AttestationPostcode = row["ATTESTATION_POSTCODE"].ToString(),
                    Condition = row["CONDITION"].ToString(),
                    Norm = row["NORM"].ToString(),
                    CertificationNumber = row["CERTIFICATE_NUMBER"].ToString(),
                    PostingDate = postingDate,
                });
            }
        }
    }
}