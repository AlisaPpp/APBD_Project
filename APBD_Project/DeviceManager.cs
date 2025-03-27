namespace APBD_Project;
/// <summary>
/// This class fulfills multiple functions related to what the user can do with the devices
/// </summary>
public class DeviceManager
{
    private const int Max = 15;
    public List<Device> devices;
    private IDeviceFileLoader _fileLoader;
    private IDeviceFileSaver _deviceSaver;

    public DeviceManager(IDeviceFileLoader fileLoader)
    {
        this._fileLoader = fileLoader;
        this.devices = fileLoader.LoadDevices();
    }
    
    public void AddDevice(Device device)
    {
        if (devices.Count >= Max)
        {
            Console.WriteLine("There are " + Max + " devices already. Storage is full.");
            return;
        }
        devices.Add(device);
    }

    public void RemoveDevice(string name)
    {
        int index = devices.FindIndex(x => x.Name == name);
        
        if (index >= 0)
            devices.RemoveAt(index);
        else
            Console.WriteLine($"Device with name '{name}' not found.");
    }

    public void EditDevice(string name, string property, object newValue)
    {
        var device = devices.Find(x => x.Name == name);

        if (device == null)
        {
            Console.WriteLine($"Device with name '{name}' not found.");
            return;
        }

        var propertyInfo = device.GetType().GetProperty(property);

        if (propertyInfo == null)
        {
            Console.WriteLine($"Property '{property}' not found in device '{name}'.");
            return;
        }

        try
        {
            object boxed = device; 

            var convertedValue = Convert.ChangeType(newValue, propertyInfo.PropertyType);
            propertyInfo.SetValue(boxed, convertedValue);

            Console.WriteLine($"Successfully updated {property} of '{name}' to '{newValue}'");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to update property '{property}' of '{name}'. Error: {e.Message}");
        }
    }

    public void TurnOn(string name)
    {
        var d = devices.Find(x => x.Name == name);
        if (d != null)
        {
            try
            {
                d.TurnOn();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public void TurnOff(string name)
    {
        var d = devices.Find(x => x.Name == name);
        if (d != null) d.TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in devices)
        {
            Console.WriteLine(device);   
        }
    }

    public List<Device> GetDevices()
    {
        return devices;
    }
}