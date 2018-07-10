using Github.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace Github.Data.Management
{
	public class Repository<T> : IRepository<T> where T : class
	{
		private readonly ApplicationDbContext dbContext;

		private readonly DbSet<T> dbSet;

		public Repository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
			this.dbSet = dbContext.Set<T>();
		}

		public EntityState Add(T entity)
		{
			throw new NotImplementedException();
		}

		public EntityState Delete(T entity)
		{
			throw new NotImplementedException();
		}

		public bool Exists(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string include)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> FromSql(string sql, params object[] parameters)
		{
			throw new NotImplementedException();
		}

		public T Get(params object[] keyValues)
		{
			throw new NotImplementedException();
		}

		public T Get<TKey>(TKey id)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetAll()
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetAll(string include)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetAll(string include, string include2)
		{
			throw new NotImplementedException();
		}

		public IQueryable<T> GetAll(int page, int pageCount)
		{
			throw new NotImplementedException();
		}

		public System.Threading.Tasks.Task<T> GetAsync<TKey>(TKey id)
		{
			throw new NotImplementedException();
		}

		public EntityState Update(T entity)
		{
			throw new NotImplementedException();
		}
	}
}