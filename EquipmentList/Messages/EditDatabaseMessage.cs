namespace EquipmentList.Messages
{
    public class EditDatabaseMessage
    {
        public TableType Table;
        public CommandType Command;
        public string Value;
        public string OldValue;
    }

    public enum CommandType
    {
        Insert,
        Update,
        Delete,
    }

    public enum TableType
    {
        Job,
        Group,
        Condition,
    }
}
