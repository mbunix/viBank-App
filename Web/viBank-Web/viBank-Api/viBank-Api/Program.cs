

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Net.WebSockets;
using System.Text.Json;
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

        //register the controllers
        //register the DbContext
        builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnectionString")));

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                LifetimeValidator = (before, expires, token, parameters) =>
                {
                    return expires > DateTime.UtcNow;
                },
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Token")!))
            };
            options.Events = new JwtBearerEvents
            {
                OnChallenge = context =>
                {
                    context.HandleResponse();
                    context.Response.ContentType = "application/json";
                    context.Response.Headers.AccessControlAllowOrigin = builder.Configuration.GetValue<String>("AllowedHosts");
                    var result = JsonSerializer.Serialize(new { message = "You are not authorized!" });
                    return context.Response.WriteAsync(result);
                }
            };
        });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy(ViBankAuthorizationPolicies.RequireAdmin, policy => policy.AddRequirements(new AdminRoleRequirement()));
            options.AddPolicy(ViBankAuthorizationPolicies.RequireUser, policy => policy.AddRequirements(new UserRoleRequirement()));
        });
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
        }
        );
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        builder.Services.AddScoped<IUserService, UserService>();

        var app = builder.Build();
        app.UseCors(allowOriginsPolicy);
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}