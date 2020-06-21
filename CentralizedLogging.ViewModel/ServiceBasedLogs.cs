using System;

namespace CentralizedLogging.ViewModel
{
    public class ServiceBasedLogs
    {
        public string LogMessages { get; set; }

        public string ServiceName { get; set; }

        public DateTime DateAndTime { get; set; }

        public string Status { get; set; }
    }
}
