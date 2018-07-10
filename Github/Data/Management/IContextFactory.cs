using System.Data.Entity;

namespace Github.Data.Management
{
	interface IContextFactory
	{
		DbContext DbContex{
			get;
		}
	}
}
