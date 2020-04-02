using System;
using DattingApp.API.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DattingApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
             var host= CreateHostBuilder(args).Build();
             using (var scope = host.Services.CreateScope()){
                 var Services= scope.ServiceProvider;
                 try {
                         var context = Services.GetRequiredService<DataContext>();
                         context.Database.Migrate();
                         Seed.SeedUsers(context);
                 }catch(Exception ex){
                     var logger = Services.GetRequiredService<ILogger<Program>>();
                     logger.LogError(ex, "An error  occored during migration");

                 }
             }
            host.Run();
            //CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
