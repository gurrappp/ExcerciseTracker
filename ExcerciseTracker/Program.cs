using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExcerciseTracker.UI;
using ExcerciseTracker.Controllers;
using ExcerciseTracker.Services;
using ExcerciseTracker.Validation;
using ExcerciseTracker.Repositories;
using OptimalSeatingArrangement.TableVizualisation;

namespace ExcerciseTracker;

public class Program
{

    private readonly ExerciseController controller;
    private readonly ExerciseService service;
    private readonly UserInput userInput;
    private readonly Validate validate;

    public Program(ExerciseController controller, ExerciseService service, UserInput userInput, Validate validate)
    {
        this.controller = controller;
        this.service = service;
        this.userInput = userInput;
        this.validate = validate;
    }

    public static void Main(string[] args)
    {

        //HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        //builder.Services.AddSingleton<IExerciseService, ExerciseService>();
        //builder.Services.AddScoped<Validate>();
        //builder.Services.AddSingleton<ExerciseController>();
        //builder.Services.AddSingleton<UserInput>();

        //using IHost host = builder.Build();

        //host.Run();


        //var userInput = new UserInput();

        //await userInput.Menu();

        var host = CreateHostBuilder(args).Build();
        host.Services.GetRequiredService<Program>().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddTransient<Program>();
                services.AddTransient<ExerciseService>();
                services.AddTransient<ExerciseController>();
                services.AddTransient<UserInput>();
                services.AddTransient<Validate>();
                services.AddTransient<ICardioRepository,CardioRepository>();
                //services.AddTransient<TableVisualizationEngine>();
            });
    }

    public void Run()
    {
        userInput.Menu();
    }
}