using System;
using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Models
{
    public partial class ServicesList
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }

        public virtual Logs Logs { get; set; }
    }
}
