namespace ClassHierarchy
{
    using System;
    using System.Collections.Generic;

    public static class Printer
    {
        public static void Print(this IEnumerable<object> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item + Environment.NewLine);
            }
        }
    }
}