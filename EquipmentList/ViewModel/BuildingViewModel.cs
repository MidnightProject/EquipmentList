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

        public BuildingViewModel(DataTable dt)
        {
            BuildingTable = dt;
            SelectedIndex = -1;
        }
    }
}
