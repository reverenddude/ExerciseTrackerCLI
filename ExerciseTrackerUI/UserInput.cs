using ExerciseTrackerUI.Controllers;

namespace ExerciseTrackerUI;

public class UserInput
{
    private readonly IExerciseController _exerciseController;

    public UserInput(IExerciseController exerciseController)
    {
        _exerciseController = exerciseController;
    }

    public void Run()
    {
        bool appRunning = true;
        while (appRunning)
        {
            Console.WriteLine("Welcome to Exercise Tracker!");
            Console.WriteLine("----------------------------");
            Console.WriteLine("1. Start New Exercise");
            Console.WriteLine("2. View All Exercises");
            Console.WriteLine("3. Quit Application");

            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        _exerciseController.StartExerciseAsync();
                        break;
                    case 2:
                        _exerciseController.ViewExercises();
                        break;
                    case 3:
                        appRunning = false;
                        Console.WriteLine("Thank you for exercising!");
                        break;
                    default:
                        Console.WriteLine("Enter a valid input (1, 2, 3).");
                        break;
                }
            }
        }
    }
}