using System;
using System.Collections.Generic;
using UoW;

namespace Github.Models
{
    public class Customer : IEntity
    {
        public int Id
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }

        public List<IEntity> Load()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}