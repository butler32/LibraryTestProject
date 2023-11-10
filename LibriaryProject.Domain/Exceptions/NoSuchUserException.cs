namespace LibraryProject.Domain.Exceptions
{
    public class NoSuchUserException : Exception
    {
        public NoSuchUserException(string message = "User not found") : base(message)
        {
        }
    }
}
