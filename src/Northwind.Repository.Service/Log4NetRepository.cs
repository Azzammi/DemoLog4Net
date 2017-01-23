using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Dapper;
using Northwind.Model;
using Northwind.Repository.Api;

namespace Northwind.Repository.Service
{
    public class Log4NetRepository : ILog4NetRepository
    {
        public int Save(Log obj)
        {
            var result = 0;

            try
            {
                var sql = @"INSERT INTO Logs (Level, ClassName, MethodName, Message, NewValue, OldValue, Exception, CreatedBy)
                            VALUES (@Level, @ClassName, @MethodName, @Message, @NewValue, @OldValue, @Exception, @CreatedBy)";

                using (IDapperContext context = new DapperContext())
                {
                    result = context.db.Execute(sql, obj);
                }
            }
            catch
            {
            }

            return result;
        }

        public int Update(Log obj)
        {
            throw new NotImplementedException();
        }

        public int Delete(Log obj)
        {
            throw new NotImplementedException();
        }

        public IList<Log> GetAll()
        {
            throw new NotImplementedException();
        }
    }    
}
