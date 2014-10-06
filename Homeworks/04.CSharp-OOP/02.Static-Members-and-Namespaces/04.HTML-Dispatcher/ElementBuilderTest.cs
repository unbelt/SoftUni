namespace HTML_Dispatcher
{
    using System;

    public class ElementBuilderTest
    {
        public static void Main()
        {
            // Create anchor element
            var element = new ElementBuilder("a");
            element.AddAttribute("href", "www.softuni.bg");
            element.AddAttribute("class", "link");
            element.AddContent("Test Content");
            Console.WriteLine(element + Environment.NewLine);

            // Create and copy div element
            var div = new ElementBuilder("div");
            Console.WriteLine((div * 2) + Environment.NewLine);

            // Shorthand element creator
            Console.WriteLine(ElementBuilder.CreateImage("www.softuni.bg/logo.png", "SoftUni Logo", "SoftUni"));
            Console.WriteLine(ElementBuilder.CreateURL("www.softuni.bg", "SoftUni Website", "Learn how to write OOP in C# here!"));
            Console.WriteLine(ElementBuilder.CreateInput("input", "register", "Register") + Environment.NewLine);

            // Empty element test case
            // try
            // {
            //     new ElementBuilder("");
            // }
            // catch (ArgumentNullException e)
            // {
            //     Console.WriteLine(e);
            // }
        }
    }
}