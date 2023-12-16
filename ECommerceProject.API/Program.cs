using ECommerceProject.Persistence.Extension;
using ECommerceProject.Application;
using ECommerceProject.Application.Validators.IdentityValidators;
using ECommerceProject.Domain.Concrete;
using ECommerceProject.Persistence.AppContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddIdentity<AppUser,AppRole>().AddEntityFrameworkStores<ECommerceAPPIDbContext>().AddErrorDescriber<CustomIdentityValidator>();

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
