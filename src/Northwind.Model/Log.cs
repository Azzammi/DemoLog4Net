using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.Model
{
    public class Log
    {
        public int LogID { get; set; }
        public string Level { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public string Message { get; set; }
        public string NewValue { get; set; }
        public string OldValue { get; set; }
        public string Exception { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LogDate { get; set; }
    }
}
