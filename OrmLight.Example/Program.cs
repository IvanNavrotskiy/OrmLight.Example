using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using OrmLight.Linq;

namespace OrmLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var dal = new ExampleAccessLayer();

            dal.Insert<Product>(new Product() { Category = "dishes", Name = "knife", Price = 20 });

            var purelinqExample = dal.Get<Product>().Where(x => x.Category =="dishes")
                .OrderByDescending(x => x.Id).GetQueryInfo();

            var ormLightLinqExample = dal
                .Get<Product>()
                .AddCondition(x => x.Category.Equals("dishes") || x.Category == "clothes" || x.Id == 41)
                .AddSort(x => x.Name)
                .AddSort(x => x.Id, isDescending: true)
                .AddSortByDescending(x => x.Price)
                .AddLimit(count: 3, offset: 1)
                .AddOffset(1)
                .Execute();
                //.GetQueryInfo();

            var query1 = dal
                .Get<Product>()
                .AddCondition(x => x.Category.Equals("dishes") || x.Category == "clothes" || x.Id == 41)
                .AddSort(x => x.Name)
                .AddSort(x => x.Id, isDescending: true)
                .AddSortByDescending(x => x.Price);

            var info1 = query1.GetQueryInfo();

            var info2 = query1.AddLimit(30, 0).GetQueryInfo();

            var info3 = query1.AddLimit(count: 3, offset: 1)
                .AddOffset(2)
                .GetQueryInfo();

            Console.ReadKey();
        }
    }
}
