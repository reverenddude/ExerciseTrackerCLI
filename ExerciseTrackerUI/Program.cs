using Microsoft.Extensions.DependencyInjection;
using ExerciseTrackerUI.Models;
using ExerciseTrackerUI.Services;
using ExerciseTrackerUI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Run();
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(cfg =>
            {
                Console.WriteLine($"CWD: {Directory.GetCurrentDirectory()}");
                cfg.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ExerciseContext>(options =>
                    options.UseSqlServer(context.Configuration["Database:ConnectionString"]));
            });
    }
}