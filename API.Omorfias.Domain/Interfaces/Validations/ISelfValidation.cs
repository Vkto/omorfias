using API.Omorfias.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Interfaces.Validations.Services
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
