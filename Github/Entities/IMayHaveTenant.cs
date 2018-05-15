namespace Github.Entities
{
	public interface IMayHaveTenant
	{
		int? TenantId { get; set; }
	}
}
