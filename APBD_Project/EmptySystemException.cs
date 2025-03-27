namespace APBD_Project;
/// <summary>
/// Is thrown when a Personal Computer does not have an operating system
/// </summary>
public class EmptySystemException : Exception
{
    public EmptySystemException(string msg) : base(msg) { }
}