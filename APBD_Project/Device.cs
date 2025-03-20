namespace APBD_Project;

abstract class Device
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsTurnedOn { get; set; }
    
    public abstract void TurnOn();
    public void TurnOff() => IsTurnedOn = false;

    public abstract override string ToString();
}