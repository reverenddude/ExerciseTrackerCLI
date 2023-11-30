using ExerciseTrackerUI.Models;

namespace ExerciseTrackerUI.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
{
    protected readonly ExerciseContext _exerciseContext;

    public Repository(ExerciseContext ExerciseContext)
    {
        _exerciseContext = ExerciseContext;
    }

    public IQueryable<TEntity> GetAll()
    {
        try
        {
            return _exerciseContext.Set<TEntity>();
        }
        catch (Exception ex)
        {
            throw new Exception($"Couldn't retrive entities {ex.Message}");
        }
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
        }

        try
        {
            await _exerciseContext.AddAsync(entity);
            await _exerciseContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
        }
    }
    
    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        if (entity == null)
        {
            throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
        }

        try
        {
            _exerciseContext.Update(entity);
            await _exerciseContext.SaveChangesAsync();

            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
        }
    }
}