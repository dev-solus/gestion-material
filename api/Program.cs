using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Hubs;
using Services;
using Providers;
using Helpers;
using Newtonsoft.Json;
using Microsoft.Extensions.Hosting;
using Extensions;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Builder;

// add services to DI container
var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;
    var env = builder.Environment;
    var Configuration = builder.Configuration;

    services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
    services.AddScoped<EmailService>();
    services.AddScoped<AccountService>();
    services.AddScoped<TokkenHandler>();
    services.AddScoped<HtmlService>();

    //Provide a secret key to Encrypt and Decrypt the Token
    // configure strongly typed settings objects
    var appSettingsSection = Configuration.GetSection("AppSettings");
    services.Configure<AppSettings>(appSettingsSection);
    // configure jwt authentication
    var appSettings = appSettingsSection.Get<AppSettings>();
    var key = System.Text.Encoding.ASCII.GetBytes(appSettings.Secret);

    services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
   .AddJwtBearer(options =>
   {
       //    x.Events = new JwtBearerEvents
       //    {
       //        OnTokenValidated = context =>
       //        {
       //            //    var userService = context.HttpContext.RequestServices.GetRequiredService/*<IUserService>*/();
       //            //    var userId = int.Parse(context.Principal.Identity.Name);
       //            //    var user = userService.GetById(userId);
       //            //    if (user == null)
       //            //    {
       //            //        // return unauthorized if user no longer exists
       //            //        context.Fail("Unauthorized");
       //            //    }
       //            return Task.CompletedTask;
       //        }
       //    };
       /**
       * this just for the sake of signalR
       */
       options.Events = new JwtBearerEvents
       {
           OnMessageReceived = context =>
           {
               var accessToken = context.Request.Query["access_token"];
               if (string.IsNullOrEmpty(accessToken) == false)
               {
                   context.Token = accessToken;
               }
               return Task.CompletedTask;
           }
       };

       options.RequireHttpsMetadata = false;
       options.SaveToken = true;
       options.TokenValidationParameters = new TokenValidationParameters
       {
           ValidateIssuerSigningKey = true,
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuer = false,
           ValidateAudience = false
       };
   });
    //auth

    services.AddDbContext<MyContext>(options =>
    {
        // options.UseSqlServer(Configuration.GetConnectionString("msi"));
        options.UseSqlite(Configuration.GetConnectionString("sqlite"));
    });

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen("Système pour la gestion des biens informatique", "API documentation");

    // services.AddControllersWithViews()

    services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

    services.AddSignalR(o =>
    {
        o.EnableDetailedErrors = true;
        o.MaximumReceiveMessageSize = 10240; // bytes
    });

}

var app = builder.Build();

// configure HTTP request pipeline
{
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
    }

    app.UseStaticFiles();

    // generated swagger json and swagger ui middleware
    // source https://christian-schou.dk/how-to-make-api-documentation-using-swagger/
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // c.RoutePrefix = "/swagger";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Système pour la gestion des biens informatique API V1");
    });

    // global cors policy
    app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

    app.UseHttpsRedirection();


    // app.UseMiddleware<QueryInterceptor>();

    // global error handler
    app.UseMiddleware<ErrorHandler>();

    app.UseAuthentication();
    app.UseAuthorization();
    app.UseHsts();

    // var provider = new FileExtensionContentTypeProvider();
    //         provider.Mappings.Add(".exe", "application/octect-stream");
    //         app.UseStaticFiles(new StaticFileOptions
    //         {
    //             ServeUnknownFileTypes = true, //allow unkown file types also to be served
    //             // DefaultContentType = "Whatver you want eg: plain/text" //content type to returned if fileType is not known.
    //             ContentTypeProvider = provider
    //         });

    app.MapControllers();

    app.MapHub<ChatHub>("/ChatHub");
}

app.Run();
// http://[::]:5000 
