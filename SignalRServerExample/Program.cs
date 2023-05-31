using SignalRServerExample.Business;
using SignalRServerExample.Hubs;

namespace SignalRServerExample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddSignalR();
            builder.Services.AddCors(opt => opt.AddDefaultPolicy(
                policy=>policy
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()
                .SetIsOriginAllowed(origin=>true)));

            builder.Services.AddTransient<MyBusiness>();

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseCors();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/myhub");
                endpoints.MapHub<MessageHub>("/messagehub");
                endpoints.MapHub<ChatHub>("/chathub");
                endpoints.MapControllers();
            });

            app.MapControllers();

            app.Run();
        }
    }
}