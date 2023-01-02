using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib.Repositories;

public sealed class SolutionRepository : ISolutionRepository
{
    private readonly DataContext _dataContext;

    public SolutionRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    #region Implementation of ISolutionRepository
    /// <inheritdoc />
    public async Task<Solution> GetByIdAsync(Guid id)
    {
        var result = _dataContext.Solutions.FirstOrDefault(x => x.Id == id);

        return result is not null ? await Task.FromResult(result) : throw new Exception($"Solution with id {id} not found");
    }

    /// <inheritdoc />
    public async Task<Solution> GetByNameAsync(string name)
    {
        var result = _dataContext.Solutions.FirstOrDefault(x => x.Name == name);
        
        return result is not null ? await Task.FromResult(result) : throw new Exception($"Solution with name {name} not found");
    }

    /// <inheritdoc />
    public async Task<Guid> SaveAsync(Solution solution)
    {
        var result = Guid.Empty;
        
        // check if solution already exists
        var existingSolution = 
            _dataContext.Solutions.FirstOrDefault(x => x.Id == solution.Id);
        
        if (existingSolution is null)
        {
            var added = _dataContext.Solutions.Add(solution);
            result = added.Entity.Id;
        }
        else
        {
            await UpdateAsync(solution);
            result = solution.Id;
        }
        
        await _dataContext.SaveChangesAsync();
        
        return result;
    }

    /// <inheritdoc />
    public async Task DeleteAsync(Guid id)
    {
        var solution = await GetByIdAsync(id);
        
        _dataContext.Solutions.Remove(solution);
        
        await _dataContext.SaveChangesAsync();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(Solution solution)
    {
        var existingSolution = await GetByIdAsync(solution.Id);
        
        existingSolution.Name = solution.Name;
        existingSolution.SolutionPath = solution.SolutionPath;
        existingSolution.DebugPath = solution.DebugPath;
        existingSolution.ReleasePath = solution.ReleasePath;
        existingSolution.PublishedPath = solution.PublishedPath;
        
        await _dataContext.SaveChangesAsync();
    }
    #endregion
}