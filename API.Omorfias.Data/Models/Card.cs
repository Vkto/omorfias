using API.Omorfias.Data.Enumerator;
using System;

namespace API.Omorfias.Data.Models
{
    public class Card
    {
        public int Id { get; set; }
        public decimal Number { get; set; }
        public string CardHolder { get; set; }
        public DateTime ExpirationDate  { get; set; }
        public int SecurityCode { get; set; }
        public CardTypeEnum CardType { get; set; }
    }
}