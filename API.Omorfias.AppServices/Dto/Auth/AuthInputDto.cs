using System.Runtime.Serialization;

namespace API.Omorfias.AppServices.Dto.Login
{
    public class AuthInputDto
    {

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "password")]
        public string Password { get; set; }
    }
}
