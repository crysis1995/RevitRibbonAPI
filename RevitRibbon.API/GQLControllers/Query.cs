using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.API.GQLControllers
{
    public class Query
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Parameter> GetParameters([ScopedService] RevitRibbonContext context)
        {
            return context.Parameters;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Group> GetGroups([ScopedService] RevitRibbonContext context)
        {
            return context.Groups;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SharedParameter> GetSharedParameters([ScopedService] RevitRibbonContext context)
        {
            return context.SharedParameters;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Script> GetScripts([ScopedService] RevitRibbonContext context)
        {
            return context.Scripts;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UsePaging(IncludeTotalCount = true)]
        [UseFiltering]
        [UseSorting]
        public IQueryable<SharedParameterGroup> GetSharedParameterGroups([ScopedService] RevitRibbonContext context)
        {
            return context.SharedParameterGroups;
        }
    }
}