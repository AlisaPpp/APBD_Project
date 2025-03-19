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
}