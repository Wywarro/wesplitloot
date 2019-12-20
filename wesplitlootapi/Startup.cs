using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDB;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using wesplitlootapi.Models.Identity;


namespace wesplitlootapi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireDigit = true;
            });

            services.Configure<MongoDBOption>(options =>
            {
                string userDb = Environment.GetEnvironmentVariable("WESPLITLOOT_USERNAME");
                string passDb = Environment.GetEnvironmentVariable("WESPLITLOOT_PASSWORD");
                string bareConnectionString
                    = Configuration.GetSection("MongoConnection:ConnectionString").Value;
                string connectionString = bareConnectionString.Replace("<password>", passDb).Replace("<username>", userDb);

                options.ConnectionString
                  = connectionString;
                options.Database
                  = Configuration.GetSection("MongoConnection:Database").Value;
            })
              .AddMongoDatabase()
              .AddMongoDbContext<AppUser, AppRole>()
              .AddMongoStore<AppUser, AppRole>();

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme =
                           CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultScheme =
                           CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme =
                           "Splitwise";
            })
            .AddCookie()
            .AddOAuth("Splitwise", options =>
            {
                options.ClientId = "Kq8swWewdB1bmdgtzQWQi6xhOieXZKswHtrYJ4oO";
                options.ClientSecret = "ivx8gNdg0syYjSZORO0Ls30TpzaIk4CNuoTyuDwK";
                options.CallbackPath = new Microsoft.AspNetCore.Http.PathString("/callback");

                options.AuthorizationEndpoint = "https://secure.splitwise.com/oauth/authorize";
                options.TokenEndpoint = "https://secure.splitwise.com/oauth/token";
                options.UserInformationEndpoint = "https://www.splitwise.com/api/v3.0/get_current_user";

                options.ClaimActions.MapJsonKey(ClaimTypes.NameIdentifier, "user:id");
                options.ClaimActions.MapJsonKey(ClaimTypes.Name, "user:email");

                options.Events = new OAuthEvents
                {
                    OnCreatingTicket = async context =>
                    {
                        var request = new HttpRequestMessage(HttpMethod.Get, context.Options.UserInformationEndpoint);
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", context.AccessToken);

                        var response = await context.Backchannel.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, context.HttpContext.RequestAborted);
                        response.EnsureSuccessStatusCode();

                        var user = JObject.Parse(await response.Content.ReadAsStringAsync());

                        context.RunClaimActions(user);
                    }
                };
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddTransient<IAppUserContext, AppUserContext>();
            //services.AddTransient<IAppUserRepository, AppUserRepository>();
          }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}
