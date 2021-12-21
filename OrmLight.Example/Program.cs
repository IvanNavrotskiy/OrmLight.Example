using System;
using System.Collections.Generic;
using OrmLight.Linq;

namespace OrmLight.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Product>();

            var res = list.AddCondition(x => x.Id == 1).AddSort(x => x.Id, isDescending:true).Execute();

            Console.ReadKey();
        }
    }
}
