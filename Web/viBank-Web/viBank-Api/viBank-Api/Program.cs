using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using viBank_Api.Services.AccountsService;
using viBank_Api.Services.authService;
using viBank_Api.Services.TransactionService;
using viBank_Api.Services.UserService;
using static viBank_Api.Authorization.RoleHandler;

namespace viBank_Api;

public class Program
{
    protected Program() { }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var allowOriginsPolicy = "Origin";
        //Registering services using DI
        builder.Services.AddControllers();
        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: allowOriginsPolicy, b =>
            {
                if (builder.Environment.IsDevelopment())
                {
                    b.AllowAnyOrigin();
                }

                b.AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed((_) => true);
            });
        });
        // Register the DbContext

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );


        // Configure authentication
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddGoogle(GoogleDefaults.AuthenticationScheme, options =>
        {
            options.ClientId = builder.Configuration.GetValue<string>("GoogleKeys:clientId");
            options.ClientSecret = builder.Configuration.GetValue<string>("GoogleKeys:clientSecret");
            options.CallbackPath = "/auth/signin-google";
        })
        .AddOpenIdConnect("Microsoft", options =>
        {
            options.Authority = "https://login.microsoftonline.com/common/v2.0";
            options.ClientId = builder.Configuration.GetValue<string>("MicrosoftKeys:ClientId");
            options.ClientSecret = builder.Configuration.GetValue<string>("MicrosoftKeys:ClientSecret");
            options.ResponseType = "code";
            options.CallbackPath = "/auth/signin-microsoft";
            options.UseTokenLifetime = true;
            options.SaveTokens = true;
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("email");
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                LifetimeValidator = (before, expires, token, parameters) => expires > DateTime.UtcNow,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Token")!))
            };

            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.AccessControlAllowOrigin = builder.Configuration.GetValue<string>("AllowedHosts");
                    var result = JsonSerializer.Serialize(new { message = "You are not authorized!" });
                    return context.Response.WriteAsync(result);
                }
            };
        });

        // Configure authorization policies
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(ViBankAuthorizationPolicies.RequireAdmin, policy => policy.AddRequirements(new AdminRoleRequirement()));
            options.AddPolicy(ViBankAuthorizationPolicies.RequireUser, policy => policy.AddRequirements(new UserRoleRequirement()));
        });

        // Add Swagger/OpenAPI support
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("jwt", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "bearer",
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme: \'Authorization: Bearer {token}\'"
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "jwt"
                        }
                    },
                    Array.Empty<string>()
                }
            });
        });

        // Register services
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IAccounts,  AccountsService>();
        builder.Services.AddScoped<Itransactions,TransactionService>();



        // Build and run the app
        var app = builder.Build();
        app.UseCors(allowOriginsPolicy);

        // Enable Swagger in development mode
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        // Map controllers
        app.MapControllers();

        // Run the application
        app.Run();
    }
}
