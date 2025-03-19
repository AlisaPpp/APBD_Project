using System.Text.RegularExpressions;

namespace APBD_Project;

class EmbeddedDevice : Device
{
    private string ipAddress;
    public string NetworkName { get; set; }

    public string IpAddress
    {
        get => ipAddress;
        set
        {
            if(!Regex.IsMatch(value, @"^\d{1,3}\.\d{1,3}\.\d{1,3}$"))
                throw new ArgumentException("Invalid IP Address");
            ipAddress = value;
        }
    }

    public override void TurnOn()
    {
        Connect();
        IsTurnedOn = true;
        Console.WriteLine("Embedded device is turned on");
    }

    public void Connect()
    {
        if(!NetworkName.Contains("MD Ltd."))
            throw new ConnectionException("Cannot connect to network that is not MD Ltd.");
        Console.WriteLine("Connected to network");
    }
}