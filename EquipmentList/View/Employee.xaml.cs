using DataGridExtensions;
using System.Windows.Controls;
using System;
using System.Diagnostics;
using System.Windows.Threading;
using System.Windows.Data;

namespace EquipmentList.View
{
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();
            
            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                DataGrid.SelectedIndex = -1;
                BindingOperations.SetBinding(columnStatus, DataGridFilterColumn.FilterProperty, new Binding("DataContext.ColumnStatusFilter") { Source = this, Mode = BindingMode.TwoWay });
            }));
        }
    }
}
