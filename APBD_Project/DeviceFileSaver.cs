namespace APBD_Project;

/// <summary>
/// This class saves devices from the list to the specified file
/// </summary>
public class DeviceFileSaver : IDeviceFileSaver
{
    private readonly string _filePath;

    public DeviceFileSaver(string filePath)
    {
        this._filePath = filePath;
    }

    public void SaveDevices(List<Device> devices)
    {
        var lines = devices.Select(d => d.ToString()).ToList();
        File.WriteAllLines(_filePath, lines);
    }
}