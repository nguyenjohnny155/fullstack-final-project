using Microsoft.EntityFrameworkCore;
using ShopApi.Models;
using InterfaceShop;
using ShopDemo;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add Jwt auth
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            //define which claim requires to check
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //store the value in appsettings.json
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


// Add services to the container.
// Add Local Database Service
builder.Services.AddScoped<IShop, Shop>();

// Add API Endpoints
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

/*
builder.Services.AddAuthentication()
    .AddGoogle(googleOptions => {
        //googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
        //googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];

        googleOptions.ClientId = "547563543724-ou44189p059fgs29tih947au1o366n2r.apps.googleusercontent.com";
        googleOptions.ClientSecret = "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";
    });
*/

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
