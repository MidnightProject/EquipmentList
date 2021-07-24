using System.ComponentModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Data;

namespace EquipmentList.View
{
    public partial class Employee : UserControl
    {
        public Employee()
        {
            InitializeComponent();

            /*
            DataTable myTable = new DataTable("myTable");
            DataColumn colItem = new DataColumn("item");
            myTable.Columns.Add(colItem);
            // Add five items.    
            DataRow NewRow;
            for (int i = 0; i < 5; i++)
            {
                NewRow = myTable.NewRow();
                NewRow["item"] = "Item " + i;
                myTable.Rows.Add(NewRow);
            }
            // Change the values in the table.    
            myTable.Rows[0]["item"] = "cat";
            myTable.Rows[1]["item"] = "dog";
            myTable.AcceptChanges();
            // Create two DataView objects with the same table.    
            DataView firstView = new DataView(myTable);

            CollectionViewSource Test = new CollectionViewSource();
            Test.Source = firstView;

            Dupa.ItemsSource = firstView;
            ICollectionView cvTasks = CollectionViewSource.GetDefaultView(Dupa.ItemsSource);
            cvTasks.GroupDescriptions.Add(new PropertyGroupDescription("item"));
            */
            
        }
    }
}
