using ExerciseTrackerUI.Models;

namespace ExerciseTrackerUI.Services;

public interface IExerciseService
{
    Task<Exercise> AddExerciseAsync(Exercise newExercise);
    Task<Exercise> UpdateExerciseAsync(Exercise exercise);
    Task<List<Exercise>> GetAllExercises();
    Task<Exercise> GetExerciseByIdAsync(int id);
}