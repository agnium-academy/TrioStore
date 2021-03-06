﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using SportsStoreWA.Infrastructure.Identity;
using System;
using Microsoft.Owin.Security.OAuth;

[assembly: OwinStartup(typeof(SportsStoreWA.IdentityConfig))]

namespace SportsStoreWA
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<StoreIdentityDbContext>(
                StoreIdentityDbContext.Create);
            app.CreatePerOwinContext<StoreUserManager>(StoreUserManager.Create);
            app.CreatePerOwinContext<StoreRoleManager>(StoreRoleManager.Create);

            //app.UseCookieAuthentication(new CookieAuthenticationOptions
            //{
            //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            //});

            app.UseOAuthBearerTokens(new OAuthAuthorizationServerOptions
            {
                Provider = new StoreAuthProvider(),
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/Authenticate")
            });
        }
    }
}