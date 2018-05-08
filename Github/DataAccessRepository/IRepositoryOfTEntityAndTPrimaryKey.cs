using Github.Entities;

namespace Github.DataAccessRepository
{
	public interface IRepository<TEntity, TPrimaryKey> : IRepository where TEntity : class, IEntity<TPrimaryKey>
	{

	}
}
