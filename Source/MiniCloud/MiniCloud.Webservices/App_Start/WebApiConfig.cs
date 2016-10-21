using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using MiniCloud.ModelHelper;
using MiniCloud.ModelHelper.Helper;
using Newtonsoft.Json.Serialization;

namespace MiniCloud.WebServices
{
    public static class WebApiConfig
    {    
        public static void Register(HttpConfiguration config)
        {
            //LogHelper.Log("Webserver started", LogType.Info);

            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler());

            config.EnableCors();

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
