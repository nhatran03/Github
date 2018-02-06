using System.Collections.Generic;

namespace UoW
{
    public interface IEntity
    {
        int Id { get; set; }
        void Insert();
        void Update();
        List<IEntity> Load();
    }
}
