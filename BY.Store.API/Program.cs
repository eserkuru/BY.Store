#region ConfigureService

using BY.Store.API.Middlewares;
using BY.Store.Application.Injections.Microsoft;
using BY.Store.Shared.Params;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(BY.Store.Application.Mappings.AutoMapper.MasterProfile));

var injector = new Injector(builder.Services)
        .InjectShared()
        .InjectRepositories()
        .InjectServices();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Configure

var app = builder.Build();

// Uygulama çalıştırıldığında kontrol ve yüklemelerin yapıldığı middlewaredır.
app.UseAppStartUpMiddleware();

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

#endregion
