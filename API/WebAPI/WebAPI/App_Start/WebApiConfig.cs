using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using WebAPI.Converters;
using WebApiContrib.Formatting.Jsonp;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Add attribute route support
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Example",
                routeTemplate: "exampleApi/{id}",
                defaults: new { controller = "Example", id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            //Change json formatter to camel case instead of Pascal Default - Also change different aspects of the Formatter this way
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.Converters.Add(new LinkModelConverter());

            CreateMediaTypes(jsonFormatter);

            // Add support JSONP - Request need header Accept: application/javascript and request with ?cb=javascriptfunction
            var formatter = new JsonpMediaTypeFormatter(jsonFormatter, "cb");
            config.Formatters.Insert(0, formatter);

            //Entire API
            //Add nuget package microsoft ASP.NET Web API 2 Cross-Origin
            //config.EnableCors(new EnableCorsAttribute("*", "*", "GET,POST"));

            //If only on controllers or methods
            //config.EnableCors();

            //All cases for this filter force HTTPS
            //config.Filters.Add(new RequireHttpsAttribute());

            // Replace the Controller Configuration
            //config.Services.Replace(typeof(IHttpControllerSelector), new ExampleVersionSelector(config));

            // Configure Caching/ETag Support
            //var connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            // REMINDER: Make sure you've run the SQL Scripts in the Package Folder!
            //var etagStore = new SqlServerEntityTagStore(connString);
            //var cacheHandler = new CachingHandler(etagStore);
            //config.MessageHandlers.Add(cacheHandler);
        }

        static void CreateMediaTypes(JsonMediaTypeFormatter jsonFormatter)
        {
            var mediaTypes = new string[] 
              { 
                "application/vnd.exampleapi.example1.v1+json",
                "application/vnd.exampleapi.example2.v2+json"
              };

            foreach (var mediaType in mediaTypes)
            {
                jsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue(mediaType));
            }

        }
    }
}
