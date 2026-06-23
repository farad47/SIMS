using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core
{
    public class TechnicalField
    {
        public Guid Id { get; init; }
        public required DateTime DateCreated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public required string UserCreated { get; set; }
        public string? UserUpdated { get; set; }
    }
}
