namespace APBD_Project;

class DeviceManager
{
    private const int max = 15;
    private List<Device> devices = new List<Device>();
    private string filePath;

    public DeviceManager(string filePath)
    {
        this.filePath = filePath;
        LoadFromFile();
    }

    private void LoadFromFile()
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found");
            return;
        }
        
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            try
            {
                if (devices.Count >= max)
                {
                    Console.WriteLine("There are " + max + " devices already. Storage is full.");
                    break;
                }

                var parts = line.Split(',');
                if (parts.Length < 2) continue;

                switch (parts[0][0])
                {
                    case 'S':
                        int battery = int.Parse(parts[3].TrimEnd('%'));
                        devices.Add(new Smartwatch
                        {
                            Id = int.Parse(parts[0].Substring(3)), Name = parts[1], BatteryLevel = battery,
                            IsTurnedOn = bool.Parse(parts[2])
                        });
                        break;
                    case 'P':
                        devices.Add(new PersonalComputer
                        {
                            Id = int.Parse(parts[0].Substring(2)), Name = parts[1], IsTurnedOn = bool.Parse(parts[2]),
                            OperatingSystem = parts.Length > 3 ? parts[3] : ""
                        });
                        break;
                    case 'E':
                        devices.Add(new EmbeddedDevice
                        {
                            Id = int.Parse(parts[0].Substring(3)), Name = parts[1], IpAddress = parts[2],
                            NetworkName = parts[3]
                        });
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in line: " + line + ", " + e.Message);
            }
        }
    }

    public void AddDevice(Device device)
    {
        if (devices.Count >= max)
        {
            Console.WriteLine("There are " + max + " devices already. Storage is full.");
            return;
        }
        devices.Add(device);
    }

    public void RemoveDevice(string Name)
    {
        int index = devices.FindIndex(x => x.Name == Name);
        
        if (index >= 0)
            devices.RemoveAt(index);
        else
            Console.WriteLine($"Device with name '{Name}' not found.");
    }

    public void EditDevice(string Name, string property, object newValue)
    {
        var device = devices.Find(x => x.Name == Name);

        if (device == null)
        {
            Console.WriteLine($"Device with name '{Name}' not found.");
            return;
        }

        var propertyInfo = device.GetType().GetProperty(property);

        if (propertyInfo == null)
        {
            Console.WriteLine($"Property '{property}' not found in device '{Name}'.");
            return;
        }

        try
        {
            object boxed = device; 

            var convertedValue = Convert.ChangeType(newValue, propertyInfo.PropertyType);
            propertyInfo.SetValue(boxed, convertedValue);

            Console.WriteLine($"Successfully updated {property} of '{Name}' to '{newValue}'");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Failed to update property '{property}' of '{Name}'. Error: {e.Message}");
        }
    }

    public void TurnOn(string Name)
    {
        var d = devices.Find(x => x.Name == Name);
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

    public void TurnOff(string Name)
    {
        var d = devices.Find(x => x.Name == Name);
        if (d != null) d.TurnOff();
    }

    public void ShowAllDevices()
    {
        foreach (var device in devices)
        {
            Console.WriteLine(device);   
        }
    }

    public void SaveToFile(string path)
    {
        List<string> lines = new List<string>();
        foreach (var device in devices)
        {
            lines.Add(device.ToString());
        }
        File.WriteAllLines(path, lines);
    }
}