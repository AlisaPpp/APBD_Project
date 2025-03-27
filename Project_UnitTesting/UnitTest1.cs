using APBD_Project;

namespace Project_UnitTesting;

public class Tests
{
    private readonly string path = "/Users/alice/RiderProjects/APBD_Project/APBD_Project/files/input.txt";

    [Test]
    public void LoadFileTest()
    {
        DeviceManager dm = new DeviceManager(path);

        var output = new StringWriter();
        Console.SetOut(output);
        dm.ShowAllDevices();

        string expected = "Smartwatch Id: 1, Name: Apple Watch SE2, Is turned on: True, Battery Level: 27\n" +
                          "Personal computer Id: 1, Name: LinuxPC, Is turned on: False, Operating system: Linux Mint\n" +
                          "Personal computer Id: 2, Name: ThinkPad T440, Is turned on: False, Operating system: \n" +
                          "Embedded device Id: 1, Name: Pi3, Is turned on: False, IP address: 192.168.1.44, Network name: MD Ltd.Wifi-1\n" +
                          "Embedded device Id: 2, Name: Pi4, Is turned on: False, IP address: 192.168.1.45, Network name: eduroam\n";
        
        Assert.AreEqual(expected, output.ToString());
        
    }
    
    [Test]
    
    
}