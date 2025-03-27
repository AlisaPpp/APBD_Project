namespace APBD_Project;
/// <summary>
/// This class serves as a factory for all the devices being processed and is reponsible for parsing info
/// about the devicees being loaded from the file
/// </summary>
public class DeviceFactory
{
    public static Device CreateDevice(string type, string[] parts)
    {
        return type switch
        {
            "SW" => new Smartwatch { Id = int.Parse(parts[0].Substring(3)), Name = parts[1], BatteryLevel = int.Parse(parts[3].TrimEnd('%')), IsTurnedOn = bool.Parse(parts[2]) },
            "P" => new PersonalComputer { Id = int.Parse(parts[0].Substring(2)), Name = parts[1], IsTurnedOn = bool.Parse(parts[2]), OperatingSystem = parts.Length > 3 ? parts[3] : "" },
            "ED" => new EmbeddedDevice { Id = int.Parse(parts[0].Substring(3)), Name = parts[1], IpAddress = parts[2], NetworkName = parts[3] },
            _ => throw new Exception("Unknown device type")
        };
    }
}