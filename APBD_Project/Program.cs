using APBD_Project;

IDeviceFileLoader loader = new DeviceFileLoader("files/input.txt");
IDeviceFileSaver saver = new DeviceFileSaver("files/output.txt");
DeviceManager dm = new DeviceManager(loader);

//printing all the devices
dm.ShowAllDevices();

//removing the device
dm.RemoveDevice("Apple Watch SE2");


//creating new devices
PersonalComputer pc = new PersonalComputer
{
    Id = 3, Name = "MacPro", IsTurnedOn = false, OperatingSystem = "macOS"
};

Smartwatch sw = new Smartwatch
{
    Id = 2, Name = "Xiaomi Band 6", BatteryLevel = 54,
    IsTurnedOn = false
};

//editing a device
dm.EditDevice("LinuxPC", "IsTurnedOn", false);

dm.ShowAllDevices();

//adding the created devices
dm.AddDevice(pc);
dm.AddDevice(sw);

//turning on the devices
dm.TurnOn("ThinkPad T440");
dm.TurnOn("LinuxPC");
dm.TurnOn("Pi4");
dm.TurnOn("Pi3");

//saving the devices
saver.SaveDevices(dm.GetDevices());

dm.ShowAllDevices();