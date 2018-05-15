using Github.Models;
using System;

namespace Github.DataAccessRepository
{
	public class clsDataAccessRepository : IDataAccessRepository<Customer, int>
	{
		
		public ApplicationDbContext context { get; set; }
		public void Delete(int id)
		{
			
		}

		public System.Collections.Generic.IEnumerable<Customer> Get()
		{
			throw new NotImplementedException();
		}

		public Customer Get(int id)
		{
			throw new NotImplementedException();
		}

		public void Post(Customer entity)
		{
			throw new NotImplementedException();
		}

		public void Put(int id, Customer entity)
		{
			throw new NotImplementedException();
		}
	}
}