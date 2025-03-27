namespace APBD_Project;
/// <summary>
/// Responsible for loading devices from the file
/// </summary>
public interface IDeviceFileLoader
{
    List<Device> LoadDevices();
}