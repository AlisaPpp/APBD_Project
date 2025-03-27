namespace APBD_Project;
/// <summary>
/// An abstract class that serves as a base for all of the devices
/// </summary>
public abstract class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }

    public virtual void TurnOn()
    {
        if (IsTurnedOn)
        {
            Console.WriteLine($"The device {Name} is already turned on");
            return;
        }
        IsTurnedOn = true;
        Console.WriteLine($"The device {Name} is turned on");
    }
    public void TurnOff()
    {
        if (IsTurnedOn == false)
        {
            Console.WriteLine($"The device {Name} is already turned off");
            return;
        }
        IsTurnedOn = false;
        Console.WriteLine($"The device {Name} is turned off");
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Is turned on: {IsTurnedOn}";
    }
}