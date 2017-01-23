using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using log4net;
using log4net.Appender;
using log4net.Core;

using Northwind.Model;
using Northwind.Repository.Api;

namespace Northwind.Repository.Service
{
    public class Log4NetAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            // cek nilai custom properties
            var newValue = (loggingEvent.LookupProperty("NewValue") != null) ? loggingEvent.LookupProperty("NewValue").ToString() : string.Empty;
            var oldValue = (loggingEvent.LookupProperty("OldValue") != null) ? loggingEvent.LookupProperty("OldValue").ToString() : string.Empty;
            var createdBy = (loggingEvent.LookupProperty("UserName") != null) ? loggingEvent.LookupProperty("UserName").ToString() : string.Empty;

            var log = new Log
            {
                Level = loggingEvent.Level.ToString(),
                ClassName = loggingEvent.LocationInformation.ClassName,
                MethodName = loggingEvent.LocationInformation.MethodName,
                Message = loggingEvent.RenderedMessage,
                NewValue = newValue,
                OldValue = oldValue,
                Exception = loggingEvent.GetExceptionString(),
                CreatedBy = createdBy
            };

            // reset nilai property NewValue dan OldValue
            LogicalThreadContext.Properties.Clear();

            // simpan hasil log ke database
            ILog4NetRepository repository = new Log4NetRepository();
            var result = repository.Save(log);
        }
    }
}
