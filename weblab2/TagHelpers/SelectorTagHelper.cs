using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.Encodings.Web;
namespace weblab2.TagHelpers
{
    public class SelectorTagHelper : TagHelper
    {
        private List<string> operations;
        public string Name { get; set; }
        public string Default { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            operations = new List<string>() { "+", "-", "*", "/" };

            output.TagName = "select";
            output.Attributes.SetAttribute("name", Name);
            foreach (string item in this.operations)
            {
                output.Content.AppendHtml(this.generateOptions(item).ToString());
            }
            output.TagMode = TagMode.StartTagAndEndTag;
        }
        private IHtmlContent generateOptions(string item)
        {
            TagBuilder optionTag = new TagBuilder("option");
            optionTag.MergeAttribute("value", item);
            optionTag.InnerHtml.Append(item);
            if (this.Default == item)
            {
                optionTag.MergeAttribute("selected", "selected");
            }
            var writer = new System.IO.StringWriter();
            optionTag.WriteTo(writer, HtmlEncoder.Default);
            return new HtmlString(writer.ToString());
        }
    }
}

