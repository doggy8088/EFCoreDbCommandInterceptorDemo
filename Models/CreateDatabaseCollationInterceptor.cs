using System.Data.Common;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

public class CreateDatabaseCollationInterceptor : DbCommandInterceptor
{
    private readonly string _collation;

    public CreateDatabaseCollationInterceptor(string collation)
    {
        _collation = collation;
    }

    public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
    {
        var pattern = @"^CREATE DATABASE (\[.*\])(.*)$";
        if (Regex.IsMatch(command.CommandText, pattern))
        {
            command.CommandText = Regex.Replace(command.CommandText, pattern, $"CREATE DATABASE $1 COLLATE {_collation} $2");
        }

        return result;
    }

    public override Task<InterceptionResult<int>> NonQueryExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
    {
        var pattern = @"^CREATE DATABASE (\[.*\])(.*)$";
        if (Regex.IsMatch(command.CommandText, pattern))
        {
            command.CommandText = Regex.Replace(command.CommandText, pattern, $"CREATE DATABASE $1 COLLATE {_collation} $2");
        }

        return Task.FromResult(result);
    }
}