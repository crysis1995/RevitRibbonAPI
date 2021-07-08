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
        public async Task<bool> DeleteGroupAsync(int Id, [ScopedService] RevitRibbonContext context)
        {
            context.Groups.Remove(context.Groups.Find(Id));
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<GroupPayload> UpdateGroupAsync(UpdateGroupInput input, [ScopedService] RevitRibbonContext context)
        {
            Group _group = context.Groups.Find(input.Id);
            var group = new Group
            {
                Id = input.Id,
                Name = input.Name ?? _group.Name,
                IsNullable = input.IsNullable ?? _group.IsNullable,
                Type = input.Type ?? _group.Type
            };

            context.Groups.Update(group);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new GroupPayload(group);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<RevitParamPayload> AddRevitParamAsync(AddRevitParamInput input, [ScopedService] RevitRibbonContext context)
        {
            var revitParam = new RevitParam
            {
                Name = input.Name,
                ScriptId = input.ScriptId,
                ParamType = input.ParamType,
                Description = input.Description
            };

            context.RevitParams.Add(revitParam);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new RevitParamPayload(revitParam);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteRevitParamAsync(int Id, [ScopedService] RevitRibbonContext context)
        {
            context.RevitParams.Remove(context.RevitParams.Find(Id));
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<RevitParamPayload> UpdateRevitParamAsync(UpdateRevitParamInput input, [ScopedService] RevitRibbonContext context)
        {
            RevitParam _revitParam = context.RevitParams.Find(input.Id);
            var revitParam = new RevitParam
            {
                Id = input.Id,
                Name = input.Name ?? _revitParam.Name,
                Description = input.Description ?? _revitParam.Description,
                ParamType = input.ParamType ?? _revitParam.ParamType,
                ScriptId = input.ScriptId ?? _revitParam.ScriptId
            };

            context.RevitParams.Update(revitParam);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new RevitParamPayload(revitParam);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ParameterPayload> AddParameterAsync(AddParameterInput input, [ScopedService] RevitRibbonContext context)
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
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ParameterPayload(parameter);
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<bool> DeleteParameterAsync(string Code, [ScopedService] RevitRibbonContext context)
        {
            context.Parameters.Remove(context.Parameters.Find(Code));
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ParameterPayload> UpdateParameterAsync(UpdateParameterInput input, [ScopedService] RevitRibbonContext context)
        {
            Parameter _parameter = context.Parameters.Find(input.Code);
            var parameter = new Parameter
            {
                Code = input.Code,
                Pl = input.Pl ?? _parameter.Pl,
                En = input.En ?? _parameter.En,
                GroupId = input.GroupId ?? _parameter.GroupId,
                RevitParamId = input.RevitParamId ?? _parameter.RevitParamId,
            };

            context.Parameters.Update(parameter);
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
        public async Task<bool> DeleteScriptAsync(int Id, [ScopedService] RevitRibbonContext context)
        {
            context.Scripts.Remove(context.Scripts.Find(Id));
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        [UseDbContext(typeof(RevitRibbonContext))]
        public async Task<ScriptPayload> UpdateScriptAsync(UpdateScriptInput input, [ScopedService] RevitRibbonContext context)
        {
            Script _script = context.Scripts.Find(input.Id);
            var script = new Script
            {
                Id = input.Id,
                Name = input.Name ?? _script.Name,
                Tooltip = input.Tooltip ?? _script.Tooltip
            };

            context.Scripts.Update(script);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new ScriptPayload(script);
        }
    }
}