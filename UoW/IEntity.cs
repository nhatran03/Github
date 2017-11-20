using System.Collections.Generic;
using UoW;

namespace UoW
{
    interface IEntity
    {
        int Id { get; set; }
        void Insert();
        void Update();
        List<IEntity> Load();
    }
}
