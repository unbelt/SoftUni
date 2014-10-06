namespace GenericList
{
    using System;

    public class GenericListTest
    {
        public static void Main()
        {
            var list = new GenericList<int>();

            var attributes = typeof(GenericList<>).GetCustomAttributes(typeof(VersionAttribute), false);
            Console.WriteLine("Version: {0}", ((VersionAttribute)attributes[0]).Version + Environment.NewLine);

            list.AddElement(3);
            list.AddElement(5);
            list.AddElement(12);
            Console.WriteLine("Add elements: {0}", list + Environment.NewLine);

            Console.WriteLine("Get element at index [0] \r\n{0}",
                list[0] + Environment.NewLine);

            list.RemoveElementAtIndex(1);
            Console.WriteLine("Remove element at index [1] \r\n{0}",
                list + Environment.NewLine);

            list.InsertElementAtIndex(2, -3);
            Console.WriteLine("Insert '-3' at index [2] \r\n{0}",
                list + Environment.NewLine);

            Console.WriteLine("Find element '-3' \r\n{0}",
                list.FindElementByValue(-3) + Environment.NewLine);

            Console.WriteLine("STATISTICS \r\nElements count: {0} \r\nMin element: {1} \r\nMax element: {2}",
                list.Count, list.Min(), list.Max() + Environment.NewLine);

            list.ClearList();
            Console.WriteLine("Clear the list \r\nList count: {0}", list.Count);
        }
    }
}