using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilder
{
    public class HtmlElement
    {
        public string name, text;
        public List<HtmlElement> htmlElements = new List<HtmlElement>();
        private const int indentSize = 2;
        public HtmlElement()
        {

        }
        public HtmlElement(string name, string text)
        {
            this.name = name;
            this.text = text;
        }

        private string ToStringImplementation(int indent)
        {
            var sb = new StringBuilder();
            var i = new String(' ', indent * indentSize);
            sb.AppendLine($"{i}<{name}>");
            if (!string.IsNullOrWhiteSpace(text))
            {
                sb.Append(new String(' ', indentSize * (indent + 1)));
                sb.AppendLine(text);
            }
            foreach (HtmlElement element in htmlElements)
            {
                sb.Append(element.ToStringImplementation(indent + 1));
            }
            sb.AppendLine($"{i}</{name}>");
            return sb.ToString();
        }
        public override string ToString()
        {
            return ToStringImplementation(0);
        }
    }
    public class HTMLBuilder
    {
        private readonly string rootName;
        HtmlElement root = new HtmlElement();

        public HTMLBuilder(string rootName)
        {
            this.rootName = rootName;
            root.name = rootName;
        }
        //here I have changed the method return type void to HtmlElement so that we'll be able to chaing the method
        public HTMLBuilder AddChild(string ChildName, string ChildText)
        {
            var e = new HtmlElement(ChildName, ChildText);
            root.htmlElements.Add(e);
            return this;
        }
        public override string ToString()
        {
            return root.ToString();
        }
        public void Clear()
        {
            root = new HtmlElement { name = rootName };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            var hello = "Hello";
            var sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append(hello);
            sb.Append("</p>");
            Console.WriteLine(sb);

            var words = new[] { "hello", "world" };
            sb.Clear();
            sb.Append("<ul>");
            foreach (var word in words)
            {
                sb.AppendFormat("<li>{0}</li>", word);
            }
            sb.Append("</ul>");
            Console.WriteLine(sb);

            var builder = new HTMLBuilder("ul");
            builder.AddChild("li", "hello");
            //add child by just chaining
            builder.AddChild("li", "world").AddChild("li","India");
            Console.WriteLine(builder.ToString());
            Console.ReadKey();
        }
    }
}
