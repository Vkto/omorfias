using System.Collections;
using System.Collections.Generic;

namespace API.Omorfias.Data.Models
{
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
            Enterprises = new List<Enterprise>();
            Schedulings = new List<Scheduling>();
            Favorites = new List<Favorites>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        #region Foreing Keys
        public virtual AccountType AccountType { get; set; }
        public virtual Premium Premium { get; set; }
        public virtual Card Card { get; set; }
        public virtual List<Post> Posts { get; set; }
        public virtual List<Enterprise> Enterprises { get; set; }
        public virtual List<Scheduling> Schedulings { get; set; }
        public virtual List<Favorites> Favorites { get; set; }
        #endregion
    }
}
