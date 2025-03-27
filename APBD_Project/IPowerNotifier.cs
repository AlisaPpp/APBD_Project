namespace APBD_Project;
/// <summary>
/// Responsible for notifying when the battery on the SmartWatch is too low
/// </summary>
interface IPowerNotifier
{
    void NotifyBattery();
}