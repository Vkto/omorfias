using API.Omorfias.Data.Enumerator;

namespace API.Omorfias.Data.Models
{
    public class Services
    {
        public int Id { get; set; }
        public CategoryEnum CategoryEnum { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
    }
}