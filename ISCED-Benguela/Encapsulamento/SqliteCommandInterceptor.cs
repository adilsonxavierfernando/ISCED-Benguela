using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace ISCED_Benguela.Encapsulamento
{
    public class SqliteCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            if (command.CommandText.StartsWith("PRAGMA foreign_keys = OFF", StringComparison.OrdinalIgnoreCase))
            {
                command.CommandText = "PRAGMA foreign_keys = ON";
            }

            return base.NonQueryExecuting(command, eventData, result);
        }
    }
}
