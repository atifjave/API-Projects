using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.Entity.Validation;
using DAL;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Models;

namespace DAL.GenericRepository
{
    class GenericRepository<T> : IGenericRepository<T>, IDisposable where T : class
    {
        private DbSet<T> table;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        private AngularEntities context;

        public GenericRepository(AngularEntities context)
        {
            _isDisposed = false;
            Context = context;
        }

        //public GenericRepository(EmployeeDBEntities context)
        //{
        //    this.context = context;
        //}

        protected virtual IDbSet<T> Entities
        {
            get { return table ?? (table = Context.Set<T>()); }
        }
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }


        public AngularEntities Context { get; set; }

        public IList<T> GetAll()
        {
            return Entities.ToList();

        }
        public void Insert(T employee)
        {
            try
            {
                if (employee == null)
                    throw new ArgumentNullException("entity");
                Entities.Add(employee);
                if (Context == null || _isDisposed)
                    Context = new AngularEntities();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + Environment.NewLine;
                throw new Exception(_errorMessage, dbEx);
            }
        }
        public T GetById(object id)
        {
            return Entities.Find(id);
        }

        public void Delete(T id)
        {
            try
            {
                if (id == null)
                    throw new ArgumentNullException("entity");
                if (Context == null || _isDisposed)
                    Context = new AngularEntities();
                Entities.Remove(id)
;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        _errorMessage += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                throw new Exception(_errorMessage, dbEx);
            }
        }

    }
}
