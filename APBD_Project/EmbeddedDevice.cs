using System.Text.RegularExpressions;

namespace APBD_Project;

/// <summary>
/// This class rovides additional information about the Embedded Devices, such as their IP address and Network Name
/// </summary>
public class EmbeddedDevice : Device, IConnectable
{
    private string ipAddress;
    public string NetworkName { get; set; }

    public string IpAddress
    {
        get => ipAddress;
        set
        {
            if(!Regex.IsMatch(value, @"^([0-9]{1,3}\.){3}[0-9]{1,3}$"))
                throw new ArgumentException("Invalid IP Address");
            
            string[] octets = value.Split('.');
            foreach (var octet in octets)
            {
                try
                {
                    int num = int.Parse(octet);
                    if (num < 0 || num > 255)
                        throw new ArgumentException("Each octet of the IP address must be between 0 and 255.");
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Invalid IP Address. Octet is not a valid number.");
                }
            }
            ipAddress = value;
        }
    }

    public override void TurnOn()
    {
        base.TurnOn();
        Connect();
    }

    public void Connect()
    {
        if(!NetworkName.Contains("MD Ltd."))
            throw new ConnectionException("Cannot connect to network that is not MD Ltd.");
        Console.WriteLine("Connected to network");
    }
    
    public override string ToString()
    {
        return base.ToString() + $"IP address: {IpAddress}, Network name: {NetworkName}";
    }
}