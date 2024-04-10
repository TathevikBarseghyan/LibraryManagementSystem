using System.Collections.Generic;

namespace testing
{
    internal class Program
    {
        static IEnumerable<int> GenerateWithoutYield()
        {
            var i = 0;
            var list = new List<int>();
            while (i < 5)
                list.Add(++i);
            return list;
        } 

        static IEnumerable<int> GenerateWithYield()
        {
            var i = 0;
            while (i < 5)
                yield return ++i;
        }

      
        static void Main(string[] args)
        {
            //foreach(var number in GenerateWithoutYield())
            //    Console.WriteLine(number);

            //foreach (var number in GenerateWithYield())
            //    Console.WriteLine(number);

        }
    }
}