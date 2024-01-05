using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodChasersModel.Dao
{
    public interface IGenericDeo<T> where T : class
    {
        public IQueryable<T> GetAll();

        public T GetById(string id);

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(string id);

        public void DeleteAll();
        

    }
}
