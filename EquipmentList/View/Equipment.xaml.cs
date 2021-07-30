using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EquipmentList.View
{
    public partial class Equipment : UserControl
    {
        public Equipment()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                DataGrid.SelectedIndex = -1;
            }));
        }
    }
}
