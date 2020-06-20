using System;
using System.Collections.Generic;

namespace CentralizedLogging.DB.EF.Models
{
    public partial class ServicesList
    {
        public ServicesList()
        {
            Logs = new HashSet<Logs>();
        }

        public int Id { get; set; }
        public string ServiceName { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }
    }
}
