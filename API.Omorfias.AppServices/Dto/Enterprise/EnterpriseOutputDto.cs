using API.Omorfias.AppServices.Dto.Services;
using API.Omorfias.Data.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Dto.Users
{
    public class EnterpriseOutputDto
    {
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

        public List<ServicesOutputDto> Services { get; set; }

    }
}
