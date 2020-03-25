using ME.S04.Core.DomainModel.General;

namespace ME.S04.Core.Contract
{
    public interface IDbContextS04
    {
        string GetTableName<TEntity>() where TEntity : IBaseEntity;
        string GetColumnName<TEntity>(string PropertyName) where TEntity : IBaseEntity;
    }
}
