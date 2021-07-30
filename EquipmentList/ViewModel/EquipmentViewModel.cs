using EquipmentList.Model;
using GalaSoft.MvvmLight;
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
                    Group = row["SUBGROUP"].ToString(),
                    EmployeeName = row["EMPLOYEE_NAME"].ToString(),
                });
            }
        }
    }
}