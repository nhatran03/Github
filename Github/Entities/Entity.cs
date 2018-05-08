using System;
using System.Collections.Generic;

namespace Github.Entities
{
	[Serializable]
	public abstract class Entity : Entity<int>, IEntity
	{

	}

	[Serializable]
	public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
	{
		public virtual TPrimaryKey Id{ get ;set; }

		public bool IsTransient()
		{
			if (EqualityComparer<TPrimaryKey>.Default.Equals(Id, default(TPrimaryKey)))
			{
				return true;
			}

			//Workaround for EF Core since it sets int/long to min value when attaching to dbcontext
			if (typeof(TPrimaryKey) == typeof(int))
			{
				return Convert.ToInt32(Id) <= 0;
			}

			if (typeof(TPrimaryKey) == typeof(long))
			{
				return Convert.ToInt64(Id) <= 0;
			}

			return false;
		}

		public override bool Equals(object obj)
		{
			if(obj == null || !(obj is Entity<TPrimaryKey>))
			{
				return false;
			}
			//The same object
			if(ReferenceEquals(this,obj))
			{
				return true;
			}

			var other =(Entity<TPrimaryKey>) obj;
			if (IsTransient() && other.IsTransient())
			{
				return false;
			}

			var typeOfThis = this.GetType();
			var typeOfOther = other.GetType();

			if(!typeOfThis.IsAssignableFrom(typeOfOther) && !typeOfOther.IsAssignableFrom(typeOfThis))
			{
				return false;
			}

			//if (this is IMayHaveTenant && other is IMayHaveTenant &&
			//   this.As<IMayHaveTenant>().TenantId != other.As<IMayHaveTenant>().TenantId)
			//{
			//	return false;
			//}

			//if (this is IMustHaveTenant && other is IMustHaveTenant &&
			//	this.As<IMustHaveTenant>().TenantId != other.As<IMustHaveTenant>().TenantId)
			//{
			//	return false;
			//}

			return Id.Equals(other.Id);
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode();
		}

		public override string ToString()
		{
			return $"[{GetType().Name} {Id}]";
		}
	}
}