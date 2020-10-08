namespace API.Omorfias.Domain.Handler
{
    public class ErrorAction
    {
        public int _Status;
        public string _Message;

        public ErrorAction(int status, string message)
        {
            _Status = status;
            _Message = message;
        }
    }
}
