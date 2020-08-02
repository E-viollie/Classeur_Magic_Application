using System.Threading.Tasks;

namespace ApplicationCore.SeedWork
{
    public interface IUnitOfWork
    {
        /// <summary>
        /// Applies all database changes.
        /// </summary>
        /// <returns>Number of affected rows.</returns>
        Task<int> Save();
    }
}
