using EquadisRJP.IdentityAuth.Extensions;
using EquadisRJP.IdentityAuth.Models.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddIdentityDbContext(builder.Configuration);

builder.Services.AddJWTAuthentication(builder.Configuration);

builder.Services.Configure<List<AuthClientModel>>(
    builder.Configuration.GetSection("AuthClients"));

builder.Services.AddServices();

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
