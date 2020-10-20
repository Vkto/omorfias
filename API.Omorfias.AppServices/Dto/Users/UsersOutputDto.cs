using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Dto.Users
{
    public class UsersOutputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

    }
}
