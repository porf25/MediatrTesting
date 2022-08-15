


using AutoMapper;
using GoofinApi.Mappings;
using GoofinApi.Models;
using GoofinApi.Repositories.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<PorfContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.Password.RequireDigit = false;
    o.Password.RequireLowercase = false;
    o.Password.RequireUppercase = false;
    o.Password.RequireNonAlphanumeric = false;
    o.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<PorfContext>()
.AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(x =>
{
    var security = new OpenApiSecurityRequirement();
    security.Add(new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the bearer scheme",
        Name = "Bearer",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    }, Array.Empty<string>());

    x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
    {
        Description = "JWT Authorization header using the bearer scheme",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });
    x.AddSecurityRequirement(security);
});
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(TestPostProcessor<,>));
builder.Services.AddTransient<ITestRepo, TestRepo>();
builder.Services.AddTransient<IUserAuthenticationRepository, UserAuthenticationRepository>();


var jwtSettings = new JwtSettings();
builder.Configuration.Bind(nameof(jwtSettings), jwtSettings);
builder.Services.AddSingleton(jwtSettings);

var mapperConfig = new MapperConfiguration(map =>
{
    map.AddProfile<UserMappingProfile>();
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

builder.Services.AddAuthentication();

//builder.Services.AddAuthentication(x =>
//{
//    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(x =>
//    {
//        x.SaveToken = true;
//        x.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuerSigningKey = true,
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)),
//            ValidateIssuer = false,
//            ValidateAudience = false,
//            RequireExpirationTime = false,
//            ValidateLifetime = true,
//        };
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
