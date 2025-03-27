namespace APBD_Project;
/// <summary>
/// Additional information about the PersonalComputer device, such as the operating system
/// </summary>
public class PersonalComputer : Device
{
    public string OperatingSystem { get; set; }

    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(OperatingSystem)) 
            throw new EmptySystemException("Operating system isn't installed");
        base.TurnOn();
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Operating system: {OperatingSystem}";
    }
}