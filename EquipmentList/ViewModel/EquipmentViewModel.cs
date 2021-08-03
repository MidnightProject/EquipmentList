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

        private List<string> employeesName;
        public List<string> EmployeesName
        {
            get
            {
                return employeesName;
            }

            set
            {
                employeesName = new List<string>();
                RaisePropertyChanged("EmployeesName");
                employeesName = value;
                RaisePropertyChanged("EmployeesName");
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

        public string EmployeesEmail { get { return DataEquipments[SelectedIndex].EmployeeEmail; } }

        public string ProducersWWW { get { return DataEquipments[SelectedIndex].ProducerWWW; } }
        public string ProducersEmail { get { return DataEquipments[SelectedIndex].ProducerEmail; } }

        public string ProvidersWWW { get { return DataEquipments[SelectedIndex].ProviderWWW; } }
        public string ProvidersEmail { get { return DataEquipments[SelectedIndex].ProviderEmail; } }

        public string ServicesWWW { get { return DataEquipments[SelectedIndex].ServiceWWW; } }
        public string ServicesEmail { get { return DataEquipments[SelectedIndex].ServiceEmail; } }

        public string AttestationsWWW { get { return DataEquipments[SelectedIndex].AttestationWWW; } }
        public string AttestationsEmail { get { return DataEquipments[SelectedIndex].AttestationEmail; } }

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

        public EquipmentViewModel(DataTable equipment)
        {
            DataEquipments = new Collection<DataEquipment>();
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
                    EmployeeName = row["EMPLOYEE_NAME"].ToString(),
                    PostedWorkerName = row["REPLACEMENT_EMPLOYEE_NAME"].ToString(),
                    EmployeesName = row["EMPLOYEE_NAME"].ToString() + "#" + replacementEmployeeName,
                    EmployeeRoom = row["EMPLOYEE_ROOM"].ToString(),
                    EmployeePhone = row["EMPLOYEE_PHONE"].ToString(),
                    EmployeeEmail = row["EMPLOYEE_EMAIL"].ToString(),
                    EmployeeBuilding = row["EMPLOYEE_BUILDING_NAME"].ToString(),
                    EmployeeBuildingCountry = row["EMPLOYEE_BUILDING_COUNTRY"].ToString(),
                    EmployeeBuildingCity = row["EMPLOYEE_BUILDING_CITY"].ToString(),
                    EmployeeBuildingAddress = row["EMPLOYEE_BUILDING_ADDRESS"].ToString(),
                    EmployeeBuildingPostcode = row["EMPLOYEE_BUILDING_POSTCODE"].ToString(),
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