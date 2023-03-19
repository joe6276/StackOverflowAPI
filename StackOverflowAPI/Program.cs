using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StackOverflowAPI.ApplicationDbContext;
using StackOverflowAPI.Interfaces;
using StackOverflowAPI.Repositories;
using System.Text;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



builder.Services.AddScoped<UserInterface, UsersRepository>();

builder.Services.AddScoped<questionInterface, QuestionsRepository>();

builder.Services.AddScoped<answerInterface, AnswerRepository>();

builder.Services.AddScoped<commentInterface, CommentRepository>();

builder.Services.AddScoped<VoteInterface, VotesRepository>();

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

builder.Services.AddAuthorization(policy =>
{
    policy.AddPolicy("admin", policy =>
    {
        policy.RequireAuthenticatedUser();
        policy.RequireClaim("Roles", "admin");
    });
});

var app = builder.Build();

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
