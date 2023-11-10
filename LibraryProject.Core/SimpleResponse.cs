namespace LibraryProject.Application
{
    public class SimpleResponse
    {
        public string Message { get; set; }

        public SimpleResponse(string message)
        {
            Message = message;
        }
    }
}
