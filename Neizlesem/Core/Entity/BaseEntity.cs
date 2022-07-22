using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity
{
    public interface IBaseEntity
    {

    }
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            Active = true;
            Delete = false;
            Created = DateTime.Now;
            Updated = DateTime.Now;
        }
        public int Id { get; set; }
        public bool Active { get; set; }
        public bool Delete { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
