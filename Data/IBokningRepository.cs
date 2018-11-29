using System.Threading.Tasks;

namespace BokningSystem.API.Data
{
    public interface IBokningRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveAll();
    }
}