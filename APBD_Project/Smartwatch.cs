namespace APBD_Project;

public class Smartwatch : Device, IPowerNotifier
{
    private int batteryLevel;

    public int BatteryLevel
    {
        get => batteryLevel;
        set
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException("Battery level must be between 0 and 100");
            batteryLevel = value;
            if (batteryLevel < 20)
                NotifyBattery();
        }
    }

    public void NotifyBattery()
    {
        Console.WriteLine($"Battery level is low: {batteryLevel}");
    }

    public override void TurnOn()
    {
        if (IsTurnedOn != false)
        {
            Console.WriteLine($"The device {Name} is already turned on");
        } else 
        {
            if (BatteryLevel < 11) throw new EmptyBatteryException("Cannot be turned on: battery level is too low");
            BatteryLevel -= 10;
            IsTurnedOn = true;
            Console.WriteLine("Smartwatch is turned on");
        }
    }

    public override string ToString()
    {
        return $"Smartwatch Id: {Id}, Name: {Name}, Is turned on: {IsTurnedOn}, Battery Level: {BatteryLevel}";
    }
}

