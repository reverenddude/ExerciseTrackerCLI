using ExerciseTrackerUI.Models;

namespace ExerciseTrackerUI.Repositories;

public interface IExerciseRepository
{
    Task<Exercise> GetExerciseByIdAsync(int id);
    Task<List<Exercise>> GetAllExercisesAsync();
    Task<Exercise> UpdateExercise(Exercise exercise);
    Task<Exercise> AddExercise(Exercise exercise);
}