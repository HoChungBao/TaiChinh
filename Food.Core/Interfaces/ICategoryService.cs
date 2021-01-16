using Data.Core;
using Food.Core.Entities;
using ReflectionIT.Mvc.Paging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Food.Core.Interfaces
{
    public interface ICategoryService: IBaseService<Category,long>
    {
    }
}
