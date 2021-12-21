using OrmLight.Enums;
using OrmLight.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrmLight.Example
{
    class ExampleAccessLayer : IDataAccessLayer
    {
        private List<Product> _Products = new List<Product>()
        {
            new Product() { Id = 1, Category = "clothes", Name = "jacket", Price = 90 },
            new Product() { Id = 2, Category = "clothes", Name = "gloves", Price = 15 },
            new Product() { Id = 3, Category = "clothes", Name = "hat", Price = 25 },

            new Product() { Id = 4, Category = "dishes", Name = "cup", Price = 5 },
            new Product() { Id = 5, Category = "dishes", Name = "plate", Price = 15 },
            new Product() { Id = 6, Category = "dishes", Name = "spoon", Price = 10 },
            new Product() { Id = 7, Category = "dishes", Name = "fork", Price = 10 }
        };

        public QueryableSource<TEntity> Get<TEntity>()
        {
            return new QueryableSource<TEntity>(this, Operation.Read);
        }
    }
}
