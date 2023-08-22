using MiniMuhasebem.Domain.Common;
using MiniMuhasebem.Domain.Repositories;

namespace MiniMuhasebem.Domain.UWork
{
    public interface IUnitWork : IDisposable
    {
        public IRepository<T> GetRepository<T>() where T : BaseEntity;
        public Task<bool> CommitAsync();
    }
}
