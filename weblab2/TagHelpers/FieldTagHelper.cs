using Microsoft.AspNetCore.Razor.TagHelpers;

namespace weblab2.TagHelpers
{
    public class FieldTagHelper : TagHelper
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "input";
            output.Attributes.SetAttribute("type", "text");
            output.Attributes.SetAttribute("name",this.Name);
            if (this.Value!= "0") {
                output.Attributes.SetAttribute("value", this.Value);
            }
        }
    }
}
