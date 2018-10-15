using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace electo.Models.Repositories
{
    public class UnitOfWork : IDisposable
    {
       

        public UnitOfWork()
        {
            //_context = new electoEntities();
        }
        
        public int Complete()
        {
            return 0;//return _context.SaveChanges();
        }

        public void Dispose()
        {
           // _context.Dispose();
        }
    }
}