using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Library.Domain.Entities;

namespace Library.Web.CustomTagHelper
{
    [HtmlTargetElement("table", Attributes = "items")]
    public class TableTagHelper : TagHelper
    {
        public dynamic Items { get; set; }
        public List<TableColumn> Columns { get; set; }

        public string IdUpdateModal { get; set; }

         public override void Process(TagHelperContext context, TagHelperOutput output)
         {
            var thead = new TagBuilder("thead");

            var headerRow = new TagBuilder("tr");
            foreach (var column in Columns)
            {
                var th = new TagBuilder("th");
                th.InnerHtml.Append(column.Title);
                headerRow.InnerHtml.AppendHtml(th);
            }
            thead.InnerHtml.AppendHtml(headerRow);

            var tbody = new TagBuilder("tbody");
            foreach (var item in Items)
            {
                var row = new TagBuilder("tr");
                row.Attributes.Add("onclick", $"openUpdateModal('{IdUpdateModal}', '{item.Id}')");
                foreach (var column in Columns)
                {
                    var td = new TagBuilder("td");
                    var value = item.GetType().GetProperty(column.Property)?.GetValue(item);
                    if (value is IEnumerable<object> enumerable && value is not string)
                    {
                        var items = enumerable.Cast<object>().Select(x => x?.ToString() ?? "");
                        value = string.Join(", ", items);
                    }
                    td.InnerHtml.AppendHtml(value?.ToString() ?? string.Empty);
                    row.InnerHtml.AppendHtml(td);
                }
                tbody.InnerHtml.AppendHtml(row);
            }

            output.Content.AppendHtml(thead);
            output.Content.AppendHtml(tbody);
         }
    }

    public class TableColumn
    {
        public string Title { get; set; }
        public string Property { get; set; }
    }
}
