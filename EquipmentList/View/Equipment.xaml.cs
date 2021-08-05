using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace EquipmentList.View
{
    public partial class Equipment : UserControl
    {
        private Boolean dataGridIsInitialize = true;
        private int defaultValue = -1;
        private List<int> cellWidth = new List<int>();
        private int maxWidth = 0;

        public Equipment()
        {
            InitializeComponent();

            DataGrid.Columns[0].Width = 0;

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                DataGrid.SelectedIndex = -1;
            }));
        }

        private void WarningColumn_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (dataGridIsInitialize)
            {
                if (defaultValue ==  -1)
                {
                    defaultValue = (int)e.NewSize.Width;
                }
                
                if ((int)e.PreviousSize.Width == 0 && defaultValue == (int)e.NewSize.Width)
                {
                    cellWidth.Add((int)e.NewSize.Width);
                }
                else
                {
                    dataGridIsInitialize = false;
                }
            }

            if (!dataGridIsInitialize)
            {
                if (maxWidth < (int)e.NewSize.Width)
                {
                    maxWidth = (int)e.NewSize.Width;
                }

                cellWidth.Remove((int)e.PreviousSize.Width);

                if (maxWidth == (int)e.PreviousSize.Width);
                {
                    maxWidth = cellWidth.Max();
                }

                cellWidth.Add((int)e.NewSize.Width);
            }

            DataGrid.Columns[0].Width = maxWidth + 5;
        }
    }
}
