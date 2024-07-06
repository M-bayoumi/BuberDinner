using BuberDinner.Application.Services.AuthenticationServices;

var builder = WebApplication.CreateBuilder(args);


#region Default Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Default Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
#endregion

var app = builder.Build();

#region pipeline
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
