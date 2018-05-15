using System.Collections.Generic;

namespace Github.DataAccessRepository
{
	interface IDataAccessRepository <TEntity, in TPrimaryKey> where TEntity : class
	{
		IEnumerable<TEntity> Get();
		TEntity Get(TPrimaryKey id);
		void Post(TEntity entity);
		void Put(TPrimaryKey id, TEntity entity);
		void Delete(TPrimaryKey id);
	}
}
