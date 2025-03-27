using APBD_Project;
namespace Project_UnitTests;
using Xunit;


public class DeviceManagerTest
{

    private string path = "files/input.txt";
    private string outputPath = "files/output.txt";

    private class Loader : IDeviceFileLoader
    {
        public List<Device> LoadDevices()
        {
            return new List<Device>
            {
                new Smartwatch { Id = 1, Name = "Apple Watch SE2", BatteryLevel = 27, IsTurnedOn = true },
                new PersonalComputer { Id = 1, Name = "LinuxPC", IsTurnedOn = false, OperatingSystem = "Linux Mint" },
                new EmbeddedDevice { Id = 1, Name = "Pi4", IpAddress = "192.168.1.44", NetworkName = "MD Ltd.Wifi-1" }
            };
        }
    }
    
    private DeviceManager CreateManager()
    {
        return new DeviceManager(new Loader());
    }
    
    
    

    [Fact]
    public void AddDeviceTest()
    {
        var dm = CreateManager();
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
        var dm = CreateManager();
        dm.RemoveDevice("LinuxPC");
        Assert.DoesNotContain(dm.devices, s => s.Name == "LinuxPC");
    }

    [Fact]
    public void EditDeviceTest()
    {
        var dm = CreateManager();
        dm.EditDevice("LinuxPC", "IsTurnedOn", true);
        Assert.Contains(dm.devices, s => s.Name == "LinuxPC" && s.IsTurnedOn == true);
    }

    [Fact]
    public void TurnOnDeviceTest()
    {
        var dm = CreateManager();
        dm.TurnOn("LinuxPC");
        Assert.True(dm.devices.Find(s => s.Name == "LinuxPC").IsTurnedOn);
    }

    [Fact]
    public void TurnOffDeviceTest()
    {
        var dm = CreateManager();
        dm.TurnOff("Apple Watch SE2");
        Assert.False(dm.devices.Find(s => s.Name == "Apple Watch SE2").IsTurnedOn);
    }
}