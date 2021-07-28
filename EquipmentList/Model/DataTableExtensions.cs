using System;

public static class DataTableExtensions
{
    public static Boolean ToBoolean(this object val)
    {
        if (String.IsNullOrEmpty(val.ToString()))
        {
            return false;
        }

        return (Boolean)val;
    }

    public static String ToStatus(this object val)
    {
        string status = val.ToString();

        switch (status)
        {
            case "True":
                return "Enabled";
            case "False":
                return "Disabled";
            default:
                return "Disabled";
        }
    }
}
