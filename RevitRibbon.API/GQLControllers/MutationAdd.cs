using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.API.Exceptions;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using RevitRibbon.Types.Inputs;
using RevitRibbon.Types.Payloads;
using System.Threading.Tasks;

namespace RevitRibbon.API.GQLControllers
{
    public partial class Mutation
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<GroupPayload> AddGroupAsync(AddGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            var group = new Group
            {
                Name = input.Name,
                IsNullable = input.IsNullable,
                Type = input.Type
            };

            context.Groups.Add(group);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new GroupPayload(group);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ParameterPayload> AddParameterAsync(AddParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            if (input.Code.Length > 5)
            {
                throw new InvalidInputException($"{input.Code} has more than 5 characters");
            }

            var parameter = new Parameter
            {
                Code = input.Code,
                Pl = input.Pl,
                En = input.En,
                GroupId = input.GroupId,
                SharedParameterId = input.SharedParameterId
            };

            context.Parameters.Add(parameter);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ParameterPayload(parameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ScriptPayload> AddScriptAsync(AddScriptInput input, [ScopedService] RevitRibbonContext context)
        {
            var script = new Script
            {
                Name = input.Name,
                Tooltip = input.Tooltip
            };

            context.Scripts.Add(script);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ScriptPayload(script);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<SharedParameterPayload> AddSharedParameterAsync(AddSharedParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            var sharedParameter = new SharedParameter
            {
                Name = input.Name,
                Description = input.Description,
                ScriptId = input.ScriptId,
                SharedParameterGroupId = input.SharedParameterGroupId,
                TextInputType = input.TextInputType,
                ParameterType = input.ParameterType,
                BuiltInParameterGroup = input.BuiltInParameterGroup,
                BuiltInCategories = input.BuiltInCategories,
            };

            context.SharedParameters.Add(sharedParameter);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new SharedParameterPayload(sharedParameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<SharedParameterGroupPayload> AddSharedParameterGroupAsync(AddSharedParameterGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            var sharedParameterGroup = new SharedParameterGroup
            {
                Name = input.Name,
            };

            context.SharedParameterGroups.Add(sharedParameterGroup);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new SharedParameterGroupPayload(sharedParameterGroup);
        }
    }
}