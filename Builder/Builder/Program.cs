using System;
using System.Text;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<p>");
            sb.Append("hello");
            sb.Append("</p>");
            Console.WriteLine(sb);
            sb.Clear();
            sb.Append("<ul>");
            sb.Append("<li>list item 1</li>");
            sb.Append("<li>list item 2</li>");
            sb.Append("<li>list item 3</li>");
            sb.Append("</ul>");
            Console.WriteLine(sb);

            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            Console.WriteLine(builder.ToString());
        }
    }
}
