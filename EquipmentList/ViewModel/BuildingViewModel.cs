using FirebirdSql.Data.FirebirdClient;
using GalaSoft.MvvmLight;
using System.Data;

namespace EquipmentList.ViewModel
{
    public class BuildingViewModel : ViewModelBase
    {
        private DataTable buildingTable;
        public DataTable BuildingTable
        {
            get
            {
                return buildingTable;
            }

            set
            {
                buildingTable = value;
                RaisePropertyChanged("BuildingTable");
            }
        }

        public BuildingViewModel(DataTable dt)
        {
            
            BuildingTable = dt;
        }
    }
}
