using GalaSoft.MvvmLight;

namespace EquipmentList.Model
{
    public class Properties : ViewModelBase
    {
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                RaisePropertyChanged("IsSelected");
            }
        }

        public Properties()
        {
            IsSelected = false;
        }
    }
}
