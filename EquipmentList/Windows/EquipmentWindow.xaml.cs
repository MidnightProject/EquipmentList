using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace EquipmentList.Windows
{
    public partial class EquipmentWindow : Window
    {
        public EquipmentWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(indexTextBox);

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                indexTextBox.SelectAll();
            }));
        }
    }
}
