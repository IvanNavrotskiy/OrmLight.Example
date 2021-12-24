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

            //Expression<Func<Product, bool>> lambda = x => x.Category == "dishes";
            Expression<Func<Product, bool>> lambda = x => x.Category == "dishes";




            //dal.Get<Product>().AddCondition(x => x.Category.Equals("dishes")).AddSort(x => x.Id, isDescending: false).AddLimit(3, 1).Execute();



            dal.Get<Product>().AddCondition(x => x.Category.Equals("dishes")).Execute();
            //dal.Get<Product>().Where(x => x.Category =="dishes").OrderByDescending(x => x.Id).ToList();

            Console.ReadKey();
        }
    }
}
