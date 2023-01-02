using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib.Repositories;

public interface ISolutionRepository
{
    /// <summary>
    /// Gets a solution by its id.
    /// </summary>
    /// <param name="id">The id of the solution.</param>
    /// <returns>The solution with the given id.</returns>
    Solution GetById(Guid id);
    
    /// <summary>
    /// Gets a solution by its name.
    /// </summary>
    /// <param name="name">The name of the solution.</param>
    /// <returns>The solution with the given name.</returns>
    Solution GetByName(string name);
    
    /// <summary>
    /// Saves the solution to the repository.
    /// </summary>
    /// <param name="solution">The solution to save.</param>
    void Save(Solution solution);
    
    /// <summary>
    /// Deletes a solution from the repository.
    /// </summary>
    /// <param name="id">The id of the solution to delete.</param>
    void Delete(Guid id);
    
    /// <summary>
    /// Updates the solution with the given id.
    /// The entry from the database will be updated with the given values.
    /// </summary>
    /// <param name="solution">New values for the entry. The Id is used for tracking.</param>
    void Update(Solution solution);
}