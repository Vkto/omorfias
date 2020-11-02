using API.Omorfias.Data.Enumerator;
using System;
using System.Collections.Generic;

namespace API.Omorfias.Data.Models
{
    public class Enterprise
    {
        public Enterprise()
        {
            Services = new List<Services>();
            Scheduling = new List<Scheduling>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Evaluation { get; set; }
        public string Description { get; set; }
        public decimal Telephone { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int AverageValue { get; set; }
        public decimal? Cnpj { get; set; }
        public decimal? Cpf { get; set; }
        public CategoryEnum Category { get; set; }
        public string UrlImage { get; set; }

        #region Foreing keys
        public virtual ServiceLocation ServiceLocation { get; set; }
        public virtual Adress Adress { get; set; }
        public virtual List<Services> Services { get; set; }
        public virtual List<Scheduling> Scheduling { get; set; }

        #endregion

    }
}
