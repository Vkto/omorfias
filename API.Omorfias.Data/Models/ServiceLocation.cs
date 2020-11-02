using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Data.Models
{
    public class ServiceLocation
    {
        public int Id { get; set; }
        public bool Home { get; set; }
        public bool Store { get; set; }
        public bool Both { get { return this.Home && this.Store; } }

    }
}
