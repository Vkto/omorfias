using API.Omorfias.Data.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.AppServices.Dto.Services
{
    public class ServicesOutputDto
    {

        public int Id { get; set; }
        public CategoryEnum CategoryEnum { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

    }
}
