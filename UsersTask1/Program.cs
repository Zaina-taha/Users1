using Docker.DotNet.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SolrNet;
using System.Reflection;
using System.Text;
using UsersTask1.Extensions;
using UsersTask1.Repo;
using UserTask1;
using UserTask1.Module;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UsersContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConStr"));
    

});


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddSwaggerGen();
builder.Services.InitServices();
builder.Services.AddSingleton<XSampleActionFilter>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddIdentity<Users, UserRoles>()
    .AddEntityFrameworkStores<UsersContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = false;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();


var app = builder.Build();
//app.UseExceptionHandlerMiddleware();

app.UseDeveloperExceptionPage();


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
