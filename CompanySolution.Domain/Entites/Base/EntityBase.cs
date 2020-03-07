using System;
using System.Collections.Generic;
using System.Text;

namespace CompanySolution.Domain.Entites.Base
{
    public abstract class EntityBase
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Active { get; set; }
    }
}
