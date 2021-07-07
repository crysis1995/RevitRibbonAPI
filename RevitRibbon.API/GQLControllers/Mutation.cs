using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using RevitRibbon.Types.Inputs;
using RevitRibbon.Types.Payloads;
using System.Threading.Tasks;

namespace RevitRibbon.API.GQLControllers
{
    public class Mutation
    {
        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<AddGroupPayload> AddGroupAsync(AddGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            var group = new Group
            {
                Name = input.Name,
                IsNullable = input.IsNullable,
                Type = input.Type
            };

            context.Groups.Add(group);
            await context.SaveChangesAsync();
            return new AddGroupPayload(group);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<AddRevitParamPayload> AddRevitParamAsync(AddRevitParamInput input, [ScopedService] RevitRibbonContext context)
        {
            var revitParam = new RevitParam
            {
                Name = input.Name,
                ScriptId = input.ScriptId,
                ParamType = input.ParamType,
                Description = input.Description
            };

            context.RevitParams.Add(revitParam);
            await context.SaveChangesAsync();
            return new AddRevitParamPayload(revitParam);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<AddParameterPayload> AddParameterAsync(AddParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            var parameter = new Parameter
            {
                Code = input.Code,
                Pl = input.Pl,
                En = input.En,
                GroupId = input.GroupId,
                RevitParamId = input.RevitParamId
            };

            context.Parameters.Add(parameter);
            await context.SaveChangesAsync();
            return new AddParameterPayload(parameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<AddScriptPayload> AddScriptAsync(AddScriptInput input, [ScopedService] RevitRibbonContext context)
        {
            var script = new Script
            {
                Name = input.Name,
                Tooltip = input.Toooltip
            };

            context.Scripts.Add(script);
            await context.SaveChangesAsync();
            return new AddScriptPayload(script);
        }
    }
}