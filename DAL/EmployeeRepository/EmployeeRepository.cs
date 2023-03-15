using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EmployeeRepository
{
   public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AngularEntities _context;

        public EmployeeRepository()
        {
            _context = new AngularEntities();
        }

        public EmployeeRepository(AngularEntities context)
        {
            _context = context;
        }

        public IEnumerable<Empolyee> GetAll()
        {
            return _context.Empolyees.ToList();
        }

    }
}
