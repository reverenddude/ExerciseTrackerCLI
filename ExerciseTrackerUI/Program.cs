using ExerciseTrackerUI;
using ExerciseTrackerUI.Controllers;
using Microsoft.Extensions.DependencyInjection;
using ExerciseTrackerUI.Models;
using ExerciseTrackerUI.Services;
using ExerciseTrackerUI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

public class Program
{
    // New set up
    static void Main(string[] args)
    {
        var builder = new ConfigurationBuilder();
        BuildConfig(builder);

        var host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ExerciseContext>(options =>
                    options.UseSqlServer(context.Configuration["Database:ConnectionString"]));
                
                // Register UI
                services.AddSingleton<UserInput>();
                
                // Register Controller
                services.AddTransient<IExerciseController, ExerciseController>();
                
                // Register Repositories
                services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
                services.AddTransient<IExerciseRepository, ExerciseRepository>();
                
                // Register Service
                services.AddTransient<IExerciseService, ExerciseService>();
            })
            .Build();

        using var scope = host.Services.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        var userInput = serviceProvider.GetRequiredService<UserInput>();
        userInput.Run();
    }
    static void BuildConfig(IConfigurationBuilder builder)
    {
        builder.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
    }
    
    // OG set up
    /*
    public static void Main(string[] args)
    {
        var host = CreateHostBuilder(args).Build();
        host.Run();
        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            UserInput.MainMenu(serviceProvider);
        }
    }
    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration(cfg =>
            {
                cfg.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            })
            .ConfigureServices((context, services) =>
            {
                services.AddDbContext<ExerciseContext>(options =>
                    options.UseSqlServer(context.Configuration["Database:ConnectionString"]));
            });
    }
    */


}