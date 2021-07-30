using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class SharedParameterType : ObjectType<SharedParameter>
    {
        protected override void Configure(IObjectTypeDescriptor<SharedParameter> descriptor)
        {
            descriptor.Description("Table of WB parameters in Revit shared parameters");

            descriptor.Field(x => x.Created).Ignore();
            descriptor.Field(x => x.CreatedBy).Ignore();
            descriptor.Field(x => x.LastModified).Ignore();
            descriptor.Field(x => x.LastModifiedBy).Ignore();

            descriptor.Field(x => x.Parameters)
                .ResolveWith<Resolvers>(m => m.GetParameters(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated parameters");

            descriptor.Field(x => x.Script)
                .ResolveWith<Resolvers>(m => m.GetScript(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated script");

            descriptor.Field(x => x.SharedParameterGroup)
                .ResolveWith<Resolvers>(m => m.GetSharedParameterGroup(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated script");
        }

        private class Resolvers
        {
            public Script GetScript(SharedParameter SharedParameter, [ScopedService] RevitRibbonContext context)
            {
                return context.Scripts.FirstOrDefault(x => x.Id == SharedParameter.ScriptId);
            }

            public IQueryable<Parameter> GetParameters(SharedParameter SharedParameter, [ScopedService] RevitRibbonContext context)
            {
                return context.Parameters.Where(x => x.SharedParameterId == SharedParameter.Id);
            }

            public SharedParameterGroup GetSharedParameterGroup(SharedParameter SharedParameter, [ScopedService] RevitRibbonContext context)
            {
                return context.SharedParameterGroups.FirstOrDefault(x => x.Id == SharedParameter.SharedParameterGroupId);
            }
        }
    }
}