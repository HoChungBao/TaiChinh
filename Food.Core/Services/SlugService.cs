using Data.Core;
using Food.Core.Interfaces;
using Infrastructure.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Food.Core.Services
{
    public class SlugService<T, TContext> : ISlugService<T, TContext> where T:class
        where TContext :DbContext
    {
        public Task<string> InstanceSlug(string name, IRepositoryWithTypedId<T, TContext> repository)
        {
            if (!string.IsNullOrEmpty(name))
            {
                //create slug
                var slug = StringUtil.CreateUrlSlug(name);

                //get category contain slug 
                var entity = repository.Query().Where(x => x.GetType().GetProperty("Slug").GetValue(x,null).ToString().Contains(slug));
                if (entity.Any())
                {
                    slug += entity.Count().ToString();
                }
                return Task.FromResult(slug);
            }
            return Task.FromResult("");
        }
    }
}
