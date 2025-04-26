using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactManager
{
    public class ListLogger
    {
        private readonly List<string> logs;

        public ListLogger()
        {
            logs = new List<string>();
        }

        public void Log(string message)
        {
            string logEntry = $"{message}";
            logs.Add(logEntry);
        }

        public List<string> GetLogs()
        {
            return new List<string>(logs);
        }
    }
}
