public class UnableToOpenFileException : Exception
{
    public UnableToOpenFileException()
    {
        Console.WriteLine("Unable to open file exception");
    }
    public UnableToOpenFileException(string message)
    : base(message)
    {
    }

    public UnableToOpenFileException(string message, Exception inner)
        : base(message, inner)
    {
    }
}