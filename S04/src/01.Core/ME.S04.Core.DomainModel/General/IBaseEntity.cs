using System;
using System.Collections.Generic;
using System.Text;

namespace ME.S04.Core.DomainModel.General
{
    public interface IBaseEntity
    {
    }

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
