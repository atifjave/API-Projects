using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DAL.EmployeeRepository
{
    interface IEmployeeRepository
    {
        IEnumerable<Empolyee> GetAll();
        

    }
}
