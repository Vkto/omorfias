using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Userame { get; set; }
        public string Password{ get; set; }
        public string Role { get; set; }

    }
}
