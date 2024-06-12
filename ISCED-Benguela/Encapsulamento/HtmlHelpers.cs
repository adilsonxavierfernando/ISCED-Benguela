using ISCED_Benguela.Modelos.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text;

namespace ISCED_Benguela.Encapsulamento
{
    public static class HtmlHelpers
    {

       
            public static string IsActive(this IHtmlHelper htmlHelper, string page, string area = "")
            {
                var routeData = htmlHelper.ViewContext.RouteData;
                var currentArea = routeData.Values["area"] as string ?? string.Empty;
                var currentPage = routeData.Values["page"] as string ?? string.Empty;

                if (string.Equals(currentPage, page, StringComparison.OrdinalIgnoreCase) &&
                    string.Equals(currentArea, area, StringComparison.OrdinalIgnoreCase))
                {
                    return "active";
                }

                return string.Empty;
            }
    
        public static string SweetAlert(this IHtmlHelper htmlHelper, string message,string Titulo, alertType Tipo)
        {
            var alert = string.Empty;
            switch (Tipo)
            {
                case alertType.success:
                    alert = "success";
                    break;
                case alertType.error:
                    alert = "error";
                    break;
                case alertType.warning:
                    alert = "warning";
                    break;
                case alertType.information:
                    alert = "information";
                    break;
                default:
                    alert = "";
                    break;
            }
            var builder = new StringBuilder();
            builder.Append($@"
                <script>
                swal({{
                      title: '{Titulo}!',
                      text: '{message}!',
                      icon: '{alert}',
                      button: 'Está bem!',
                }});
                </script>        
            ");
            return builder.ToString();
        }
        //confirme button
        public static string SweetConfirmAlert(this IHtmlHelper htmlHelper, string Titulo, string Mensagem)
        {
            StringBuilder scriptBuilder = new StringBuilder();
            scriptBuilder.Append(@"<script>
    function confirmDelete(element, id, handler) {
        event.preventDefault();
        var itemId = element.getAttribute('asp-route-id');
        var _handler = element.getAttribute('asp-page-handler');
        swal({
              title: ""_titulo"",
              text: ""_mensagem"",
              icon: ""warning"",
              buttons: true,
              dangerMode: true,
            })
        .then((willDelete) => {
            if (willDelete) {
                var baseUrl = window.location.origin + window.location.pathname;
                var url = baseUrl + '?handler=' + handler + '&id=' + id;
                window.location.href = url;
            }
        });
    }
</script>");
            return scriptBuilder.ToString().Replace("_titulo",Titulo).Replace("_mensagem", Mensagem);

        }

        
    }
}
