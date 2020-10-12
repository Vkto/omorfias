using API.Omorfias.Domain.Interfaces.Validations.Services;
using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Models
{
    public class UserDomain : ISelfValidation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

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
