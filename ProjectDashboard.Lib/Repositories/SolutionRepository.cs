using ProjectDashboard.Lib.Models;

namespace ProjectDashboard.Lib.Repositories;

public sealed class SolutionRepository : ISolutionRepository
{
    #region Implementation of ISolutionRepository
    /// <inheritdoc />
    public Solution GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public Solution GetByName(string name)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Save(Solution solution)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Update(Solution solution)
    {
        throw new NotImplementedException();
    }
    #endregion
}