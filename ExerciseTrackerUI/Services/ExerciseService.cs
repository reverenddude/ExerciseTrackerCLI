using ExerciseTrackerUI.Models;
using ExerciseTrackerUI.Repositories;

namespace ExerciseTrackerUI.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;
    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<Exercise> AddExerciseAsync(Exercise newExercise)
    {
        return await _exerciseRepository.AddExercise(newExercise);
    }

    public async Task<Exercise> UpdateExerciseAsync(Exercise exercise)
    {
        return await _exerciseRepository.UpdateExercise(exercise);
    }

    public async Task<List<Exercise>> GetAllExercises()
    {
        return await _exerciseRepository.GetAllExercisesAsync();
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        return await _exerciseRepository.GetExerciseByIdAsync(id);
    }
    
}