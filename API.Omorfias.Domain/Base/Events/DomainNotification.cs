using API.Omorfias.Domain.Base.Interfaces;
using System;

namespace API.Omorfias.Domain.Base.Events
{
    public class DomainNotification : IDomainEvent
    {
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DateTime OccurrenceDate { get; private set; }
        public int Version { get; private set; }

        public DomainNotification(string key, string value)
        {
            this.Version = 1;
            this.Key = key;
            this.Value = value;
            this.OccurrenceDate = DateTime.Now;
        }
    }
}
