using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.API.Helpers;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using RevitRibbon.Types.Inputs;
using RevitRibbon.Types.Payloads;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RevitRibbon.API.GQLControllers
{
    public partial class Mutation
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<GroupPayload> UpdateGroupAsync(UpdateGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            Group _group = context.Groups.SingleOrDefault(x => x.Id == input.Id);

            if (_group is null)
            {
                throw new ArgumentException("There is no Group with given Id");
            }
            _group.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new GroupPayload(_group);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ParameterPayload> UpdateParameterAsync(UpdateParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            Parameter _parameter = context.Parameters.SingleOrDefault(x => x.Code == input.Code);
            if (_parameter is null)
            {
                throw new ArgumentException("There is no Parameter with given Code");
            }

            _parameter.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ParameterPayload(_parameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ScriptPayload> UpdateScriptAsync(UpdateScriptInput input, [ScopedService] RevitRibbonContext context)
        {
            Script _script = context.Scripts.SingleOrDefault(x => x.Id == input.Id);
            if (_script is null)
            {
                throw new ArgumentException("There is no Script with given Id");
            }

            _script.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ScriptPayload(_script);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<SharedParameterPayload> UpdateSharedParameterAsync(UpdateSharedParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            SharedParameter _sharedParameter = context.SharedParameters.SingleOrDefault(x => x.Id == input.Id);
            if (_sharedParameter is null)
            {
                throw new ArgumentException("There is no SharedParameter with given Id");
            }

            _sharedParameter.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new SharedParameterPayload(_sharedParameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<SharedParameterGroupPayload> UpdateSharedParameterGroupAsync(UpdateSharedParameterGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            SharedParameterGroup _sharedParameterGroup = context.SharedParameterGroups.SingleOrDefault(x => x.Id == input.Id);
            if (_sharedParameterGroup is null)
            {
                throw new ArgumentException("There is no SharedParameterGroup with given Id");
            }

            _sharedParameterGroup.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new SharedParameterGroupPayload(_sharedParameterGroup);
        }
    }
}