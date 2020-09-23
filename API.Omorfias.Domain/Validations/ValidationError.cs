using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Validations
{
    public class ValidationError
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
