﻿using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using TrainingHelper.DataProvider.User;

namespace TrainingHelper.StandaloneApiServer.Helper.Auth
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        /// <summary>
        /// Vérifie et génère un token pour l'utilisateurs
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            if (!context.OwinContext.Response.Headers.ContainsKey("Access-Control-Allow-Origin"))
            { context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" }); }


            using (var repo = new AuthProvider())
            {
                var user = await repo.Connect(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                //permet d'avoir un token signé
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim("sub", context.UserName));
                identity.AddClaim(new Claim("roles",string.Join(";",user.Roles) ));
                identity.AddClaim(new Claim(ClaimTypes.Name, context.ClientId));
                context.Validated(identity);
            }

        }

    }
}
