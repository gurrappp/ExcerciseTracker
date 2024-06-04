using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ExcerciseTracker.UI;
using ExcerciseTracker.Controllers;
using ExcerciseTracker.Services;
using ExcerciseTracker.Validation;

namespace ExcerciseTracker;

public class Program
{
    public static async Task Main(string[] args)
    {

        HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

        builder.Services.AddSingleton<IExerciseService,ExerciseService>();
        builder.Services.AddScoped<Validate>();
        builder.Services.AddSingleton<ExerciseController>();

        using IHost host = builder.Build();

        host.Run();


        var userInput = new UserInput();

        await userInput.Menu();
    }
}