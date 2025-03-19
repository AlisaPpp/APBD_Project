namespace APBD_Project;

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException(string msg) : base(msg) { }
}