using API.Omorfias.Data.Enumerator;
using System;

namespace API.Omorfias.Data.Models
{
    public class Scheduling
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime CreateDate { get; set; }
        public ServiceLocationEnum ServiceLocation { get; set; }

        #region
        public virtual Card Card { get; set; }
        #endregion
    }
}