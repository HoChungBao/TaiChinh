using Data.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Food.Core.Interfaces
{
    public interface ISlugService<T,TContext> where T:class 
        where TContext: DbContext
    {
        Task<string> InstanceSlug(string name, IRepositoryWithTypedId<T, TContext> repository);
    }
}
