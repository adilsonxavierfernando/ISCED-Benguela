using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ISCED_Benguela.Encapsulamento
{
    [HtmlTargetElement("my-button")]
    public class Button:TagHelper
    {
        private readonly IHtmlGenerator _generator;

        public Button(IHtmlGenerator generator)
        {
            _generator = generator;
        }

        public string Text { get; set; }
        public string CssClass { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var button = new TagBuilder("button");
            button.AddCssClass(CssClass);
            button.Attributes.Add("onclick", "ShowConfirmationDialog();");
            button.InnerHtml.Append(Text);
            output.Content.AppendHtml(button);

            var script = new TagBuilder("script");
            script.InnerHtml.AppendHtml(@"
            function ShowConfirmationDialog() {
                swal(""A wild Pikachu appeared! What do you want to do?"", {
                    buttons: {
                        cancel: ""Run away!"",
                        catch: {
                            text: ""Throw Pokéball!"",
                            value: ""catch"",
                        },
                        defeat: true,
                    },
                })
                .then((value) => {
                    switch (value) {

                        case ""defeat"":
                            swal(""Pikachu fainted! You gained 500 XP!"");
                            break;

                        case ""catch"":
                            swal(""Gotcha!"", ""Pikachu was caught!"", ""success"");
                            break;

                        default:
                            swal(""Got away safely!"");
                    }
                });
            }
        ");

            output.Content.AppendHtml(script);
        }
    }
}
