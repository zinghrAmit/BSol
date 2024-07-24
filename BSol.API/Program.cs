using BSol.API.DBContexts.Four;
using BSol.API.DBContexts.One;
using BSol.API.DBContexts.Three;
using BSol.API.DBContexts.Two;
using BSol.API.Models.Auth;
using BSol.API.Services.Auth;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

// Add DbContext services
builder.Services.AddDbContext<UserOneDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);

builder.Services.AddDbContext<UserTwoDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);

builder.Services.AddDbContext<UserThreeDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);

builder.Services.AddDbContext<UserFourDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("Default"))
        .EnableDetailedErrors()
        .EnableSensitiveDataLogging()
);

// Add Identity services with unique schemes
builder.Services.AddIdentityCore<UserOne>(options => options.SignIn.RequireConfirmedEmail = true)
        .AddEntityFrameworkStores<UserOneDbContext>()
        .AddDefaultTokenProviders()
        .AddSignInManager<SignInManager<UserOne>>();

builder.Services.AddIdentityCore<UserTwo>(options => options.SignIn.RequireConfirmedEmail = true)
        .AddEntityFrameworkStores<UserTwoDbContext>()
        .AddDefaultTokenProviders()
        .AddSignInManager<SignInManager<UserTwo>>();

builder.Services.AddIdentityCore<UserThree>(options => options.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserThreeDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<UserThree>>();

builder.Services.AddIdentityCore<UserFour>(options => options.SignIn.RequireConfirmedEmail = true)
    .AddEntityFrameworkStores<UserFourDbContext>()
    .AddDefaultTokenProviders()
    .AddSignInManager<SignInManager<UserFour>>();

// Configure Data Protection Token lifespan for reset password
builder.Services.Configure<DataProtectionTokenProviderOptions>(options =>
    options.TokenLifespan = TimeSpan.FromHours(1)
);

// Add Authentication with JWT Bearer and unique cookie schemes
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]!))
    };
})
.AddCookie("UserOneScheme")
.AddCookie("UserTwoScheme")
.AddCookie("UserThreeScheme")
.AddCookie("UserFourScheme");

// Add MediatR and other services
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
builder.Services.AddScoped<IAuthServices, AuthServices>();

// Add Controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });

    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
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
