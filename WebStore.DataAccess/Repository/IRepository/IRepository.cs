using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //Generic type, T. Must be public!
    {
        //T - Category or any other generic model upon we want to perform crud op. 
        IEnumerable<T> GetAll(); //The first thing we need is to display all categories
        //On ex. edit we need to retrieve the details of one category. so we need:
        T Get(Expression<Func<T, bool>> filter); //Fetching only one. General syntax for "first or default". (u => u.Id == id)
        void Add(T entity);
        //void Update(T entity); we dont use update here because updating category-logic might different from updating product-logic
        void Remove(T entity); //can also use delete instead of remove
        void RemoveRange(IEnumerable<T> entity);
      
    }
}
