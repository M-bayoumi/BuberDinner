using BuberDinner.Api.Filters;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


#region Default Services
builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region User Defined Services
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);
#endregion

var app = builder.Build();

#region pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
#endregion
