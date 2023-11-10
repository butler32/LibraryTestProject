namespace LibraryProject.Domain.Exceptions
{
    public class EntityAlreadyExistsException : Exception
    {
        public EntityAlreadyExistsException(string message = "Entity already exist") : base(message)
        {
        }
    }
}
