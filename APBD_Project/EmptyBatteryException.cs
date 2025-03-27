namespace APBD_Project;
/// <summary>
/// Is thrown when the battery level of the Smartwatch is too low
/// </summary>
public class EmptyBatteryException : Exception
{
    public EmptyBatteryException(string msg) : base(msg) { }
}