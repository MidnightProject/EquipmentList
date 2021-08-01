using EquipmentList.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

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

        public string WWW { get { return "www.wp.pl"; } }

        public EquipmentViewModel(DataTable dt)
        {
            DataEquipments = new Collection<DataEquipment>();
            foreach (DataRow row in dt.Rows)
            {
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
                });
            }
        }
    }
}