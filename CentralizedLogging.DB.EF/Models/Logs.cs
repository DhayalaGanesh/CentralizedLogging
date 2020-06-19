using System;
using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Models
{
    public partial class Logs
    {
        public int LogId { get; set; }
        public int ServiceId { get; set; }
        public string LogMessages { get; set; }

        public virtual ServicesList Log { get; set; }
    }
}
