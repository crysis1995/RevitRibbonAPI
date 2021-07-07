using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class ScriptType : ObjectType<Script>
    {
        protected override void Configure(IObjectTypeDescriptor<Script> descriptor)
        {
            descriptor.Description("Table of scripts in RevitRibbon");

            descriptor.Field(x => x.Created).Ignore();
            descriptor.Field(x => x.CreatedBy).Ignore();
            descriptor.Field(x => x.LastModified).Ignore();
            descriptor.Field(x => x.LastModifiedBy).Ignore();

            descriptor.Field(x => x.RevitParams)
                .ResolveWith<Resolvers>(m => m.GetParameters(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated Revit parameters");
        }

        private class Resolvers
        {
            public IQueryable<RevitParam> GetParameters(Script script, [ScopedService] RevitRibbonContext context)
            {
                return context.RevitParams.Where(x => x.ScriptId == script.Id);
            }
        }
    }
}