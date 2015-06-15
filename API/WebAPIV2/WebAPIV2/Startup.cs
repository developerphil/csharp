using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using WebAPIV2.Providers;

[assembly: OwinStartup(typeof(WebAPIV2.Startup))]

namespace WebAPIV2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // token generation
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                // for demo purposes
                AllowInsecureHttp = true,

                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromHours(1),

                Provider = new SimpleAuthorizationServerProvider(),
                RefreshTokenProvider = new SimpleRefreshTokenProvider()
            });

            // token consumption
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
