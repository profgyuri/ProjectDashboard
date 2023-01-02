using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib.Repositories;

public interface ISolutionRepository
{
    /// <summary>
    /// Gets a solution by its id.
    /// </summary>
    /// <param name="id">The id of the solution.</param>
    /// <returns>The solution with the given id.</returns>
    Task<Solution> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Gets a solution by its name.
    /// </summary>
    /// <param name="name">The name of the solution.</param>
    /// <returns>The solution with the given name.</returns>
    Task<Solution> GetByNameAsync(string name);
    
    /// <summary>
    /// Saves the solution to the repository.
    /// </summary>
    /// <param name="solution">The solution to save.</param>
    /// <returns>The id of the saved solution.</returns>
    Task<Guid> SaveAsync(Solution solution);
    
    /// <summary>
    /// Deletes a solution from the repository.
    /// </summary>
    /// <param name="id">The id of the solution to delete.</param>
    Task DeleteAsync(Guid id);
    
    /// <summary>
    /// Updates the solution with the given id.
    /// The entry from the database will be updated with the given values.
    /// </summary>
    /// <param name="solution">New values for the entry. The Id is used for tracking.</param>
    Task UpdateAsync(Solution solution);
}