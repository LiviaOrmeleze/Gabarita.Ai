using Gabarita.Ai.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conex�o com o banco de dados
builder.Services.AddDbContext<GabaritaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configurar o CORS (Cross-Origin Resource Sharing)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); });
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Adionar o Swagger com JWT Bearer
builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
    {
        new OpenApiSecurityScheme
        {
        Reference = new OpenApiReference
            {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header,

        },
        new List<string>()
        }
    });
});

// Servi�o de EndPoints do Identity Framework
builder.Services.AddIdentityApiEndpoints<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedAccount = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
})
    .AddEntityFrameworkStores<GabaritaContext>()
    .AddDefaultTokenProviders(); // Adiocionando o provedor de tokens padr�o

// Add Services de Autentica��o e Autoriza��o
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();



var app = builder.Build();

//Swagger em ambiente de produ��o
app.UseSwagger();
app.UseSwaggerUI();


// Mapear os EdePoints padr�o do Identity Framework
app.MapGroup("/Users").MapIdentityApi<IdentityUser>();
//app.MapGroup("/Roles").MapIdentityApi<IdentityRole>();

app.UseHttpsRedirection();
//Permitir a autentica��o e autoriza��o de qualquer origem
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
