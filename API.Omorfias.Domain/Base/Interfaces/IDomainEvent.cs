using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Base.Interfaces
{
    public interface IDomainEvent
    {
        int Version { get; }
        DateTime OccurrenceDate { get; }
    }
}
