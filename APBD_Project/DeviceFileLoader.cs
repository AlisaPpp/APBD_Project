namespace APBD_Project;

/// <summary>
/// This class loads devices into the list from the specified file
/// </summary>
public class DeviceFileLoader : IDeviceFileLoader
{
    private readonly string _filePath;

    public DeviceFileLoader(string filePath)
    {
        this._filePath = filePath;
    }

    public List<Device> LoadDevices()
    {
        var devices = new List<Device>();
    
        if (!File.Exists(_filePath)) return devices;
    
        foreach (var line in File.ReadAllLines(_filePath))
        {
            try
            {
                var parts = line.Split(',');
                var device = DeviceFactory.CreateDevice(parts[0][0].ToString(), parts);
                devices.Add(device);
            }
            catch (Exception ex)  
            {
                Console.WriteLine($"Error loading device from line: {line}");
            }
        }
    
        return devices;
    }
}