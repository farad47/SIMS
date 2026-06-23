using System;
using System.Collections.Generic;
using System.Text;

namespace SIMS.Core.Enums
{
    public enum PaymentStatusType
    {
        Pending,
        Authorized,
        Captured,
        Completed,
        Failed,
        Refunded,
        PartiallyRefunded,
        Voided,
        Cancelled
    }
}
