namespace HTML_Dispatcher
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ElementBuilder
    {
        private string element;
        private StringBuilder content = new StringBuilder();
        private StringBuilder attributes = new StringBuilder();

        public ElementBuilder(string element)
        {
            this.Element = element;
        }

        public string Element
        {
            get
            {
                return this.element;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Element", "The element cannot be null or white space!");
                }

                this.element = value;
            }
        }

        public static string operator *(ElementBuilder element, int copyTime)
        {
            var result = string.Concat(Enumerable.Repeat(element, copyTime));

            return result;
        }

        public static ElementBuilder CreateImage(string src = "", string alt = "", string title = "")
        {
            var image = new ElementBuilder("img");
            image.AddAttribute("src", src);
            image.AddAttribute("alt", alt);
            image.AddAttribute("title", title);

            return image;
        }

        public static ElementBuilder CreateURL(string url = "", string title = "", string text = "")
        {
            var link = new ElementBuilder("a");
            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);

            return link;
        }

        public static ElementBuilder CreateInput(string type = "", string name = "", string value = "")
        {
            var input = new ElementBuilder("input");
            input.AddAttribute("type", type);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);

            return input;
        }

        public void AddAttribute(string attribute, string value = null)
        {
            this.attributes.AppendFormat(" {0}=\"{1}\"", attribute, value);
        }

        public void AddContent(string content)
        {
            this.content.Append(content);
        }

        public override string ToString()
        {
            var print = new StringBuilder();

            print.AppendFormat("<{0}{1}>{2}</{3}>", this.Element, this.attributes, this.content, this.Element);

            return print.ToString();
        }
    }
}