using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    // gelen bütün istekler kabul edilir
    policy.AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .SetIsOriginAllowed(origin => true)));

builder.Services.AddTransient<MyBusiness>();

builder.Services.AddSignalR();

builder.Services.AddControllers();



var app = builder.Build();

app.UseRouting();

app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints =>
{
    // https://localhost:7082/myhub
    endpoints.MapHub<MyHub>("/myhub");
    endpoints.MapHub<MessageHub>("/messagehub");
    endpoints.MapControllers();
});

app.Run();
