using APBD_Project;

namespace Project_UnitTests;


public class DeviceManagerTest
{

    private string path = "files/input.txt";
    
    [Fact]
    public void LoadFileTest()
    {
        DeviceManager dm = new DeviceManager(path);

        var output = new StringWriter();
        Console.SetOut(output);
        dm.ShowAllDevices();
        
        var result = output.ToString();
        Assert.Contains("LinuxPC", result);
        Assert.Contains("Apple Watch SE2", result);
        
    }

    [Fact]
    public void AddDeviceTest()
    {
        DeviceManager dm = new DeviceManager(path);
        Smartwatch sw = new Smartwatch
        {
            Id = 2, Name = "Xiaomi Band 6", BatteryLevel = 54,
            IsTurnedOn = false
        };
        
        dm.AddDevice(sw);
        
        Assert.Contains(dm.devices, s => s.Name == "Xiaomi Band 6");
    }

    [Fact]
    public void RemoveDeviceTest()
    {
        DeviceManager dm = new DeviceManager(path);
        dm.RemoveDevice("LinuxPC");
        Assert.DoesNotContain(dm.devices, s => s.Name == "LinuxPC");
    }

    [Fact]
    public void EditDeviceTest()
    {
        DeviceManager dm = new DeviceManager(path);
        dm.EditDevice("LinuxPC", "IsTurnedOn", true);
        Assert.Contains(dm.devices, s => s.Name == "LinuxPC" && s.IsTurnedOn == true);
    }

    [Fact]
    public void TurnOnDeviceTest()
    {
        DeviceManager dm = new DeviceManager(path);
        dm.TurnOn("LinuxPC");
        Assert.True(dm.devices.Find(s => s.Name == "LinuxPC").IsTurnedOn);
    }

    [Fact]
    public void TurnOffDeviceTest()
    {
        DeviceManager dm = new DeviceManager(path);
        dm.TurnOff("Apple Watch SE2");
        Assert.False(dm.devices.Find(s => s.Name == "Apple Watch SE2").IsTurnedOn);
    }

    [Fact]
    public void SaveToFileTest()
    {
        DeviceManager dm = new DeviceManager(path);
        string outputpath = "files/output.txt";
        dm.SaveToFile(outputpath);
        
        string[] lines = File.ReadAllLines(outputpath);
        string line = lines[0];
        Assert.Contains("Apple Watch SE2", line);
    }
}