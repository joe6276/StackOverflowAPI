using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackOverflowAPI.ApplicationDbContext;
<<<<<<< Updated upstream
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Repositories;
using System.ComponentModel;
=======
<<<<<<< Updated upstream
=======
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Repositories;
using System.ComponentModel;
using System.Text;
>>>>>>> Stashed changes
>>>>>>> Stashed changes

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

<<<<<<< Updated upstream
=======
<<<<<<< Updated upstream
=======
>>>>>>> Stashed changes


//AddingNewEventArgs Repositories

builder.Services.AddScoped<UserInterface, UsersRepository>();
<<<<<<< Updated upstream



=======
builder.Services.AddScoped<questionInterface, QuestionsRepository>();

builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Authentication:Issuer"],
        ValidAudience = builder.Configuration["Authentication:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
            builder.Configuration["Authentication:SecretKey"]
            ))
    };
});

>>>>>>> Stashed changes
>>>>>>> Stashed changes
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
