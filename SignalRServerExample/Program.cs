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
            builder.Services.AddCors(opt => opt.AddDefaultPolicy(policy=>policy.AllowAnyMethod().AllowAnyHeader().AllowCredentials().SetIsOriginAllowed(origin=>true)));
            builder.Services.AddTransient<MyBusiness>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //if (!app.Environment.IsDevelopment())
            //{
            //    app.UseExceptionHandler("/Home/Error");
            //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //    app.UseHsts();
            //}


            app.UseHttpsRedirection();
            //app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<MyHub>("/myhub");
            });

            app.MapControllers();

            app.Run();
        }
    }
}