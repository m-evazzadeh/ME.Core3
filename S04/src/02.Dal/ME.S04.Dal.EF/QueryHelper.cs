using ME.S04.Core.Contract;
using ME.S04.Core.DomainModel.General;
using Microsoft.EntityFrameworkCore;
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



    }
}
