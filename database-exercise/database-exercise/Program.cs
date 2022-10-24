using database_exercise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database_exercise
{
    static class Extensions
    {
        public static void ToConsole<T>(this IEnumerable<T> input, string str)
        {
            Console.WriteLine("*** BEGIN " + str);
            foreach (T item in input)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("*** END " + str);
            Console.ReadLine();
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            CarDbContext ctx = new CarDbContext();
            ctx.Brands.Select(x => x.Name).ToConsole("BRANDS");
            ctx.Cars.Select(x => $"{x.Model} from {x.Brand.Name}").ToConsole("CARS");

            var q = from car in ctx.Cars
                    group car by new { car.BrandId, car.Brand.Name } into grp
                    select new { Brand = grp.Key, AvgPrice = grp.Average(x => x.BasePrice) };
            q.ToConsole("AVG PRICES");



        }
    }
}
