namespace APBD_Project;
/// <summary>
/// Additional information about the SmartWatch (i.e. battery)
/// </summary>
public class Smartwatch : Device, IPowerNotifier
{
    private int _batteryLevel;

    public int BatteryLevel
    {
        get => _batteryLevel;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException("Battery level must be between 0 and 100");
            _batteryLevel = value;
            if (_batteryLevel < 20)
                NotifyBattery();
        }
    }

    public void NotifyBattery()
    {
        Console.WriteLine($"Battery level is low: {_batteryLevel}");
    }

    public override void TurnOn()
    {
        if (BatteryLevel < 11) 
            throw new EmptyBatteryException("Cannot be turned on: battery level is too low");
        base.TurnOn();
        _batteryLevel -= 10;
    }

    public override string ToString()
    {
        return base.ToString() + $", Battery Level: {_batteryLevel}";
    }
}

