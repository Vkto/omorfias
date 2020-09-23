using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
