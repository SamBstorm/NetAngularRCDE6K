using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TF_NET_Angular_RCD_Bibliotheque.API.Tools;
using TF_NET_Angular_RCD_Bibliotheque.BLL.Services;
using TF_NET_Angular_RCD_Bibliotheque.DAL.DataContext;
using TF_NET_Angular_RCD_Bibliotheque.DAL.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Main")));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();

builder.Services.AddScoped<INoticeRepository, NoticeRepository>();
builder.Services.AddScoped<INoticeService, NoticeService>();

builder.Services.AddScoped<TokenManager>();

builder.Services.AddAuthorization(
    options => { options.AddPolicy("connectedUser", policy => policy.RequireAuthenticatedUser()); }
    );

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                builder.Configuration.GetSection("TokenInfo").GetSection("secretKey").Value)),
            ValidateLifetime = true,
            ValidateIssuer = true,
            ValidIssuer = "monServeur.com",
            ValidateAudience = true,
            ValidAudience = "monClient.com"
            
        };
    }
    );

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
