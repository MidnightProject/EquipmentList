namespace EquipmentList.Model
{
    public class Clipboard
    {
        public DataBuilding Building { get; set; }
        public DataEmployee Employee { get; set; }

        public Clipboard()
        {
            Building = new DataBuilding();
            Employee = new DataEmployee();
        }
    }
}
