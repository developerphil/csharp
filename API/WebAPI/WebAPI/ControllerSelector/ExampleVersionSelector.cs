﻿using System;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebAPI.ControllerSelector
{
    public class ExampleVersionSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;

        public ExampleVersionSelector(HttpConfiguration config)
            : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();

            var routeData = request.GetRouteData();

            var controllerName = (string)routeData.Values["controller"];

            HttpControllerDescriptor descriptor;

            if (controllers.TryGetValue(controllerName, out descriptor))
            {
                //var version = GetVersionFromQueryString(request);
                //var version = GetVersionFromHeader(request);
                //var version = GetVersionFromAcceptHeaderVersion(request);
                //Or SDammann.WebApi.Version on github or nuget - namespace versioning included
                var version = GetVersionFromMediaType(request);

                var newName = string.Concat(controllerName, "V", version);

                HttpControllerDescriptor versionedDescriptor;

                if (controllers.TryGetValue(newName, out versionedDescriptor))
                {
                    return versionedDescriptor;
                }

                return descriptor;
            }

            return null;
        }

        //WebApiConfig for adding new media types which deal with json
        //Accept:application/vnd.exampleapi.example2.v2+json
        private string GetVersionFromMediaType(HttpRequestMessage request)
        {
            var accept = request.Headers.Accept;
            var ex = new Regex(@"application\/vnd\.exampleapi\.([a-z]+)\.v([0-9]+)\+json", RegexOptions.IgnoreCase);

            foreach (var mime in accept)
            {
                var match = ex.Match(mime.MediaType);
                if (match != null)
                {
                    return match.Groups[2].Value;
                }
            }

            return "1";
        }

        //Accept: application/json; version=2
        private string GetVersionFromAcceptHeaderVersion(HttpRequestMessage request)
        {
            var accept = request.Headers.Accept;

            foreach (var mime in accept)
            {
                if (mime.MediaType == "application/json")
                {
                    var value = mime.Parameters
                                    .Where(v => v.Name.Equals("version", StringComparison.OrdinalIgnoreCase))
                                    .FirstOrDefault();

                    return value.Value;
                }
            }

            return "1";
        }

        //X-ExampleApi-Version:2
        private string GetVersionFromHeader(HttpRequestMessage request)
        {
            const string HEADER_NAME = "X-ExampleApi-Version";

            if (request.Headers.Contains(HEADER_NAME))
            {
                var header = request.Headers.GetValues(HEADER_NAME).FirstOrDefault();
                if (header != null)
                {
                    return header;
                }
            }

            return "1";
        }

        private string GetVersionFromQueryString(HttpRequestMessage request)
        {
            var query = HttpUtility.ParseQueryString(request.RequestUri.Query);

            var version = query["v"];
            if (version != null)
            {
                return version;
            }

            return "1";
        }
    }
}