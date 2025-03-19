namespace APBD_Project;

public class EmptyBatteryException : Exception
{
    public EmptyBatteryException(string message) : base(message) { }
}