using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Domain.Base.Interfaces
{
    public interface IHandler<T> : IDisposable where T : IDomainEvent
    {
        void Handle(T args);
        IEnumerable<T> Notify();
        bool HasNotifications();
        List<T> GetValues();
    }
}
