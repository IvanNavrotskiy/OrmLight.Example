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

            //dal.Get<Product>().Where(x => x.Category =="dishes").OrderByDescending(x => x.Id).ToList();

            var example = dal
                .Get<Product>()
                .AddCondition(x => x.Category.Equals("dishes") || x.Category == "clothes" || x.Id == 41)
                .AddSort(x => x.Name)
                .AddSort(x => x.Id, isDescending: true)
                .AddSortByDescending(x => x.Price)
                .AddLimit(count: 3, offset: 1)
                .AddOffset(1)
                .Execute();

            Console.ReadKey();
        }
    }
}
