namespace UniAtHome.BLL.DTOs
{
    public class OperationError
    {
        public OperationError(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }
}
