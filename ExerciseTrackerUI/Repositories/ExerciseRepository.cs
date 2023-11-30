using ExerciseTrackerUI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExerciseTrackerUI.Repositories;

public class ExerciseRepository: Repository<Exercise>, IExerciseRepository
{
    public ExerciseRepository(ExerciseContext exerciseContext)
        :base(exerciseContext)
    {
    }

    public async Task<Exercise> GetExerciseByIdAsync(int id)
    {
        return await GetAll().FirstOrDefaultAsync(e => e.ExerciseId == id);
    }

    public async Task<List<Exercise>> GetAllExercisesAsync()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Exercise> UpdateExercise(Exercise exercise)
    {
        return await UpdateAsync(exercise);
    }

    public async Task<Exercise> AddExercise(Exercise exercise)
    {
        return await AddAsync(exercise);
    }
    
}