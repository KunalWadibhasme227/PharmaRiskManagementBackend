namespace Common.Exceptions
{
    public class RecordNotFoundException(string message = "Record not found.") : Exception(message);
}
