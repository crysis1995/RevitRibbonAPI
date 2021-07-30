using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RevitRibbon.API.GQLControllers
{
    public partial class Mutation
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteGroupAsync(int id, [ScopedService] RevitRibbonContext context)
        {
            Group _group = context.Groups.SingleOrDefault(x => x.Id == id);

            if (_group is not null)
            {
                context.Groups.Remove(_group);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteParameterAsync(string code, [ScopedService] RevitRibbonContext context)
        {
            Parameter _parameter = context.Parameters.SingleOrDefault(x => x.Code == code);
            if (_parameter is not null)
            {
                context.Parameters.Remove(_parameter);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteScriptAsync(int id, [ScopedService] RevitRibbonContext context)
        {
            Script _script = context.Scripts.SingleOrDefault(x => x.Id == id);
            if (_script is not null)
            {
                context.Scripts.Remove(_script);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteSharedParameterAsync(Guid id, [ScopedService] RevitRibbonContext context)
        {
            SharedParameter _sharedParameters = context.SharedParameters.SingleOrDefault(x => x.Id == id);
            if (_sharedParameters is not null)
            {
                context.SharedParameters.Remove(_sharedParameters);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteSharedParameterGroupAsync(int id, [ScopedService] RevitRibbonContext context)
        {
            SharedParameterGroup _sharedParameterGroups = context.SharedParameterGroups.SingleOrDefault(x => x.Id == id);
            if (_sharedParameterGroups is not null)
            {
                context.SharedParameterGroups.Remove(_sharedParameterGroups);
                await context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            return false;
        }
    }
}