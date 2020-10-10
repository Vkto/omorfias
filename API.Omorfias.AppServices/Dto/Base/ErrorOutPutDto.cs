using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Dto.Base
{
    public class ErrorOutPutDto
    {
        public int Status;
        public string Message;
        

        public ErrorOutPutDto(int status, string message)
        {
            Status = status;
            Message = message;
        }
    }
}
