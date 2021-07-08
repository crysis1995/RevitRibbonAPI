using HotChocolate;
using HotChocolate.Data;
using RevitRibbon.Database.Common;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using RevitRibbon.Types.Inputs;
using RevitRibbon.Types.Payloads;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RevitRibbon.API.GQLControllers
{
    // TODO Add OneOf instead of throwing error
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
        public async Task<bool> DeleteRevitParamAsync(int id, [ScopedService] RevitRibbonContext context)
        {
            RevitParam _revitParams = context.RevitParams.SingleOrDefault(x => x.Id == id);
            if (_revitParams is not null)
            {
                context.RevitParams.Remove(_revitParams);
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
        public async Task<RevitParamPayload> UpdateRevitParamAsync(UpdateRevitParamInput input, [ScopedService] RevitRibbonContext context)
        {
            RevitParam _revitParam = context.RevitParams.SingleOrDefault(x => x.Id == input.Id);
            if (_revitParam is null)
            {
                throw new ArgumentException("There is no RevitParam with given Id");
            }

            _revitParam.UpdateEntity(input);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return new RevitParamPayload(_revitParam);
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
    }

    internal static class MutationHelper
    {
        public static void UpdateEntity<TEntity, Tinput>(this TEntity entity, Tinput input) where TEntity : IEntity
        {
            foreach (var prop in input.GetType().GetProperties().Where(x => x.GetValue(input) is not null))
            {
                entity.GetType().GetProperty(prop.Name).SetValue(entity, prop.GetValue(input));
            }
        }
    }
}