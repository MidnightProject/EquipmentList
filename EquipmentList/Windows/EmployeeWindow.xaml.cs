using EquipmentList.Model;
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
    public partial class EmployeeWindow : Window
    {
        public List<string> StatusList { get { return new List<string>() { "ENABLED", "DISABLED" }; } }
        public List<string> JobTitleList { get; set; }

        public DataEmployee Employee { get; set; }

        private string status;
        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                if (status != value)
                {
                    status = value;
                }
            }
        }

        public EmployeeWindow()
        {
            InitializeComponent();
            DataContext = this;

            Status = "ENABLED";

            Employee = new DataEmployee();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(nameTextBox);

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() =>
            {
                nameTextBox.SelectAll();
            }));
        }
    }
}
