using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.UnitofWork
{
    public interface IUnitofWork
    {
        AngularEntities Context { get; }
        void CreateTransaction();
        void Rollback();
        void Commit();
        void Save();
    }
}
