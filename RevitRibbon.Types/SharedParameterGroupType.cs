using HotChocolate;
using HotChocolate.Types;
using RevitRibbon.Database.Models;
using RevitRibbon.Infrastructure.Data;
using System.Linq;

namespace RevitRibbon.Types
{
    public class SharedParameterGroupType : ObjectType<SharedParameterGroup>
    {
        protected override void Configure(IObjectTypeDescriptor<SharedParameterGroup> descriptor)
        {
            descriptor.Description("Table shared parameters groups");

            descriptor.Field(x => x.Created).Ignore();
            descriptor.Field(x => x.CreatedBy).Ignore();
            descriptor.Field(x => x.LastModified).Ignore();
            descriptor.Field(x => x.LastModifiedBy).Ignore();

            descriptor.Field(x => x.SharedParameters)
                .ResolveWith<Resolvers>(m => m.GetSharedParameters(default!, default!))
                .UseDbContext<RevitRibbonContext>()
                .Description("Get associated shared parameter");
        }

        private class Resolvers
        {
            public IQueryable<SharedParameter> GetSharedParameters(SharedParameterGroup SharedParameterGroup, [ScopedService] RevitRibbonContext context)
            {
                return context.SharedParameters.Where(x => x.SharedParameterGroupId == SharedParameterGroup.Id);
            }
        }
    }
}