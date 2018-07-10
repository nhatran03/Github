using System;
using System.Data.Entity;
using System.Web;

namespace Github.Data.Management
{
	public class ContextFactory : IContextFactory
	{
		private const string TenantIdFieldName = "tenantid";
		private const string DatabaseFieldKeyword = "Database";

		private readonly HttpContext httpContext;
		private string connectionString="";

		public DbContext DbContex
		{
			get
			{
				throw new NotImplementedException();
			}
		}
	}
}