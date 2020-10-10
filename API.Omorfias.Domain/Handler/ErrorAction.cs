using System;

namespace API.Omorfias.Domain.Handler
{
    public class ErrorAction : Exception
    {
        public int Status;
        public string Text;

        public ErrorAction(int status, string text)
        {
            Status = status;
            Text = text;
        }
    }
}
