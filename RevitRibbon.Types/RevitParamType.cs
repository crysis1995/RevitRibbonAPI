using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class RevitParamType : ObjectType<RevitParam>
    {
        protected override void Configure(IObjectTypeDescriptor<RevitParam> descriptor)
        {
            descriptor.Description("Table of WB parameters in Revit shared parameters");

            descriptor.Field(x => x.Parameters)
                .ResolveWith<Resolvers>(m => m.GetParameters(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated parameters");

            descriptor.Field(x => x.Script)
                .ResolveWith<Resolvers>(m => m.GetScript(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated script");
        }

        private class Resolvers
        {
            public Script GetScript(RevitParam revitParam, [ScopedService] RevitRibbonContext context)
            {
                return context.Scripts.FirstOrDefault(x => x.Id == revitParam.ScriptId);
            }

            public IQueryable<Parameter> GetParameters(RevitParam revitParam, [ScopedService] RevitRibbonContext context)
            {
                return context.Parameters.Where(x => x.RevitParamId == revitParam.Id);
            }
        }
    }
}