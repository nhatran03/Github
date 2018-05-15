using Github.Entities;

namespace Github.DataAccessRepository
{
	public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class, IEntity<int>
	{

	}

}
