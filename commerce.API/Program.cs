using Commerce.Application.eventHandler;
using Commerce.Application.IServices.User;
using Commerce.Application.Services.User;
using Commerce.Domain.Core.UserBoundedContext.IRepository;
using Commerce.Infrastructure.Database.DependencyInjectionConfiguration;
using Commerce.Infrastructure.Pattern;
using Commerce.Infrastructure.Repository.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseSetup(builder.Configuration);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddUserEventHandler).Assembly));
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
