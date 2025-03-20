using APBD_Project;

DeviceManager dm = new DeviceManager("files/input.txt");

dm.ShowAllDevices();

dm.RemoveDevice("Apple Watch SE2");

PersonalComputer pc = new PersonalComputer
{
    Id = 3, Name = "MacPro", IsTurnedOn = false, OperatingSystem = "macOS"
};

Smartwatch sw = new Smartwatch
{
    Id = 2, Name = "Xiaomi Band 6", BatteryLevel = 54,
    IsTurnedOn = false
};

dm.EditDevice("LinuxPC", "IsTurnedOn", false);

dm.ShowAllDevices();

//Adding devices
dm.AddDevice(pc);
dm.AddDevice(sw);

//Turning on
dm.TurnOn("ThinkPad T440");
dm.TurnOn("LinuxPC");
dm.TurnOn("Pi4");
dm.TurnOn("Pi3");

dm.SaveToFile("files/output.txt");

dm.ShowAllDevices();