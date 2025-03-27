namespace APBD_Project;
/// <summary>
/// Is thrown when the Embedded Device fails to connect to the network
/// </summary>
public class ConnectionException : Exception
{
    public ConnectionException(string msg) : base(msg) { }
}