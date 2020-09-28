using API.Omorfias.Domain.Interfaces.Validations.Services;
using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Models
{
    public class User : ISelfValidation
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ValidationResult ValidationResult { get; private set; }
        public bool IsValid
        {
            get
            {
                return true;
            }
        }

    }
}
