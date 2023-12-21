public class WrongTypeException : Exception
{
    public WrongTypeException()
    {
        Console.WriteLine("Wrong file type exception");
    }
    public WrongTypeException(string message)
    : base(message)
    {
    }

    public WrongTypeException(string message, Exception inner)
        : base(message, inner)
    {
    }
}