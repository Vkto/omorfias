using API.Omorfias.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace API.Omorfias.Data.Base
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private OmorfiasContext _context;

        public UnitOfWork(OmorfiasContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
            if (_context == null) return;

            _context.Dispose();
            _context = null;
        }
    }
}
