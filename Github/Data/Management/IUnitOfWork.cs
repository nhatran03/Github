using System;

namespace Github.Data.Management
{
	interface IUnitOfWork : IDisposable
	{
		IRepository<TEntity> GetRepository<TEntity>()
			where TEntity : class;

		/// <summary>
		/// Saves all pending changes
		/// </summary>
		/// <returns>The number of objects in an Added, Modified, or Deleted state</returns>

		int Commit();
	}
}
