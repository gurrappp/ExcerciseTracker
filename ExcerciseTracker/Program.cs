

using ExcerciseTracker.UI;

namespace ExcerciseTracker;

public class Program
{
    public static async Task Main(string[] args)
    {
        var userInput = new UserInput();

        await userInput.Menu();
    }
}