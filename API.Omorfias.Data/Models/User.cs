﻿using API.Omorfias.Data.Enumerator;

namespace API.Omorfias.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //public AccountType AccountType { get; set; }

    }
}