using ME.S04.Core.Contract;
using ME.S04.Core.DomainModel.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace ME.S04.Dal.EF
{
    public static class QueryHelper
    {
        public static string KeyValueTypeQueryGenerator<TSource>(IDbContextS04 dbContext, string id, IEnumerable<string> title) where TSource : IBaseEntity
        {
            var tableName = dbContext.GetTableName<TSource>();
            var Cid = dbContext.GetColumnName<TSource>(id);
            
            string CTitle = string.Empty;
            List<string> titleColumns = new List<string>();
            if (title.Count() == 1)
                CTitle = $"[{dbContext.GetColumnName<TSource>(title.Single())}]";
            else
            {
                foreach (string c in title)
                {
                    titleColumns.Add(dbContext.GetColumnName<TSource>(c));
                }
                CTitle = string.Join(" , ' '  ,", titleColumns.Select(x => $"[{x}]"));
            }

            return $"SELECT CONCAT([{Cid}],'') Id ,CONCAT({CTitle}) Title FROM {tableName}";
        }

        public static string RemoveAll<TSource>(IDbContextS04 dbContext) where TSource : IBaseEntity,class
        {
            var tableName = dbContext.GetTableName<TSource>();
            
            return $"DELETE FROM {tableName}";
        }
        /// <summary>
        /// get dbcontext from dbset
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <returns></returns>
        public static DbContext GetDbContext<T>(this DbSet<T> dbSet) where T : class
        {
            var infrastructure = dbSet as IInfrastructure<IServiceProvider>;
            var serviceProvider = infrastructure.Instance;
            var currentDbContext = serviceProvider.GetService(typeof(ICurrentDbContext))
                                       as ICurrentDbContext;
            return currentDbContext.Context;
        }

        /// <summary>
        /// exists this dbset in dbcontext?
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="dbContext"></param>
        /// <returns></returns>
        public static bool ContainsEntity<TEntity>(this DbContext dbContext)  where TEntity : class
        {
            return dbContext.Model.FindEntityType(typeof(TEntity)) != null;
        }
    }
}
