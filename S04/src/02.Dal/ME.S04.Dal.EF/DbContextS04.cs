using ME.S04.Core.Contract;
using ME.S04.Core.DomainModel.Customers;
using ME.S04.Core.DomainModel.General;
using ME.S04.Core.DomainModel.Invoices;
using ME.S04.Core.DomainModel.products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Logging;

namespace ME.S04.Dal.EF
{
    /// <summary>
    /// agar bekhahim ba migration 1 DB besazim bayad in interface ra impliment bekonim
    /// </summary>
    public class DbContextFactory : IDesignTimeDbContextFactory<DbContextS04>
    {
        public DbContextS04 CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DbContextS04> optionsBuilder = new DbContextOptionsBuilder<DbContextS04>();
            //البته می شود این کانکشن را از فایل کانفیگ گرفت
            optionsBuilder.UseSqlServer("Server=.; initial Catalog=S04; integrated security=true;");
            return new DbContextS04(optionsBuilder.Options);
        }
    }

    public class DbContextS04 : DbContext, IDbContextS04
    {
        /// <summary>
        /// <c>Log Query</c>
        /// <c >Install-Package Microsoft.Extensions.Logging.Console</c>
        /// <see langword=" need to method: " cref="LogAllCommandExecuteInSqlServer"/>
        /// </summary>
        public static readonly ILoggerFactory MyLoggerFactory
                = LoggerFactory.Create(builder => { builder.AddConsole(); });


        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        //چون نمی خواهیم به صورت مستقیم در دسترس باشد و میخواهیم از طریف پدرش در دسترس باشد یعنی خود فاکتور
        //public DbSet<InvoiceLine> InvoiceLines { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbQuery<KeyValueType> KeyValueType { get; set; }

        public DbContextS04(DbContextOptions<DbContextS04> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(connStr);
            //LogAllCommandExecuteInSqlServer(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// لاگ کردن تمامی دستورات که اجرا می شود در اس کیو ال
        /// <see cref="MyLoggerFactory"/>
        /// </summary>
        /// <param name="optionsBuilder"></param>
        private static void LogAllCommandExecuteInSqlServer(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //در صورتی که بخواهیم خودمان در زمان اجرای برنامه کوئری بنویسیسم دیگر نیاز به کانفیگ زیر نیست
            //modelBuilder.Query<KeyValueType>().ToView("SqlServerViewName");


            base.OnModelCreating(modelBuilder);
        }
        /// <summary>
        /// get name of table with Entity
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public string GetTableName<TEntity>() where TEntity : IBaseEntity
        {
            var entityType = Model.FindEntityType(typeof(TEntity));
            var schema = entityType.GetSchema();
            var tableName = entityType.GetTableName();
            return string.Concat(schema ?? "dbo" , ".", tableName);
        }
        /// <summary>
        /// get name of Column with Property Name
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="PropertyName"></param>
        /// <returns></returns>
        public string GetColumnName<TEntity>(string PropertyName) where TEntity : IBaseEntity
        {
            var entityType = Model.FindEntityType(typeof(TEntity));
            var columnName = entityType.FindDeclaredProperty(PropertyName).GetColumnName();
            return columnName;
        }
    }
}
