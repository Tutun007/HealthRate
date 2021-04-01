using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthRate.Enums
{
    public enum EventStatus
    {
        Forming = 0,
        Awaiting = 1,
        InProgress = 2,
        Finished = 3,
        Canceled = 4
    }
}
