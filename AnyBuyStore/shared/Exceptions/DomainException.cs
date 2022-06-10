namespace AnyBuyStore.shared.Exceptions
{
    public abstract class DomainException :System.Exception
    {
        public DomainException(string message) : base(message)
        {

        }
    }

    public class DomainNotFoundException : DomainException
    {
        public DomainNotFoundException(string message):base(message)
        {

        }
    }
    public class ValidationException : DomainException
    {
        public ValidationException(string message) : base(message)
        {

        }
    }

}
