using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Learn.HtmlHelpers.App_Code
{
    public static class ListHelper
    {
        public static HtmlString CreateList(this IHtmlHelper html, string[] items)
        {
            string result = "<ul>";

            foreach (string item in items) { result += $"<li>{item}</li>"; }

            result += "</ul>";

            return new HtmlString(result);
        }

        // Пример использования TagBuilder, он упрощает работу с тегами.
        public static HtmlString CreateListWithTagBuilder(this IHtmlHelper html, string[] items)
        {
            TagBuilder ul = new TagBuilder("ul");
            foreach (var item in items)
            {
                TagBuilder li = new TagBuilder("li");
                // Добавляет элемент в <li>
                li.InnerHtml.Append(item);
                // Добавляет элемент в <ul>
                ul.InnerHtml.AppendHtml(li);
            }
            ul.Attributes.Add("class", "itemsList");
            var writer = new StringWriter();
            ul.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}
