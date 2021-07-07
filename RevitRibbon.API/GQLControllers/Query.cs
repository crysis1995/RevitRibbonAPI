using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.API.GQLControllers
{
    public class Query
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Parameter> GetParameters([ScopedService] RevitRibbonContext context)
        {
            return context.Parameters;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Group> GetGroups([ScopedService] RevitRibbonContext context)
        {
            return context.Groups;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<RevitParam> GetRevitParams([ScopedService] RevitRibbonContext context)
        {
            return context.RevitParams;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Script> GetScripts([ScopedService] RevitRibbonContext context)
        {
            return context.Scripts;
        }
    }
}