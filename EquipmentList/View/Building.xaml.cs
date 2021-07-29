using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EquipmentList.View
{
    public partial class Building : UserControl
    {
        public Building()
        {
            InitializeComponent();

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                DataGrid.SelectedIndex = -1;
            }));
        }
    }
}
