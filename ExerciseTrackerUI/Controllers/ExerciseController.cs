using ExerciseTrackerUI.Services;
using ExerciseTrackerUI.Models;
using Microsoft.IdentityModel.Tokens;

namespace ExerciseTrackerUI.Controllers;

public class ExerciseController : IExerciseController
{
    private readonly IExerciseService _exerciseService;
    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    public async void StartExerciseAsync()
    {
        Console.WriteLine("Starting timer, press enter to complete exercise");
        DateTime startTime = DateTime.Now.ToUniversalTime();

        while (!Console.ReadLine().IsNullOrEmpty())
        {
            TimeSpan timeElapsed = DateTime.Now.ToUniversalTime() - startTime;
            Console.Write($"{timeElapsed.TotalSeconds}");
            Thread.Sleep(1000);
        }
        
        DateTime endTime = DateTime.Now.ToUniversalTime();
        
        Console.Write("Nice workout! Have anything else to say?: ");
        string? comments = Console.ReadLine();

        Exercise newExercise = new Exercise()
        {
            DateStart = startTime,
            DateEnd = endTime,
            Duration = endTime - startTime,
            Comments = comments
        };

        var exercise = await _exerciseService.AddExerciseAsync(newExercise);
        
        Console.WriteLine($"Added new exercise: {exercise.ExerciseId}");

    }

    public void ViewExercises()
    {
        
    }
}