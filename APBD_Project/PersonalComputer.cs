namespace APBD_Project;

class PersonalComputer : Device
{
    public string OperatingSystem { get; set; }

    public override void TurnOn()
    {
        if (string.IsNullOrEmpty(OperatingSystem)) 
            throw new EmptySystemException("Operating system isn't installed");
        IsTurnedOn = true;
        Console.WriteLine("Personal computer is turned on");
    }
    
    public override string ToString()
    {
        return $"Personal computer Id: {Id}, Name: {Name}, Is turned on: {IsTurnedOn}, " +
               $"Operating system: {OperatingSystem}";
    }
}