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
        //private List<int> cellWidth = new List<int>();
        private int[] cellWidth = new int[12];
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
                    //cellWidth.Add((int)e.NewSize.Width);
                    cellWidth[0]++;
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

                //cellWidth.Remove((int)e.PreviousSize.Width);
                if((int)e.PreviousSize.Width == defaultValue)
                {
                    cellWidth[0]--;
                }
                else
                {
                    cellWidth[(int)e.PreviousSize.Width / 10]--;
                }

                if (maxWidth == (int)e.PreviousSize.Width)
                {
                    //maxWidth = cellWidth.Max();
                    for (int i = 11; i > 0; i--)
                    {
                        if (cellWidth[i] != 0)
                        {
                            if (i != 0)
                            {
                                maxWidth = cellWidth[i] * 10;
                            }
                            else
                            {
                                maxWidth = defaultValue;
                            }
                        }
                    }
                }

                //cellWidth.Add((int)e.NewSize.Width);
                cellWidth[(int)e.NewSize.Width / 10]++;
            }

            DataGrid.Columns[0].Width = maxWidth + 5;
        }
    }
}
