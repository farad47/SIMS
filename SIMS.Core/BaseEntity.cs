using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public abstract class BaseEntity
    {
        public Guid Id { get; protected set; } = Guid.CreateVersion7();
        public DateTime DateCreated { get; protected set; } = DateTime.UtcNow;
        public DateTime? DateUpdated { get; protected set; }
    }
}
